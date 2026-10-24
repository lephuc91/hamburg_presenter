using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Timecode;

public partial class TimecodeWindow : ChromedWindow, IComponentConnector
{
	private ICommand<bool>? MonitorCommand => (base.DataContext as ITimecodeVM)?.MonitorCommand;

	public TimecodeWindow()
	{
		InitializeComponent();
	}

	private void Monitor_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		MonitorCommand?.Invoke(parameter: true);
	}

	private void Monitor_PreviewMouseUp(object? sender, MouseButtonEventArgs e)
	{
		MonitorCommand?.Invoke(parameter: false);
	}
}
