using Agate.MVC.Base;
using Leguna.ExampleMVC.Module.ClickGame;
using Leguna.ExampleMVC.Module.SoundFx;
using UnityEngine;

namespace Leguna.ExampleMVC.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] public ClickGameView ClickGameView;
        [SerializeField] public SoundFxView SoundFxView;
    }
}