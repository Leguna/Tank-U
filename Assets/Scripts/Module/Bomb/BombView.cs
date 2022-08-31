using Agate.MVC.Base;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace TankU.Module.Bomb
{
    public class BombView : ObjectView<IBombModel>
    {
        private Action _onCountTimer;
        private Action<float> _onUpdate;

        public List<ExplosionView> _explosionView;

        protected override void InitRenderModel(IBombModel model)
        {
            transform.position = model.SpawnPosition;
            gameObject.SetActive(!model.IsDeath);
        }

        protected override void UpdateRenderModel(IBombModel model)
        {
            gameObject.SetActive(!model.IsDeath);
        }

        public void SetCallback(Action onCountTimer, Action<float> onUpdateEvent)
        {
            _onCountTimer = onCountTimer;
            _onUpdate = onUpdateEvent;
        }

        private void OnTriggerExit(Collider other)
        {
            other.isTrigger = false;
        }


        private void Update()
        {
            _onCountTimer?.Invoke();
            _onUpdate?.Invoke(Time.deltaTime);
        }
    }
}
