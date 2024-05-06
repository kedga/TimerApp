using System.Text.Json;
using Timer.Classes;

namespace Timer.Data;

public class JsonTimerProvider(IConfiguration configuration) : ITimerDataProvider
{
	string _jsonFilePath = configuration["TimerSettings:JsonFilePath"]
		?? throw new Exception("File path not found for TimerSettings:JsonFilePath");

	JsonSerializerOptions _jsonOptions = new()
	{
		WriteIndented = true
	};

	public async Task<List<TimerModel>> GetTimerModels()
	{
		if (!File.Exists(_jsonFilePath))
		{
			using (File.Create(_jsonFilePath)) { }
		}

		string jsonContent = await File.ReadAllTextAsync(_jsonFilePath);

		if (jsonContent.Length < 1)
		{
			return [];
		}

		var timers = JsonSerializer.Deserialize<List<TimerModel>>(jsonContent)
			?? throw new Exception($"Unable to deserialize timers from {_jsonFilePath}");

		return timers;
	}

	public async Task SaveTimers(IEnumerable<TimerModel> timers)
	{
		using FileStream fs = File.Create(_jsonFilePath);

		await JsonSerializer.SerializeAsync(fs, timers, _jsonOptions);
	}
}
