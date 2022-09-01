using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.Base;

namespace TankU.Module.MatchHistory
{
    public interface IMatchHistoryModel : IBaseModel
    {
        public MatchHistoryItemDataController[] MatchHistoryItemData { get; }
        public List<MatchData> MatchHistoryItemModels { get; }
        public void Save();
        public List<MatchData> Load();

        public void AddMatch(int objWinner, int[] objListColorIndex, int[] levelList);
    }
}