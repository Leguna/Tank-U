using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Boot;

namespace SpacePlan.Main
{
    public class MainLauncher : SceneLauncher<MainLauncher, MainView>

    {
        public override string SceneName => "Main";

        protected override IController[] GetSceneDependencies()
        {
            return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallbacks(OnClickPlayButton);
            yield return null;
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
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