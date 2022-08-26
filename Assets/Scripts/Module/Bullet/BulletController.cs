using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.Bullet
{
    public class BulletController : ObjectController<BulletController, BulletModel, IBulletModel, BulletView>
    {
        public override void SetView(BulletView view)
        {
            view.SetCallback(OnCollisionEnter, OnUpdate);
            base.SetView(view);
        }

        public void SpawnBullet(Vector3 transformSpawnerPosition, Quaternion transformSpawnerRotation, bool b, float f,
            int i)
        {
            _model.SpawnBullet(transformSpawnerPosition, transformSpawnerRotation, b, f, i);
            var transform = _view.transform;
            transform.rotation = _model.SpawnRotation;
            transform.position = _model.SpawnPosition;
            _view.Rigidbody.velocity = Vector3.zero;
            _view.gameObject.SetActive(!_model.IsDeath);
            _view.Rigidbody.AddRelativeForce(Vector3.forward * (100 * _model.Speed));
        }

        private void OnUpdate(float deltaTime)
        {
            _model.OnUpdateTime(deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageableView>();
            damageable?.TakeDamage(_model);
            _model.TakeDamage(1);
        }

        public void Init(BulletModel bulletModel, BulletView bulletView)
        {
            SetView(bulletView);
            _model = bulletModel;
        }
    }
}