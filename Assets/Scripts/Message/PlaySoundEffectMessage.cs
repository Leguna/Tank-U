namespace TankU.Sound
{
    public struct PlaySoundEffectMessage
    {
        public PlaySoundEffectMessage(SoundEffectName soundEffectName)
        {
            SoundEffectName = soundEffectName;
        }

        public SoundEffectName SoundEffectName { get; }
    }
}