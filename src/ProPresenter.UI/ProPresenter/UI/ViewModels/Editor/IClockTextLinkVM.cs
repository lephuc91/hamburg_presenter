using System.ComponentModel;
using System.Windows.Input;
using Pro.Localization;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IClockTextLinkVM : INotifyPropertyChanged
{
	FormatLength DateFormat { get; set; }

	FormatLength TimeFormat { get; set; }

	bool Use24HourFormat { get; set; }

	string DisplayFormatText { get; set; }

	ClockTokenCollection? ClockTokens { get; }

	ClockData? ClockData { get; }

	ICommand SaveAsDefaultCommand { get; }

	ICommand ResetToDefaultCommand { get; }
}
