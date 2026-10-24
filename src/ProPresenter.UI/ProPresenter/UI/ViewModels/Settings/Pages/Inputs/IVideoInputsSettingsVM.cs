using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Audio;
using Pro.UI.Controls;
using Pro.ssAPI.Devices;
using ProPresenter.Controller;
using ProPresenter.DO.LiveVideo;
using ProPresenter.UI.LiveVideo;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

public interface IVideoInputsSettingsVM : INotifyPropertyChanged
{
	bool IsActive { get; set; }

	bool IsPreviewActive { get; set; }

	InputsTab Index { get; }

	INotifyEnumerableChanged<IVideoInputDevice> VideoDevices { get; }

	INotifyEnumerableChanged<IAudioInputDevice> AudioDevices { get; }

	INotifyEnumerableChanged<LiveVideoInput> LiveVideoInputs { get; }

	LiveVideoInput? ActiveLiveVideoInput { get; set; }

	LiveVideoInput? SelectedLiveVideoInput { get; set; }

	TimeSlice VideoInputAudioDelay { get; }

	bool CanConfigureAirCast { get; }

	string? AirCastDisplayName { get; set; }

	string? AirCastPassword { get; set; }

	bool AirCastPasswordEnabled { get; set; }

	IRelayCommand AddVideoInputCommand { get; }

	IAsyncRelayCommand<LiveVideoInput?> AddAirCastDeviceCommand { get; }

	IAsyncRelayCommand<AudioSource?> AddAirCastDeviceAudioSourceCommand { get; }

	IAsyncRelayCommand AddAirCastDeviceOnEmptyCommand { get; }

	IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> AddVideoDeviceCommand { get; }

	IAsyncRelayCommand RemoveVideoInputCommand { get; }

	IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> SelectVideoDeviceCommand { get; }

	IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> SelectAudioSourceVideoDeviceCommand { get; }

	IRelayCommand<IAudioInputDevice> SelectAudioSourceAudioDeviceCommand { get; }

	IRelayCommand RefreshVideoInputSourceCommand { get; }

	IRelayCommand ClearSelectedVideoInputDeviceCommand { get; }

	IAsyncRelayCommand SelectThumbnailCommand { get; }

	IRelayCommand ClearThumbnailCommand { get; }

	IRelayCommand<CreateRenderViewParameters> LoadPreviewCommand { get; }

	IRelayCommand<DestroyRenderViewParameters> UnloadPreviewCommand { get; }

	IRelayCommand ToggleVideoInputAudioMonitoringCommand { get; }

	IAsyncRelayCommand CaptureThumbnailCommand { get; }

	IRelayCommand ClearDeviceCommand { get; }

	IRelayCommand EnableAllChannelsCommand { get; }

	IRelayCommand DisableAllChannelsCommand { get; }

	IRelayCommand<RequestRenderParameter> RequestRenderCommand { get; }

	IRelayCommand GotFocusCommand { get; }

	event Action<UndoStack>? StackChanged;
}
