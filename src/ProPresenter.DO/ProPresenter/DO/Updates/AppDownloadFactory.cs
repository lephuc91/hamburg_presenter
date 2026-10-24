using Pro.Common.Downloads;
using Pro.Common.Logging;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.DO.Updates;

public class AppDownloadFactory : IAppDownloadFactory
{
	private readonly IDownloadProcessFactory _downloadProcessFactory;

	private readonly IAppInstallerFactory _appInstallerFactory;

	private readonly ILogger _logger;

	public AppDownloadFactory(IDownloadProcessFactory downloadProcessFactory, IAppInstallerFactory appInstallerFactory, ILogger logger)
	{
		_downloadProcessFactory = downloadProcessFactory;
		_appInstallerFactory = appInstallerFactory;
		_logger = logger;
	}

	public IAppDownload Create(BuildInformation downloadVersion)
	{
		return new AppDownload(downloadVersion, _downloadProcessFactory, _appInstallerFactory, _logger);
	}
}
