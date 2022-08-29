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
            _playerInput._PlayerMapInput.move.performed += (ctx)=> OnMoveInput(ctx, 0);
            _playerInput._PlayerMapInput.rotate.performed += (ctx) => OnRotateInput(ctx, 0);
            _playerInput._PlayerMapInput.rotate.canceled += (ctx) => OnRotateInput(ctx, 0);
            _playerInput._PlayerMapInput.Action.performed += (ctx) => OnFire(ctx, 0);
            _playerInput._PlayerMapInput1.Enable();
            _playerInput._PlayerMapInput1.move.performed += (ctx) => OnMoveInput(ctx, 1);
            _playerInput._PlayerMapInput1.rotate.performed += (ctx) => OnRotateInput(ctx, 1);
            _playerInput._PlayerMapInput1.rotate.canceled += (ctx) => OnRotateInput(ctx, 1);
            _playerInput._PlayerMapInput1.Action.performed += (ctx) => OnFire(ctx, 1);
        }

        private void OnMoveInput(UnityEngine.InputSystem.InputAction.CallbackContext obj, int i)
        {
            //Debug.Log(obj.ReadValue<Vector3>());
            Publish(new InputMoveMessage(obj.ReadValue<Vector3>(), i));
        }

        private void OnRotateInput(UnityEngine.InputSystem.InputAction.CallbackContext obj, int i)
        {
            //Debug.Log($"from obj iput ({obj.ReadValue<Vector2>()})");
            Publish(new InputRotateMessage(obj.ReadValue<Vector2>(), i));
        }

        private void OnFire(UnityEngine.InputSystem.InputAction.CallbackContext obj, int i)
        {
            Publish(new FireMessage(i));
        }

        public override IEnumerator Terminate()
        {
            _playerInput._PlayerMapInput.Disable();
            _playerInput._PlayerMapInput1.Disable();
            yield return base.Terminate();
        }

    }
}
