using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Module.BulletSpawner
{
    public class BulletSpawnerConnector : BaseConnector
    {
        private BulletSpawnerController _bulletSpawnerController;

        protected override void Connect()
        {
            Subscribe<SpawnBulletMessage>(_bulletSpawnerController.SpawnBullet);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SpawnBulletMessage>(_bulletSpawnerController.SpawnBullet);
        }
    }
}