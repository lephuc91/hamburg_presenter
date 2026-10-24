using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.DO.Audio;
using Pro.UI.Components;
using ProPresenter.DO.Capture;
using ProPresenter.DO.Resi;

namespace ProPresenter.UI.ViewModels;

public interface IResiCaptureVM : INotifyPropertyChanged
{
	string ResiEventName { get; set; }

	string ResiSocialDescription { get; set; }

	Guid SelectedResiDestinationGroup { get; set; }

	IEnumerable<IDestinationGroup> ResiDestinationGroups { get; }

	bool FetchingDestinationGroups { get; }

	Guid SelectedResiEncoderProfile { get; set; }

	IEnumerable<IEncoderProfile> ResiEncoderProfiles { get; }

	AudioMap<Bus, StreamAudioChannel>? AudioOutputMap { get; }

	bool CanResiStartStream { get; }

	bool ResiLoggedIn { get; }

	string ResiAccountName { get; }

	string ResiEncoderID { get; }

	bool ResiPluginInstalled { get; }

	bool ResiPluginStarted { get; }

	UpdateStatus ResiUpdateStatus { get; }

	double ResiDownloadProgress { get; }

	ICommand<IEncoderProfile> ResiSelectEncoderProfileCommand { get; }

	ICommand<IDestinationGroup> ResiSelectDestinationGroupCommand { get; }

	bool ResiStreaming { get; }

	ICommand ResiRefreshDestinationGroupCommand { get; }

	ICommand ResiPreferencesCommand { get; }

	ICommand ResiMoreInfoCommand { get; }

	ICommand ResiLoginCommand { get; }

	ICommand ResiInstallPluginCommand { get; }

	ICommand AbortUploadCommand { get; }

	ICommand ResiCancelDownloadCommand { get; }

	UploadInfo? UploadInfo { get; }

	event Action? ShowResiPreferences;

	event Action? QuitImmediately;

	bool QuitResiStreaming();
}
