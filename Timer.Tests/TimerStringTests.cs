namespace Timer.Tests;
using Timer.Utilities;
public class TimeStringTests
{
	[Theory]
	[InlineData(0, false, false, "0 seconds")]
	[InlineData(1, false, false, "1 second")]
	[InlineData(60, false, false, "1 minute 0 seconds")]
	[InlineData(3600, false, false, "1 hour 0 minutes 0 seconds")]
	[InlineData(3600, false, true, "1 hour")]
	[InlineData(3661, false, false, "1 hour 1 minute 1 second")]
	[InlineData(3601, false, true, "1 hour 1 second")]
	[InlineData(3661, true, false, "1h 1m 1s")]
	[InlineData(2797200, true, true, "777h")]
	public void GetTimeString_FromInt_ShouldReturnCorrectFormat(int seconds, bool compact, bool hideZeros, string expected)
	{
		// Act
		var result = seconds.GetTimeString(compact, hideZeros);

		// Assert
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(0, false, false, "0 seconds")]
	[InlineData(1, false, false, "1 second")]
	[InlineData(60, false, false, "1 minute 0 seconds")]
	[InlineData(3600, false, false, "1 hour 0 minutes 0 seconds")]
	[InlineData(3661, false, false, "1 hour 1 minute 1 second")]
	[InlineData(3661, true, false, "1h 1m 1s")]
	[InlineData(-3661, false, false, "1 hour 1 minute 1 second")] // Negative input
	public void GetTimeString_FromTimeSpan_ShouldReturnCorrectFormat(int totalSeconds, bool compact, bool hideZeros, string expected)
	{
		// Arrange
		var timeSpan = TimeSpan.FromSeconds(totalSeconds);

		// Act
		var result = timeSpan.GetTimeString(compact, hideZeros);

		// Assert
		Assert.Equal(expected, result);
	}
}
