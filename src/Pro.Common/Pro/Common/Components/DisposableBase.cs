using System;
using System.Threading;
using Pro.Common.Logging;

namespace Pro.Common.Components;

public abstract class DisposableBase : IDisposableObject, IDisposable
{
	private byte _isDisposed;

	public bool IsDisposed => _isDisposed > 0;

	~DisposableBase()
	{
		if (!IsDisposed)
		{
			Log.Warning($"{GetType().FullName} was left to go out of scope");
		}
		Dispose(disposeObjects: false);
	}

	protected virtual void OnDispose(bool disposeObjects)
	{
	}

	public void Dispose()
	{
		Dispose(disposeObjects: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposeObjects)
	{
		if (Interlocked.Exchange(ref _isDisposed, 1) == 0)
		{
			try
			{
				OnDispose(disposeObjects);
			}
			catch (Exception exception)
			{
				Log.Error("Suppressed exception during Dispose() call - run in debug mode to throw the exception.");
				Log.Error(exception);
			}
		}
	}

	protected void EnsureValid()
	{
		if (IsDisposed)
		{
			throw new Exception("Attempt to access a disposed object");
		}
	}
}
