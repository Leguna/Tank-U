using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Base;

namespace TankU.Module.VisualEffect
{
    public class VisualEffectConnector : BaseConnector
    {
        private VisualEffectController _visualEffectController;

        protected override void Connect()
        {
            Subscribe<SpawnVisualEffectMessage>(SpawnVisualEffect);
            Subscribe<SpawnBulletMessage>(OnSpawnBullet);
            Subscribe<BombExplodeMessage>(OnBombExplode);
            Subscribe<PlayerExplodeMessage>(AfterBombExplode);
            Subscribe<TankMoveMessage>(TankMove);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SpawnVisualEffectMessage>(SpawnVisualEffect);
            Unsubscribe<SpawnBulletMessage>(OnSpawnBullet);
            Unsubscribe<BombExplodeMessage>(OnBombExplode);
            Unsubscribe<PlayerExplodeMessage>(AfterBombExplode);
            Unsubscribe<TankMoveMessage>(TankMove);
        }

        private void OnSpawnBullet(SpawnBulletMessage message)
        {
            _visualEffectController.SpawnVisualEffect(VisualEffectCategory.MuzzleFlash, message.TransformSpawner);
        }

        private void OnBombExplode(BombExplodeMessage message)
        {
            _visualEffectController.SpawnVisualEffect(VisualEffectCategory.Explosion, message.TransformSpawner);
        }

        private void AfterBombExplode(PlayerExplodeMessage message)
        {
            _visualEffectController.SpawnVisualEffect(VisualEffectCategory.Fire, message.TransformSpawner);
        }

        private void TankMove(TankMoveMessage message)
        {
            _visualEffectController.SpawnVisualEffect(VisualEffectCategory.Trail, message.TransformSpawner);
        }

        private void SpawnVisualEffect(SpawnVisualEffectMessage message)
        {
            _visualEffectController.SpawnVisualEffect(message.VisualEffectCategory, message.SpawnTransform);
        }
    }
}