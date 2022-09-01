using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Boot;
using TankU.MainMenu;
using TankU.Module.Base;
using TankU.Module.LevelUp;
using TankU.Setting;
using UnityEngine;

namespace TankU.Main
{
    public class MainLauncher : SceneLauncher<MainLauncher, MainView>
    {
        public override string SceneName => "MainMenu";

        private MainMenuController _mainMenuController;
        private SettingController _settingController;
        private MatchHistoryController _matchHistoryController;
        private LevelUpController _levelUpController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new MainMenuController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _mainMenuController.SetView(_view._mainMenuView);
            _settingController.SetView(_view._settingView);
            _matchHistoryController.Load();
            if (_levelUpController.IsGameUpdated())
            {
                _levelUpController.UpdateData(_matchHistoryController.WinCount());
            }
            else
            {
                _levelUpController.LoadData();
            }

            _matchHistoryController.SetView(_view._matchHistoryView);
            //_settingController.SetClickListener(OnMatchHistory, OnExit);
            // Publish(new GameOverMessage(new List<int>() { 1, 2 }, 1));
            yield return null;
        }

        private void OnExit()
        {
            Application.Quit();
        }

        //private void OnMatchHistory()
        //{
        //    _matchHistoryController.ShowView();
        //}

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}