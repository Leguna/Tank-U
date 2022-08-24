using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Agate.MVC.Base;

namespace TankU.PowerUp
{
    public class PowerUpPoolerView : BaseView
    {
        private Action OnSpawnPowerUpHealth;
        private Action OnSpawnPowerUpBounce;

        public void SetCallback(Action onSpawnPowerUpHealth, Action onSpawnPowerUpBounce)
        {
            OnSpawnPowerUpHealth = onSpawnPowerUpHealth;
            OnSpawnPowerUpBounce = onSpawnPowerUpBounce;
        }

        private void Update()
        {
            OnSpawnPowerUpHealth?.Invoke();
            OnSpawnPowerUpBounce?.Invoke();
        }
    }
}
