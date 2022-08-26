using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TankU.Gameplay
{
    public class HUDView : BaseView
    {
        [SerializeField] public GameObject PlayerHUD1;
        [SerializeField] public GameObject PlayerHUD2;
        private List<Color> _colors;

        private Action<List<Color>> _GetColor;

        internal void SetCallBack(Action<List<Color>> GetColor)
        {
            _GetColor = GetColor;
        }


        private void Start()
        {
            _GetColor?.Invoke(_colors);
        }

        private void Update()
        {
            
        }
    }
}
