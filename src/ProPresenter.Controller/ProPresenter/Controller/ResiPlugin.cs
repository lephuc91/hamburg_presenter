using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using ProPresenter.DO;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Resi;
using ProPresenterCore.ProCore.Interop.Resi.Types;

namespace ProPresenter.Controller;

public class ResiPlugin : LinkedNotifyPropertyChangedBase, IResiPlugin, INotifyPropertyChanged
{
	private static readonly string ResiLocation = Path.Combine(CommonPaths.InstallLocation, "ResiStreamingEngine");

	private static readonly string ResiExecutable = Path.Combine(ResiLocation, "ResiStreamingEngine.exe");

	private readonly IProCoreInstance _proCore;

	private readonly IErrorPrompt _errorPrompt;

	private readonly IApp _app;

	private readonly List<IEncoderProfile> _encoderProfiles = new List<IEncoderProfile>();

	private readonly List<IDestinationGroup> _destinationGroups = new List<IDestinationGroup>();

	private readonly object _destinationGroupsLockObject = new object();

	private PluginStatus _pluginStatus;

	private ResiStreamStatus _currentStatus;

	private IAboutInfo? _aboutInfo;

	private AccountStatus? _accountStatus;

	private ResiStreamStatus _requestedState;

	private UploadInfo? _uploadInfo;

	private UploadHealth _uploadHealth;

	private ErrorCode _errorCodes;

	public Version SupportedApiVersion { get; } = new Version("1.0.2");

	public PluginStatus PluginStatus
	{
		get
		{
			return _pluginStatus;
		}
		private set
		{
			SetValue("PluginStatus", ref _pluginStatus, value);
		}
	}

	public ResiStreamStatus CurrentStatus
	{
		get
		{
			return _currentStatus;
		}
		private set
		{
			SetValue("CurrentStatus", ref _currentStatus, value);
		}
	}

	public ResiStreamStatus RequestedStatus
	{
		get
		{
			return _requestedState;
		}
		private set
		{
			SetValue("RequestedStatus", ref _requestedState, value);
		}
	}

	public IAboutInfo? AboutInfo
	{
		get
		{
			return _aboutInfo;
		}
		private set
		{
			SetValue("AboutInfo", ref _aboutInfo, value);
		}
	}

	public AccountStatus? AccountStatus
	{
		get
		{
			return _accountStatus;
		}
		private set
		{
			SetValue("AccountStatus", ref _accountStatus, value);
		}
	}

	public UploadInfo? UploadInfo
	{
		get
		{
			return _uploadInfo;
		}
		private set
		{
			SetValue("UploadInfo", ref _uploadInfo, value);
		}
	}

	public UploadHealth UploadHealth
	{
		get
		{
			return _uploadHealth;
		}
		private set
		{
			SetValue("UploadHealth", ref _uploadHealth, value);
		}
	}

	public ErrorCode ErrorCodes
	{
		get
		{
			return _errorCodes;
		}
		private set
		{
			SetValue("ErrorCodes", ref _errorCodes, value);
		}
	}

	public IEnumerable<IEncoderProfile> EncoderProfiles => from p in _encoderProfiles
		orderby p.Resolution.Y, p.FrameRate, p.VideoBitRate
		select p;

	public IEnumerable<IDestinationGroup> DestinationGroups
	{
		get
		{
			lock (_destinationGroupsLockObject)
			{
				return _destinationGroups.OrderBy((IDestinationGroup g) => g.Name);
			}
		}
	}

	public bool PluginInstalled => File.Exists(ResiExecutable);

	public bool CanCheckForUpdate
	{
		get
		{
			if (CurrentStatus != ResiStreamStatus.Stopped)
			{
				return CurrentStatus == ResiStreamStatus.Unknown;
			}
			return true;
		}
	}

	public event Action<ErrorCode>? ErrorIssued;

