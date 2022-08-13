using Agate.MVC.Base;
using Leguna.ExampleMVC.Boot;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Leguna.ExampleMVC.Main
{
    public class MainView : BaseSceneView
    {
        [SerializeField] private Button _playButton;

        public void SetCallbacks(UnityAction onClickPlayButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);
        }

    }
}