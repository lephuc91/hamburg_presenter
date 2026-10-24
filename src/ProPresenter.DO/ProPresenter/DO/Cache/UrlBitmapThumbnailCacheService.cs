using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;

namespace ProPresenter.DO.Cache;

[Pro.Common.SourceGenerator.Attributes.AsyncDisposable("_asyncExecutor", "OnDisposeAsync", new string[] { "_fileSystemCache" })]
public class UrlBitmapThumbnailCacheService : IUriCacheService<NullableBitmapSource>, IAsyncDisposable, IDisposable
{
	private const int MAXIMUM_PARALLEL_DOWNLOADS = 10;

	private static readonly TimeSpan CACHE_EVICTION_TIMEOUT = TimeSpan.FromDays(30);

	private const string CACHE_BASE_SUB_DIRECTORY = "OnlineImageCache";

	private readonly IUriCacheService<byte[]> _fileSystemCache;

	private readonly ILogger _logger;

	private readonly IBitmapImageDecoder _decoder;

	private readonly IAsyncExecutor _asyncExecutor;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UrlBitmapThumbnailCacheService(IFileSystemUriCacheServiceFactory fileSystemCacheFactory, ILogger logger, IBitmapImageDecoder decoder, IAsyncExecutor asyncExecutor)
	{
		_fileSystemCache = fileSystemCacheFactory.Create(10, CACHE_EVICTION_TIMEOUT, Path.Combine(CommonPaths.ThumbnailCache, "OnlineImageCache"));
		_logger = logger;
		_decoder = decoder;
		_asyncExecutor = asyncExecutor;
	}

	public void Prefetch(Uri uri)
	{
		_fileSystemCache.Prefetch(uri);
	}

	public Task<NullableBitmapSource> GetAsync(Uri uri)
	{
		return Task.Run(async delegate
		{
			byte[] bytes = await _fileSystemCache.GetAsync(uri);
			return Convert(bytes);
		});
	}

	private static ValueTask OnDisposeAsync()
	{
		return default(ValueTask);
	}

	private NullableBitmapSource Convert(byte[] bytes)
	{
		try
		{
			return new NullableBitmapSource(_decoder.DecodeImage(bytes));
		}
		catch (Exception ex)
		{
			_logger.Error("[{0}] Failed to decode image:{1}\n{2}", "UrlBitmapThumbnailCacheService", string.Join(" ", bytes.Select((byte b) => b.ToString("X"))), ex);
			return NullableBitmapSource.Default;
		}
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
			await _fileSystemCache.DisposeAsync();
		}
	}
}
