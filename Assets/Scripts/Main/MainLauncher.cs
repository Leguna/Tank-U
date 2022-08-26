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