using System;
using System.IO.Abstractions;
using Pro.Common.Background;
using Pro.Common.Concurrency;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Time;

namespace ProPresenter.DO.Cache;

public class FileSystemUriCacheServiceFactory : IFileSystemUriCacheServiceFactory
{
	private readonly IRestClientFactory _restClientFactory;

	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly ISemaphoreFactory _semaphoreFactory;

	private readonly ICurrentTime _currentTime;

	public FileSystemUriCacheServiceFactory(IRestClientFactory restClientFactory, ILogger logger, IFileSystem fileSystem, IAsyncExecutor asyncExecutor, ISemaphoreFactory semaphoreFactory, ICurrentTime currentTime)
	{
		_restClientFactory = restClientFactory;
		_logger = logger;
		_fileSystem = fileSystem;
		_asyncExecutor = asyncExecutor;
		_semaphoreFactory = semaphoreFactory;
		_currentTime = currentTime;
	}

	public IUriCacheService<byte[]> Create(int maximumParalellDownloads, TimeSpan cacheEvictionTimeout, string cacheFolder)
	{
		return new FileSystemUriCacheService(_restClientFactory, _logger, _semaphoreFactory, _fileSystem, _asyncExecutor, _currentTime, maximumParalellDownloads, cacheEvictionTimeout, cacheFolder);
	}
}
