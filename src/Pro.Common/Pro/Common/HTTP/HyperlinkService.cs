using System;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Utility;

namespace Pro.Common.HTTP;

public class HyperlinkService : IHyperlinkService
{
	private readonly ILogger _logger;

	private readonly IFlagService _flagService;

	private readonly IInternetAccess _internetAccess;

	public HyperlinkService(ILogger logger, IFlagService flagService, IInternetAccess internetAccess)
	{
		_logger = logger;
		_flagService = flagService;
		_internetAccess = internetAccess;
	}

	public void Open(Uri link)
	{
		if (_internetAccess.CheckIfInternetAvailableThenShowPrompt())
		{
			OpenPrivate(link);
		}
	}

	public void OpenLocal(Uri link)
	{
		OpenPrivate(link);
	}

	private void OpenPrivate(Uri link)
	{
		if (_flagService.IsFlagEnabled(Flag.LogExternalBrowserUrls))
		{
			_logger.Info("[{0}] opening: {1}", "HyperlinkService", link);
		}
		ProcessHelper.StartProcess(link.ToString());
	}
}
