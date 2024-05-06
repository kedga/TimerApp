using Microsoft.AspNetCore.SignalR;
using Timer.Classes;

namespace Timer.Hubs;

public class TimerHub : Hub
{
	public Task SendStateUpdate(TimerState timerState)
	{
		return Clients.All.SendAsync("ReceiveUpdate", timerState);
	}

	public Task SendRefresh()
	{
		return Clients.All.SendAsync("ReceiveRefresh");
	}
}