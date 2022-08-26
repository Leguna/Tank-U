using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bullet
{
    public class BulletModel : BaseModel, IBulletModel
    {
        public BulletModel()
        {
            Speed = 5;
            SpawnPosition = Vector3.zero;
            IsBouncingPowerUp = false;
            PowerUpBounceTimeLeft = 0f;
            Velocity = Vector3.forward;
            Health = 0;
            Damage = 1;
        }

        public void SpawnBullet(Vector3 spawnPos, Quaternion rotation, bool isBouncing, float timeLeft, int health)
        {
            SpawnPosition = spawnPos;
            SpawnRotation = rotation;
            IsBouncingPowerUp = isBouncing;
            PowerUpBounceTimeLeft = timeLeft;
            Health = health;
            SetDataAsDirty();
        }

        public float Speed { get; }
        public Vector3 SpawnPosition { get; private set; }
        public Quaternion SpawnRotation { get; private set; }
        public int Damage { get; }
        public bool IsDeath => Health <= 0;

        public int Health { get; private set; }

        public void TakeDamage(int damage)
        {
            if (IsBouncingPowerUp) return;
            Health -= 1;
            SetDataAsDirty();
        }

        public void SetPosition(Vector3 pos)
        {
            SpawnPosition = pos;
        }

        public Vector3 Velocity { get; private set; }

        public void SetVelocity(Vector3 dir)
        {
            Velocity = dir;
            SetDataAsDirty();
        }

        public void OnUpdateTime(float deltaTime)
        {
            PowerUpBounceTimeLeft -= deltaTime;
            if (PowerUpBounceTimeLeft <= 0)
            {
                DeactivatePowerUpBounce();
            }
        }

        public bool IsBouncingPowerUp { get; private set; }
        public float PowerUpBounceTimeLeft { get; private set; }

        public void ActivatePowerUpBounce(float powerUpDuration)
        {
            IsBouncingPowerUp = true;
            PowerUpBounceTimeLeft = powerUpDuration;
            SetDataAsDirty();
        }

        public void DeactivatePowerUpBounce()
        {
            IsBouncingPowerUp = false;
            SetDataAsDirty();
        }
    }
}