	public ResiPlugin(IProCoreInstance proCore, IErrorPrompt errorPrompt, IApp app, bool autoStart = false)
	{
		_app = app;
		_proCore = proCore;
		_errorPrompt = errorPrompt;
		_proCore.ResiSetProcessLocation(ResiExecutable);
		IProCoreInstance proCore2 = _proCore;
		proCore2.ResiTransferHandler = (ResiTransferDelegate)Delegate.Combine(proCore2.ResiTransferHandler, new ResiTransferDelegate(HandleResiTransfer));
		if (autoStart && !string.IsNullOrEmpty(_app.ResiToken))
		{
			Start();
		}
	}

	public void Start()
	{
		PluginStatus = PluginStatus.Starting;
		_proCore.ResiSetAccessToken(_app.ResiToken);
	}

	public void Stop()
	{
		PluginStatus = PluginStatus.Stopped;
		_proCore.ResiSetAccessToken(" ");
	}

	public void Remove()
	{
		_proCore.ResiBeginPluginRemoval();
	}

	private void RemovePlugin()
	{
		try
		{
			Directory.Delete(ResiLocation, recursive: true);
			AboutInfo = null;
			ResetStatus();
		}
		catch (Exception exception)
		{
			Log.Error("Could not successfully remove Resi plugin");
			Log.Error(exception);
		}
	}

	private void HandleResiTransfer(Transfer resiTransfer)
	{
		if (resiTransfer == null)
		{
			return;
		}
		switch (resiTransfer.Type)
		{
		case ProResiTransferType.kProResiTransferEncoderProfiles:
			EnumerateEncoderProfiles();
			break;
		case ProResiTransferType.kProResiTransferDestinationGroups:
			EnumerateDestinationGroups();
			break;
		case ProResiTransferType.kProResiTransferAboutInfo:
			HandleAboutInfoTransfer(resiTransfer as AboutInfoTransfer);
			break;
		case ProResiTransferType.kProResiTransferEventStatus:
			HandleEventStatusChanged(resiTransfer as EventStatusTransfer);
			break;
		case ProResiTransferType.kProResiTransferBeginUpdateReady:
			PluginStatus = PluginStatus.Stopped;
			break;
		case ProResiTransferType.kProResiTransferPluginRemovalReady:
			RemovePlugin();
			break;
		}
		if (!resiTransfer.Success)
		{
			_errorPrompt.ShowError(resiTransfer.Type);
			if (resiTransfer.Type == ProResiTransferType.kProResiTransferStreamStart)
			{
				CurrentStatus = ResiStreamStatus.Starting;
				CurrentStatus = ResiStreamStatus.Stopped;
			}
		}
		if (resiTransfer is EventStatusTransfer && ErrorCodes != 0)
		{
			_errorPrompt.ShowError(ErrorCodes);
			this.ErrorIssued?.Invoke(ErrorCodes);
			if (ErrorCodes.HasFlag(ErrorCode.DestinationGroupInUse) || ErrorCodes.HasFlag(ErrorCode.DestinationGroupDeleted))
			{
				CurrentStatus = ResiStreamStatus.Starting;
				CurrentStatus = ResiStreamStatus.Stopped;
			}
		}
	}

	private void HandleEventStatusChanged(EventStatusTransfer? eventStatus)
	{
		if (eventStatus != null)
		{
			AccountStatus = eventStatus.Status.AccountStatus.ToAccountStatus();
			UploadInfo = GetUploadInfo(eventStatus);
			UploadHealth = eventStatus.Status.UploadHealth.ToUploadHealth();
			ErrorCodes = eventStatus.Status.ErrorCodes.ToErrorCodes();
			CurrentStatus = eventStatus.Status.CurrentState.ToStatus();
			RequestedStatus = eventStatus.Status.RequestedState.ToStatus();
			if (AccountStatus == ProPresenter.DO.Resi.AccountStatus.Active)
			{
				PluginStatus = PluginStatus.Started;
			}
		}
	}

	private static UploadInfo GetUploadInfo(EventStatusTransfer eventStatus)
	{
		FileUploadStatus fileUploadStatus = eventStatus.Status.FileUploadStatus;
		return new UploadInfo(fileUploadStatus.InitialCount - fileUploadStatus.CurrentCount, fileUploadStatus.InitialCount);
	}

