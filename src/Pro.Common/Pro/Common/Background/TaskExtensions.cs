using System;
using System.Threading.Tasks;
using Pro.Common.Logging;

namespace Pro.Common.Background;

public static class TaskExtensions
{
	public static void ExecuteAsync(this Task task, Action<Exception>? errorHandler = null)
	{
		if (task != null)
		{
			ForgetAwaited(task, errorHandler);
		}
	}

	public static void ExecuteAsync(this ValueTask task, Action<Exception>? errorHandler = null)
	{
		ForgetAwaited(task.AsTask(), errorHandler);
	}

	private static async Task ForgetAwaited(Task task, Action<Exception>? errorHandler)
	{
		try
		{
			await task;
		}
		catch (Exception ex)
		{
			Log.Error($"Error occured when executing task with error - {ex}");
			errorHandler?.Invoke(ex);
		}
	}
}
