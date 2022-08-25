using System;
using Agate.MVC.Base;
using TMPro;
using UnityEngine;

namespace TankU.Module.Timer
{
    public class TimerView : ObjectView<ITimerModel>
    {
        private Action _onTimerUpdateEvent;
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private TMP_Text _countDownText;

        public void SetCallback(Action onTimerUpdateEvent)
        {
            _onTimerUpdateEvent = onTimerUpdateEvent;
        }

        public void Update()
        {
            _onTimerUpdateEvent?.Invoke();
        }

        protected override void InitRenderModel(ITimerModel model)
        {
            _timerText.text = model.GetTimeLeftAsString();
            _countDownText.text = $"{model.CountDown:0}";
        }

        protected override void UpdateRenderModel(ITimerModel model)
        {
            if (model.IsCountDown) ShowCountDown();
            else if (model.IsRunning)
            {
                _timerText.gameObject.SetActive(true);
                _countDownText.gameObject.SetActive(false);
            }

            if (model.IsFinished)
            {
                _timerText.gameObject.SetActive(false);
                _countDownText.gameObject.SetActive(false);
            }

            _timerText.text = model.GetTimeLeftAsString();
            _countDownText.text = model.CountDown < 1 ? "START!" : $"{model.CountDown:0}";
        }

        public void ShowCountDown()
        {
            _timerText.gameObject.SetActive(false);
            _countDownText.gameObject.SetActive(true);
        }
    }
}