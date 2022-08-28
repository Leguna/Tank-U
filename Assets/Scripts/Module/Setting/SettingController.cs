using System.Collections;
using Agate.MVC.Base;
using TankU.Message;
using TankU.Sound;

namespace TankU.Setting
{
    public class SettingController : ObjectController<SettingController, SettingModel, ISettingModel, SettingView>
    {
        public void Init(SettingModel model)
        {
            _model = model;
            //SetView(view);
        }

        public override IEnumerator Initialize()
        {
            return base.Initialize();
        }

        public void ShowSettingPanel(ShowSettingMessage msg)
        {
            _view.Show();
        }

        public void OnTurnSFX()
        {
            _model.SetSfxToggle();
            //TODO:
            //Publish message to audio, send data bool
            Publish(new SoundSettingsUpdateMessage(false));
        }

        public void OnTurnBGM()
        {
            _model.SetBgmToggle();
            //TODO:
            Publish(new SoundSettingsUpdateMessage(true));
        }

        public void BackToMainMenu()
        {
            _view.Close();
        }

        public override void SetView(SettingView view)
        {
            base.SetView(view);
            _view.SetCallback(OnTurnSFX, OnTurnBGM, BackToMainMenu);
        }
    }
}