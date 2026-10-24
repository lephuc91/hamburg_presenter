using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Pro.Common.Components;
using Pro.Common.FeatureFlag;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.OAuth;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Settings;
using RestSharp;

namespace ProPresenter.DO.Resi;

public class ResiWebClient : NotifyPropertyChangedBase, IResiWebClient, IConsumer, INotifyPropertyChanged
{
	public const string LoginIDParameter = "id";

	public const string LoginPluginInstalledParameter = "pluginInstalled";

	public const string PlatformParameter = "platform";

	public const string Win32Key = "win32";

	public const string TestModeParameter = "isTest";

	private CredentialState _authorizationState;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IResiPlugin _resiPlugin;

	private readonly IFlagService _flagService;

	private readonly IRestClientFactory _clientFactory;

	private readonly IResiEndpoints _resiCustomEndpoints;

	private readonly IApp _app;

	public CredentialState AuthorizationState
	{
		get
		{
			return _authorizationState;
		}
		private set
		{
			SetValue("AuthorizationState", ref _authorizationState, value);
		}
	}

	public string MoreInfoLink => _resiCustomEndpoints.MoreInfo;

	public string SupportEmail => "support@resi.io";

	public string SupportLink
	{
		get
		{
			if (!IsAuthorized)
			{
				return _resiCustomEndpoints.HomePage;
			}
			return _resiCustomEndpoints.Support;
		}
	}

	public string ManageAccountUrl => _resiCustomEndpoints.ManageAccount;

	public bool IsAuthorized => AuthorizationState == CredentialState.Authorized;

	public bool UsesCustomEndpoints => _resiCustomEndpoints.IsCustom;

	public ResiWebClient(IRegistrationStateProvider registrationStateProvider, IResiPlugin resiPlugin, IApp app, IFlagService flagService, IRestClientFactory clientFactory, IResiEndpoints resiCustomEndpoints)
	{
		_registrationStateProvider = registrationStateProvider;
		_resiPlugin = resiPlugin;
		_app = app;
		_flagService = flagService;
		_clientFactory = clientFactory;
		_resiCustomEndpoints = resiCustomEndpoints;
		if (!string.IsNullOrEmpty(_app.ResiToken))
		{
			AuthorizationState = CredentialState.Authorized;
		}
	}

	public async Task<string> BeginAuthorizationAsync()
	{
		Uri login = _resiCustomEndpoints.Login;
		if ((object)login == null)
		{
			return string.Empty;
		}
		RestRequest request = new RestRequest(login);
		request.AddParameter("id", _registrationStateProvider.HardwareInformation.HardwareFingerprint);
		request.AddParameter("pluginInstalled", _resiPlugin.PluginInstalled ? "1" : "0");
		return (await ExecuteRequestAsync(request))?.ResponseUri?.ToString() ?? string.Empty;
	}

	public bool TryCompleteAuthorization(string url)
	{
		AuthorizationState = CredentialState.AwaitingAuthorization;
		if (url.TryGetValueFromURLQuery("token", out string value))
		{
			_app.ResiToken = value;
			AuthorizationState = CredentialState.Authorized;
			return true;
		}
		return false;
	}

	public async Task<string> GetDeauthorizationResourceAsync()
	{
		RestRequest request = new RestRequest(_resiCustomEndpoints.Logout);
		request.AddParameter("id", _registrationStateProvider.HardwareInformation.HardwareFingerprint);
		return (await ExecuteRequestAsync(request))?.ResponseUri?.ToString() ?? string.Empty;
	}

	public void Deauthorize()
	{
		AuthorizationState = CredentialState.Unauthorized;
		_app.ResiToken = string.Empty;
	}

	public async Task<Version?> GetLatestVersionAsync(Version apiVersion)
	{
		return (await GetDownloadJsonDataAsync(apiVersion))?.Version;
	}

	public async Task<string> GetLatestVersionDownloadLinkAsync(Version apiVersion)
	{
		return (await GetDownloadJsonDataAsync(apiVersion))?.Win32?.Url ?? string.Empty;
	}

	private async Task<Uploader?> GetDownloadJsonDataAsync(Version apiVersion)
	{
		string text = await GetDownloadLinkAsync();
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		WebClient webClient = new WebClient();
		Uploader result = null;
		using (Stream stream = webClient.OpenRead(text))
		{
			using StreamReader streamReader = new StreamReader(stream);
			try
			{
				result = UpdateHelper.GetLatestUploader(streamReader.ReadToEnd(), apiVersion);
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				result = null;
			}
		}
		return result;
	}

	private async Task<string> GetDownloadLinkAsync()
	{
		RestRequest request = new RestRequest(_resiCustomEndpoints.DownloadPlugin);
		request.AddParameter("platform", "win32");
		return (await ExecuteRequestAsync(request))?.ResponseUri?.ToString() ?? string.Empty;
	}

	private async Task<RestResponse?> ExecuteRequestAsync(RestRequest request)
	{
		if (_flagService?.IsFlagEnabled(Flag.ResiTestApis) ?? false)
		{
			request.AddParameter("isTest", "1");
		}
		return await _clientFactory.Get().ExecuteAsync(request);
	}
}
