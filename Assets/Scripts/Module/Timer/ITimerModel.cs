using Agate.MVC.Base;

namespace TankU.Module.Timer
{
    public interface ITimerModel : IBaseModel
    {
        float TimeLeft { get; }
        float TimeTotal { get; }
        float CountDown { get; }
        float CountTotal { get; }
        bool IsRunning { get; }
        bool IsFinished { get; }
        bool IsCountDown { get; }
        string GetTimeLeftAsString();
        void StartTimer();
        void ResumeTimer();
        void PauseTimer();
        void Reset();
    }
}