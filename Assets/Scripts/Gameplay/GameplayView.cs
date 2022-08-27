using Agate.MVC.Base;
using TankU.Module.ColourPicker;
using TankU.Module.Timer;
using TankU.PowerUp;
using TankU.MainMenu;
using UnityEngine;
using TankU.Setting;

namespace TankU.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public TimerView TimerView;
        public ColorPickerView ColorPickerView;
        public PowerUpPoolerView powerUpPooler;
        public SettingView setting;
    }
}