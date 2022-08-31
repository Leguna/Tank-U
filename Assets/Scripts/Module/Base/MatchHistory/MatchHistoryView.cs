using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TankU.Module.Base
{
    public class MatchHistoryView : BaseView
    {
        [SerializeField] private GameObject matchHistoryCanvas;
        [SerializeField] private Button _backToMainMenu;

        public void SetCallbacks(UnityAction backToMainMenu)
        {
            _backToMainMenu.onClick.RemoveAllListeners();
            _backToMainMenu.onClick.AddListener(backToMainMenu);
        }

        public void ShowBoard()
        {
            gameObject.SetActive(true);
        }

        public void HideBoard()
        {

        }

        public void UpdateMatchHistoryData(MatchHistoryModel matchHistoryData)
        {
            // resultlist.text = matchHistoryData;
        }
    }
}
