using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class HUDView : BaseView
    {
        [SerializeField] private GameObject PlayerHUD1;
        [SerializeField] private GameObject PlayerHUD2;

        private Action _GetColorPlayer;

        internal void SetCallBack(Action GetColor)
        {
            _GetColorPlayer = GetColor;
        }

        private void Start()
        {
            Debug.Log(PlayerHUD1);
        }
    }
}
