using Agate.MVC.Base;
using TankU.Module.BulletSpawner;
using TankU.Module.ColourPicker;
using TankU.Module.Timer;
using TankU.PowerUp;

namespace TankU.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public TimerView TimerView;
        public ColorPickerView ColorPickerView;
        public BulletSpawnerView bulletSpawnerView;
        public PlayerView PlayerView;
        public PowerUpPoolerView powerUpPooler;
    }
}