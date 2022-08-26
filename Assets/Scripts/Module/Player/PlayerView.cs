using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TankU.Gameplay
{
    public class PlayerView : ObjectView<IPlayerModel>
    {

        private Action _Move;
        private Action<Vector3> _onMove;
        private Action _rotate;

        protected override void InitRenderModel(IPlayerModel model)
        {
            _onMove?.Invoke(Vector3.zero);
        }

        protected override void UpdateRenderModel(IPlayerModel model)
        {
        }

        internal void SetCallbacks(Action Move, Action Rotate, Action<Vector3> OnMove)
        {
            _Move = Move;
            _onMove = OnMove;
            _rotate = Rotate;
        }


        private void FixedUpdate()
        {
            _rotate?.Invoke();
            _Move?.Invoke();
        }


    }
}
