using System;
using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.MatchHistory;
using TankU.Module.Utilities;
using UnityEngine;

namespace TankU.Module.Base
{
    [Serializable]
    public class MatchHistoryModel : BaseModel, IMatchHistoryModel
    {
        private const string _historyKey = "_History_";

        public MatchHistoryItemDataController[] MatchHistoryItemData { get; private set; }
        public List<MatchData> MatchHistoryItemModels { get; private set; } = new();

        public void Save()
        {
            var data = JsonHelper.ToJson(MatchHistoryItemModels.ToArray());
            PlayerPrefs.SetString(_historyKey, data);
        }

        public List<MatchData> Load()
        {
            if (PlayerPrefs.HasKey(_historyKey))
            {
                string json = PlayerPrefs.GetString(_historyKey);
                MatchHistoryItemModels = new List<MatchData>(JsonHelper.FromJson<MatchData>(json));
                Debug.Log(json);
            }
            else
            {
                Save();
            }
            return MatchHistoryItemModels;
        }

        public void AddMatch(int objWinner, List<int> objListColorIndex)
        {
            Debug.Log($"{objWinner} {objListColorIndex.Count}");
            List<PlayerData> playerData = new List<PlayerData>();
            for (int i = 0; i < objListColorIndex.Count; i++)
            {
                playerData.Add(new PlayerData(i, 0, objListColorIndex[i]));
            }

            MatchHistoryItemModels.Add(new MatchData(objWinner, objListColorIndex.ToArray()));
            Save();
        }

        public List<int> GetWinCount()
        {
            var winCount = new List<int> { 0, 0, 0, 0 };
            foreach (var t in MatchHistoryItemModels)
            {
                winCount[t.WinnerIndex]++;
            }
            return winCount;
        }
    }

    [Serializable]
    public class MatchData
    {
        public MatchData(int winnerIndex, int[] colorIndex)
        {
            WinnerIndex = winnerIndex;
            ColorIndex = colorIndex;
        }

        public int WinnerIndex;
        public int[] ColorIndex;
    }
}