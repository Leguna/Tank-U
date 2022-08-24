using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.PowerUp
{
    public class PowerUpView : ObjectView<IPowerUpModel>
    {
        private Action OnCountTimer;
        private Action OnObjectActive;

        protected override void InitRenderModel(IPowerUpModel model)
        {
            gameObject.SetActive(true);
        }

        protected override void UpdateRenderModel(IPowerUpModel model)
        {
            
        }

        public void SetCallback(Action onCountTimer, Action onObjectActive)
        {
            OnCountTimer = onCountTimer;
            OnObjectActive = onObjectActive;
        }

        private void Update()
        {
            OnCountTimer?.Invoke();
            OnObjectActive?.Invoke();
        }
    }
}
