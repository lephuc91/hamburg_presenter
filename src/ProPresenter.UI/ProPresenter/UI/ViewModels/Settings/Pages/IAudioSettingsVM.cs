using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Time;
using Pro.DO.Audio;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages;

public interface IAudioSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	int BusCount { get; set; }

	bool MonitorOnMains { get; }

	bool DisableMainOutputDevice { get; }

	IAudioOutputDeviceCollection AudioOutputDevices { get; }

	string MonitorDestinationDisplayName { get; }

	IEnumerable<IAudioOutputDevice> ASIODevices { get; }

	IEnumerable<IAudioOutputDevice> WaveOutDevices { get; }

	IAudioDestination MonitorDestination { get; }

	IAudioDestination MainDestination { get; }

	IAudioDestination SdiNdiDestination { get; }

	TimeSlice MainDelay { get; set; }

	TimeSlice SDINDIDelay { get; set; }

	bool SDINDIEnabled { get; set; }

	ICommand<IAudioOutputDevice?> SelectInspectorDeviceCommand { get; }

	ICommand SelectMonitorOnMainsCommand { get; }

	ICommand<IAudioOutputDevice?> SelectMainDeviceCommand { get; }

	ICommand SelectNoMainDeviceCommand { get; }

	ICommand HelpCommand { get; }

	ICommand ClearAllTestTones { get; }
}
