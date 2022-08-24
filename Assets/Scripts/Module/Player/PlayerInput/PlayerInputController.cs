using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerInputController : BaseController<PlayerInputController>
    {

        public PlayerInput _playerInput = new();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _playerInput._PlayerMapInput.Disable();
            _playerInput._PlayerMapInput.move.performed += OnMoveInput;
        }

        private void OnMoveInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Publish(new InputMoveMessage(obj.ReadValue<Vector3>()));
        }

        public override IEnumerator Terminate()
        {
            _playerInput._PlayerMapInput.Disable();
            yield return base.Terminate();
        }

    }
}
