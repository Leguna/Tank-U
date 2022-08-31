using System.Collections;
using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Sound
{
    public class SoundController : ObjectController<SoundController, SoundModel, ISoundModel, SoundView>
    {
        private const string _viewPrefabPath = "Prefabs/Sound/SoundView";

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

            SoundView view = SoundView.Instantiate(Resources.Load<SoundView>(_viewPrefabPath));
            GameObject.DontDestroyOnLoad(view);
            SetView(view);
        }

        public void ToggleMuteBgm() => _model.ToggleMuteBgm();
        public void ToggleMuteSfx() => _model.ToggleMuteSfx();

        public void PlayBgm(SoundBgmName bgm)
            => _view.PlayBgm(_model.GetBgmClip(bgm));

        public void PlaySfx(SoundEffectName effect)
            => _view.PlaySfx(_model.GetSfxClip(effect));

    }
}