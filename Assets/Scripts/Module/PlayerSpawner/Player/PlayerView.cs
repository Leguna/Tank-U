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
        private Action<Vector3, int> _onMove;
        private Action _rotate;

        internal void SetCallbacks(Action Move, Action Rotate, Action<PlayerModel, PlayerView> Init, Action<Vector3, int> OnMove)
        {
            _Move = Move;
            _onInit = Init;
            _onMove = OnMove;
            _rotate = Rotate;
        }

        protected override void InitRenderModel(IPlayerModel model)
        {
            TryGetComponent(out MeshRenderer meshRenderer);
            meshRenderer.material = model.MaterialColor;
            _onMove?.Invoke(Vector3.zero, _model.PlayerNumber);
        }

        protected override void UpdateRenderModel(IPlayerModel model)
        {
            TryGetComponent(out MeshRenderer meshRenderer);
            meshRenderer.material = model.MaterialColor;
        }


        private void FixedUpdate()
        {
            _rotate?.Invoke();
            _Move?.Invoke();
        }

    }
}
