using System;
using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bullet
{
    public class BulletView : ObjectView<IBulletModel>
    {
        [SerializeField] private Rigidbody _rigidbody;
        private Action<Collision> _onCollisionEvent;
        private Action<float> _onUpdate;

        public void SetCallback(Action<Collision> onCollisionEnter, Action<float> onUpdateEvent)
        {
            _onCollisionEvent = onCollisionEnter;
            _onUpdate = onUpdateEvent;
        }

        protected override void InitRenderModel(IBulletModel model)
        {
            transform.position = model.SpawnPosition;
            gameObject.SetActive(!model.IsDeath);
            _rigidbody.AddRelativeForce(Vector3.forward * (100 * model.Speed));
        }

        protected override void UpdateRenderModel(IBulletModel model)
        {
            if (model.IsDeath) gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _onCollisionEvent?.Invoke(collision);
        }

        private void Update()
        {
            _onUpdate?.Invoke(Time.deltaTime);
        }
    }
}