using Agate.MVC.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using TankU.Message;
using TankU.Module.Base;
using UnityEngine;
using UnityEngine.UI;

namespace TankU.Gameplay
{
    public class HUDController : ObjectController<HUDController, HUDView>
    {

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

        }

        public override void SetView(HUDView view)
        {
            view.SetCallBack(GetColor);
            base.SetView(view);
        }

        private void GetColor(List<Color> obj)
        {
            _view.PlayerHUD1.GetComponent<Image>().color = obj[0];
            _view.PlayerHUD2.GetComponent<Image>().color = obj[1];

            Debug.Log($"list color = {obj}");
        }

        public void GetColorPlayer(List<Color> colorList, PickingState pickingState)
        {
            if ( pickingState == PickingState.Finish)
            {
            }        
                GetColor(colorList);
        }



    }
}
