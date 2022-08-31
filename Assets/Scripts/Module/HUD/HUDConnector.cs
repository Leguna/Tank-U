using Agate.MVC.Base;
using TankU.Gameplay;
using TankU.Message;
using TankU.Module.Base;

namespace TankU.Module.HUD
{
    public class HUDConnector : BaseConnector
    {
        public HUDController hud;

        private void GetColorPlayer(ColorPickingMessage message)
        {
            if (message.PickingState == PickingState.Finish)
                hud.GetColorPlayer(message.PickedColorIndex);
        }

        private void GetPlayerStatus(PlayerStatusMessage message)
        {
            hud.GetPlayerHealth(message.HealthPoint, message.PlayerIndex);
            hud.GetStatusPowerUp(message.PowerUpStatus, message.PlayerIndex);
        }

        protected override void Connect()
        {
            Subscribe<ColorPickingMessage>(GetColorPlayer);
            Subscribe<PlayerStatusMessage>(GetPlayerStatus);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ColorPickingMessage>(GetColorPlayer);
            Unsubscribe<PlayerStatusMessage>(GetPlayerStatus);
        }
    }
}