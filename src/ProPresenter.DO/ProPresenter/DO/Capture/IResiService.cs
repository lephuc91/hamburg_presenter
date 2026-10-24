using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.OAuth;
using ProPresenter.DO.Resi;

namespace ProPresenter.DO.Capture;

public interface IResiService : INotifyPropertyChanged
{
	bool PluginStarted { get; }

	CredentialState AuthorizationState { get; }

	AccountStatus AccountStatus { get; }

	UpdateStatus UpdateStatus { get; }

	ResiStreamStatus ResiStreamStatus { get; }

	UploadHealth UploadHealth { get; }

	ErrorCode ErrorCodes { get; }

	UploadInfo? UploadInfo { get; }

	double DownloadProgress { get; }

	string CustomerName { get; }

	string EncoderName { get; }

	Version? PluginVersion { get; }

	bool PluginInstalled { get; }

	bool UpdateAvailable { get; }

	string Schedule { get; }

	string EventName { get; set; }

	string SocialDescription { get; set; }

	IEnumerable<IDestinationGroup> ResiDestinationGroups { get; }

	IEnumerable<IEncoderProfile> ResiEncoderProfiles { get; }

	void Download();

	void ShowMoreInfo();

	bool CanShowMoreInfo();

	bool IsResiBusy();

	void CancelDownload();

	void AbortFileUpload();

	void PrepareForShutdown();

	void RefreshDestinationGroups();
}
