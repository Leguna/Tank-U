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
        }

        protected override void Disconnect()
        {
            Unsubscribe<SpawnVisualEffectMessage>(SpawnVisualEffect);
            Unsubscribe<SpawnBulletMessage>(OnSpawnBullet);
        }

        private void OnSpawnBullet(SpawnBulletMessage message)
        {
            _visualEffectController.SpawnVisualEffect(VisualEffectCategory.MuzzleFlash, message.TransformSpawner);
        }

        private void SpawnVisualEffect(SpawnVisualEffectMessage message)
        {
            _visualEffectController.SpawnVisualEffect(message.VisualEffectCategory, message.SpawnTransform);
        }
    }
}