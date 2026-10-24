using System;
using ProPresenter.UI.Settings.PageTemplates.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;

namespace ProPresenter.ViewModels.Settings.Pages.Devices;

public class MidiWindowProvider : IMidiWindowProvider
{
	private Lazy<MIDISettingsWindow>? _midiSettingsWindow;

	public void ToggleWindowVisibility(IDevicesSettingsVM deviceSettingsVm)
	{
		if (_midiSettingsWindow == null)
		{
			_midiSettingsWindow = new Lazy<MIDISettingsWindow>(() => new MIDISettingsWindow
			{
				DataContext = deviceSettingsVm
			});
		}
		if (!_midiSettingsWindow.Value.IsVisible)
		{
			_midiSettingsWindow.Value.Show();
		}
		else
		{
			_midiSettingsWindow.Value.Close();
		}
	}
}