	private void HandleAboutInfoTransfer(AboutInfoTransfer? aboutInfoTransfer)
	{
		if (aboutInfoTransfer != null && aboutInfoTransfer.Success)
		{
			Version.TryParse(aboutInfoTransfer.AboutInfo.EncoderVersion, out Version result);
			AboutInfo = new ProPresenter.DO.Resi.AboutInfo(aboutInfoTransfer.AboutInfo.CustomerName, aboutInfoTransfer.AboutInfo.EncoderName, result, aboutInfoTransfer.AboutInfo.ManageUrl);
		}
		else
		{
			AboutInfo = new ProPresenter.DO.Resi.AboutInfo(string.Empty, string.Empty, null, string.Empty);
		}
	}

	public void StopStream()
	{
		InvokeIfAuthenticated(delegate
		{
			_proCore.ResiAbortRemoteStream();
		});
	}

	public void BeginUpdate()
	{
		_proCore.ResiBeginUpdate();
	}

	public void EndUpdate()
	{
		OnPropertyChanged("PluginInstalled");
		_proCore.ResiSetAccessToken(_app.ResiToken);
		_proCore.ResiEndUpdate();
	}

	public void ResetStatus()
	{
		PluginStatus = PluginStatus.Unknown;
		if (PluginInstalled)
		{
			EndUpdate();
		}
	}

	private void EnumerateDestinationGroups()
	{
		lock (_destinationGroupsLockObject)
		{
			_destinationGroups.Clear();
			OnPropertyChanged("DestinationGroups");
			_proCore.ResiEnumerateDestinationGroups(HandleGroupAdded);
		}
	}

	private static Vector2<uint> HeightToResolution16_9(uint resolutionHeight)
	{
		return new Vector2<uint>((uint)Math.Round((double)resolutionHeight * 16.0 / 9.0), resolutionHeight);
	}

	private void EnumerateEncoderProfiles()
	{
		_encoderProfiles.Clear();
		OnPropertyChanged("EncoderProfiles");
		_proCore.ResiEnumerateEncoderProfiles(HandleProfileAdded);
	}

	private void HandleGroupAdded(ProPresenterCore.ProCore.Interop.Resi.Types.DestinationGroup group)
	{
		Guid result;
		Guid id = (Guid.TryParse(group.Id, out result) ? result : Guid.NewGuid());
		_destinationGroups.Add(new ProPresenter.DO.Resi.DestinationGroup(id, group.Name));
		OnPropertyChanged("DestinationGroups");
	}

	private void HandleProfileAdded(ProPresenterCore.ProCore.Interop.Resi.Types.EncoderProfile profile)
	{
		Guid result;
		ProPresenter.DO.Resi.EncoderProfile item = new ProPresenter.DO.Resi.EncoderProfile(Guid.TryParse(profile.Id, out result) ? result : Guid.NewGuid(), profile.Format, HeightToResolution16_9(profile.Resolution), profile.FrameRate.ToFrameRate(), profile.Interlaced, profile.VideoBitRate, profile.VideoBufSize, profile.VideoMinRate, profile.VideoMaxRate, profile.Gop, profile.SegmentSize);
		_encoderProfiles.Add(item);
		OnPropertyChanged("EncoderProfiles");
	}

	private void InvokeIfAuthenticated(Action action)
	{
		if (AccountStatus == ProPresenter.DO.Resi.AccountStatus.Active)
		{
			action();
		}
	}

	public void AbortUpload()
	{
		_proCore.ResiAbortFileUpload();
	}

	public void PrepareForShutdown()
	{
		_proCore.ResiPrepareForShutdown();
	}

	public void RefreshDestinationGroups()
	{
		_proCore.RefreshDestinationGroups();
	}

	public void ResetErrorCodesShown()
	{
		_errorPrompt.ResetErrorCodesShown();
	}
}
