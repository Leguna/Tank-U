using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using TankU.Message;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerInputController : BaseController<PlayerInputController>
    {

        public PlayerInput _playerInput = new();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _playerInput._PlayerMapInput.Enable();
            _playerInput._PlayerMapInput.move.performed += OnMoveInput;
            _playerInput._PlayerMapInput.rotate.performed += OnRotateInput;
            _playerInput._PlayerMapInput.rotate.canceled += OnRotateInput;
            _playerInput._PlayerMapInput.Action.performed += OnFire;
        }

        private void OnMoveInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Publish(new InputMoveMessage(obj.ReadValue<Vector3>()));
        }

        private void OnRotateInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Publish(new InputRotateMessage(obj.ReadValue<Vector2>()));
        }

        private void OnFire(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Publish(new FireMessage());
        }

        public override IEnumerator Terminate()
        {
            _playerInput._PlayerMapInput.Disable();
            yield return base.Terminate();
        }

        /*public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _playerInput._PlayerMapInput.rotate.canceled -= OnRotateInput;

        }*/
    }
}
