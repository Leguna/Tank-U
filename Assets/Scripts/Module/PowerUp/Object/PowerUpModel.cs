using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.PowerUp
{
    public class PowerUpModel : BaseModel, IPowerUpModel
    {
        public float SpawnTimer { get; private set; }
        public bool IsActive { get; private set; }

        public PowerUpModel()
        {
            SpawnTimer = 5f;
            IsActive = true;
        }

        public void SetActive(bool b)
        {
            IsActive = b;
            SetDataAsDirty();
        }

        public void SetTimerSpawn(float timer)
        {
            SpawnTimer = timer;
            SetDataAsDirty();
        }

        public void DecreaseTimerByDeltatime()
        {
            SpawnTimer -= Time.deltaTime;
        }
    }
}
