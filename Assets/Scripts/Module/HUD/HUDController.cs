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
            base.SetView(view);
        }

        // set color player in HUD
        private void SetColor(List<Color> obj)
        {
            for (var i = 0; i <= (_view.barList.Count -1); i++)
            {
                _view.barList[i].Player.GetComponent<Image>().color = obj[i];
            }
        }

        //get color from pickedColorMesage
        public void GetColorPlayer(List<Color> colorList, PickingState pickingState)
        {
            if ( pickingState == PickingState.Finish)
            {
                SetColor(colorList);
            }        
        }

    }
}
