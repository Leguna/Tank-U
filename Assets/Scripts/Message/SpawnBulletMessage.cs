using UnityEngine;

namespace TankU.Message
{
    public struct SpawnBulletMessage
    {
        public Transform TransformSpawner { get; }
        public float PowerUpDuration { get; }
        public bool IsPowerUp { get; }

        public SpawnBulletMessage(Transform tr, float powerUpDuration, bool isPowerUp)
        {
            TransformSpawner = tr;
            PowerUpDuration = powerUpDuration;
            IsPowerUp = isPowerUp;
        }
    }
}