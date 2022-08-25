using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.Bullet
{
    public interface IBulletModel : IBaseModel, IDoingDamageModel, IDamageableModel
    {
        bool IsDeath { get; }
        float Speed { get; }
        Vector3 SpawnPosition { get; }
        void SetPosition(Vector3 pos);
        Vector3 Velocity { get; }
        void SetVelocity(Vector3 dir);
        bool IsBouncingPowerUp { get; }
        float PowerUpBounceTimeLeft { get; }
        void ActivatePowerUpBounce(float duration);
        void DeactivatePowerUpBounce();
        void OnUpdateTime(float deltaTime);
    }
}