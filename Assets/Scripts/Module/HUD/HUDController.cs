using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            view.SetCallBack(GetColorPlayer);
            base.SetView(view);
        }


        public void GetColorPlayer()
        {

        }
    }
}
