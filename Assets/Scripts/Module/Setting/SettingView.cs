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
        [SerializeField] private Button _sfxButton;
        [SerializeField] private Button _bgmButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _sfxText;
        [SerializeField] private TMP_Text _bgmText;

        public void Show()
        {
            _settingPanel.SetActive(true);
        }

        public void Close()
        {
            _settingPanel.SetActive(false);
        }

        public void SetCallback(UnityAction onTurnSFX, UnityAction onTurnBGM, UnityAction onBack)
        {
            _sfxButton.onClick.RemoveAllListeners();
            _bgmButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _sfxButton.onClick.AddListener(onTurnSFX);
            _bgmButton.onClick.AddListener(onTurnBGM);
            _backButton.onClick.AddListener(onBack);
        }

        protected override void InitRenderModel(ISettingModel model)
        {
            
        }

        protected override void UpdateRenderModel(ISettingModel model)
        {
            _sfxText.text = $"SFX {(_model.IsSfxOn ? "On" : "Off")}";
            _bgmText.text = $"BGM {(_model.IsBgmOn ? "On" : "Off")}";
        }
    }
}
