using System.Collections.Generic;
using TankU.Module.Base;

namespace TankU.Message
{
    public struct OnLevelDataUpdateMessage
    {
        private List<LevelUpData> LevelUpDataList { get; }

        public OnLevelDataUpdateMessage(List<LevelUpData> levelUpDataList)
        {
            LevelUpDataList = levelUpDataList;
        }
    }
}