using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.Base;
using TankU.Module.MatchHistory.MatchHistoryItem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TankU.Module.MatchHistory
{
    public class MatchHistoryView : ObjectView<IMatchHistoryModel>
    {
        [SerializeField] private Transform _containerMatchItem;
        [SerializeField] private Button _backToMainMenu;
        public List<ItemMatchHistoryView> _matchHistoryViews = new();

        public void SetCallbacks(UnityAction backToMainMenu)
        {
            _backToMainMenu.onClick.RemoveAllListeners();
            _backToMainMenu.onClick.AddListener(delegate
            {
                HideBoard();
                backToMainMenu?.Invoke();
            });
        }

        public void ShowBoard(List<MatchData> matchDatas)
        {
            Init(matchDatas.ToArray());
            UpdateMatchHistoryData(matchDatas.ToArray());
            gameObject.SetActive(true);
        }

        public void HideBoard()
        {
            gameObject.SetActive(false);
        }


        public void Init(MatchData[] matchData)
        {
            for (int i = 0; i < _matchHistoryViews.Count; i++)
            {
                Destroy(_matchHistoryViews[i].gameObject);
            }

            _matchHistoryViews = new List<ItemMatchHistoryView>();

            ItemMatchHistoryView prefab = Resources.Load<ItemMatchHistoryView>("Prefabs/UIMenu/ListData");
            for (int i = 0; i < matchData.Length; i++)
            {
                ItemMatchHistoryView view = Instantiate(prefab, _containerMatchItem);
                _matchHistoryViews.Add(view);
            }
        }


        public void UpdateMatchHistoryData(MatchData[] matchData)
        {
            for (int indexRow = 0; indexRow < matchData.Length; indexRow++)
            {
                for (int indexPlayer = 0; indexPlayer < matchData[indexRow].ColorIndex.Length; indexPlayer++)
                {
                    _matchHistoryViews[indexRow].numberText.text = $"{indexRow + 1}";

                    if (matchData[indexRow].WinnerIndex == indexPlayer)
                    {
                        _matchHistoryViews[indexRow].winnerText.text = $"Player {indexPlayer + 1}";
                        _matchHistoryViews[indexRow].winnerColor.color =
                            BaseColor.PlayerColors[matchData[indexRow].ColorIndex[matchData[indexRow].WinnerIndex]];
                        continue;
                    }

                    _matchHistoryViews[indexRow].loseText.text = $"Player {indexPlayer + 1}";
                    _matchHistoryViews[indexRow].loseColor.color =
                        BaseColor.PlayerColors[matchData[indexRow].ColorIndex[indexPlayer]];
                }
            }
        }

        protected override void InitRenderModel(IMatchHistoryModel model)
        {
        }

        protected override void UpdateRenderModel(IMatchHistoryModel model)
        {
        }
    }
}