using Agate.MVC.Base;
using TankU.Module.Bullet;
using TankU.Module.ColourPicker;
using TankU.Module.Timer;

namespace TankU.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public TimerView TimerView;
        public ColorPickerView ColorPickerView;
        public BulletView BulletView;
    }
}