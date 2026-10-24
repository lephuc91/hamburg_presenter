using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Downloads;
using Pro.Common.SourceGenerator.Attributes;

namespace ProPresenter.DO.Downloads;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_downloadLocationSubject", "_downloadProgressSubject", "_downloadSemaphore" })]
public abstract class DownloadItemBase : IDownloadItem, IDisposable
{
	private readonly object _cancellationTokenAccessLock = new object();

	private CancellationTokenSource? _cancellationToken;

	private readonly IDownloadProcessFactory _processFactory;

	private readonly IFileService _fileService;

	private readonly IFileSystem _fileSystem;

	private readonly BehaviorSubject<DownloadProgress> _downloadProgressSubject = new BehaviorSubject<DownloadProgress>(new DownloadProgress(DownloadStatus.Active, 0, 0L, 0L, 0L));

	private readonly SemaphoreSlim _downloadSemaphore = new SemaphoreSlim(1);

	private Task _downloadTask = Task.CompletedTask;

	private readonly ReplaySubject<string> _downloadLocationSubject = new ReplaySubject<string>(1);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public abstract IObservable<string> WhenNameChanged { get; }

	public abstract IObservable<Uri> WhenThumbnailUrlChanged { get; }

	protected virtual Func<IEnumerable<KeyValuePair<string, IEnumerable<string>>>, Task<bool>>? IsDuplicate { get; }

	public IObservable<DownloadProgress> WhenDownloadProgressChanged => _downloadProgressSubject;

	public DownloadStatus Status => _downloadProgressSubject.Value.Status;

	protected abstract string DownloadUrl { get; }

	public IObservable<string> WhenFileDestinationChanged => _downloadLocationSubject;

	protected DownloadItemBase(IDownloadProcessFactory processFactory, IFileService fileService, IFileSystem fileSystem)
	{
		_processFactory = processFactory;
		_fileService = fileService;
		_fileSystem = fileSystem;
	}

	public void Cancel()
	{
		lock (_cancellationTokenAccessLock)
		{
			_cancellationToken?.Cancel();
		}
	}

	public async Task CompleteAndCleanupAsync(bool requestCleanup)
	{
		await _downloadSemaphore.WaitAsync();
		await _downloadTask;
		_downloadSemaphore.Release();
		if (requestCleanup && _downloadProgressSubject.Value.Status == DownloadStatus.Stopped)
		{
			_downloadProgressSubject.OnNext(new DownloadProgress(DownloadStatus.Cleanup, 0, 0L, 0L, 0L));
		}
		_downloadProgressSubject.OnCompleted();
	}

	public void Download()
	{
		TryDownloadLocked(DoDownloadAsyncUnsafe);
	}

	public virtual bool CanRetry()
	{
		return false;
	}

	public virtual void Retry()
	{
	}

	protected void TryDownloadLocked(Func<CancellationToken, Task> lockedAsyncOperation)
	{
		if (_downloadSemaphore.Wait(0))
		{
			_downloadTask = DoDownloadAsyncAndUnlockWhenComplete(lockedAsyncOperation);
		}
	}

	private async Task DoDownloadAsyncAndUnlockWhenComplete(Func<CancellationToken, Task> lockedAsyncOperation)
	{
		CancellationTokenSource token = new CancellationTokenSource();
		lock (_cancellationTokenAccessLock)
		{
			_cancellationToken = token;
		}
		try
		{
			await lockedAsyncOperation(token.Token);
		}
		finally
		{
			lock (_cancellationTokenAccessLock)
			{
				_cancellationToken = null;
			}
			_downloadSemaphore.Release();
			token.Dispose();
		}
	}

	protected async Task DoDownloadAsyncUnsafe(CancellationToken token)
	{
		DownloadResult result = await RunDownloadProcessAndObserveProgress(token);
		if (result?.IsSuccessful ?? false)
		{
			string importDestination = GetImportDestination();
			if (result.IsDuplicate)
			{
				NotifySuccess(importDestination);
				return;
			}
			bool copySucceeded = await _fileService.CopyFileAsync(result.Destination, importDestination);
			await DeleteTempFile(result.Destination);
			if (copySucceeded)
			{
				NotifySuccess(importDestination);
				return;
			}
		}
		_downloadProgressSubject.OnNext(_downloadProgressSubject.Value with
		{
			Status = DownloadStatus.Stopped
		});
	}

	private void NotifySuccess(string importDestination)
	{
		_downloadProgressSubject.OnNext(_downloadProgressSubject.Value with
		{
			Status = DownloadStatus.Completed,
			PercentComplete = 100
		});
		_downloadLocationSubject.OnNext(importDestination);
	}

	private async Task<DownloadResult> RunDownloadProcessAndObserveProgress(CancellationToken token)
	{
		IDownloadProcess downloadProcess = _processFactory.Create();
		using (downloadProcess.WhenDownloadProgressChanged.Subscribe(delegate(DownloadProgress value)
		{
			_downloadProgressSubject.OnNext(ConvertCompletionToActive(value));
		}, _downloadProgressSubject.OnError))
		{
			return await downloadProcess.DownloadAsync(DownloadUrl, token, IsDuplicate);
		}
	}

	protected abstract string GetImportDestination();

	private async Task DeleteTempFile(string file)
	{
		await Task.Run(delegate
		{
			try
			{
				_fileSystem.File.Delete(file);
			}
			catch
			{
			}
		});
	}

	private DownloadProgress ConvertCompletionToActive(DownloadProgress value)
	{
		if (value.Status == DownloadStatus.Completed)
		{
			return value with
			{
				Status = DownloadStatus.Active
			};
		}
		return value;
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
			_downloadLocationSubject.Dispose();
			_downloadProgressSubject.Dispose();
			_downloadSemaphore.Dispose();
		}
	}
}
