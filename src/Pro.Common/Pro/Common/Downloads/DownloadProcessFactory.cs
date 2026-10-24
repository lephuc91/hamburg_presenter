using System.IO.Abstractions;
using Pro.Common.Delay;
using Pro.Common.HTTP;
using Pro.Common.Logging;

namespace Pro.Common.Downloads;

public class DownloadProcessFactory : IDownloadProcessFactory
{
	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IRestClientFactory _restClientFactory;

	private readonly IDelayFactory _delayFactory;

	public DownloadProcessFactory(ILogger logger, IFileSystem fileSystem, IRestClientFactory restClientFactory, IDelayFactory delayFactory)
	{
		_logger = logger;
		_fileSystem = fileSystem;
		_restClientFactory = restClientFactory;
		_delayFactory = delayFactory;
	}

	public IDownloadProcess Create(bool enableSpeedReporting = true)
	{
		return new DownloadProcess(_logger, _fileSystem, _restClientFactory, _delayFactory, enableSpeedReporting);
	}
}
