using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.PowerUp.Object;

namespace TankU.PowerUp
{
    public class
        PowerUpPoolerController : ObjectController<PowerUpPoolerController, PowerUpPoolerModel, PowerUpPoolerView>
    {
        public void CreatePowerUpObject(int index)
        {
            if (index == 1)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/PowerUp/PowerUpHealth");
                PowerUpView powerUpView = Object.Instantiate(prefab, GetRandomSpawnPoin().position, Quaternion.identity)
                    .GetComponent<PowerUpView>();
                powerUpView.transform.SetParent(_view.transform);
                _model.AddToListHealth(powerUpView);

                PowerUpModel powerUpModel = new PowerUpModel(index);
                PowerUpController powerUpController = new PowerUpController();

                InjectDependencies(powerUpController);
                powerUpController.Init(powerUpModel, powerUpView);
            }
            else if (index == 2)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/PowerUp/PowerUpBounce");
                PowerUpView powerUpView = Object.Instantiate(prefab, GetRandomSpawnPoin().position, Quaternion.identity)
                    .GetComponent<PowerUpView>();
                powerUpView.transform.SetParent(_view.transform);
                _model.AddToListBounce(powerUpView);

                PowerUpModel powerUpModel = new PowerUpModel(index);
                PowerUpController powerUpController = new PowerUpController();

                InjectDependencies(powerUpController);
                powerUpController.Init(powerUpModel, powerUpView);
            }
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _model.SetTimerSpawnHealth(8f);
            _model.SetTimerSpawnBounce(5f);
        }

        public Transform GetRandomSpawnPoin()
        {
            int rand = Random.Range(0, _view.spawnPoin.Count);
            if (rand == _model.TempRandomPosIndex)
            {
                if (rand <= _view.spawnPoin.Count - 2)
                {
                    rand += 1;
                }
            }

            _model.SetTemporaryIndex(rand);

            return _view.spawnPoin[_model.TempRandomPosIndex];
        }

        public void SpawnPowerUpHealth()
        {
            PowerUpView powerUp = _model.GetPowerUpHealth();
            if (powerUp == null)
            {
                CreatePowerUpObject(1);
            }
            else
            {
                powerUp.SetTransform(GetRandomSpawnPoin().position);
            }
        }

        public void SpawnPowerUpBounce()
        {
            PowerUpView powerUp = _model.GetPowerUpBounce();
            if (powerUp == null)
            {
                CreatePowerUpObject(2);
            }
            else
            {
                powerUp.SetTransform(GetRandomSpawnPoin().position);
            }
        }

        public void CountTimerSpawnHealth()
        {
            if (_model.TimerHealth <= 0)
            {
                SpawnPowerUpHealth();
                _model.SetTimerSpawnHealth(8f);
            }

            _model.DecreaseTimeHealthByDeltatime();
        }

        public void CountTimerSpawnBounce()
        {
            if (_model.TimerBounce <= 0)
            {
                SpawnPowerUpBounce();
                _model.SetTimerSpawnBounce(5f);
            }

            _model.DecreaseTimeBounceByDeltatime();
        }

        public override void SetView(PowerUpPoolerView view)
        {
            base.SetView(view);
            _view.SetCallback(CountTimerSpawnHealth, CountTimerSpawnBounce);
        }

        public void OnStart(TimerCountDownMessage message)
        {
            if (message.TimerEventTypeType == TimerEventType.OnCountdownFinish)
            {
                _view.gameObject.SetActive(true);
            }
            else
            {
                _view.gameObject.SetActive(false);
            }

        }
    }
}