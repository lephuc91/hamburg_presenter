using System;
using Pro.Common.Utility;
using Pro.Common.Versioning;
using Pro.Web.Services;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;

namespace ProPresenter.DO.Web;

public class WebSourceProvider : IWebSourceProvider
{
	private sealed class LinkParameters
	{
		public string? Pro6Name { get; }

		public string? Pro6Key { get; }

		public string? HardwareID { get; }

		public string? AppVersion { get; }

		public LinkParameters(string pro6Name, string pro6Key, string hardwareID)
		{
			Pro6Name = pro6Name;
			Pro6Key = pro6Key;
			HardwareID = hardwareID;
		}

		public LinkParameters(string? appVersion)
		{
			AppVersion = appVersion;
		}
	}

	private const string ResourceEndpoint = "/pro/resource/{0}";

	private const string SampleContentDataEndpoint = "/pro/sample_content";

	private const string SampleContentDownloadEndpoint = "/pro/sample_content/{0}";

	private const string ProPresenterControlUrl = "http://localhost:{0}/v1/control";

	private static readonly Uri SongSelectLink = new Uri("https://songselect.com/");

	private static readonly Uri ProPresenterLink = new Uri("https://renewedvision.com/propresenter/");

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IApiService _apiService;

	public Uri MediaStore => GenerateLink(ResourceType.MediaStore);

	public Uri MigrationHelp => GenerateLink(ResourceType.MigrationHelp);

	public Uri InfoCenter => GenerateLink(ResourceType.InfoCenter);

	public Uri UserManual => GenerateLink(ResourceType.UserManual);

	public Uri Support => GenerateLink(ResourceType.Support);

	public Uri SubmitTicket => GenerateLink(ResourceType.SubmitTicket);

	public Uri Tutorials => GenerateLink(ResourceType.Tutorials);

	public Uri Forums => GenerateLink(ResourceType.Forums);

	public Uri ScreenConfiguration => GenerateLink(ResourceType.ScreenConfiguration);

	public Uri WhatsNew => GenerateLink(ResourceType.WhatsNew);

	public Uri OpenFeedback => GenerateLink(ResourceType.OpenFeedback);

	public Uri SongSelect => SongSelectLink;

	public Uri ProPresenter => ProPresenterLink;

	public Uri SampleContentData => BuildLink(_apiService.GetTargetRedirectHost(includeProtocol: true) + "/pro/sample_content");

	public Uri VideoTutorials => GenerateLink(ResourceType.Tutorials);

	public Uri ContactSupport => GenerateLink(ResourceType.Help);

	public Uri UserGroup => GenerateLink(ResourceType.UserGroup);

	public Uri KnowledgeBase => GenerateLink(ResourceType.KnowledgeBase);

	public Uri Blog => GenerateLink(ResourceType.Blog);

	public Uri ProContent => GenerateLink(ResourceType.ProContent);

	public Uri DiscoverCloud => GenerateLink(ResourceType.DiscoverCloud);

	public Uri CloudEarlyAccess => GenerateLink(ResourceType.CloudEarlyAccess);

	public Uri UnlockCloud => GenerateLink(ResourceType.UnlockCloud);

	public Uri CloudCollaboration => GenerateLink(ResourceType.CloudCollaboration);

	public Uri CloudTroubleShooting => GenerateLink(ResourceType.CloudTroubleShooting);

	public WebSourceProvider(IRegistrationStateProvider registrationStateProvider, IApiService apiService)
	{
		_registrationStateProvider = registrationStateProvider;
		_apiService = apiService;
	}

	public Uri GetReleaseNotes(string? appVersion = null)
	{
		return GenerateLink(ResourceType.ReleaseNotes, new LinkParameters(appVersion));
	}

	private Uri BuildLink(string baseURL, LinkParameters? parameters = null)
	{
		return new UriBuilder(baseURL)
		{
			Query = BuildQuery(parameters)
		}.Uri;
	}

	private string BuildQuery(LinkParameters? parameters = null)
	{
		string text = $"platform=win32&osVersion={VersionInfo.OSVersion}&appVersion={parameters?.AppVersion ?? VersionInfo.ShortDisplayAppVersion}";
		if (_registrationStateProvider.Registration.ProPresenter is IRegisteredState registeredState)
		{
			text = text + "&activationKey=" + registeredState.ActivationKey;
		}
		if (parameters?.HardwareID != null)
		{
			text = text + "&hardwareID=" + parameters.HardwareID;
		}
		if (parameters?.Pro6Name != null)
		{
			text = text + "&data1=" + parameters.Pro6Name;
		}
		if (parameters?.Pro6Key != null)
		{
			text = text + "&data2=" + parameters.Pro6Key;
		}
		return text;
	}

	public Uri GenerateLink(ResourceType resourceType)
	{
		return GenerateLink(resourceType, null);
	}

	private Uri GenerateLink(ResourceType resourceType, LinkParameters? parameters)
	{
		return BuildLink(_apiService.GetTargetRedirectHost(includeProtocol: true) + $"/pro/resource/{resourceType.GetEnumDescription()}", parameters);
	}

	public Uri GenerateLink(InAppStoreType storeType)
	{
		Pro6LicenseReader.TryLoadPro6License(out string name, out string key);
		return GenerateLink(storeType.ToResourceType(), new LinkParameters(name ?? string.Empty, key ?? string.Empty, _registrationStateProvider.HardwareInformation.HardwareFingerprint));
	}

	public Uri GenerateSampleContentDownloadLink(string resourceKey)
	{
		return BuildLink(_apiService.GetTargetRedirectHost(includeProtocol: true) + $"/pro/sample_content/{resourceKey}");
	}

	public Uri ProPresenterControlLink(int port)
	{
		return new Uri($"http://localhost:{port}/v1/control");
	}
}
