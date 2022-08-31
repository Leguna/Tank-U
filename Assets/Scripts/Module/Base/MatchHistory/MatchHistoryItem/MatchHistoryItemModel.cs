using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.Module.Base
{
    public class MatchHistoryItemModel : BaseModel
    {
        private List<PlayerData> _playerDataList;
        public int WinnerIndex { get; private set; }

        public void SetPlayerDataList(List<PlayerData> data)
        {
            _playerDataList = data;
            SetDataAsDirty();
        }

        public void AddPlayerDataToList(PlayerData player)
        {
            _playerDataList.Add(player);
        }

        public void SetWinnerPlayerIndex(int index)
        {
            WinnerIndex = index;
            SetDataAsDirty();
        }
    }
}
