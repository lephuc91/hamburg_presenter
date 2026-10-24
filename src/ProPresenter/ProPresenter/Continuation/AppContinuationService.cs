using System.Collections.Concurrent;
using System.Diagnostics;
using Pro.Common.Logging;

namespace ProPresenter.Continuation;

public sealed class AppContinuationService : IAppContinuationService
{
	private readonly ConcurrentBag<string> _continuations = new ConcurrentBag<string>();

	public void Add(string continuationProcess)
	{
		Log.Info("Registering \"" + continuationProcess + "\" to be run just before the app terminates");
		_continuations.Add(continuationProcess);
	}

	public void Run()
	{
		try
		{
			foreach (string continuation in _continuations)
			{
				try
				{
					Process.Start(new ProcessStartInfo(continuation)
					{
						UseShellExecute = true
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}
}
