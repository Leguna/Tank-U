using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TankU.Message;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerInputConector : BaseConnector
    {
        private PlayerInputController _playerInputController;
        private PlayerController _playerController;

        public void OnGetpowerUpBounce(PowerupBouncePickupMessage message)
        {
            _playerController.OnGetpowerUpBounce(message.Duration);
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
