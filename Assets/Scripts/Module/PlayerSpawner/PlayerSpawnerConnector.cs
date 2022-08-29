using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Message;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerSpawnerConnector : BaseConnector
    {
        public PlayerSpawnerController _playerSpawnerController;

        public void GetColorPlayer(ColorPickingMessage message)
        {
            _playerSpawnerController.GetColorPlayer(message.ColorList, message.PickingState);
        }
        protected override void Connect()
        {
            Subscribe<ColorPickingMessage>(GetColorPlayer);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ColorPickingMessage>(GetColorPlayer);
        }
    }
}
