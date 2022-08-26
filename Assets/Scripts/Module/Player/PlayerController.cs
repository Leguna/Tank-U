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
            view.SetCallbacks(Move, Rotate, Init, OnMove);
            view.TryGetComponent(out rg);
            base.SetView(view);
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

        public void OnFire()
        {
            Transform bulletSpawner = _model.Head.GetChild(1);
            //Debug.Log($"posisis {bulletSpawner.transform.position}, direction {bulletSpawner.eulerAngles}");
            Publish(new SpawnBulletMessage(bulletSpawner.transform, 0, false));
        }

        public void Init()
        {
            _model.SetSpeed(20);
            _model.SetPosition(new Vector3(0, 0.3f, 0));
            _model.SetHead(_view.transform.GetChild(0));
        }
    }
}