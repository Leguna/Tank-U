using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using UnityEngine.Events;

namespace TankU.Module.Base
{
    public class MatchHistoryController : ObjectController<MatchHistoryController, MatchHistoryModel, MatchHistoryView>
    {
        public void SetMatchHistoryData()
        {
            
        }

        public override void SetView(MatchHistoryView view)
        {
            base.SetView(view);
            view.SetCallbacks(null);
        }

        public void SetCallbacks(UnityAction backToMainMenu)
        {
            _view.SetCallbacks(backToMainMenu);
        }
    }
}
