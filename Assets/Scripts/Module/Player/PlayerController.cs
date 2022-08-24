using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerController : ObjectController<PlayerController, PlayerModel, IPlayerModel, PlayerView>
    {
        private Rigidbody _rigidbody;

        public override void SetView(PlayerView view)
        {
            base.SetView(view);
            view.SetCallbacks(Move, Init);
            view._playerInput = new PlayerInput();
            view.v = view._playerInput._PlayerMapInput.move.ReadValue<Vector3>();
            view.TryGetComponent(out _rigidbody);
        }

        public override IEnumerator Initialize()
        {
            return base.Initialize();
            _view._playerInput._PlayerMapInput.Enable();
        }

        public override IEnumerator Finalize()
        {
            return base.Finalize();
            _view._playerInput._PlayerMapInput.Disable();
        }

        private void Move()
        {
            Debug.Log($"move = {_model.Position}, speed = {_model.Speed}");
            _view.rg.velocity = _model.Position * _model.Speed;
            _model.SetPosition(_view.v);
        }

        public void Init()
        {
            _model.SetSpeed(5);
            _view.v = new Vector3(0, 0.3f, 0);
            
        }
    }
}
