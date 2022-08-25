using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.Bullet
{
    public class BulletController : ObjectController<BulletController, BulletModel, IBulletModel, BulletView>
    {
        public override void SetView(BulletView view)
        {
            view.SetCallback(OnCollisionEnter,OnUpdate);
            base.SetView(view);
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
    }
}