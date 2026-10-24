using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Audio;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Audio;
using ProPresenter.UI.LiveVideo;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs.Audio;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

public interface IAudioInputsSettingsVM : INotifyPropertyChanged
{
	bool IsActive { get; set; }

	InputsTab Index { get; }

	INotifyEnumerableChanged<AudioInput> AudioInputs { get; }

	INotifyEnumerableChanged<IVideoInputItemVM> VideoInputs { get; }

	AudioInput? SelectedAudioInput { get; set; }

	AudioBehaviorModeInternal BehaviorMode { get; set; }

	TimeSlice AudioInputAudioDelay { get; set; }

	INotifyEnumerableChanged<IAudioInputDevice> AudioDevices { get; }

	INotifyEnumerableChanged<IVideoInputDevice> VideoDevices { get; }

	bool CanConfigureAirCast { get; }

	string? AirCastDisplayName { get; set; }

	string? AirCastPassword { get; set; }

	bool AirCastPasswordEnabled { get; set; }

	IRelayCommand RefreshAudioInputSourceCommand { get; }

	IRelayCommand AddAudioInputCommand { get; }

	IAsyncRelayCommand<AudioSource?> AddAirCastDeviceCommand { get; }

	IAsyncRelayCommand AddAirCastDeviceOnEmptyCommand { get; }

	IRelayCommand RemoveAudioInputCommand { get; }

	IRelayCommand ClearDeviceCommand { get; }

	IRelayCommand<IAudioInputDevice> SelectAudioDeviceCommand { get; }

	IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> SelectVideoDeviceCommand { get; }

	IRelayCommand<IAudioInputDevice> AddAudioDeviceCommand { get; }

	IAsyncRelayCommand<SelectVideoDeviceCommandParameter> AddVideoDeviceCommand { get; }

	IRelayCommand ToggleAudioInputAudioMonitoringCommand { get; }

	IRelayCommand EnableAllChannelsCommand { get; }

	IRelayCommand DisableAllChannelsCommand { get; }

	IRelayCommand GotFocusCommand { get; }

	event Action<UndoStack>? StackChanged;
}
