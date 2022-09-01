using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace TankU.Module.Result
{
    public class ResultView : BaseView
    {
        public GameObject tutorialCanvas;
        [SerializeField] private GameObject _resultCanvas;
        [SerializeField] private TMP_Text _playerWin;
        [SerializeField] private TMP_Text _playerLose;

        [SerializeField] private Button _tryAgain;
        [SerializeField] private Button _backToMainMenu;
        [SerializeField] private Button _closeTutorial;

        public void SetCallbacks(UnityAction backToMainMenu, UnityAction tryAgain, UnityAction closeTutorial)
        {
            _backToMainMenu.onClick.RemoveAllListeners();
            _tryAgain.onClick.RemoveAllListeners();
            _closeTutorial.onClick.RemoveAllListeners();
            _backToMainMenu.onClick.AddListener(backToMainMenu);
            _tryAgain.onClick.AddListener(tryAgain);
            _closeTutorial.onClick.AddListener(() =>
            {
                closeTutorial?.Invoke();
                tutorialCanvas.SetActive(false);
            });
        }

        public void SetResultText(string result)
        {
            _playerWin.gameObject.SetActive(true);
            _playerWin.text = result;
        }

        public void ToggleGameOver()
        {
            _resultCanvas.SetActive(!_resultCanvas.activeSelf);
        }

        public void ToggleTutorial()
        {
            tutorialCanvas.SetActive(!tutorialCanvas.activeSelf);
        }
    }
}