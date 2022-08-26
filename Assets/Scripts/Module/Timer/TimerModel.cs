using System;
using Agate.MVC.Base;

namespace TankU.Module.Timer
{
    public class TimerModel : BaseModel, ITimerModel
    {
        public TimerModel()
        {
            IsRunning = false;
            IsCountDown = false;
            TimeTotal = 5;
            TimeLeft = TimeTotal;
            CountTotal = 3;
            CountDown = CountTotal;
        }

        public float TimeLeft { get; private set; }
        public float TimeTotal { get; }
        public float CountDown { get; private set; }
        public float CountTotal { get; }
        public bool IsRunning { get; private set; }
        public bool IsFinished { get; private set; }
        public bool IsCountDown { get; private set; }

        public string GetTimeLeftAsString()
        {
            return $"{MathF.Floor(TimeLeft / 60f):00}:{MathF.Floor(TimeLeft % 60f):00}";
        }

        public void OnTimerRunning(float deltaTime)
        {
            if (!IsRunning) return;

            if (IsCountDown) CountDown -= deltaTime;
            else TimeLeft -= deltaTime;

            if (CountDown <= 0) IsCountDown = false;

            if (TimeLeft <= 0) IsFinished = true;

            SetDataAsDirty();
        }

        public void Reset()
        {
            TimeLeft = TimeTotal;
            CountDown = CountTotal;
            SetDataAsDirty();
        }

        public void StartTimer()
        {
            IsCountDown = true;
            IsRunning = true;
            IsCountDown = true;
            IsFinished = false;
            Reset();
            SetDataAsDirty();
        }

        public void ResumeTimer()
        {
            IsRunning = true;
            SetDataAsDirty();
        }

        public void PauseTimer()
        {
            IsRunning = false;
            SetDataAsDirty();
        }
    }
}