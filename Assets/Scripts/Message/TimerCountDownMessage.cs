namespace TankU.Message
{
    public struct TimerCountDownMessage
    {
        public TimerEvent TimerEvent { get; }
        public float CountDown { get; }
        public float TimeLeft { get; }

        public TimerCountDownMessage(float countDown, float timeLeft, TimerEvent timerEvent)
        {
            CountDown = countDown;
            TimeLeft = timeLeft;
            TimerEvent = timerEvent;
        }
    }

    public enum TimerEvent
    {
        OnTimerFinish,
        OnCountdownFinish
    }
}