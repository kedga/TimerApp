using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Timer.Classes;
using Timer.Data;

namespace Timer.Services;

public class TimerService(NavigationManager navigationManager, ITimerDataProvider timerDataProvider) : IAsyncDisposable
{
	public Guid InstanceId { get; set; } = Guid.NewGuid();

	public Action? StateChanged;

	public List<TimerManager> Timers { get; set; } = [];

	private HubConnection? _hubConnection;

	public async Task Initialize()
	{
		await Console.Out.WriteLineAsync("TIMER SERVICE INITIALIZED! INSTANCE ID: " + InstanceId);

		//Timers = (await timerDataProvider.GetTimerModels())
		//	.Select(TimerModelToTimer)
		//	.ToList();

		Timers = await GetTimers();

		_hubConnection = new HubConnectionBuilder()
			.WithUrl(navigationManager.ToAbsoluteUri("/timerhub"))
			.WithAutomaticReconnect()
			.Build();

		_hubConnection.On<TimerState>("ReceiveUpdate", HandleUpdate);

		_hubConnection.On("ReceiveRefresh", HandleRefresh);

		await _hubConnection.StartAsync();
	}

	public async Task<List<TimerManager>> GetTimers()
	{
		var timers = (await timerDataProvider.GetTimerModels())
			.Select(TimerModelToTimer)
			.ToList();

        foreach (var timer in timers)
        {
            await Console.Out.WriteLineAsync("timer color: " + timer.Color);

            if (string.IsNullOrWhiteSpace(timer.Color) || true)
			{
				timer.Color = CssClasses.GetRandomColorName();
			}
        }

		return timers;
    }

	public TimerManager TimerModelToTimer(TimerModel timerModel)
	{
		return new TimerManager(this, timerModel.TimeLimitSeconds,
			  timerModel.Id, timerModel.Name, timerModel.Color);
	}

	public async Task AddTimer()
	{
		var timer = TimerModelToTimer(new()
		{
			Id = Guid.NewGuid().ToString(),
			Name = "New timer",
			TimeLimitSeconds = 60,
			Color = CssClasses.GetRandomColorName()
		});

		timer.Status = TimerStatus.Edit;

		Timers = [.. Timers, timer];

		await SaveTimers();
	}

	public async Task DeleteTimer(string timerId)
	{
		Timers = [.. Timers.Where(t => t.Id != timerId)];

		await SaveTimers();
	}

	public async Task SaveTimers()
	{
		var timerModels = Timers.Select(TimerExtensions.TimerToTimerModel);

		await timerDataProvider.SaveTimers(timerModels);

		await SendRefresh();
	}

	public async Task SendUpdate(TimerState timerState)
	{
		if (_hubConnection is null) return;

		await _hubConnection.SendAsync("SendStateUpdate", timerState);
	}

	public async Task SendRefresh()
	{
		if (_hubConnection is null) return;

		await _hubConnection.SendAsync("SendRefresh");
	}

	public async Task HandleRefresh()
	{
		var freshTimers = await GetTimers();

		foreach (var timer in Timers)
		{
			if (!freshTimers.Any(t => t.Id == timer.Id))
			{
				Timers = [.. Timers.Where(t => t.Id != timer.Id)];
			}
		}

		foreach (var timer in freshTimers)
		{
			if (!Timers.Any(t => t.Id == timer.Id))
			{
				Timers = [.. Timers, timer];
			}
		}

		StateChanged?.Invoke();
	}

	public async Task HandleUpdate(TimerState newState)
	{
		var timer = Timers.FirstOrDefault(t => t.Id == newState.Id)
			?? throw new Exception("Timer not found");

		if (timer.Guid == newState.Guid) return;

		switch (newState.Status)
		{
			case TimerStatus.Stopped:
				await timer.Stop(newState.Guid);
				break;
			case TimerStatus.Running:
				await timer.Start(newState.Guid);
				break;
			case TimerStatus.Paused:
				await timer.Pause(newState.Guid);
				break;
			default:
				break;
		}

		timer.TimeLimit = newState.TimeLimitSeconds;

		timer.TimeElapsed = newState.TimeElapsed;

		timer.Name = newState.Name;

		Console.WriteLine($"Update received from {newState.Guid} to {timer.Guid}: {newState.Status}");

		timer.StateChanged?.Invoke();
	}

	public async ValueTask DisposeAsync()
	{
		foreach (var timer in Timers)
		{
			timer.Dispose();
		}

		if (_hubConnection is not null) await _hubConnection.DisposeAsync();
	}
}