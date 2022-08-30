using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.PlayerSpawner;

namespace TankU.Gameplay
{
    public class PlayerSpawnerConnector : BaseConnector
    {
        public PlayerSpawnerController _playerSpawnerController;

        public void GetColorPlayer(ColorPickingMessage message)
        {
            _playerSpawnerController.GetColorPlayer(message.PickedColorIndex, message.PickingState);
        }

        protected override void Connect()
        {
            Subscribe<ColorPickingMessage>(GetColorPlayer);
            Subscribe<TimerCountDownMessage>(OnTimerStart);
        }

        private void OnTimerStart(TimerCountDownMessage obj)
        {
            _playerSpawnerController.OnGameStart();
        }

        protected override void Disconnect()
        {
            Unsubscribe<ColorPickingMessage>(GetColorPlayer);
            Unsubscribe<TimerCountDownMessage>(OnTimerStart);
        }
    }
}