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

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        public void OnCountTimer()
        {
            if (_view.gameObject.activeInHierarchy)
            {
                if (_model.SpawnTimer <= 0)
                {
                    _model.SetTimerSpawn(5f);
                    _model.SetActive(false);
                }

                _model.DecreaseTimerByDeltatime();
                //Debug.Log("Timer : " + _model.SpawnTimer);
            }
        }

        public void OnCollideWithPlayer(PowerupBouncePickupMessage msg)
        {
            _model.SetActive(false);
            _model.SetTimerSpawn(5f);
        }

        public void OnCollideWithPlayer(PowerupHealthPickupMessage msg)
        {
            _model.SetActive(false);
            _model.SetTimerSpawn(3f);
        }

        public void OnActive()
        {
            if (_model.IsActive)
            {
                _view.gameObject.SetActive(true);
            }
            else
            {
                _view.gameObject.SetActive(false);
            }
        }

        public override void SetView(PowerUpView view)
        {
            base.SetView(view);
            _view.SetCallback(OnCountTimer, OnActive);
        }
    }
}
