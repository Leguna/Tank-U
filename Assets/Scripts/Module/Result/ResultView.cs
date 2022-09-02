using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

        [SerializeField] private TMP_Text _playerWinExp;
        [SerializeField] private TMP_Text _playerWinLevel;
        [SerializeField] private TMP_Text _expToWinNextLevel;

        [SerializeField] private TMP_Text _playerLoseExp;
        [SerializeField] private TMP_Text _playerLoseLevel;
        [SerializeField] private TMP_Text _expToLoseNextLevel;

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

        public void SetResultText(int[] playerColorList, int winnerIndex, List<LevelUpData> levelUpDatas)
        {
            _resultCanvas.SetActive(true);
            for (int i = 0; i < playerColorList.Length; i++)
            {
                if (i == winnerIndex)
                {
                    _playerWin.gameObject.SetActive(true);
                    _playerWin.text = "Player " + (i + 1) + " wins!";
                    _playerWinExp.text = $"EXP: {levelUpDatas[i].Exp}";
                    _playerWinLevel.text = $"Level: {levelUpDatas[i].Level}";
                    _expToWinNextLevel.text = $"Next Level: {levelUpDatas[i].ExpToNextLevel}";
                }
                else
                {
                    _playerLose.gameObject.SetActive(true);
                    _playerLose.text = "Player " + (i + 1) + " loses!";
                    _playerLoseExp.text = $"EXP: {levelUpDatas[i].Exp}";
                    _playerLoseLevel.text = $"Level: {levelUpDatas[i].Level}";
                    _expToLoseNextLevel.text = $"Next Level: {levelUpDatas[i].ExpToNextLevel}";
                }
            }
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