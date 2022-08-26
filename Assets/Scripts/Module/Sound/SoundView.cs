using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Sound
{
    public class SoundView : ObjectView<ISoundModel>
    {
        [SerializeField] private AudioSource _bgmAudioSource;
        [SerializeField] private AudioSource _sfxAudioSource;

        protected override void InitRenderModel(ISoundModel model)
        {
            
        }

        protected override void UpdateRenderModel(ISoundModel model)
        {
            _bgmAudioSource.volume = model.BgmVolume;
            _sfxAudioSource.volume = model.SfxVolume;
        }

        public void PlayBgm(AudioClip bgm)
        {
            _bgmAudioSource.clip = bgm;
            _bgmAudioSource.Play();
        }

        public void PlaySfx(AudioClip sfx)
            => _sfxAudioSource.PlayOneShot(sfx);
    }
}
