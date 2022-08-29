using Agate.MVC.Base;

// TODO @Leguna: Delete this.
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