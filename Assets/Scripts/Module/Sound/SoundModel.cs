using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Sound
{
    public class SoundModel : BaseModel, ISoundModel
    {
        private const string _sfxPath = "Audio/SFX/";
        private const string _bgmPath = "Audio/BGM/";

        private AudioConfigModel _configModel = new AudioConfigModel();
        private Dictionary<string, AudioClip> _bgmLibrary = new Dictionary<string, AudioClip>();
        private Dictionary<string, AudioClip> _sfxLibrary = new Dictionary<string, AudioClip>();

        public float BgmVolume => _configModel.BgmVolume;
        public float SfxVolume => _configModel.SfxVolume;

        public bool IsBgmMuted => BgmVolume == 0f;
        public bool IsSfxMuted => SfxVolume == 0f;

        public SoundModel()
        {
            AudioClip[] bgms = Resources.LoadAll<AudioClip>(_bgmPath);
            foreach (AudioClip bgm in bgms)
            {
                _bgmLibrary.Add(bgm.name, bgm);
            }

            AudioClip[] sfxs = Resources.LoadAll<AudioClip>(_sfxPath);
            foreach (AudioClip sfx in sfxs)
            {
                _sfxLibrary.Add(sfx.name, sfx);
            }
        }

        public void ToggleMuteBgm()
        {
            _configModel.SetBgmVolume(BgmVolume == 0f ? 2f : 0f);
            SetDataAsDirty();
        }

        public void ToggleMuteSfx()
        {
            _configModel.SetSfxVolume(SfxVolume == 0f ? 2f : 0f);
            SetDataAsDirty();
        }

        public AudioClip GetBgmClip(SoundBgmName bgm)
            => _bgmLibrary["bgm_" + bgm.ToString().ToLower()];

        public AudioClip GetSfxClip(SoundEffectName effect)
            => _sfxLibrary["sfx_" + effect.ToString().ToLower()];
    }
}