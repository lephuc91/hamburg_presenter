using System;
using System.IO;
using Pro.Common.Components;

namespace Pro.Common.FileSystem;

public interface IFileWatcher : IDisposableObject, IDisposable
{
	bool EnableRaisingEvents { get; set; }

	string Filter { get; set; }

	bool IncludeSubdirectories { get; set; }

	int InternalBufferSize { get; set; }

	NotifyFilters NotifyFilter { get; set; }

	string TargetPath { get; set; }

	event FileSystemEventHandler Changed;

	event FileSystemEventHandler Created;

	event FileSystemEventHandler Deleted;

	event RenamedEventHandler Renamed;
}
