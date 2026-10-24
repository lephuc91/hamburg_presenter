using System.Collections.Generic;
using Pro.Common.Collections.Concurrency.Locking;

namespace ProPresenter.DO.ChangeDirectory;

public static class ChangeDirectoryPrompt
{
	private static readonly LockingList<ChangeDirectoryListener> _listeners = new LockingList<ChangeDirectoryListener>();

	public static IReadOnlyCollection<ChangeDirectoryListener> Listeners => _listeners;

	public static void RegisterDelegate(ChangeDirectoryListener listener)
	{
		_listeners.Add(listener);
	}

	public static void UnregisterDelegate(ChangeDirectoryListener listener)
	{
		_listeners.Remove(listener);
	}
}
