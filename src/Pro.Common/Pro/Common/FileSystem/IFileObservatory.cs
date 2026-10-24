namespace Pro.Common.FileSystem;

public interface IFileObservatory
{
	WatcherReference? StartWatching(string file);
}
