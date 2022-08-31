using Agate.MVC.Base;
using TankU.Message;
using UnityEngine;

namespace TankU.Module.Timer
{
    // TODO @Leguna: Remove debug code
    public class TimerController : ObjectController<TimerController, TimerModel, ITimerModel, TimerView>
    {
        private bool _isAlreadyPublishCountDown;
        private bool _isAlreadyPublishTimerFinished = true;

        public override void SetView(TimerView view)
        {
            view.SetCallback(OnTimerUpdate);
            base.SetView(view);
        }

        // TODO @Mark: Start Game Message, need add start game event message
        public void OnStartGame()
        {
            Debug.Log("Timer Start");
            _model.StartTimer();
            _view.ShowCountDown();
            _isAlreadyPublishTimerFinished = false;
        }

        // TODO @Mark: On Game Resume Message, need on resume event message
        public void OnGameResume()
        {
            Debug.Log("Timer Resume");
            _model.ResumeTimer();
        }

        // TODO @Mark: On Game Pause Message, need on pause event message
        public void OnGamePause()
        {
            Debug.Log("Timer Pause");
            _model.PauseTimer();
        }

        private void OnTimerUpdate()
        {
            _model.OnTimerRunning(Time.deltaTime);
            CheckTimer();
        }

        private void CheckTimer()
        {
            if (_model.CountDown <= 0 && !_isAlreadyPublishCountDown)
            {
                _isAlreadyPublishCountDown = true;
                Debug.Log("Count Down Finish");
                Publish(new TimerCountDownMessage(_model.CountDown, _model.TimeLeft, TimerEventType.OnCountdownFinish));
            }
            else if (_model.IsFinished && !_isAlreadyPublishTimerFinished)
            {
                _isAlreadyPublishTimerFinished = true;
                Debug.Log("Timer Finish");
                Publish(new TimerCountDownMessage(_model.CountDown, _model.TimeLeft, TimerEventType.OnTimerFinish));
            }
        }

        public void HideView()
        {
            _view.gameObject.SetActive(false);
            _isAlreadyPublishCountDown = true;
            _isAlreadyPublishTimerFinished = true;
        }
    }
}