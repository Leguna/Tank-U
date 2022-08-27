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
        private Action<PlayerModel, PlayerView > _onInit;
        private Action<Vector3> _onMove;
        private Action _rotate;

        internal void SetCallbacks(Action Move, Action Rotate, Action<PlayerModel, PlayerView> Init, Action<Vector3> OnMove)
        {
            _Move = Move;
            _onInit = Init;
            _onMove = OnMove;
            _rotate = Rotate;
        }

        protected override void InitRenderModel(IPlayerModel model)
        {
            //_onInit?.Invoke();
        }

        protected override void UpdateRenderModel(IPlayerModel model)
        {
        }


        private void FixedUpdate()
        {
            _rotate?.Invoke();
            _Move?.Invoke();
            _onMove?.Invoke(Vector3.zero);
        }


    }
}
