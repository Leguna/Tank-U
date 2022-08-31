using System;
using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.Bullet
{
    public class BulletView : ObjectView<IBulletModel>
    {
        [SerializeField] public Rigidbody Rigidbody;
        private Action<Collision> _onCollisionEvent;
        private Action<float> _onUpdate;

        public void SetCallback(Action<Collision> onCollisionEnter, Action<float> onUpdateEvent)
        {
            _onCollisionEvent = onCollisionEnter;
            _onUpdate = onUpdateEvent;
        }

        protected override void InitRenderModel(IBulletModel model)
        {
            transform.rotation = model.SpawnRotation;
            transform.position = model.SpawnPosition;
            gameObject.SetActive(!model.IsDeath);
        }

        protected override void UpdateRenderModel(IBulletModel model)
        {
            gameObject.SetActive(!model.IsDeath);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _onCollisionEvent?.Invoke(collision);
        }

        private void Update()
        {
            _onUpdate?.Invoke(Time.deltaTime);
            if (Vector3.Distance(transform.position, _model.SpawnPosition) > 100) _model.TakeDamage(1);
        }
    }
}