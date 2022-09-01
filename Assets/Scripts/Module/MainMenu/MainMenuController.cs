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
            _view.SetButtonListener(PlayGame, ShowSetting, ShowMatchHistory, ExitGame);
        }

        public void PlayGame()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        public void ShowSetting()
        {
            Publish(new ShowSettingMessage());
        }

        public void ShowMatchHistory()
        {
            Publish(new ShowMatchHistoryMessage());
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
