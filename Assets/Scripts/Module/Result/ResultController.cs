using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine.Events;

namespace TankU.Module.Result
{
    public class ResultController : ObjectController<ResultController, ResultView>
    {
        public override void SetView(ResultView view)
        {
            base.SetView(view);
            view.SetCallbacks(null, null, null);
        }

        public void SetCallbacks(UnityAction backToMainMenu, UnityAction tryAgain, UnityAction closeTutorial)
        {
            _view.SetCallbacks(backToMainMenu, tryAgain, closeTutorial);
        }

        public void ShowResult(int[] playerColorList, int winnerIndex, List<LevelUpData> levelUpDatas)
        {
            _view.SetResultText(playerColorList, winnerIndex, levelUpDatas);
        }

        public void ShowTutorial()
        {
            _view.tutorialCanvas.SetActive(true);
        }
    }
}