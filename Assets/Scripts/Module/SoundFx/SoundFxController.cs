using Agate.MVC.Base;
using UnityEngine;

namespace Leguna.ExampleMVC.Module.SoundFx
{
    public class SoundFxController : ObjectController<SoundFxController, SoundFxView>
    {

        public void OnUpdateCoin()
        {
            _view.PlayCoinSound();
        }
    }
}