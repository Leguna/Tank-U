using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.Base;

namespace TankU.Module.MatchHistory.MatchHistoryItem
{
    public interface IMatchHistoryItemModel : IBaseModel
    {
        List<PlayerData> PlayerDataList { get; }
        int WinnerIndex { get; }

        void SetPlayerDataList(List<PlayerData> data);

        void AddPlayerDataToList(PlayerData player);

        void SetWinnerPlayerIndex(int index);
    }
}