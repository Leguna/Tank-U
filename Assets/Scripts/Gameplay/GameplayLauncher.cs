using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Boot;
using TankU.PowerUp;

namespace SpacePlan.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        private PowerUpPoolerController _powerUpPooler;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new PowerUpPoolerController(),
                new PowerUpController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _powerUpPooler.SetView(_view.powerUpPooler);
            yield return null;
        }


        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
                new PowerUpConnector()
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}