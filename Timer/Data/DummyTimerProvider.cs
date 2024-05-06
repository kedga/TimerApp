using Timer.Classes;

namespace Timer.Data;

public class DummyTimerProvider : ITimerDataProvider
{
	public List<TimerModel> Timers { get; set; } =
			[
				new()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Dummy timer 1",
					TimeLimitSeconds = 5
				},
				new()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Dummy timer 2",
					TimeLimitSeconds = 123
				},
				new()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Dummy timer 3",
					TimeLimitSeconds = 5098
				},
			];

	public async Task<List<TimerModel>> GetTimerModels()
	{
		return await Task.Run(() => Timers);
	}

	public async Task SaveTimers(IEnumerable<TimerModel> timers)
	{
		await Task.Run(() =>
		{
			Timers = timers.ToList();

            Console.WriteLine("Timers saved: \n" + timers.PrintTimers());
        });
	}
}
