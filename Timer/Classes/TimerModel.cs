namespace Timer.Classes;

public class TimerModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int TimeLimitSeconds { get; set; }
    public string Color { get; set; } = string.Empty;
}

public static class TimerExtensions
{
    public static TimerModel TimerToTimerModel(TimerManager timerThing) => 
        new() { Id = timerThing.Id, Name = timerThing.Name, TimeLimitSeconds = timerThing.TimeLimit, Color = timerThing.Color };

    public static string PrintTimers(this IEnumerable<TimerModel> timers)
    {
        List<string> result = [];

        foreach (var timer in timers)
        {
            result.Add("id: " + timer.Id.ToString());
            result.Add("  name: " + timer.Name);
            result.Add("  time limit: " + timer.TimeLimitSeconds.ToString());
            result.Add("  color: " + timer.Color);
        }

        return string.Join('\n', result);
    }
}