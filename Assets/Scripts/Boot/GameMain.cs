using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Module.SaveGame;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace TankU.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IController[] GetDependencies()
        {
            return new IController[]
            {
                new SaveDataController(),
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
            obj.AddComponent<InputSystemUIInputModule>();
            DontDestroyOnLoad(obj);
        }
    }
}