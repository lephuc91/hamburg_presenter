using System;
using System.Threading;
using System.Windows.Threading;

namespace Pro.Common.Utility;

public static class DispatcherExtensions
{
	public static bool IsAssociatedWithCurrentThread(this Dispatcher dispatcher)
	{
		return dispatcher.Thread.ManagedThreadId == Thread.CurrentThread.ManagedThreadId;
	}

	public static void InvokeIfRequired(this Dispatcher dispatcher, Action callback)
	{
		if (dispatcher.IsAssociatedWithCurrentThread())
		{
			callback();
		}
		else
		{
			dispatcher.Invoke(callback);
		}
	}

	public static T InvokeIfRequired<T>(this Dispatcher dispatcher, Func<T> callback)
	{
		if (dispatcher.IsAssociatedWithCurrentThread())
		{
			return callback();
		}
		return dispatcher.Invoke<T>(callback);
	}

	public static void InvokeAsyncIfRequired(this Dispatcher dispatcher, Action callback)
	{
		if (dispatcher.IsAssociatedWithCurrentThread())
		{
			callback();
		}
		else
		{
			dispatcher.InvokeAsync(callback);
		}
	}
}
