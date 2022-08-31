using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TankU.Module.Result
{
    public class ResultView : BaseView
    {
        [SerializeField] private GameObject tutorialCanvas;
        [SerializeField] private GameObject resultCanvas;
        [SerializeField] private Text resultText;
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
            resultCanvas.SetActive(true);
            resultText.text = result;
        }

        public void ToggleGameOver()
        {
            resultCanvas.SetActive(!resultCanvas.activeSelf);
        }

        public void ToggleTutorial()
        {
            tutorialCanvas.SetActive(!tutorialCanvas.activeSelf);
        }
    }
}