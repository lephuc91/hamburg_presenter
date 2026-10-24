using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Downloads;

[Pro.Common.SourceGenerator.Attributes.AsyncDisposable("_asyncExecutor", "OnDisposeAsync", new string[] { "_downloadQueuesSubject", "_downloadItems" })]
public sealed class DownloadManager : IDownloadManager, IDisposable, IAsyncDisposable
{
	private readonly LockingList<IDownloadItem> _downloadItems = new LockingList<IDownloadItem>();

	private readonly BehaviorSubject<IReadOnlyList<IDownloadItem>> _downloadQueuesSubject = new BehaviorSubject<IReadOnlyList<IDownloadItem>>(Array.Empty<IDownloadItem>());

	private readonly IAsyncExecutor _asyncExecutor;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<IReadOnlyList<IDownloadItem>> WhenDownloadItemsChanged => _downloadQueuesSubject;

	public DownloadManager(IAsyncExecutor asyncExecutor)
	{
		_asyncExecutor = asyncExecutor;
	}

	public IDownloadItem GetOrAdd(Predicate<IDownloadItem> isMatch, Func<IDownloadItem> create)
	{
		if (!_downloadItems.TryGetOrAdd(isMatch, create, out IDownloadItem resolvedItem))
		{
			_downloadQueuesSubject.OnNext(_downloadItems);
			resolvedItem.Download();
		}
		return resolvedItem;
	}

	public bool TryGet(Predicate<IDownloadItem> isMatch, out IDownloadItem? item)
	{
		return _downloadItems.TryGet(isMatch, out item);
	}

	public async Task RemoveAllAsync(Predicate<IDownloadItem> predicate, bool doCleanup = false)
	{
		List<Task> list = (from i in _downloadItems.RemoveAll(predicate)
			select CancelAsync(i, doCleanup)).ToList();
		if (list.Count > 0)
		{
			_downloadQueuesSubject.OnNext(_downloadItems);
			await Task.WhenAll(list);
		}
	}

	private async ValueTask OnDisposeAsync()
	{
		await RemoveAllAsync((IDownloadItem _) => true);
	}

	private static async Task CancelAsync(IDownloadItem downloadItem, bool doCleanup = false)
	{
		downloadItem.Cancel();
		await downloadItem.CompleteAndCleanupAsync(doCleanup);
		downloadItem.Dispose();
	}

	public bool HasStoppedItems()
	{
		return _downloadItems.Any((IDownloadItem i) => i.Status == DownloadStatus.Stopped);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		_asyncExecutor.ExecuteAsyncValueTask(DisposeAsync);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public async ValueTask DisposeAsync()
	{
		await DisposeAsync(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private async ValueTask DisposeAsync(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			await OnDisposeAsync();
			_downloadQueuesSubject.Dispose();
			_downloadItems.Dispose();
		}
	}
}
