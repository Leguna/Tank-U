using System;
using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.Base;

namespace TankU.Module.MatchHistory.MatchHistoryItem
{
    [Serializable]
    public class MatchHistoryItemModel : BaseModel, IMatchHistoryItemModel
    {
        public MatchHistoryItemModel()
        {
        }

        public MatchHistoryItemModel(List<PlayerData> playerDataList, int winnerIndex)
        {
            PlayerDataList = playerDataList;
            WinnerIndex = winnerIndex;
        }

        public List<PlayerData> PlayerDataList { get; private set; }
        public int WinnerIndex { get; private set; }

        public void SetPlayerDataList(List<PlayerData> data)
        {
            PlayerDataList = data;
            SetDataAsDirty();
        }

        public void AddPlayerDataToList(PlayerData player)
        {
            PlayerDataList.Add(player);
        }

        public void SetWinnerPlayerIndex(int index)
        {
            WinnerIndex = index;
            SetDataAsDirty();
        }
    }
}