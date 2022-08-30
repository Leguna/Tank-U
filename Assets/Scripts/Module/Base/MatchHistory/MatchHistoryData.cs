using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Base
{
    [System.Serializable]
    public class MatchHistoryData : BaseModel
    {
        private const string _historyKey = "_History_";



        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(_historyKey, json);
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(_historyKey))
            {
                string json = PlayerPrefs.GetString(_historyKey);
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else Save();
        }
    }
}
