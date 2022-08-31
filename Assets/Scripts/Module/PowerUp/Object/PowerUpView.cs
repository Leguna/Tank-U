using System;
using Agate.MVC.Base;
using TankU.PowerUp;
using UnityEngine;

namespace TankU.Module.PowerUp.Object
{
    public class PowerUpView : ObjectView<IPowerUpModel>
    {
        private Action _onCountTimer;
        private Action<Collider> _onCollidePlayer;

        protected override void InitRenderModel(IPowerUpModel model)
        {
            gameObject.SetActive(true);
        }

        protected override void UpdateRenderModel(IPowerUpModel model)
        {
        }

        public void SetCallback(Action onCountTimer, Action<Collider> onCollidePlayer)
        {
            _onCountTimer = onCountTimer;
            _onCollidePlayer = onCollidePlayer;
        }

        public void SetTransform(Vector3 pos)
        {
            transform.position = pos;
        }

        private void Update()
        {
            _onCountTimer?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            _onCollidePlayer?.Invoke(other);
        }
    }
}