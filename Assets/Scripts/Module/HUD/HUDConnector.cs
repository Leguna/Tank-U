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

        protected override void Connect()
        {
            Subscribe<ColorPickingMessage> (GetColorPlayer) ;
        }

        protected override void Disconnect()
        {
            Unsubscribe<ColorPickingMessage> (GetColorPlayer) ;
            
        }
    }
}
