using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Concurrency;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using RestSharp;

namespace ProPresenter.DO.Cache;

[Pro.Common.SourceGenerator.Attributes.AsyncDisposable("_asyncExecutor", "OnDisposeAsync", new string[] { "_cancellationTokenSource" })]
public class FileSystemUriCacheService : IUriCacheService<byte[]>, IAsyncDisposable, IDisposable
{
	private struct Result<T> where T : class
	{
		public T? Value { get; }

		[MemberNotNullWhen(true, "Value")]
		public bool IsSuccess
		{
			[MemberNotNullWhen(true, "Value")]
			get;
		}

		public Result(T value)
		{
			Value = value;
			IsSuccess = true;
		}

		public Result()
		{
			Value = null;
			IsSuccess = false;
		}
	}

	private const int MAX_DOWNLOAD_ATTEMPTS = 3;

	private readonly IRestClientFactory _restClientFactory;

	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly ICurrentTime _currentTime;

	private readonly TimeSpan _cacheEvictionTimeout;

	private readonly string _cacheFolder;

	private readonly ISemaphore _concurrentDownloadSemaphore;

	private readonly Channel<Uri> _prefetchQueue;

	private readonly Task _prefetchTask;

	private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

	private readonly ConcurrentDictionary<Uri, Task<byte[]>> _activeFileRequests = new ConcurrentDictionary<Uri, Task<byte[]>>();

	private readonly ISemaphore _fileSystemAccessSemaphore;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public FileSystemUriCacheService(IRestClientFactory restClientFactory, ILogger logger, ISemaphoreFactory semaphoreFactory, IFileSystem fileSystem, IAsyncExecutor asyncExecutor, ICurrentTime currentTime, int maximumParalellDownloads, TimeSpan cacheEvictionTimeout, string cacheFolder)
	{
		_restClientFactory = restClientFactory;
		_logger = logger;
		_fileSystem = fileSystem;
		_asyncExecutor = asyncExecutor;
		_currentTime = currentTime;
		_cacheEvictionTimeout = cacheEvictionTimeout;
		_cacheFolder = cacheFolder;
		_concurrentDownloadSemaphore = semaphoreFactory.Create(maximumParalellDownloads);
		_fileSystemAccessSemaphore = semaphoreFactory.Create(1);
		_prefetchQueue = Channel.CreateUnbounded<Uri>();
		_prefetchTask = DoPrefetch();
	}

	public void Prefetch(Uri uri)
	{
		_prefetchQueue.Writer.TryWrite(uri);
	}

	public Task<byte[]> GetAsync(Uri uri)
	{
		if (_cancellationTokenSource.IsCancellationRequested)
		{
			return Task.FromResult(Array.Empty<byte>());
		}
		return _activeFileRequests.GetOrAdd(uri, async delegate(Uri key)
		{
			string filePath = GetFullPath(key);
			try
			{
				using (await _fileSystemAccessSemaphore.AquireAsync(_cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false))
				{
					if (_fileSystem.File.Exists(filePath))
					{
						return await _fileSystem.File.ReadAllBytesAsync(filePath, _cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				await RemoveOverflowingCacheItems();
				Result<byte[]> result = await FetchOnlineAsync(key).ConfigureAwait(continueOnCapturedContext: false);
				if (!result.IsSuccess)
				{
					return Array.Empty<byte>();
				}
				using (await _fileSystemAccessSemaphore.AquireAsync(_cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false))
				{
					_fileSystem.Directory.CreateDirectory(_cacheFolder);
					await _fileSystem.File.WriteAllBytesAsync(filePath, result.Value).ConfigureAwait(continueOnCapturedContext: false);
				}
				return result.Value;
			}
			catch (Exception ex)
			{
				_logger.Error("[{0}]Failed to get data for {1} - {2}", "FileSystemUriCacheService", key, ex);
				return Array.Empty<byte>();
			}
			finally
			{
				_activeFileRequests.TryRemove(key, out Task<byte[]> _);
			}
		});
	}

	private async Task DoPrefetch()
	{
		_ = 1;
		try
		{
			while (await _prefetchQueue.Reader.WaitToReadAsync(_cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false))
			{
				Uri item;
				while (!_cancellationTokenSource.IsCancellationRequested && _prefetchQueue.Reader.TryRead(out item))
				{
					await GetAsync(item).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}
		catch (OperationCanceledException)
		{
		}
	}

	private async Task RemoveOverflowingCacheItems()
	{
		try
		{
			IEnumerable<string> enumerable = from f in _fileSystem.Directory.GetFiles(_cacheFolder)
				where _fileSystem.File.GetLastAccessTimeUtc(f) < _currentTime.UtcNow - _cacheEvictionTimeout
				select f;
			foreach (string file in enumerable)
			{
				using (await _fileSystemAccessSemaphore.AquireAsync(_cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false))
				{
					try
					{
						_fileSystem.File.Delete(file);
					}
					catch (Exception ex)
					{
						_logger.Error("[{0}]Failed to delete cache file {1} - {2}", "FileSystemUriCacheService", file, ex.Message);
					}
				}
			}
		}
		catch (DirectoryNotFoundException)
		{
		}
	}

	private async Task<Result<byte[]>> FetchOnlineAsync(Uri uri)
	{
		for (int downloadAttemptIndex = 0; downloadAttemptIndex < 3; downloadAttemptIndex++)
		{
			if (_cancellationTokenSource.IsCancellationRequested)
			{
				return new Result<byte[]>();
			}
			using (await _concurrentDownloadSemaphore.AquireAsync(_cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false))
			{
				RestResponse restResponse = await _restClientFactory.Get(delegate(RestClientOptions options)
				{
					options.BaseUrl = uri;
				}).ExecuteAsync(new RestRequest(), _cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false);
				if (restResponse.IsSuccessful && restResponse.RawBytes != null)
				{
					return new Result<byte[]>(restResponse.RawBytes);
				}
				_logger.Error("[{0}]Failed to load image from {1} - StatusCode: {2}", GetType().Name, uri, restResponse.StatusCode);
			}
		}
		return new Result<byte[]>();
	}

	private async ValueTask OnDisposeAsync()
	{
		_prefetchQueue.Writer.Complete();
		await _cancellationTokenSource.CancelAsync().ConfigureAwait(continueOnCapturedContext: false);
		await _prefetchTask;
	}

	private static string GetFileName(Uri key)
	{
		using SHA1 sHA = SHA1.Create();
		return string.Join("", from x in sHA.ComputeHash(Encoding.UTF8.GetBytes(key.ToString()))
			select x.ToString("X2"));
	}

	private string GetFullPath(Uri key)
	{
		return _fileSystem.Path.GetFullPath(_fileSystem.Path.Combine(_cacheFolder, GetFileName(key)));
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
	protected virtual async ValueTask DisposeAsync(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			await OnDisposeAsync();
			_cancellationTokenSource.Dispose();
		}
	}
}
