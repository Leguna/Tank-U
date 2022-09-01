using System;
using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.LevelUp
{
    [Serializable]
    public class LevelUpModel : BaseModel
    {
        public int maxLevel = 8;
        public ListLevelUpData levelUpData = new();
        private const string LevelDataKey = "LevelData";

        public ListLevelUpData LoadData()
        {
            var levelDataString = PlayerPrefs.GetString(LevelDataKey);
            if (levelDataString == null)
            {
                return new ListLevelUpData();
            }

            JsonUtility.FromJsonOverwrite(levelDataString, this);

            return levelUpData;
        }

        public void SaveData()
        {
            var levelDataString = JsonUtility.ToJson(this);
                             PlayerPrefs.SetString(LevelDataKey, levelDataString);
        }

        public void UpdateLevelFromMatchData(MatchData matchData)
        {
            for (var i = 0; i < matchData.ColorIndex.Length; i++)
            {
                if (levelUpData.LevelUpDataList.Count < i + 1)
                    levelUpData.LevelUpDataList.Add(new LevelUpData());

                if (levelUpData.LevelUpDataList[i].Level >= maxLevel)
                    continue;

                bool isLevelUp = levelUpData.LevelUpDataList[i].AddExp(i == matchData.WinnerIndex ? 100 : 50);

                if (isLevelUp)
                    UnlockNewColor(i);
            }
        }

        private void UnlockNewColor(int index)
        {
            var newColorUnlocked = levelUpData.LevelUpDataList[index].Level / 2;
            if (newColorUnlocked > 4) return;
            if (newColorUnlocked > levelUpData.LevelUpDataList[index].Inventory.ColorUnlocked)
                levelUpData.LevelUpDataList[index].Inventory.ColorUnlocked = newColorUnlocked;
        }

        public void ForceUnlockColor(List<int> winCount)
        {
            for (int i = 0; i < winCount.Count; i++)
            {
                if (levelUpData.LevelUpDataList.Count < i + 1)
                    levelUpData.LevelUpDataList.Add(new LevelUpData());

                levelUpData.LevelUpDataList[i].Inventory.ColorUnlocked = winCount[i] / 2;
            }
        }

        public LevelUpData GetPlayerData(int playerIndex)
        {
            if (playerIndex > levelUpData.LevelUpDataList.Count)
            {
                Debug.Log("Player index out of range");
                return new LevelUpData();
            }

            return levelUpData.LevelUpDataList[playerIndex];
        }

        public bool CheckGameUpdate()
        {
            return !PlayerPrefs.HasKey(LevelDataKey);
        }
    }
}