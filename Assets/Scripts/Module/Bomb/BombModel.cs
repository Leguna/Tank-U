using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class BombModel : BaseModel, IBombModel
    {
        public int Damage { get; private set; }

        public Vector3 SpawnPosition { get; private set; }

        public BombModel()
        {
            SpawnPosition = Vector3.zero;
            Damage = 1;
        }

        public BombModel(Vector3 spawnPosition, int damage)
        {
            SpawnPosition = spawnPosition;
            Damage = damage;
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
    }
}
