using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;

namespace ProPresenter.UI.Settings.PageTemplates.Devices;

public partial class MidiDeviceSettingsView : UserControl, IComponentConnector
{
	private ISettingsNavigationVM _navigationVM;

	public MidiDeviceSettingsView()
	{
		_navigationVM = UIServiceProvider.GetService<ISettingsNavigationVM>();
		InitializeComponent();
	}

	private void DeleteDevice_Click(object? sender, RoutedEventArgs e)
	{
		if (base.DataContext is IMidiDeviceSettingsVM midiDeviceSettingsVM)
		{
			midiDeviceSettingsVM.RemoveDeviceItemCommand?.Invoke();
			_navigationVM.RemovePage(midiDeviceSettingsVM);
		}
	}
}
