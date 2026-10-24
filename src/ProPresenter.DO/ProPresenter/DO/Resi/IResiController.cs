using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Pro.Common.OAuth;

namespace ProPresenter.DO.Resi;

public interface IResiController : INotifyPropertyChanged, IDownloader, IDownloadProgress
{
	bool PluginStarted { get; }

	CredentialState AuthorizationState { get; }

	string UserName { get; }

	ResiStreamStatus CurrentStatus { get; }

	ResiStreamStatus RequestedStatus { get; }

	AccountStatus AccountStatus { get; }

	UpdateStatus UpdateStatus { get; }

	UploadHealth UploadHealth { get; }

	ErrorCode ErrorCodes { get; }

	string EncoderName { get; }

	Version? PluginVersion { get; }

	bool PluginInstalled { get; }

	bool UpdateAvailable { get; }

	string Schedule { get; }

	bool CanCheckForUpdate { get; }

	UploadInfo? UploadInfo { get; }

	IEnumerable<IDestinationGroup> DestinationGroups { get; }

	IEnumerable<IEncoderProfile> EncoderProfiles { get; }

	event Action StartCaptureRequested;

	event Action StopCaptureRequested;

	event Action<ErrorCode> ErrorIssued;

	void ShowMoreInfo();

	bool CanShowMoreInfo();

	void Manage();

	void NavigateSupportLink();

	Task<Version?> CheckUpdateAsync();

	void StopStream();

	void AbortUpload();

	void PrepareForShutdown();

	void RefreshDestinationGroups();

	void ResetErrorCodesShown();
}
