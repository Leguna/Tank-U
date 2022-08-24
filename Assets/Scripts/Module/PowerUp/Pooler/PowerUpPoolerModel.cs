using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.PowerUp
{
    public class PowerUpPoolerModel : BaseModel
    {
        private List<PowerUpView> powerUpHealth = new List<PowerUpView>();
        private List<PowerUpView> powerUpBounce = new List<PowerUpView>();

        public float TimerHealth { get; private set; }
        public float TimerBounce { get; private set; }

        public void AddToListHealth(PowerUpView obj)
        {
            powerUpHealth.Add(obj);
            Debug.Log("Count health list : " + powerUpHealth.Count);
        }

        public void AddToListBounce(PowerUpView obj)
        {
            powerUpBounce.Add(obj);
            Debug.Log("Count bounce list : " + powerUpBounce.Count);
        }

        public PowerUpView GetPowerUpHealth()
        {
            foreach(PowerUpView p in powerUpHealth)
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
            foreach (PowerUpView p in powerUpBounce)
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
    }
}
