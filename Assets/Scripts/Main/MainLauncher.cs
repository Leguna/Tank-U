using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Boot;
using TankU.MainMenu;
using TankU.Setting;

namespace TankU.Main
{
    public class MainLauncher : SceneLauncher<MainLauncher, MainView>

    {
        public override string SceneName => "Main";

        private MainMenuController _mainMenuController;
        private SettingController _settingController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new MainMenuController(),
                new SettingController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _mainMenuController.SetView(_view._mainMenuView);
            _settingController.SetView(_view._settingView);
            yield return null;
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new SettingConnector()
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }


        private void OnClickPlayButton()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
    }
}