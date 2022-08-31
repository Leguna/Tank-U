using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Module.PowerUp.Object;

namespace TankU.PowerUp
{
    public class PowerUpPoolerModel : BaseModel
    {
        private List<PowerUpView> _powerUpHealth = new List<PowerUpView>();
        private List<PowerUpView> _powerUpBounce = new List<PowerUpView>();

        public float TimerHealth { get; private set; }
        public float TimerBounce { get; private set; }
        public int TempRandomPosIndex { get; private set; }

        public void AddToListHealth(PowerUpView obj)
        {
            _powerUpHealth.Add(obj);
        }

        public void AddToListBounce(PowerUpView obj)
        {
            _powerUpBounce.Add(obj);
        }

        public PowerUpView GetPowerUpHealth()
        {
            foreach(PowerUpView p in _powerUpHealth)
            {
                if (!p.gameObject.activeInHierarchy)
                {
                    p.gameObject.SetActive(true);
                    return p;
                }
            }

            return null;
        }

        public PowerUpView GetPowerUpBounce()
        {
            foreach (PowerUpView p in _powerUpBounce)
            {
                if (!p.gameObject.activeInHierarchy)
                {
                    p.gameObject.SetActive(true);
                    return p;
                }
            }

            return null;
        }

        public void SetTimerSpawnHealth(float timer)
        {
            TimerHealth = timer;
            SetDataAsDirty();
        }

        public void SetTimerSpawnBounce(float timer)
        {
            TimerBounce = timer;
            SetDataAsDirty();
        }

        public void DecreaseTimeHealthByDeltatime()
        {
            TimerHealth -= Time.deltaTime;
        }

        public void DecreaseTimeBounceByDeltatime()
        {
            TimerBounce -= Time.deltaTime;
        }

        public void SetTemporaryIndex(int temp)
        {
            TempRandomPosIndex = temp;
            SetDataAsDirty();
        }
    }
}
