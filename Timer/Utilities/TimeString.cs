namespace Timer.Utilities;

public static class TimeString
{
	public static string GetTimeString(this TimeSpan timeSpan, bool compact = false, bool hideZeros = false)
	{
		var hours = Math.Abs(timeSpan.Hours) + Math.Abs(timeSpan.Days) * 24;
		var minutes = Math.Abs(timeSpan.Minutes);
		var seconds = Math.Abs(timeSpan.Seconds);

		var hourString = compact ? "h" : " hour" + (hours != 1 ? "s" : "");
		var minutesString = compact ? "m" : " minute" + (minutes != 1 ? "s" : "");
		var secondString = compact ? "s" : " second" + (seconds != 1 ? "s" : "");

		var result = new List<string>();

		if (hours > 0)
		{
			result.Add(hours + hourString);
			if (minutes != 0 || !hideZeros) result.Add(minutes + minutesString);
			if (seconds != 0 || !hideZeros) result.Add(seconds + secondString);
		}
		else if (minutes > 0)
		{
			result.Add(minutes + minutesString);
			if (seconds != 0 || !hideZeros) result.Add(seconds + secondString);
		}
		else result.Add(seconds + secondString);

		return string.Join(" ", result);
	}

	public static string GetTimeString(this int seconds, bool compact = false, bool hideZeros = false)
	{
		return TimeSpan.FromSeconds(seconds).GetTimeString(compact, hideZeros);
	}
}
