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
            _view.SetButtonListener(PlayGame, ShowSetting, ExitGame);
        }

        public void PlayGame()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        public void ShowSetting()
        {
            Publish<ShowSettingMessage>(new ShowSettingMessage());
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
