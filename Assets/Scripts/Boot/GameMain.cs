using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Module.SaveGame;
using TankU.Module.Base;
using TankU.Setting;
using TankU.Sound;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace TankU.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        private SettingController _settingController;
        private MatchHistoryController _matchHistoryController;

        protected override IController[] GetDependencies()
        {
            return new IController[]
            {
                new SaveDataController(),
                new SettingController(),
                new SoundController(),
                new MatchHistoryController()
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

        public void SpawnSetting()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/UIMenu/SettingView");
            SettingView settingView =
                Instantiate(prefab, Vector3.zero, Quaternion.identity, transform).GetComponent<SettingView>();

            SettingModel settingModel = new SettingModel();
            _settingController.Init(settingModel, settingView);
        }
    }
}