using System.Collections;
using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Sound
{
    public class SoundController : ObjectController<SoundController, SoundModel, ISoundModel, SoundView>
    {
        private const string _viewPrefabPath = "Prefabs/SoundView";

        public bool IsBgmMuted => _model.BgmVolume == 0f;
        public bool IsSfxMuted => _model.SfxVolume == 0f;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

            SoundView view = SoundView.Instantiate(Resources.Load<SoundView>(_viewPrefabPath));
            GameObject.DontDestroyOnLoad(view);
            SetView(view);
        }

        public void TogleMuteBgm() => _model.ToggleMuteBgm();
        public void TogleMuteSfx() => _model.ToggleMuteSfx();

        public void PlayBgm(SoundBgmName bgm)
            => _view.PlayBgm(_model.GetBgmClip(bgm));

        public void PlaySfx(SoundSfxName sfx)
            => _view.PlaySfx(_model.GetSfxClip(sfx));

    }
}
