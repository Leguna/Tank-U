using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.Module.Base
{
    public class MatchHistoryItemDataController : DataController<MatchHistoryItemDataController, MatchHistoryItemModel>
    {
        public void SetPlayerData(List<PlayerData> listPlayerData)
        {
            _model.SetPlayerDataList(listPlayerData);
        }

        public void AddPlayerData(PlayerData playerData)
        {
            _model.AddPlayerDataToList(playerData);
        }

        //todo:
        //add playerdata to list from gameover (receive message from gameover)
    }
}
