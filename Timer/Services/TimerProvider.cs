//using Timer.Classes;

//namespace Timer.Services;

//public class TimerProvider(TimerService timerService)
//{
//    public async Task<List<TimerThing>> GetTimers() 
//    {
//		return await Task.Run(GetTimersSync);
//    }

//	List<TimerThing> GetTimersSync()
//	{
//		return 
//		[
//			timerService.CreateTimer(10, 1),
//			timerService.CreateTimer(64, 1),
//			timerService.CreateTimer(3692, 3)
//		];
//	}
//}
