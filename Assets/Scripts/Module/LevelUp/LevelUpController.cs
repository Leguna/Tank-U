using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Base;

namespace TankU.Module.LevelUp
{
    public class LevelUpController : DataController<LevelUpController, LevelUpModel>
    {
        public void OnMatchUpdate(MatchData matchData)
        {
            _model.UpdateLevelFromMatchData(matchData);
            _model.SaveData();
            Publish(new OnLevelDataUpdateMessage(_model.levelUpData.LevelUpDataList));
        }

        public ListLevelUpData LoadData()
        {
            return _model.LoadData();
        }

        public bool IsGameUpdated()
        {
            return _model.CheckGameUpdate();
        }

        public LevelUpData GetPlayerData(int index)
        {
            return _model.GetPlayerData(index);
        }

        public List<LevelUpData> GetAllPlayerData()
        {
            return _model.levelUpData.LevelUpDataList;
        }

        public void UpdateData(List<int> winCount)
        {
            _model.ForceUnlockColor(winCount);
            _model.SaveData();
        }

        public int[] GetPlayerColorUnlocked()
        {
            return (from levelUpData in _model.levelUpData.LevelUpDataList select levelUpData.Inventory.ColorUnlocked)
                .ToArray();
        }

        public int[] GetAllPlayerLevel()
        {
            return (from levelData in _model.levelUpData.LevelUpDataList select levelData.Level).ToArray();
        }
    }
}