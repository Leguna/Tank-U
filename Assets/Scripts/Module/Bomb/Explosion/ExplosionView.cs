using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Module.Bomb
{
    public class ExplosionView : BaseView
    {
        private Action<Collider> _onTriggerEvent;

        private void OnTriggerEnter(Collider other)
        {
            _onTriggerEvent?.Invoke(other);
        }

        public void SetCallback(Action<Collider> onTriggerEvent)
        {
            _onTriggerEvent = onTriggerEvent;
        }

    }
}
