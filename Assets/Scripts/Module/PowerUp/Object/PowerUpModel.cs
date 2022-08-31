using Agate.MVC.Base;
using TankU.Module.Base;
using TankU.PowerUp;
using UnityEngine;

namespace TankU.Module.PowerUp.Object
{
    public class PowerUpModel : BaseModel, IPowerUpModel
    {
        public float SpawnTimer { get; private set; }
        public float Duration { get; private set; }
        public PowerUpType PowerUpType { get; }

        public PowerUpModel()
        {
            SpawnTimer = 5f;
            Duration = 8f;
        }

        public PowerUpModel(int index) : this()
        {
            switch (index)
            {
                case 1:
                    PowerUpType = PowerUpType.Health;
                    break;
                case 2:
                    PowerUpType = PowerUpType.Bounce;
                    break;
            }
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

        public void DecreaseTimerByDeltaTime()
        {
            SpawnTimer -= Time.deltaTime;
        }
    }
}