using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Message;

namespace TankU.PowerUp
{
    public class PowerUpController : ObjectController<PowerUpController, PowerUpModel, IPowerUpModel, PowerUpView>
    {
        public void Init(PowerUpModel model, PowerUpView view)
        {
            _model = model;
            SetView(view);
        }

        public void OnCountTimer()
        {
            if (_view.gameObject.activeInHierarchy)
            {
                if (_model.SpawnTimer <= 0)
                {
                    _model.SetTimerSpawn(5f);
                    _view.gameObject.SetActive(false);
                }

                _model.DecreaseTimerByDeltatime();
            }
        }

        public void OnCollidePlayer()
        {
            Publish<PowerupBouncePickupMessage>(new PowerupBouncePickupMessage(_model.Duration));
        }

        public override void SetView(PowerUpView view)
        {
            base.SetView(view);
            _view.SetCallback(OnCountTimer);
        }
    }
}
