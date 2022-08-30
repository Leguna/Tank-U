using Agate.MVC.Base;
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

        public void ShowResult(int winnerIndex)
        {
            _view.SetResultText(winnerIndex == -1 ? "DRAW!" : $"Player {winnerIndex + 1} Win!");
        }
    }
}