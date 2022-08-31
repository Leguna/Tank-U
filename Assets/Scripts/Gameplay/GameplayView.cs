using Agate.MVC.Base;
using TankU.Module.Bomb;
using TankU.Module.BulletSpawner;
using TankU.Module.ColourPicker;
using TankU.Module.HUD;
using TankU.Module.Result;
using TankU.Module.Timer;
using TankU.PowerUp;
using TankU.Setting;

namespace TankU.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public TimerView TimerView;
        public ColorPickerView ColorPickerView;
        public BulletSpawnerView bulletSpawnerView;
        public BombPoolView bombPoolView;
        public PlayerSpawnerView PlayerSpawnerView;
        public PowerUpPoolerView powerUpSpawner;
        public HUDView HUDView;
        public SettingView setting;
        public ResultView resultView;
    }
}