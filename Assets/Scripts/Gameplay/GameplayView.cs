using Agate.MVC.Base;
using SpacePlan.Module.ClickGame;
using SpacePlan.Module.SoundFx;
using TankU.PowerUp;
using UnityEngine;

namespace SpacePlan.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] public PowerUpPoolerView powerUpPooler;
    }
}