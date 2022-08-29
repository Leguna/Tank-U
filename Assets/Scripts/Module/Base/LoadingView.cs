using Agate.MVC.Base;
using TMPro;
using UnityEngine;

namespace TankU.Module.Base
{
    public class LoadingView : BaseView
    {
        [SerializeField] private TMP_Text _loadingText;
        private float _timer = 0.2f;
        private int _resetTime;

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (!(_timer <= 0)) return;
            _resetTime++;
            _timer = 0.4f;
            _loadingText.text += ".";

            if (_resetTime <= 3) return;
            _loadingText.text = "Loading";
            _resetTime = 0;
        }
    }
}