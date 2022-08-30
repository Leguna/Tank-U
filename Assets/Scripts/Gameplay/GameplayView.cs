using Agate.MVC.Base;
using TankU.Module.BulletSpawner;
using TankU.Module.Bomb;
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
        public BulletSpawnerView bulletSpawnerView;
        public BombPoolView bombPoolView;
        public PlayerSpawnerView PlayerSpawnerView;
        public PowerUpPoolerView powerUpPooler;
        public HUDView HUDView;
        public SettingView setting;
    }
}