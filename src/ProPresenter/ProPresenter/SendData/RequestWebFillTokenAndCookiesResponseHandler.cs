using System;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Web.Cookies;
using ProPresenter.Controller;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class RequestWebFillTokenAndCookiesResponseHandler : ISendDataResponseHandler
{
	private readonly ICoreManager _coreManager;

	private readonly IApp _app;

	private readonly ICookieManagerService _cookieManagerService;

	public RequestWebFillTokenAndCookiesResponseHandler(ICoreManager coreManager, IApp app, ICookieManagerService cookieManagerService)
	{
		_coreManager = coreManager;
		_app = app;
		_cookieManagerService = cookieManagerService;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.RequestWebfillTokenAndCookies;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		if (sendDataResponse.MessageTypeCase == SendDataResponse.MessageTypeOneofCase.RequestWebfillTokenAndCookies)
		{
			WebFillTokenAndCookies tokenAndCookies = new WebFillTokenAndCookies();
			if (sendDataResponse.RequestWebfillTokenAndCookies.Link.Contains(".planningcenteronline.com"))
			{
				await HandlePCO(sendDataResponse, tokenAndCookies);
			}
			else
			{
				HandleWebFill(sendDataResponse, tokenAndCookies);
			}
			if (_coreManager.SendWebFillTokenAndCookies(sendDataResponse.MessageId, tokenAndCookies) != 0)
			{
				Log.Error($"SendPCOToken was not successful for MessageId:{sendDataResponse.MessageId}");
			}
		}
	}

	private void HandleWebFill(SendDataResponse sendDataResponse, WebFillTokenAndCookies tokenAndCookies)
	{
		if (Uri.TryCreate(sendDataResponse.RequestWebfillTokenAndCookies.Link, UriKind.Absolute, out Uri result))
		{
			CookieModel cookie = _cookieManagerService.GetCookie(result.Host);
			tokenAndCookies.Cookies.Add(CreateProtoCookie(cookie));
		}
	}

	private async Task HandlePCO(SendDataResponse sendDataResponse, WebFillTokenAndCookies tokenAndCookies)
	{
		if (sendDataResponse.RequestWebfillTokenAndCookies.RefreshFirst)
		{
			await _coreManager.PCOConsumer.RefreshOAuthTokenAsync();
		}
		if (_coreManager.PCOConsumer.IsAuthorized)
		{
			CookieModel cookie = _cookieManagerService.GetCookie(".planningcenteronline.com", "planning_center_session");
			tokenAndCookies.Token = _app.PCOAccessToken;
			tokenAndCookies.Cookies.Add(CreateProtoCookie(cookie));
		}
	}

	private WebFillTokenAndCookies.Types.Cookie CreateProtoCookie(CookieModel? cookie)
	{
		return new WebFillTokenAndCookies.Types.Cookie
		{
			Domain = (cookie?.Domain ?? string.Empty),
			Name = (cookie?.Name ?? string.Empty),
			Value = (cookie?.Value ?? string.Empty),
			Expiry = (ulong)(cookie?.Expiration.ToUnixTimestamp() ?? 0)
		};
	}
}
