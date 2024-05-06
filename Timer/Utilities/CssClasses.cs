using Timer.Classes;
using Timer.Components.Components.TimerStates;

namespace Timer.Utilities;

public static class CssClasses
{

	//public static string GetColorClass(TimerThing timer, bool hover = false, bool lighter = false)
	//{
	//	if (timer.Status == TimerStatus.Running)
	//	{
	//		var bgColor = timer.Completed ? "bg-completed-600" : "bg-running-500";
	//		var bgColorHover = timer.Completed ? "bg-completed-700" : "bg-running-600";
	//		return hover ? bgColorHover : bgColor;
	//	}

	//	if (timer.Status == TimerStatus.Edit)
	//	{
	//		return lighter ? "bg-edit-400" : "bg-edit-500";
	//	}

	//	if (timer.Status == TimerStatus.Stopped)
	//	{
	//		return lighter ? "bg-neutral-300" : "bg-neutral-400";
	//	}

	//	return "";
	//}

	public static string GetBaseColorClass(TimerManager timer)
	{
		if (timer.Status == TimerStatus.Running)
		{
			return timer.Completed ? "bg-completed-600" : "bg-running-500";
		}

		if (timer.Status == TimerStatus.Edit)
		{
			return "bg-edit-500";
		}

		if (timer.Status == TimerStatus.Stopped)
		{
			return GetBaseClass(timer.Color);
		}

		return "";
	}

	public static string GetHoverColorClass(TimerManager timer)
	{
		if (timer.Status == TimerStatus.Running)
		{
			return timer.Completed ? "hover:bg-completed-700" : "hover:bg-running-600";
		}

		if (timer.Status == TimerStatus.Edit)
		{
			return "hover:bg-edit-400";
		}

		if (timer.Status == TimerStatus.Stopped)
		{
			return GetHoverClass(timer.Color);
		}

		return "";
	}

	public static string GetContainerHoverColorClass(TimerManager timer)
	{
		if (timer.Status == TimerStatus.Running)
		{
			return timer.Completed ? "bg-completed-700" : "bg-running-600";
		}

		if (timer.Status == TimerStatus.Edit)
		{
			return "bg-edit-500";
		}

		if (timer.Status == TimerStatus.Stopped)
		{
			return GetBaseClass(timer.Color);
		}

		return "";
	}

	public static string GetLighterColorClass(TimerManager timer)
	{
		if (timer.Status == TimerStatus.Running)
		{
			return timer.Completed ? "bg-completed-700" : "bg-running-600";
		}

		if (timer.Status == TimerStatus.Edit)
		{
			return "bg-edit-400";
		}

		if (timer.Status == TimerStatus.Stopped)
		{
			return GetLighterClass(timer.Color);
		}

		return "";
	}

	static readonly List<Color> _colors =
	[
		//new Color { Name = "teal", BaseClass = "bg-teal-500", LighterClass = "bg-teal-400", HoverClass = "hover:bg-teal-400" },
		new Color { Name = "cyan", BaseClass = "bg-cyan-500", LighterClass = "bg-cyan-400", HoverClass = "hover:bg-cyan-400" },
		//new Color { Name = "sky", BaseClass = "bg-sky-500", LighterClass = "bg-sky-400", HoverClass = "hover:bg-sky-400" },
		//new Color { Name = "blue", BaseClass = "bg-blue-500", LighterClass = "bg-blue-400", HoverClass = "hover:bg-blue-400" },
		//new Color { Name = "indigo", BaseClass = "bg-indigo-500", LighterClass = "bg-indigo-400", HoverClass = "hover:bg-indigo-400" },
		//new Color { Name = "violet", BaseClass = "bg-violet-500", LighterClass = "bg-violet-400", HoverClass = "hover:bg-violet-400" },
		//new Color { Name = "purple", BaseClass = "bg-purple-500", LighterClass = "bg-purple-400", HoverClass = "hover:bg-purple-400" },
		//new Color { Name = "fuchsia", BaseClass = "bg-fuchsia-500", LighterClass = "bg-fuchsia-400", HoverClass = "hover:bg-fuchsia-400" },
		//new Color { Name = "pink", BaseClass = "bg-pink-500", LighterClass = "bg-pink-400", HoverClass = "hover:bg-pink-400" },
		//new Color { Name = "rose", BaseClass = "bg-rose-500", LighterClass = "bg-rose-400", HoverClass = "hover:bg-rose-400" },
		//new Color { Name = "red", BaseClass = "bg-red-500", LighterClass = "bg-red-400", HoverClass = "hover:bg-red-400" },
		//new Color { Name = "orange", BaseClass = "bg-orange-500", LighterClass = "bg-orange-400", HoverClass = "hover:bg-orange-400" },
		//new Color { Name = "amber", BaseClass = "bg-amber-500", LighterClass = "bg-amber-400", HoverClass = "hover:bg-amber-400" },
		//new Color { Name = "yellow", BaseClass = "bg-yellow-500", LighterClass = "bg-yellow-400", HoverClass = "hover:bg-yellow-400" },
		//new Color { Name = "lime", BaseClass = "bg-lime-500", LighterClass = "bg-lime-400", HoverClass = "hover:bg-lime-400" },
		//new Color { Name = "green", BaseClass = "bg-green-500", LighterClass = "bg-green-400", HoverClass = "hover:bg-green-400" },
		//new Color { Name = "emerald", BaseClass = "bg-emerald-500", LighterClass = "bg-emerald-400", HoverClass = "hover:bg-emerald-400" },
	];

	static string GetBaseClass(string name) => _colors.FirstOrDefault(c => c.Name == name)?.BaseClass ?? "bg-white";
	static string GetLighterClass(string name) => _colors.FirstOrDefault(c => c.Name == name)?.LighterClass ?? "bg-white";
	static string GetHoverClass(string name) => _colors.FirstOrDefault(c => c.Name == name)?.HoverClass ?? "bg-white";

	public static string GetRandomColorName()
	{
		Random random = new();
		int randomIndex = random.Next(0, _colors.Count);
		return _colors[randomIndex].Name;
	}
}

public class Color
{
	public string Name { get; set; } = string.Empty;
	public string BaseClass { get; set; } = string.Empty;
	public string LighterClass { get; set; } = string.Empty;
	public string HoverClass { get; set; } = string.Empty;
}