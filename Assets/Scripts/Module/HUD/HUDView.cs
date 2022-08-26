using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TankU.Gameplay
{
    public class HUDView : BaseView
    {
        [SerializeField] public GameObject PlayerHUD1;
        [SerializeField] public GameObject PlayerHUD2;
        [SerializeField] public GameObject panelOPtion;
        [SerializeField] public GameObject toggleAudio;
        [SerializeField] public Image _1barP1;
        [SerializeField] public Image _2barP1;
        [SerializeField] public Image _3barP1;
        [SerializeField] public Image _4barP1;
        [SerializeField] public Image _5barP1;
        [SerializeField] public Image _1barP2;
        [SerializeField] public Image _2barP2;
        [SerializeField] public Image _3barP2;
        [SerializeField] public Image _4barP2;
        [SerializeField] public Image _5barP2;
        [HideInInspector] public List<GameObject> healtP1;
        [HideInInspector] public List<GameObject> healtP2;
        private List<Color> _colors;
        private bool _isOn;

        private Action<List<Color>> _GetColor;

        internal void SetCallBack(Action<List<Color>> GetColor)
        {
            _GetColor = GetColor;
        }


        private void Start()
        {
            _GetColor?.Invoke(_colors);
            _isOn = toggleAudio.GetComponent<Toggle>().isOn;
        }

        private void Update()
        {
        }


        public void OpenOption()
        {
            Time.timeScale = 0f;
            panelOPtion.SetActive(true);
        }
        
        public void CloseOption()
        {
            Time.timeScale = 1.0f;
            panelOPtion.SetActive(false);
        }

        public void ToggleAudio()
        {
            if (_isOn)
            {
                Debug.Log("audio oof");
            }
            else
            {
                Debug.Log("audio on");
            }
        }
    }
}
