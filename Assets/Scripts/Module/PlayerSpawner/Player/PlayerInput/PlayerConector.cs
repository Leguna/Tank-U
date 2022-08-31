using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Message;
using TankU.Module.PlayerSpawner.Player;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerConector : BaseConnector
    {
        private PlayerInputController _playerInputController;
        private PlayerController _playerController;

        public void OnGetpowerUpBounce(PowerupBouncePickupMessage message)
        {
            _playerController.OnGetPowerUpBounce(message.Duration);
        }

        protected override void Connect()
        {
            Subscribe<PowerupBouncePickupMessage>(OnGetpowerUpBounce);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PowerupBouncePickupMessage>(OnGetpowerUpBounce);
        }
    }
}
