using System;
using System.CodeDom.Compiler;
using System.IO;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO.Storage;

namespace ProPresenter.Controller.Monitors;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_watcher" })]
public class FileMonitor : MonitorBase, IDisposable
{
	private readonly FileWatcher _watcher;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public override MonitorType MonitorType => MonitorType.FileFeed;

	public RelativePath Filepath { get; }

	public FileMonitor(IUiDispatcher dispatcher, RelativePath path)
	{
		string directoryName = Path.GetDirectoryName(path);
		directoryName.ThrowWhenNull("directory");
		_watcher = new FileWatcher(directoryName, path.Filename, dispatcher.Dispatcher);
		Filepath = path;
		_watcher.Changed += delegate
		{
			OnResourceChanged();
		};
		_watcher.EnableRaisingEvents = true;
	}

	public override void StopMonitoring()
	{
		_watcher.EnableRaisingEvents = false;
		_watcher.Dispose();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_watcher.Dispose();
		}
	}
}
