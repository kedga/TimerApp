using Timer.Classes;

namespace Timer.Data;

public interface ITimerDataProvider
{
	Task<List<TimerModel>> GetTimerModels();
	Task SaveTimers(IEnumerable<TimerModel> timers);
}
