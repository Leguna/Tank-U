namespace TankU.Sound
{
    public struct SoundSettingsUpdateMessage
    {
        public SoundSettingsUpdateMessage(bool isBGM)
        {
            IsBGM = isBGM;
        }

        public bool IsBGM { get; }
    }
}