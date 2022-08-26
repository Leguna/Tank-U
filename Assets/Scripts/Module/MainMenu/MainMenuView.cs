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

        public void SetCallback(UnityAction onPlay, UnityAction onSetting)
        {
            _playButton.onClick.RemoveAllListeners();
            _settingButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onPlay);
            _settingButton.onClick.AddListener(onSetting);
        }
    }
}
