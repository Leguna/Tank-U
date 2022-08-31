using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Base;

namespace TankU.Module.Timer
{
    public class TimerConnector : BaseConnector
    {
        private TimerController _controller;

        protected override void Connect()
        {
            // TODO @Vivian and Mark: Need Subscribe to TimerMessage On Start, On Pause, On Resume
            Subscribe<ColorPickingMessage>(OnTimerStart);
            // Subscribe<>(_controller.OnGamePause());
            // Subscribe<>(_controller.OnGameResume());
        }

        private void OnTimerStart(ColorPickingMessage message)
        {
            if (message.PickingState == PickingState.Finish) _controller.OnStartGame();
        }

        protected override void Disconnect()
        {
            // TODO @Vivian and Mark: Need Subscribe to TimerMessage On Start, On Pause, On Resume
            Unsubscribe<ColorPickingMessage>(OnTimerStart);
            // Unsubscribe<>(_controller.OnGamePause());
            // Unsubscribe<>(_controller.OnGameResume());
        }
    }
}