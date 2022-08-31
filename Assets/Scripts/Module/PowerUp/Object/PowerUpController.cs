using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Base;
using TankU.Module.PowerUp.Object;
using UnityEngine;

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

                _model.DecreaseTimerByDeltaTime();
            }
        }

        public void OnCollidePlayer(Collider collider)
        {
            collider.TryGetComponent(out IPowerUpAbleView powerUpAbleView);
            if (powerUpAbleView == null) return;
            if (_model.PowerUpType == PowerUpType.Health)
                powerUpAbleView.OnHealthPowerUp(1);
            else
                powerUpAbleView.OnBulletPowerUp(_model.Duration);

            _view.gameObject.SetActive(false);

            Publish(new PowerupBouncePickupMessage(_model.Duration));
        }

        public override void SetView(PowerUpView view)
        {
            base.SetView(view);
            _view.SetCallback(OnCountTimer, OnCollidePlayer);
        }
    }
}