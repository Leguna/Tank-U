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


        protected override void Connect()
        {
            Subscribe<ColorPickingMessage> (_hud.) ;
        }

        protected override void Disconnect()
        {
            
        }
    }
}
