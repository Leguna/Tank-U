using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Message;

namespace TankU.PowerUp
{
    public class PowerUpConnector : BaseConnector
    {
        private PowerUpController powerUp;

        protected override void Connect()
        {
            Subscribe<PowerupBouncePickupMessage>(powerUp.OnCollideWithPlayer);
            Subscribe<PowerupHealthPickupMessage>(powerUp.OnCollideWithPlayer);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PowerupBouncePickupMessage>(powerUp.OnCollideWithPlayer);
            Unsubscribe<PowerupHealthPickupMessage>(powerUp.OnCollideWithPlayer);
        }
    }
}
