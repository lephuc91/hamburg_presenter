using System.ComponentModel;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IAutoAdvanceTextLinkVM : INotifyPropertyChanged
{
	SourceType AutoAdvanceSource { get; set; }

	TimerFormatData? TimerFormatData { get; }

	TimerFormatStyle SelectedHourFormat { get; set; }

	TimerFormatStyle SelectedMinuteFormat { get; set; }

	TimerFormatStyle SelectedSecondFormat { get; set; }

	TimerFormatStyle SelectedMillisecondFormat { get; set; }
}
