using System.Collections.Generic;
using System.ComponentModel;
using Pro.UI.Components;
using Pro.ssAPI.Devices;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Screens;

public interface IClockSourceVM : INotifyPropertyChanged
{
	ClockSourceCollection ClockSources { get; }

	ClockSource? SelectedClockSource { get; }

	string SelectedClockSourceName { get; }

	IEnumerable<ClockSource> Outputs { get; }

	IEnumerable<ClockSource> Inputs { get; }

	ICommand<ClockSource> SelectClockSourceCommand { get; }

	void RefreshClockSources();
}
