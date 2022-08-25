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

        protected override void InitRenderModel(IPowerUpModel model)
        {
            gameObject.SetActive(true);
        }

        protected override void UpdateRenderModel(IPowerUpModel model)
        {
            
        }

        public void SetCallback(Action onCountTimer)
        {
            OnCountTimer = onCountTimer;
        }

        public void SetTransform(Vector3 pos)
        {
            transform.position = pos;
        }

        private void Update()
        {
            OnCountTimer?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
