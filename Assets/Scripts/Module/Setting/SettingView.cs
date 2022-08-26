using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;
using TMPro;

namespace TankU.Setting
{
    public class SettingView : ObjectView<ISettingModel>
    {
        [SerializeField] private GameObject _settingPanel;
        [SerializeField] private Button _audioButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _audioText;

        public void Show()
        {
            _settingPanel.SetActive(true);
        }

        public void Close()
        {
            _settingPanel.SetActive(false);
        }

        public void SetCallback(UnityAction onTurnAudio, UnityAction onBack)
        {
            _audioButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _audioButton.onClick.AddListener(onTurnAudio);
            _backButton.onClick.AddListener(onBack);
        }

        protected override void InitRenderModel(ISettingModel model)
        {
            
        }

        protected override void UpdateRenderModel(ISettingModel model)
        {
            _audioText.text = $"Audio {(_model.IsAudioOn ? "On" : "Off")}";
        }
    }
}
