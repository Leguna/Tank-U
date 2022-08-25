using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.PowerUp
{
    public class PowerUpModel : BaseModel, IPowerUpModel
    {
        public float SpawnTimer { get; private set; }
        public float Duration { get; private set; }

        public PowerUpModel()
        {
            SpawnTimer = 5f;
            Duration = 8f;
        }

        public void SetTimerSpawn(float timer)
        {
            SpawnTimer = timer;
            SetDataAsDirty();
        }

        public void SetDuration(float duration)
        {
            Duration = duration;
            SetDataAsDirty();
        }

        public void DecreaseTimerByDeltatime()
        {
            SpawnTimer -= Time.deltaTime;
        }
    }
}
