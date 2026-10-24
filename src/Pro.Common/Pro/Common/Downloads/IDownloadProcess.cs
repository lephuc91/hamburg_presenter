using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Common.Downloads;

public interface IDownloadProcess : IDisposable
{
	IObservable<DownloadProgress> WhenDownloadProgressChanged { get; }

	Task<DownloadResult> DownloadAsync(string url, CancellationToken cancellationToken, Func<IEnumerable<KeyValuePair<string, IEnumerable<string>>>, Task<bool>>? isDuplicate = null, string? downloadLocationPath = null);
}
