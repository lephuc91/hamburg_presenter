using System;
using System.Threading.Tasks;
using Pro.Common.HTTP;
using Pro.Common.Internet;
using Pro.Web.Services;
using ProPresenter.DO.ProContent.Consumer;

namespace ProPresenter.DO.ProContent;

public class ProContentUserInteractionBehavior : IProContentUserInteractionBehavior
{
	private readonly IProContentConsumer _consumer;

	private readonly IInternetAccessCheck _internetAccessCheck;

	private readonly IProContentDownloadFailedDialogService _dialogService;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	private readonly IHyperlinkService _hyperlinkService;

	public ProContentUserInteractionBehavior(IProContentConsumer consumer, IInternetAccessCheck internetAccessCheck, IProContentDownloadFailedDialogService dialogService, IRegistrationWebResourceService registrationWebResourceService, IHyperlinkService hyperlinkService)
	{
		_consumer = consumer;
		_internetAccessCheck = internetAccessCheck;
		_dialogService = dialogService;
		_registrationWebResourceService = registrationWebResourceService;
		_hyperlinkService = hyperlinkService;
	}

	public async Task ExecuteDownloadAsync<T>(Func<T, IProContentDownloadInfo?> getDownloadInfo, Func<IProContentDownloadInfo, Task> performDownload, T toDownload)
	{
		IProContentDownloadInfo proContentDownloadInfo = getDownloadInfo(toDownload);
		if (proContentDownloadInfo != null)
		{
			await ExecuteDownloadAsync(performDownload, proContentDownloadInfo);
		}
	}

	public async Task ExecuteDownloadAsync<T>(Func<T, Task> performDownload, T toDownload)
	{
		if (!_internetAccessCheck.Available())
		{
			_dialogService.ShowInternetUnavailable();
		}
		else if (!_consumer.IsAuthorized)
		{
			_dialogService.ShowNotSignedIn();
		}
		else
		{
			await performDownload(toDownload);
		}
	}

	public Task LoginLogoutAsync()
	{
		_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetSignIn()));
		return Task.CompletedTask;
	}
}
