using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Setting
{
    public class SettingConnector : BaseConnector
    {
        private SettingController _settingController;

        protected override void Connect()
        {
            Subscribe<ShowSettingMessage>(_settingController.ShowSettingPanel);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ShowSettingMessage>(_settingController.ShowSettingPanel);
        }
    }
}
