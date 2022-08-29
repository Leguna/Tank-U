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
        }

        protected override void Disconnect()
        {
            Unsubscribe<SoundSettingsUpdateMessage>(ToggleBgmSound);
            Unsubscribe<SoundSettingsUpdateMessage>(ToggleSoundEffect);
        }
    }

    public struct SoundSettingsUpdateMessage
    {
        public SoundSettingsUpdateMessage(bool isBGM)
        {
            IsBGM = isBGM;
        }

        public bool IsBGM { get; }
    }
}