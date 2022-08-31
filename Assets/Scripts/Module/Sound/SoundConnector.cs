using Agate.MVC.Base;

namespace TankU.Sound
{
    public class SoundConnector : BaseConnector
    {
        private SoundController _soundController;

        public void ToggleSoundEffect(SoundSettingsUpdateMessage message)
        {
            if (message.IsBGM) return;
            _soundController.ToggleMuteSfx();
        }

        public void ToggleBgmSound(SoundSettingsUpdateMessage message)
        {
            if (!message.IsBGM) return;
            _soundController.ToggleMuteBgm();
        }

        protected override void Connect()
        {
            Subscribe<SoundSettingsUpdateMessage>(ToggleBgmSound);
            Subscribe<SoundSettingsUpdateMessage>(ToggleSoundEffect);
            Subscribe<PlaySoundEffectMessage>(PlaySoundEffect);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SoundSettingsUpdateMessage>(ToggleBgmSound);
            Unsubscribe<SoundSettingsUpdateMessage>(ToggleSoundEffect);
            Unsubscribe<PlaySoundEffectMessage>(PlaySoundEffect);
        }

        private void PlaySoundEffect(PlaySoundEffectMessage message)
        {
            _soundController.PlaySfx(message.SoundEffectName);
        }
    }
}