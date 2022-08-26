using Agate.MVC.Base;
using TankU.Module.Bullet;
using TankU.Module.ColourPicker;
using TankU.Module.Timer;
using TankU.PowerUp;
using TankU.Gameplay;
using UnityEngine;

namespace TankU.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public TimerView TimerView;
        public ColorPickerView ColorPickerView;
        // TODO @Leguna: Remove This after implement bullet pool
        public BulletView BulletView;
        public PowerUpPoolerView powerUpPooler;
    }
}