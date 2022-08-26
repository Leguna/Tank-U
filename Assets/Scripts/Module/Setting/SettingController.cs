using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TankU.Message;

namespace TankU.Setting
{
    public class SettingController : ObjectController<SettingController, SettingModel, ISettingModel, SettingView>
    {
        public void ShowSettingPanel(ShowSettingMessage msg)
        {
            _view.Show();
        }

        public void OnTurnAudio()
        {
            _model.SetAudioToggle();
            //TODO:
            //Publish message to audio, send data bool
        }

        public void BackToMainMenu()
        {
            _view.Close();
        }

        public override void SetView(SettingView view)
        {
            base.SetView(view);
            _view.SetCallback(OnTurnAudio, BackToMainMenu);
        }
    }
}
