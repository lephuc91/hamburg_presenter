using System.ComponentModel;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels.Editor.Links;

public interface IFormatDataVM : INotifyPropertyChanged
{
	TimerLinkFormatData? FormatData { get; }

	IColorTriggersVM ColorTriggersVM { get; }

	TimerTokenCollection? TimerTokens { get; }

	TimerFormatData? TimerFormatData { get; }

	string DisplayFormatText { get; set; }

	TimerFormatStyle SelectedHourFormat { get; set; }

	TimerFormatStyle SelectedMinuteFormat { get; set; }

	TimerFormatStyle SelectedSecondFormat { get; set; }

	TimerFormatStyle SelectedMillisecondFormat { get; set; }
}
