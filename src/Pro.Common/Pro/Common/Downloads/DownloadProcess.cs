using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Delay;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using RestSharp;
using RestSharp.Interceptors;

namespace Pro.Common.Downloads;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_progressSubject" })]
public class DownloadProcess : IDownloadProcess, IDisposable
{
	private sealed record HeaderGetResult(IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers, long ContentLength);

	private sealed record SpeedCalculationIntermediate(long ReceivedBytes, long BytesPerSecond);

	private sealed record DownloadProgressEmissionCandidate(DownloadProgress Progress, DateTimeOffset Timestamp, bool ShouldEmit);

	private sealed class HeaderGetInterceptor : Interceptor
	{
		public HeaderGetResult Result { get; private set; } = new HeaderGetResult(Array.Empty<KeyValuePair<string, IEnumerable<string>>>(), 0L);

		public override async ValueTask AfterHttpRequest(HttpResponseMessage responseMessage, CancellationToken cancellationToken)
		{
			await base.AfterHttpRequest(responseMessage, cancellationToken);
			Result = new HeaderGetResult(responseMessage.Headers, (responseMessage.Content?.Headers.ContentLength).GetValueOrDefault());
		}
	}

	private const int MINIMUM_TIME_BETWEEN_DOWNLOAD_PROGRESS_NOTIFICATIONS = 50;

	private const int TIME_BETWEEN_SPEED_UPDATES = 250;

	private readonly BehaviorSubject<DownloadProgress> _progressSubject = new BehaviorSubject<DownloadProgress>(new DownloadProgress(DownloadStatus.Active, 0, 0L, 0L, 0L));

	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IRestClientFactory _restClientFactory;

	private readonly IDelayFactory _delayFactory;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<DownloadProgress> WhenDownloadProgressChanged { get; }

	public DownloadProcess(ILogger logger, IFileSystem fileSystem, IRestClientFactory restClientFactory, IDelayFactory delayFactory, bool enableSpeedReporting)
	{
		_logger = logger;
		_fileSystem = fileSystem;
		_restClientFactory = restClientFactory;
		_delayFactory = delayFactory;
		if (enableSpeedReporting)
		{
			IObservable<Timestamped<DownloadProgress>> source = _progressSubject.Timestamp();
			IObservable<SpeedCalculationIntermediate> second = from timestamped in source.Sample(TimeSpan.FromMilliseconds(250L, 0L)).Scan(new Timestamped<SpeedCalculationIntermediate>(new SpeedCalculationIntermediate(0L, 0L), DateTimeOffset.UtcNow), CalculateSpeed)
				select timestamped.Value;
			IObservable<DownloadProgress> first = from c in source.Scan(new DownloadProgressEmissionCandidate(DownloadProgress.Empty, DateTimeOffset.MinValue, ShouldEmit: false), CalculateProgressEmissionCandidate)
				where c.ShouldEmit
				select c.Progress;
			WhenDownloadProgressChanged = first.CombineLatest(second).Select(GetCombinedProgress).DistinctUntilChanged();
		}
		else
		{
			WhenDownloadProgressChanged = _progressSubject;
		}
	}

