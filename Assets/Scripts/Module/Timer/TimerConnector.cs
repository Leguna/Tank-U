using Agate.MVC.Base;

namespace TankU.Module.Timer
{
    public class TimerConnector : BaseConnector
    {
        private TimerController _controller;

        protected override void Connect()
        {
            // TODO @Vivian and Mark: Need Subscribe to TimerMessage On Start, On Pause, On Resume
            // Subscribe<>(_controller.OnStartGame());
            // Subscribe<>(_controller.OnGamePause());
            // Subscribe<>(_controller.OnGameResume());
        }

        protected override void Disconnect()
        {
            // TODO @Vivian and Mark: Need Subscribe to TimerMessage On Start, On Pause, On Resume
            // Unsubscribe<>(_controller.OnStartGame());
            // Unsubscribe<>(_controller.OnGamePause());
            // Unsubscribe<>(_controller.OnGameResume());
        }
    }
}