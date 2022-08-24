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

        [SerializeField]  public Rigidbody rg;
        [HideInInspector] public Vector3 v;
        public PlayerInput _playerInput;

        private Action _onMove;
        private Action _onInit;

        internal void SetCallbacks(Action Move, Action Init)
        {
            _onMove = Move;
            _onInit = Init;
        }
        private void Awake()
        {
            _playerInput = new PlayerInput();
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
            _onMove?.Invoke();
        }


    }
}
