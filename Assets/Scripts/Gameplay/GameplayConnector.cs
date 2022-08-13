using Agate.MVC.Base;
using Leguna.ExampleMVC.Message;
using Leguna.ExampleMVC.Module.SaveGame;
using Leguna.ExampleMVC.Module.SoundFx;

namespace Leguna.ExampleMVC.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private SaveDataController _saveData;
        private SoundFxController _soundFx;

        public void OnUpdateCoin(UpdateCoinMessage message)
        {
            _saveData.OnUpdateCoin(message.Coin);
            _soundFx.OnUpdateCoin();
        }

        protected override void Connect()
        {
            Subscribe<UpdateCoinMessage>(OnUpdateCoin);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateCoinMessage>(OnUpdateCoin);
        }
    }
}