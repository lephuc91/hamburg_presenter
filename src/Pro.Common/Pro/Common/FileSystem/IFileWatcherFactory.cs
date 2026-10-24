using System.Windows.Threading;

namespace Pro.Common.FileSystem;

public interface IFileWatcherFactory
{
	IFileWatcher Create(string path, Dispatcher? dispatcher = null);

	IFileWatcher Create(string path, string filter, Dispatcher? dispatcher = null);
}
