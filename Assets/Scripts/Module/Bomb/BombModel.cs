using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombModel : BaseModel, IBombModel
    {
        public int Damage { get; private set; }
        public Vector3 SpawnPosition { get; private set; }

        public bool IsDeath => Health <= 0;
        public int Health { get; private set; }

        public float SpawnTimer { get; private set; }
        public float Duration { get; private set; }

        public BombModel()
        {
            SpawnPosition = Vector3.zero;
            Damage = 1;
            Health = 0;
            SpawnTimer = 4f;
            Duration = 5.5f;
        }

        public void SpawnBomb(Vector3 spawnPosition, int damage, int health)
        {
            SpawnPosition = spawnPosition;
            Damage = damage;
            Health = health;
            SetDataAsDirty();
        }
        
        public void SetDamage(int damage)
        {
            Damage = damage;
            SetDataAsDirty();
        }

        public void SetPosition(Vector3 pos)
        {
            SpawnPosition = pos;
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

        public void DecreaseTimer()
        {
            SpawnTimer -= Time.deltaTime;
            Duration -= Time.deltaTime;
        }

        public void OnUpdateTime(float deltaTime)
        {
            
        }
    }
}
