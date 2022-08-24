using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Message;

namespace TankU.PowerUp
{
    public class PowerUpPoolerController : ObjectController<PowerUpPoolerController, PowerUpPoolerModel, PowerUpPoolerView>
    {
        public void CreatePowerUpObject(int index)
        {
            if(index == 1)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/PowerUpHealth");
                PowerUpView powerUpView = Object.Instantiate(prefab).GetComponent<PowerUpView>();
                powerUpView.transform.SetParent(_view.transform);
                _model.AddToListHealth(powerUpView);

                PowerUpModel powerUpModel = new PowerUpModel();
                PowerUpController powerUpController = new PowerUpController();

                InjectDependencies(powerUpController);
                powerUpController.Init(powerUpModel, powerUpView);
            } 
            else if(index == 2)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/PowerUpBounce");
                PowerUpView powerUpView = Object.Instantiate(prefab).GetComponent<PowerUpView>();
                powerUpView.transform.SetParent(_view.transform);
                _model.AddToListBounce(powerUpView);

                PowerUpModel powerUpModel = new PowerUpModel();
                PowerUpController powerUpController = new PowerUpController();

                InjectDependencies(powerUpController);
                powerUpController.Init(powerUpModel, powerUpView);
            }
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _model.SetTimerSpawnHealth(2f);
            _model.SetTimerSpawnBounce(6f);
        }

        public void SpawnPowerUpHealth()
        {
            PowerUpView powerUp = _model.GetPowerUpHealth();
            if (powerUp == null)
            {
                CreatePowerUpObject(1);
            }
        }

        public void SpawnPowerUpBounce()
        {
            PowerUpView powerUp = _model.GetPowerUpBounce();
            if (powerUp == null)
            {
                CreatePowerUpObject(2);
            }
        }

        public void CountTimerSpawnHealth()
        {
            if (_model.TimerHealth <= 0)
            {
                SpawnPowerUpHealth();
                _model.SetTimerSpawnHealth(2f);
                Publish<PowerupHealthPickupMessage>(new PowerupHealthPickupMessage());
            }

            _model.DecreaseTimeHealthByDeltatime();
        }

        public void CountTimerSpawnBounce()
        {
            if (_model.TimerBounce <= 0)
            {
                SpawnPowerUpBounce();
                _model.SetTimerSpawnBounce(6f);
            }

            _model.DecreaseTimeBounceByDeltatime();
        }

        public override void SetView(PowerUpPoolerView view)
        {
            base.SetView(view);
            _view.SetCallback(CountTimerSpawnHealth, CountTimerSpawnBounce);
        }
    }
}
