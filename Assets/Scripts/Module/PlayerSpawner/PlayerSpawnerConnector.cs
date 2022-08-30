using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Module.PlayerSpawner
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
            if (obj.TimerEventTypeType == TimerEventType.OnCountdownFinish)
                _playerSpawnerController.OnGameStart();
            else if(obj.TimerEventTypeType == TimerEventType.OnTimerFinish)
                _playerSpawnerController.OnGameStop();
        }

        protected override void Disconnect()
        {
            Unsubscribe<ColorPickingMessage>(GetColorPlayer);
            Unsubscribe<TimerCountDownMessage>(OnTimerStart);
        }
    }
}