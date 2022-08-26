using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Boot;
using TankU.Message;

namespace TankU.MainMenu
{
    public class MainMenuController : ObjectController<MainMenuController, MainMenuView>
    {
        public override void SetView(MainMenuView view)
        {
            base.SetView(view);
            _view.SetCallback(PlayGame, ShowSetting);
        }

        public void PlayGame()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        public void ShowSetting()
        {
            Publish<ShowSettingMessage>(new ShowSettingMessage());
        }
    }
}
