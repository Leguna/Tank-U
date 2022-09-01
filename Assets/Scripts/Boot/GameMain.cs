using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TankU.Module.Base;
using TankU.Module.LevelUp;
using TankU.Setting;
using TankU.Sound;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace TankU.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        private LevelUpController _levelUpController;
        private MatchHistoryController _matchHistoryController;

        protected override IController[] GetDependencies()
        {
            return new IController[]
            {
                new SettingController(),
                new SoundController(),
                new MatchHistoryController(),
                new LevelUpController()
            };
        }

        protected override IConnector[] GetConnectors()
        {
            return new IConnector[]
            {
                new SettingConnector(),
                new SoundConnector(),
                new MatchHistoryConnector()
            };
        }

        protected override IEnumerator StartInit()
        {
            CreateEventSystem();

            yield return null;
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