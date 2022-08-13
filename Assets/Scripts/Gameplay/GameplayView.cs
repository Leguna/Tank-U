using Agate.MVC.Base;
using SpacePlan.Module.ClickGame;
using SpacePlan.Module.SoundFx;
using UnityEngine;

namespace SpacePlan.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] public ClickGameView ClickGameView;
        [SerializeField] public SoundFxView SoundFxView;
    }
}