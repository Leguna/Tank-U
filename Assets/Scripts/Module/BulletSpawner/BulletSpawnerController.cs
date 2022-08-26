using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Bullet;
using UnityEngine;

namespace TankU.Module.BulletSpawner
{
    public class
        BulletSpawnerController : ObjectController<BulletSpawnerController, BulletSpawnerModel, BulletSpawnerView>
    {
        public override void SetView(BulletSpawnerView view)
        {
            base.SetView(view);
            for (var i = 0; i < _model.PoolSize; i++)
            {
                AddObjectToPool();
            }
        }

        public void SpawnBullet(SpawnBulletMessage message)
        {
            Debug.Log($"Fire {message.TransformSpawner.position} Rotation: {message.TransformSpawner.rotation}");
            var bulletController = _model.GetObjectController() ?? AddObjectToPool();
            bulletController.SpawnBullet(message.TransformSpawner.position,
                message.TransformSpawner.rotation, false, 5f, 1);
        }

        private BulletController AddObjectToPool()
        {
            var bulletModel = new BulletModel();
            var bulletController = new BulletController();
            var bulletView = Object.Instantiate(_model.BulletView, bulletModel.SpawnPosition, Quaternion.identity,
                _view.transform);
            bulletController.Init(bulletModel, bulletView);
            InjectDependencies(bulletController);
            _model.AddBullet(bulletController);
            return bulletController;
        }
    }
}