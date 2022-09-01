using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.MatchHistory;
using UnityEngine.Events;
using TankU.Message;

namespace TankU.Module.Base
{
    public class MatchHistoryController : ObjectController<MatchHistoryController, MatchHistoryModel, IMatchHistoryModel
        , MatchHistoryView>
    {

        public override void SetView(MatchHistoryView view)
        {
            base.SetView(view);
            view.SetCallbacks(null);
        }

        public void SetCallbacks(UnityAction backToMainMenu)
        {
            _view.SetCallbacks(backToMainMenu);
        }

        //public void ShowView(List<MatchData> matchDatas)
        //{
        //    _view.ShowBoard(matchDatas);
        //}

        public void ShowView(ShowMatchHistoryMessage msg)
        {
            _view.ShowBoard(_model.Load());
        }

        public List<MatchData> Load()
        {
            return _model.Load();
        }

        public void AddMatch(int objWinner, List<int> objListColorIndex)
        {
            _model.AddMatch(objWinner, objListColorIndex);
        }

        public List<int> WinCount()
        {
            return _model.GetWinCount();
        }
    }
}