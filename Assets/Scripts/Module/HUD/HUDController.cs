using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Gameplay;
using TankU.Module.Base;
using UnityEngine.UI;

namespace TankU.Module.HUD
{
    public class HUDController : ObjectController<HUDController, HUDView>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        private void SetColor(List<int> obj)
        {
            for (var i = 0; i <= (_view.barList.Count - 1); i++)
            {
                _view.barList[i].Player.GetComponent<Image>().color = BaseColor.PlayerColors[obj[i]];
            }
        }

        public void GetColorPlayer(List<int> colorList, PickingState pickingState)
        {
            if (pickingState == PickingState.Finish)
            {
                SetColor(colorList);
            }
        }
    }
}