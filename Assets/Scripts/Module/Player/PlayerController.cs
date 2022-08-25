using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerController : ObjectController<PlayerController, PlayerModel, IPlayerModel, PlayerView>
    {
        private Rigidbody rg;
        public override void SetView(PlayerView view)
        {
            view.SetCallbacks(Move, Init, OnMove);
            view.TryGetComponent(out rg);
            base.SetView(view);
        }


        private void Move()
        {
            rg.velocity = _model.Velocity * _model.Speed;
            //Debug.Log($"{rg.velocity} , {_model.Velocity}");
            _model.SetPosition(rg.velocity);
            
        }

        public void OnMove(Vector3 direction)
        {
            _model.Move(direction);
            //Debug.Log($"move = {direction}, speed = {_model.Speed}");
        }

        internal void OnRotate(Vector2 direction)
        {
            
        }

        public void Init()
        {
            _model.SetSpeed(20);
            _model.SetPosition(new Vector3(0, 0.3f, 0));
            
        }
    }
}
