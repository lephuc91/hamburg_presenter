using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components.Reversibility;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Communication.MIDI;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Devices;

public interface IDevicesSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool IsActive { get; }

	DeviceCollection Devices { get; }

	IMIDIActionMap MIDIMappings { get; }

	int AutoFillStart { get; set; }

	string LastNoteReceived { get; }

	IRelayCommand OpenMIDISettingsCommand { get; }

	IRelayCommand<IRelayCommand<ISettingsItemVM>> AddMIDIDeviceCommand { get; }

	IRelayCommand<IDevice> ToggleDeviceConnectionCommand { get; }

	IRelayCommand AutoFillCommand { get; }

	IRelayCommand AutoFillBlocksCommand { get; }

	IRelayCommand<KeyValuePair<MIDIAction, int>> AssignNoteNumberCommand { get; }

	IRelayCommand HelpCommand { get; }

	IRelayCommand<IDevice> DeleteDeviceCommand { get; }

	IRelayCommand GotFocusCommand { get; }

	event Action<UndoStack> StackChanged;
}
