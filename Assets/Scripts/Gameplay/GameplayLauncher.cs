using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Boot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        //private SFXController _sfx;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
              {
              new GameplayConnector()
              };
        }

        protected override IController[] GetSceneDependencies()
        {
            throw new System.NotImplementedException();
            /*return new IController[]
             * {
             * new SFXController()
             * };
             */
        }

        protected override IEnumerator InitSceneObject()
        {
            throw new System.NotImplementedException();
            //_sfx.SetView(_view.SFXView);
            //yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
