using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agate.MVC.Base;
using UnityEngine.Events;

namespace TankU.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _exitButton;

        private UnityAction OnExit;

        public void SetButtonListener(UnityAction onPlay, UnityAction onSetting, UnityAction onExit)
        {
            _playButton.onClick.RemoveAllListeners();
            _settingButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onPlay);
            _settingButton.onClick.AddListener(onSetting);
            _exitButton.onClick.AddListener(onExit);
        }
    }
}
