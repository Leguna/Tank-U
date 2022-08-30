using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public interface IBombModel : IBaseModel, IDoingDamageModel
    {
        bool IsDeath { get; }
        Vector3 SpawnPosition { get; }
        void SpawnBomb(Vector3 spawnpos, int damage, int health);
        void SetPosition(Vector3 pos);
        void OnUpdateTime(float deltaTime);
    }
}
