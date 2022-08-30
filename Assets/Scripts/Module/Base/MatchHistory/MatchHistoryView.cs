using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Module.Base
{
    public class MatchHistoryView : BaseView
    {
        public void ShowBoard()
        {
            gameObject.SetActive(true);
        }

        public void HideBoard()
        {

        }

        public void UpdateMatchHistoryData(MatchHistoryModel matchHistoryData)
        {

        }
    }
}
