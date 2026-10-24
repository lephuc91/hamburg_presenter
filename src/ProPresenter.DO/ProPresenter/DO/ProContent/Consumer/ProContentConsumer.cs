using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Flurl;
using Pro.Common.AuthenticatingApiConsumer;
using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.OAuth.Authenticator;
using Pro.Web.Services;
using ProPresenter.DO.CloudOnboarding.Model;
using ProPresenter.DO.ProContent.Consumer.Model.Content;
using ProPresenter.DO.ProContent.Consumer.Model.Download;
using ProPresenter.DO.ProContent.Consumer.Model.Result;
using ProPresenter.DO.Settings;
using RestSharp;

namespace ProPresenter.DO.ProContent.Consumer;

public class ProContentConsumer : ObservableObject, IProContentConsumer, INotifyPropertyChanged
{
	private const string PRO_CONTENT_HOME_PAGE_TEXT = "procontent.renewedvision.com";

	private const string PRO_CONTENT_HOME_PAGE_TEXT_STAGING = "procontent-staging.renewedvision.com";

	private const string PRO_CONTENT_API_URI_BASE = "/pro/procontent";

	private const string API_DEFAULT_UNAUTHORIZED_REDIRECT_PATH = "/unauthorized";

	private static readonly Uri PRO_CONTENT_BASE_URL = new Uri("https://procontent.renewedvision.com");

	private static readonly Uri PRO_CONTENT_BASE_URL_STAGING = new Uri("https://procontent-staging.renewedvision.com");

	private const string AUTHORIZE_PATH = "/oauth/authorize";

	private const string GET_TOKEN_PATH = "/oauth/token";

	private const string GET_GROUPS_ENDPOINT = "/api/v1/propresenter/media_bin/content_groups";

	private const string GET_GROUP_ENDPOINT = "/api/v1/propresenter/media_bin/content_group";

	private const string GET_SEARCH_RESULT_ENDPOINT = "/api/v1/propresenter/media_bin/search?term=";

	private const string GET_DOWNLOAD_ENDPOINT = "/api/v1/download";

	private const string GET_THUMBNAIL_ENDPOINT = "/api/v1/thumbnail";

	private const string CLOUD_PLAN_ENDPOINT = "/v1/pro/cloud-plan";

	private const string UNAUTHORIZED_HEADER_NAME = "X-Unauthorized-Redirect";

	private const string AUTHORIZE_CALLBACK_URI = "https://renewedvision.com/oauth2/callback";

	private const int DEFAULT_REQUEST_TIMEOUT_SECONDS = 15;

	private readonly IOAuth2AuthorizationStore _authorizationStorage;

	private readonly IAuthenticatingApiConsumer _consumer;

	private readonly ILogger _logger;

	private readonly IApp _app;

	private readonly Uri _baseUrl;

	[ObservableProperty]
	private bool _isAuthorized;

	public string ProContentApiBaseUrl { get; }

