using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Sound
{
    [System.Serializable]
    public class AudioConfigModel : BaseModel
    {
        private const string _prefsKey = "_Audios_";
        
        [SerializeField] private float _bgmVolume = 1f;
        [SerializeField] private float _sfxVolume = 1f;

        public float BgmVolume => _bgmVolume;
        public float SfxVolume => _sfxVolume;

        public void Load()
        {
            if (PlayerPrefs.HasKey(_prefsKey))
            {
                string json = PlayerPrefs.GetString(_prefsKey);
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else
            {
                Save();
            }
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(_prefsKey, json);
        }


        public void SetBgmVolume(float volume)
        {
            _bgmVolume = volume;
            Save();
        }

        public void SetSfxVolume(float vol)
        {
            _sfxVolume = vol;
            Save();
        }
    }
}
