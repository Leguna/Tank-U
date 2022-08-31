using System;

namespace TankU.Module.Base
{
    [Serializable]
    public struct PlayerData
    {
        public int PlayerIndex { get; }
        public int WinCount { get; }
        public ColorType ColorType { get; }

        public PlayerData(int index, int winCount, int colorIndex)
        {
            PlayerIndex = index;
            WinCount = winCount;
            ColorType = (ColorType)colorIndex;
        }
    }
}