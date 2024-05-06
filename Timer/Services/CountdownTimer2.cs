using System.Diagnostics;

namespace Timer.Services;

public class CountdownTimer2
{
    public bool TimerElapsed => _remainingTime <= 0;

    private int _remainingTime;
    public int TotalDuration { get; set; }
    private int _duration;
    private readonly Action<TimerEventArgs>? _onTick;
    private readonly Action? _onCompleted;
    private System.Threading.Timer? _timer;
    private int _secondsSinceElapsed;

    public CountdownTimer2(Action<TimerEventArgs> onTick, Action? onCompleted)
    {
        _onCompleted = onCompleted;
        _onTick = onTick;
    }

    public void Start(int duration)
    {
        Stop();
        _duration = duration;
        _remainingTime = duration;
        _secondsSinceElapsed = 0;
        _timer = new(TimerTick, null, 0, 1000);
    }

    public void Stop()
    {
        _timer?.Dispose();
        _timer = null;
    }

    private void TimerTick(object? state)
    {
        _onTick?.Invoke(new(_remainingTime,_duration,_secondsSinceElapsed, TimerElapsed));

        if (_remainingTime == 0) _onCompleted?.Invoke();

        _remainingTime--;

        if (_remainingTime < 0) _secondsSinceElapsed++;
    }

    public void JumpToEnd()
    {
        Start(_duration - _remainingTime);
        _remainingTime = -1;
    }
}

public class TimerEventArgs
{
    public int SecondsRemaining { get; }
    public int Duration { get; }
    public int SecondsSinceElapsed { get; set; }
    public bool TimerElapsed { get; set; }

    public TimerEventArgs(int secondsRemaining, int duration, int secondsSinceElapsed, bool timerElapsed)
    {
        SecondsRemaining = secondsRemaining;
        Duration = duration;
        SecondsSinceElapsed = secondsSinceElapsed;
        TimerElapsed = timerElapsed;
    }
}