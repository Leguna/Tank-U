using Agate.MVC.Base;

namespace SpacePlan.Module.SoundFx
{
    public class SoundFxController : ObjectController<SoundFxController, SoundFxView>
    {

        public void OnUpdateCoin()
        {
            _view.PlayCoinSound();
        }
    }
}