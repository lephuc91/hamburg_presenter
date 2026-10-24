using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Common.Downloads;

public interface IDownloadManager
{
	IObservable<IReadOnlyList<IDownloadItem>> WhenDownloadItemsChanged { get; }

	IDownloadItem GetOrAdd(Predicate<IDownloadItem> isMatch, Func<IDownloadItem> create);

	bool TryGet(Predicate<IDownloadItem> isMatch, out IDownloadItem? item);

	Task RemoveAllAsync(Predicate<IDownloadItem> predicate, bool doCleanup = false);

	bool HasStoppedItems();
}
