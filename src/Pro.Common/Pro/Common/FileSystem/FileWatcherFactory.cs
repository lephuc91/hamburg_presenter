using System.Windows.Threading;

namespace Pro.Common.FileSystem;

public class FileWatcherFactory : IFileWatcherFactory
{
	public IFileWatcher Create(string path, Dispatcher? dispatcher = null)
	{
		return new FileWatcher(path, null, dispatcher);
	}

	public IFileWatcher Create(string path, string filter, Dispatcher? dispatcher = null)
	{
		return new FileWatcher(path, filter, dispatcher);
	}
}
