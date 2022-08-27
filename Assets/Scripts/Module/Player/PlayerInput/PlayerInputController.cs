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
            _playerInput._PlayerMapInput.Action.performed += OnFire;
            _playerInput._PlayerMapInput.Bomb.performed += OnBomb;
        }

        private void OnMoveInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            //Debug.Log(obj.ReadValue<Vector3>());
            Publish(new InputMoveMessage(obj.ReadValue<Vector3>()));
        }

        private void OnRotateInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            //Debug.Log($"from obj iput ({obj.ReadValue<Vector2>()})");
            Publish(new InputRotateMessage(obj.ReadValue<Vector2>()));
        }

        private void OnFire(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Publish(new FireMessage());
        }

        private void OnBomb(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Publish(new BombMessage());
        }

        public override IEnumerator Terminate()
        {
            _playerInput._PlayerMapInput.Disable();
            yield return base.Terminate();
        }

    }
}
