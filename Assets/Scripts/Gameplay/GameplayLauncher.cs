using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Boot;
using SpacePlan.Module.ClickGame;
using SpacePlan.Module.SoundFx;
using TankU.Gameplay;

namespace SpacePlan.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        private ClickGameController _clickGame;
        private SoundFxController _soundFx;
        private PlayerController _playerController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new ClickGameController(),
                new SoundFxController(),
                new PlayerController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _clickGame.SetView(_view.ClickGameView);
            _soundFx.SetView(_view.SoundFxView);
            _playerController.SetView(_view.PlayerView);
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