	public string ProContentHomePageText { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsAuthorized
	{
		get
		{
			return _isAuthorized;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isAuthorized, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsAuthorized);
				_isAuthorized = value;
				OnIsAuthorizedChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsAuthorized);
			}
		}
	}

	public ProContentConsumer(IAuthenticatingApiConsumerFactory consumerFactory, IApp app, ILogger logger, IApiService apiService, IFlagService flagService, IOAuth2AuthorizationStore authorizationStorage, IOAuth2ClientInfoProvider clientInfoProvider)
	{
		_logger = logger;
		_app = app;
		ProContentApiBaseUrl = apiService.GetTargetRedirectHost(includeProtocol: true) + "/pro/procontent";
		ProContentHomePageText = (flagService.IsFlagEnabled(Flag.StagingApiEndpoints) ? "procontent-staging.renewedvision.com" : "procontent.renewedvision.com");
		_baseUrl = (flagService.IsFlagEnabled(Flag.StagingApiEndpoints) ? PRO_CONTENT_BASE_URL_STAGING : PRO_CONTENT_BASE_URL);
		_authorizationStorage = authorizationStorage;
		_authorizationStorage.IsAuthorized.Subscribe(delegate(bool authorized)
		{
			IsAuthorized = authorized;
		});
		_consumer = consumerFactory.CreateOAuth2ConsumerWithPkceFlow(_authorizationStorage, clientInfoProvider, _baseUrl, _baseUrl, "/oauth/authorize", "/oauth/token", "https://renewedvision.com/oauth2/callback");
	}

	public Task<IRequestResult> GetRootGroupsAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		RestRequest request = new RestRequest("/api/v1/propresenter/media_bin/content_groups");
		return ExecuteGetWithErrorHandlingAsync<Groups>(request, cancellationToken);
	}

	public Task<IRequestResult> GetSearchResultAsync(string searchTerm, CancellationToken cancellationToken = default(CancellationToken))
	{
		RestRequest request = new RestRequest(GetSearchEndpoint(searchTerm));
		return ExecuteGetWithErrorHandlingAsync<Group>(request, cancellationToken);
	}

	public Task<IRequestResult> GetGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken))
	{
		RestRequest request = new RestRequest(GetGroupEndpoint(groupId));
		return ExecuteGetWithErrorHandlingAsync<Group>(request, cancellationToken);
	}

	public Task<IRequestResult> GetDownloadDataAsync(string assetFormatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		RestRequest request = new RestRequest(GetDownloadEndpoint(assetFormatId));
		return ExecuteGetWithErrorHandlingAsync<DownloadAssets>(request, cancellationToken);
	}

	public async Task<PricingOptionsResponse?> GetPricingOptionsAsync(long workspaceSizeBytes, string locale, CancellationToken ct = default(CancellationToken))
	{
		RestRequest request = new RestRequest("/v1/pro/cloud-plan")
		{
			Timeout = TimeSpan.FromSeconds(15L)
		};
		request.AddQueryParameter("workspace_size", workspaceSizeBytes);
		request.AddQueryParameter("locale", locale);
		if (!(await ExecuteGetWithErrorHandlingAsync<PricingOptionsResponse>(request, ct).ConfigureAwait(continueOnCapturedContext: false) is SuccessResult<PricingOptionsResponse> { Data: var data }))
		{
			return null;
		}
		return (data != null && data.Result?.Success == true) ? data : null;
	}

	public Uri GetAssetThumbnailUrl(string assetFormatId)
	{
		return _baseUrl.AppendPathSegments("/api/v1/thumbnail", assetFormatId).ToUri();
	}

	private static string GetSearchEndpoint(string searchTerm)
	{
		return "/api/v1/propresenter/media_bin/search?term=" + searchTerm;
	}

	private static string GetGroupEndpoint(string groupId)
	{
		return "/api/v1/propresenter/media_bin/content_group/" + groupId;
	}

	private static string GetDownloadEndpoint(string downloadId)
	{
		return "/api/v1/download/" + downloadId;
	}

	private async Task<IRequestResult> ExecuteGetWithErrorHandlingAsync<T>(RestRequest request, CancellationToken cancellationToken = default(CancellationToken)) where T : notnull
	{
		try
		{
			RestResponse<T> restResponse = await _consumer.ExecuteAsync<T>(request, Method.Get, cancellationToken);
			if (restResponse.IsSuccessful)
			{
				return new SuccessResult<T>(restResponse.Data);
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return new CancelledResult();
			}
			_logger.Warning("[{0}] Failed to get resource {1}. Returned status code: {2}, error: {3}\nreturned data: {4}", "ProContentConsumer", request.Resource, restResponse.StatusCode, restResponse.ErrorException, restResponse.Content);
			HttpStatusCode statusCode = restResponse.StatusCode;
			if ((uint)(statusCode - 401) <= 2u)
			{
				if (!Uri.TryCreate(restResponse.Headers?.FirstOrDefault((HeaderParameter h) => "X-Unauthorized-Redirect".Equals(h.Name, StringComparison.InvariantCultureIgnoreCase))?.Value ?? string.Empty, UriKind.Absolute, out Uri result))
				{
					result = new Uri(ProContentApiBaseUrl + "/unauthorized");
				}
				return new RedirectResult(result);
			}
		}
		catch (Exception ex)
		{
			_logger.Warning("[{0}] Failed to get resource {1}. Exception was thrown:{2}", "ProContentConsumer", request.Resource, ex);
		}
		return new ErrorResult();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsAuthorizedChanged(bool value)
	{
		if (!value)
		{
			_app.ProContentUserEmail = null;
			_app.ProContentUserName = null;
		}
	}
}
