using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Timer.Classes;

public class TimerManager(TimerService timerService, int timeLimitSeconds, string id, string name, string color) : IDisposable
{
	private TimerStatus _status;

	public string Id { get; set; } = id;
	public string Name { get; set; } = name;
	public string Color { get; set; } = color;
	public TimerStatus Status { get => _status; set { _status = value; StateChanged?.Invoke(); } }
	public Guid Guid { get; set; } = Guid.NewGuid();
	public int TimeLimit { get; set; } = timeLimitSeconds;
	public int TimeElapsed { get; set; }
	public int TimeRemaining => TimeLimit - TimeElapsed;
	public bool Completed => TimeRemaining < 1;
	public System.Threading.Timer? Timer { get; set; }
	public Action? StateChanged { get; set; }
	public Action? OnCompleted { get; set; }
	public TimerState CurrentState => this.GetTimerState();
	public Guid DriverGuid { get; set; }
	public bool Driver => Guid == DriverGuid;

	public async Task Start(Guid driver)
	{
		await Console.Out.WriteLineAsync(Guid + " Start() from " + driver);

		DriverGuid = driver;

		if (Status == TimerStatus.Running) return;

		if (Status == TimerStatus.Paused)
		{
			await UnPause(driver);

			return;
		}

		Timer?.Dispose();

		Timer = null;

		Timer = new(async (_) => await TimerTick(_), null, 1000, 1000);

		Status = TimerStatus.Running;

		if (Driver) await timerService.SendUpdate(CurrentState);
	}
	public async Task TimerTick(object? _)
	{
		await Console.Out.WriteLineAsync(Guid + " Tick(), Driver: " + Driver);

		if (Driver is false) return;

		TimeElapsed++;

		if (TimeRemaining == 0)
		{
			OnCompleted?.Invoke();
		}

		StateChanged?.Invoke();

		if (Driver) await timerService.SendUpdate(CurrentState);
	}

	public async Task Stop(Guid driver)
	{
		await Console.Out.WriteLineAsync(Guid + " Stop()");

		DriverGuid = driver;

		Dispose();

		Status = TimerStatus.Stopped;

		TimeElapsed = 0;

		if (Driver) await timerService.SendUpdate(CurrentState);
	}

	public async Task Pause(Guid driver)
	{
		await Console.Out.WriteLineAsync(Guid + " Pause()");

		DriverGuid = driver;

		if (Driver && Timer is null)
		{
			await Start(Guid);
		}

		if (Timer is not null && Status != TimerStatus.Paused)
		{
			Timer.Change(Timeout.Infinite, Timeout.Infinite);

			Status = TimerStatus.Paused;

			if (Driver) await timerService.SendUpdate(CurrentState);
		}
	}

	public async Task UnPause(Guid driver)
	{
		await Console.Out.WriteLineAsync(Guid + " UnPause()");

		DriverGuid = driver;

		if (Timer is not null && Status == TimerStatus.Paused)
		{
			Timer.Change(0, 1000);

			Status = TimerStatus.Running;

			if (Driver) await timerService.SendUpdate(CurrentState);
		}
	}

	public async Task Edit(Guid driver)
	{
		await Console.Out.WriteLineAsync(Guid + " Edit()");

		DriverGuid = driver;

		await Stop(driver);

		Status = TimerStatus.Edit;
	}

	public void Dispose()
	{
		Timer?.Dispose();
		Timer = null;
	}
}

public enum TimerStatus
{
	Stopped,
	Running,
	Paused,
	Edit,
	New
}