using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Leguna.ExampleMVC.Boot;
using Leguna.ExampleMVC.Module.ClickGame;
using Leguna.ExampleMVC.Module.SoundFx;

namespace Leguna.ExampleMVC.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        private ClickGameController _clickGame;
        private SoundFxController _soundFx;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new ClickGameController(),
                new SoundFxController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _clickGame.SetView(_view.ClickGameView);
            _soundFx.SetView(_view.SoundFxView);
            yield return null;
        }


        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector()
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}