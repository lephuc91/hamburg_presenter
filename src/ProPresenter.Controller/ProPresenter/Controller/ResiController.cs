using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Common.OAuth;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Resi;

namespace ProPresenter.Controller;

public class ResiController : LinkedNotifyPropertyChangedBase, IResiController, INotifyPropertyChanged, IDownloader, IDownloadProgress
{
	private readonly IResiPlugin _plugin;

	private readonly IUpdateClient _updateClient;

	private readonly IResiWebClient _webClient;

	private readonly IHyperlinkService _hyperlinkService;

	private bool _updateAvailable;

	public CredentialState AuthorizationState => _webClient.AuthorizationState;

	public string UserName => _plugin.AboutInfo?.CustomerName ?? string.Empty;

	public AccountStatus AccountStatus => _plugin.AccountStatus ?? AccountStatus.Unknown;

	public UpdateStatus UpdateStatus => _updateClient.UpdateStatus;

	public UploadHealth UploadHealth => _plugin.UploadHealth;

	public string EncoderName => _plugin.AboutInfo?.EncoderName ?? string.Empty;

	public Version? PluginVersion => _plugin.AboutInfo?.EncoderVersion;

	public bool PluginInstalled => _plugin.PluginInstalled;

	public bool UpdateAvailable
	{
		get
		{
			return _updateAvailable;
		}
		private set
		{
			SetValue("UpdateAvailable", ref _updateAvailable, value);
		}
	}

	public string Schedule { get; } = string.Empty;

	public bool IsDownloading => _updateClient.IsDownloading;

	public double DownloadProgress => _updateClient.DownloadProgress;

	public bool PluginStarted => _plugin.PluginStatus == PluginStatus.Started;

	public ResiStreamStatus CurrentStatus => _plugin.CurrentStatus;

	public ResiStreamStatus RequestedStatus => _plugin.RequestedStatus;

	public bool CanCheckForUpdate => _plugin.CanCheckForUpdate;

	public UploadInfo? UploadInfo => _plugin.UploadInfo;

	public IEnumerable<IDestinationGroup> DestinationGroups => _plugin.DestinationGroups;

	public IEnumerable<IEncoderProfile> EncoderProfiles => _plugin.EncoderProfiles;

	public ErrorCode ErrorCodes => _plugin.ErrorCodes;

	public event Action? StartCaptureRequested;

	public event Action? StopCaptureRequested;

	public event Action<ErrorCode>? ErrorIssued;

	public ResiController(IResiPlugin plugin, IUpdateClient updateClient, IResiWebClient webClient, IHyperlinkService hyperlinkService)
	{
		_plugin = plugin;
		_webClient = webClient;
		_hyperlinkService = hyperlinkService;
		_updateClient = updateClient;
		HookupLinkedProperties();
	}

	public void ShowMoreInfo()
	{
		if (Uri.TryCreate(_webClient?.MoreInfoLink, UriKind.RelativeOrAbsolute, out Uri result))
		{
			_hyperlinkService.Open(result);
		}
	}

	public bool CanShowMoreInfo()
	{
		return true;
	}

	public void Manage()
	{
		if (Uri.TryCreate(_webClient?.ManageAccountUrl, UriKind.RelativeOrAbsolute, out Uri result))
		{
			_hyperlinkService.Open(result);
		}
	}

	public void Download()
	{
		_updateClient?.Download();
	}

	public void CancelDownload()
	{
		_updateClient?.CancelDownload();
	}

	public void NavigateSupportLink()
	{
		if (Uri.TryCreate(_webClient?.SupportLink, UriKind.RelativeOrAbsolute, out Uri result))
		{
			_hyperlinkService.Open(result);
		}
	}

	private void HookupLinkedProperties()
	{
		LinkAction("AuthorizationState", OnAuthorizationChanged);
		LinkProperties("AboutInfo", new string[5] { "UserName", "EncoderName", "PluginVersion", "UpdateAvailable", "AccountStatus" });
		LinkAction("AboutInfo", delegate
		{
			CheckUpdateAsync().ExecuteAsync();
		});
		LinkAction("RequestedStatus", OnRequestedStatusChanged);
		LinkAction("PluginStatus", OnPluginStatusChanged);
		LinkProperties("DownloadProgress", "DownloadProgress");
		LinkProperties("UpdateStatus", "UpdateStatus");
		LinkProperties("IsDownloading", "IsDownloading");
		LinkProperties("CurrentStatus", "CurrentStatus");
		LinkProperties("AccountStatus", "AccountStatus");
		LinkProperties("DestinationGroups", "DestinationGroups");
		LinkProperties("EncoderProfiles", "EncoderProfiles");
		LinkProperties("PluginInstalled", "PluginInstalled");
		LinkProperties("UploadInfo", "UploadInfo");
		LinkProperties("UploadHealth", "UploadHealth");
		LinkProperties("ErrorCodes", "ErrorCodes");
		if (_plugin != null)
		{
			_plugin.PropertyChanged += base.RaiseLinkedValues;
			_plugin.ErrorIssued += delegate(ErrorCode e)
			{
				this.ErrorIssued?.Invoke(e);
			};
		}
		if (_webClient != null)
		{
			_webClient.PropertyChanged += base.RaiseLinkedValues;
		}
		if (_updateClient != null)
		{
			_updateClient.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	private void OnPluginStatusChanged()
	{
		OnPropertyChanged("PluginStarted");
		if (PluginStarted)
		{
			ResiStartUpEvent.Publish();
		}
	}

	private void OnRequestedStatusChanged()
	{
		OnPropertyChanged("RequestedStatus");
		if (AuthorizationState != CredentialState.Authorized || !PluginInstalled || AccountStatus != 0 || _plugin.CurrentStatus == _plugin.RequestedStatus)
		{
			return;
		}
		switch (_plugin.RequestedStatus)
		{
		case ResiStreamStatus.Starting:
		case ResiStreamStatus.Started:
			if (_plugin.CurrentStatus == ResiStreamStatus.Stopped)
			{
				this.StartCaptureRequested?.Invoke();
			}
			break;
		case ResiStreamStatus.Stopping:
		case ResiStreamStatus.Stopped:
			if (_plugin.CurrentStatus == ResiStreamStatus.Started)
			{
				this.StopCaptureRequested?.Invoke();
			}
			break;
		case ResiStreamStatus.StartCheck:
		case ResiStreamStatus.StartError:
		case ResiStreamStatus.StopCheck:
			break;
		}
	}

	public async Task<Version?> CheckUpdateAsync()
	{
		Version version = await _webClient.GetLatestVersionAsync(_plugin.SupportedApiVersion);
		if (version != null)
		{
			UpdateAvailable = PluginVersion != null && PluginVersion < version;
		}
		return version;
	}

	private void OnAuthorizationChanged()
	{
		OnPropertyChanged("AuthorizationState");
		if (AuthorizationState == CredentialState.Authorized)
		{
			if (!PluginInstalled)
			{
				Download();
			}
			else
			{
				_plugin.Start();
			}
		}
	}

	public void StopStream()
	{
		_plugin.StopStream();
	}

	public void AbortUpload()
	{
		_plugin.AbortUpload();
	}

	public void PrepareForShutdown()
	{
		_plugin.PrepareForShutdown();
	}

	public void RefreshDestinationGroups()
	{
		_plugin.RefreshDestinationGroups();
	}

	public void ResetErrorCodesShown()
	{
		_plugin.ResetErrorCodesShown();
	}
}
