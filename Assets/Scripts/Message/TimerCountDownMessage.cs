namespace TankU.Message
{
    public struct TimerCountDownMessage
    {
        public TimerEventType TimerEventTypeType { get; }
        public float CountDown { get; }
        public float TimeLeft { get; }

        public TimerCountDownMessage(float countDown, float timeLeft, TimerEventType timerEventTypeType)
        {
            CountDown = countDown;
            TimeLeft = timeLeft;
            TimerEventTypeType = timerEventTypeType;
        }
    }

    public enum TimerEventType
    {
        OnTimerFinish,
        OnCountdownFinish
    }
}