	public async Task<DownloadResult> DownloadAsync(string url, CancellationToken cancellationToken, Func<IEnumerable<KeyValuePair<string, IEnumerable<string>>>, Task<bool>>? isDuplicate = null, string? downloadLocationPath = null)
	{
		string destination = (downloadLocationPath.NullableIsNullOrEmpty() ? _fileSystem.Path.Combine(_fileSystem.Path.GetTempPath(), _fileSystem.Path.GetRandomFileName()) : downloadLocationPath);
		using IRestClient client = _restClientFactory.Get();
		HeaderGetInterceptor headerInterceptor = new HeaderGetInterceptor();
		RestRequest request = new RestRequest(url)
		{
			Interceptors = new List<Interceptor>(1) { headerInterceptor }
		};
		using CancellationTokenSource downloadCancellation = new CancellationTokenSource();
		using (cancellationToken.Register(downloadCancellation.Cancel))
		{
			using Stream downloadStream = await client.DownloadStreamAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (downloadStream == null)
			{
				return new DownloadResult(IsSuccessful: false);
			}
			ConfiguredTaskAwaitable<bool> download = DoDownloadAsync(downloadStream, destination, headerInterceptor.Result.ContentLength, downloadCancellation.Token).ConfigureAwait(continueOnCapturedContext: false);
			bool flag = isDuplicate != null;
			if (flag)
			{
				flag = await isDuplicate(headerInterceptor.Result.Headers).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (flag)
			{
				await downloadCancellation.CancelAsync();
				await download;
				DeleteTemporaryFile(destination);
				_progressSubject.OnNext(new DownloadProgress(DownloadStatus.Completed, 100, headerInterceptor.Result.ContentLength, headerInterceptor.Result.ContentLength, 0L));
				return new DownloadResult(IsSuccessful: true, IsDuplicate: true);
			}
			if (await download)
			{
				return new DownloadResult(IsSuccessful: true, IsDuplicate: false, destination);
			}
			DeleteTemporaryFile(destination);
			return new DownloadResult(IsSuccessful: false);
		}
	}

	private async Task<bool> DoDownloadAsync(Stream downloadStream, string destination, long contentLength, CancellationToken cancellationToken)
	{
		byte[] buffer = new byte[4096];
		long totalRead = 0L;
		try
		{
			using FileSystemStream fileStream = _fileSystem.File.OpenWrite(destination);
			int num;
			while ((num = await CopyBytesAsyncWithStalledObserving(buffer, downloadStream, fileStream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)) > 0)
			{
				totalRead += num;
				_progressSubject.OnNext(new DownloadProgress(DownloadStatus.Active, (int)((double)totalRead * 100.0 / (double)contentLength), totalRead, contentLength, 0L));
			}
		}
		catch (Exception ex) when (ex is OperationCanceledException || ex is IOException)
		{
			_progressSubject.OnNext(new DownloadProgress(DownloadStatus.Stopped, (int)((double)totalRead * 100.0 / (double)contentLength), totalRead, contentLength, 0L));
			return false;
		}
		_progressSubject.OnNext(new DownloadProgress(DownloadStatus.Completed, 100, contentLength, contentLength, 0L));
		return true;
	}

	private void DeleteTemporaryFile(string destination)
	{
		if (_fileSystem.File.Exists(destination))
		{
			_fileSystem.File.Delete(destination);
		}
	}

	private async Task<int> CopyBytesAsyncWithStalledObserving(byte[] buffer, Stream? source, Stream destination, CancellationToken cancellationToken)
	{
		CancellationTokenSource starvationCancellation = new CancellationTokenSource();
		int result;
		try
		{
			using (cancellationToken.Register(starvationCancellation.Cancel))
			{
				Task<int> copyTask = CopyBytesAsync(buffer, source, destination, starvationCancellation.Token);
				Task starvedTask = _delayFactory.Delay(TimeSpan.FromSeconds(30L), starvationCancellation.Token);
				if (await Task.WhenAny(copyTask, starvedTask).ConfigureAwait(continueOnCapturedContext: false) == starvedTask)
				{
					if (!cancellationToken.IsCancellationRequested)
					{
						_logger.Warning("[{0}] Download failed because of starvation", "DownloadProcess");
					}
					throw new OperationCanceledException();
				}
				result = await copyTask.ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		finally
		{
			await starvationCancellation.CancelAsync();
			starvationCancellation.Dispose();
		}
		return result;
	}

	private static async Task<int> CopyBytesAsync(byte[] buffer, Stream? source, Stream destination, CancellationToken cancellationToken)
	{
		if (source == null)
		{
			return -1;
		}
		int bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return bytesRead;
	}

	private Timestamped<SpeedCalculationIntermediate> CalculateSpeed(Timestamped<SpeedCalculationIntermediate> oldProgress, Timestamped<DownloadProgress> newProgress)
	{
		long num = newProgress.Value.ReceivedBytes - oldProgress.Value.ReceivedBytes;
		TimeSpan timeSpan = newProgress.Timestamp - oldProgress.Timestamp;
		if (num <= 0)
		{
			return oldProgress;
		}
		double num2 = (double)num / timeSpan.TotalSeconds;
		long bytesPerSecond = oldProgress.Value.BytesPerSecond;
		long num3 = ((timeSpan.TotalSeconds >= 3.0) ? ((long)num2) : ((long)((num2 * timeSpan.TotalSeconds + (double)bytesPerSecond * (3.0 - timeSpan.TotalSeconds)) / 3.0)));
		if (Math.Abs(num3 - bytesPerSecond) < bytesPerSecond / 50)
		{
			num3 = bytesPerSecond;
		}
		return new Timestamped<SpeedCalculationIntermediate>(new SpeedCalculationIntermediate(newProgress.Value.ReceivedBytes, num3), newProgress.Timestamp);
	}

	private DownloadProgressEmissionCandidate CalculateProgressEmissionCandidate(DownloadProgressEmissionCandidate oldCandidate, Timestamped<DownloadProgress> newValue)
	{
		TimeSpan timeSpan = newValue.Timestamp - oldCandidate.Timestamp;
		if (oldCandidate.Progress.Status == newValue.Value.Status && timeSpan.TotalMilliseconds < 50.0)
		{
			return oldCandidate with
			{
				ShouldEmit = false
			};
		}
		return new DownloadProgressEmissionCandidate(newValue.Value, newValue.Timestamp, ShouldEmit: true);
	}

	private DownloadProgress GetCombinedProgress((DownloadProgress rawProgress, SpeedCalculationIntermediate speedCalculation) tuple)
	{
		return tuple.rawProgress with
		{
			BytesPerSecond = tuple.speedCalculation.BytesPerSecond
		};
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
			_progressSubject.Dispose();
		}
	}
}
