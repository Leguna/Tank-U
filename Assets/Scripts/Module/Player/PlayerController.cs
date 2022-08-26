using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using TankU.Message;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerController : ObjectController<PlayerController, PlayerModel, IPlayerModel, PlayerView>
    {
        private Rigidbody rg;

        public override void SetView(PlayerView view)
        {
            view.SetCallbacks(Move, Rotate, OnMove);
            view.TryGetComponent(out rg);
            base.SetView(view);
            _model.SetHead(_view.transform.GetChild(0));

        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _model.SetSpeed(20);
            _model.SetPosition(new Vector3(0, 0.3f, 0));
            OnGetpowerUpBounce(5f);
        }

        private void Move()
        {
            rg.velocity = _model.Velocity * _model.Speed;
            _model.SetPosition(rg.velocity);
        }

        private void Rotate()
        {
            _model.Head.transform.Rotate(0, _model.RotateDirec.x, _model.RotateDirec.y, Space.Self);
        }

        public void OnMove(Vector3 direction)
        {
            _model.Move(direction);
        }

        internal void OnRotate(Vector2 direction)
        {
            _model.Rotate(direction);
        }

        public void OnGetpowerUpBounce(float duration)
        {
            if (_model.PowerUpDuration == 0)
            {
                _model.SetDurationPowerUp(duration);
                Debug.Log($"duration powerup bounce {duration}");
            }
        }

        public void OnGetPowerUpHealth()
        {
            _model.SetHealth(20);
        }

        public void OnFire()
        {
            Transform bulletSpawner = _model.Head.GetChild(1);
            //                            direction         , duration , ispowerup active;
            Publish(new SpawnBulletMessage(bulletSpawner.transform, 5, true));
        }


    }
}