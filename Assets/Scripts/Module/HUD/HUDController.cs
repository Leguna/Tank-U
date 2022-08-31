using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Message;
using UnityEngine;

namespace TankU.Module.HUD
{
    public class HUDController : ObjectController<HUDController, HUDView>
    {
        public void SetBar()
        {
            var barPlayerColor = Resources.Load<GameObject>("Prefabs/HUD/BarPlayerColor");
            var barItem = Resources.Load<GameObject>("Prefabs/HUD/BarItem");
            _view.AddBar(barItem, barPlayerColor, 2);
        }

        public void GetColorPlayer(List<int> colorList)
        {
            SetBar();
            _view.ShowBar(colorList.Count);
            _view.SetPlayerColor(colorList);
        }

        public void GetStatusPowerUp(bool powerUpStatus, int playerIndex)
        {
        }

        public void GetPlayerHealth(int health, int playerIndex)
        {
            _view.SetHealth(playerIndex, health);
        }

        public void HideBar()
        {
            _view.HideBar();
        }

        public override void SetView(HUDView view)
        {
            base.SetView(view);
            view.SetCallback(delegate
            {
                Debug.Log("TES");
                Publish(new ShowSettingMessage());
            });
        }

        public void ToggleOption()
        {
            _view.ToggleOptions();
        }
    }
}