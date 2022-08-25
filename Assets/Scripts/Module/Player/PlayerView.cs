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
        private Action _onInit;
        private Action<Vector3> _onMove;

        internal void SetCallbacks(Action Move, Action Init, Action<Vector3> OnMove)
        {
            _Move = Move;
            _onInit = Init;
            _onMove = OnMove;
        }

        protected override void InitRenderModel(IPlayerModel model)
        {
            _onInit?.Invoke();
        }

        protected override void UpdateRenderModel(IPlayerModel model)
        {
        }


        private void FixedUpdate()
        {
            _Move?.Invoke();
            _onMove?.Invoke(Vector3.zero);
        }


    }
}
