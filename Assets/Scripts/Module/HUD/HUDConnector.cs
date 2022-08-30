using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Message;
using UnityEngine;

namespace TankU.Gameplay
{
    public class HUDConnector : BaseConnector

    {

        public HUDController _hud;

        private void GetColorPlayer(ColorPickingMessage message)
        {
            _hud.GetColorPlayer(message.PickedColorList, message.PickingState);
        }

        private void GetPlayerStatus(PlayerStatusMessage message)
        {
            _hud.GetPlayerHealth(message.HealtPoint);
            _hud.GetStatusPowerUp(message.PowerUpStatus);
        }

        protected override void Connect()
        {
            Subscribe<ColorPickingMessage> (GetColorPlayer) ;
            Subscribe<PlayerStatusMessage>(GetPlayerStatus) ;
        }

        protected override void Disconnect()
        {
            Unsubscribe<ColorPickingMessage> (GetColorPlayer) ;
            Unsubscribe<PlayerStatusMessage>(GetPlayerStatus) ;
            
        }
    }
}
