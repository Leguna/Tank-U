using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Leguna.ExampleMVC.Module.SaveGame;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Leguna.ExampleMVC.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IController[] GetDependencies()
        {
            return new IController[]{
                new SaveDataController()
            };
        }

        protected override IEnumerator StartInit()
        {
            CreateEventSystem();
            yield return null;
        }

        protected override IConnector[] GetConnectors()
        {
            return null;
        }

        private void CreateEventSystem()
        {
            GameObject obj = new GameObject("Event System");
            obj.AddComponent<EventSystem>();
            obj.AddComponent<StandaloneInputModule>();
            GameObject.DontDestroyOnLoad(obj);
        }
    }
}