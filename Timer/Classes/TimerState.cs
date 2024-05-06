namespace Timer.Classes;

public class TimerState
{
    public string Id { get; set; } = string.Empty;
    public Guid Guid { get; set; }
    public TimerStatus Status { get; set; }
    public int TimeLimitSeconds { get; set; }
    public int TimeElapsed { get; set; }
    public string Name { get; set; } = string.Empty;
}

public static class TimerStateExtensions
{
    public static TimerState GetTimerState(this TimerManager timer) =>
        new()
        {
            Id = timer.Id,
            Guid = timer.Guid,
            Status = timer.Status,
            TimeLimitSeconds = timer.TimeLimit,
            TimeElapsed = timer.TimeElapsed,
            Name = timer.Name,
        };

    public static void SetTimerState(this TimerManager timer, TimerState timerState)
    {
        //timer.Id = timerState.Id;
        timer.Status = timerState.Status;
        timer.TimeLimit = timerState.TimeLimitSeconds;
        timer.TimeElapsed = timerState.TimeElapsed;
    }
}