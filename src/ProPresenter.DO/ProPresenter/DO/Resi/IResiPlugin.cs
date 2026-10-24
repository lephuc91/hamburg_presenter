using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.DO.Resi;

public interface IResiPlugin : INotifyPropertyChanged
{
	Version SupportedApiVersion { get; }

	PluginStatus PluginStatus { get; }

	ResiStreamStatus CurrentStatus { get; }

	ResiStreamStatus RequestedStatus { get; }

	IAboutInfo? AboutInfo { get; }

	AccountStatus? AccountStatus { get; }

	UploadInfo? UploadInfo { get; }

	UploadHealth UploadHealth { get; }

	ErrorCode ErrorCodes { get; }

	IEnumerable<IEncoderProfile> EncoderProfiles { get; }

	IEnumerable<IDestinationGroup> DestinationGroups { get; }

	bool PluginInstalled { get; }

	bool CanCheckForUpdate { get; }

	event Action<ErrorCode> ErrorIssued;

	void Start();

	void Stop();

	void Remove();

	void StopStream();

	void BeginUpdate();

	void EndUpdate();

	void ResetStatus();

	void AbortUpload();

	void PrepareForShutdown();

	void RefreshDestinationGroups();

	void ResetErrorCodesShown();
}
