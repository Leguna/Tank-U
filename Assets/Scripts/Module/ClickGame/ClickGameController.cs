using System.Collections;
using Agate.MVC.Base;
using Leguna.ExampleMVC.Boot;
using Leguna.ExampleMVC.Message;
using Leguna.ExampleMVC.Module.SaveGame;

#pragma warning disable CS0465

namespace Leguna.ExampleMVC.Module.ClickGame
{
    public class ClickGameController : ObjectController<ClickGameController, ClickGameModel, IClickGameModel, ClickGameView>
    {
        private SaveDataController _saveData;

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _model.SetCoin(_saveData.Model.Coin);
        }

        private void OnClickEarnCoin()
        {
            _model.AddCoin();
            Publish(new UpdateCoinMessage(_model.Coin));
        }

        private void OnClickSpendCoin()
        {
            _model.SubstractCoin();
            Publish(new UpdateCoinMessage(_model.Coin));
        }

        private void OnClickBack()
        {
            SceneLoader.Instance.LoadScene("Main");
        }

        public override void SetView(ClickGameView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickEarnCoin, OnClickSpendCoin, OnClickBack);
        }
    }
}