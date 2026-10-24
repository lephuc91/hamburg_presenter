using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.UI.TransportStatus;

namespace ProPresenter.UI.ViewModels.TransportStatus;

public interface ITransportStatusVM : INotifyPropertyChanged
{
	TransportStatusView View { get; set; }

	IPlaybackStatusVM PresentationStatusVM { get; }

	IPlaybackStatusVM AnnouncementStatusVM { get; }

	IPlaybackStatusVM AudioStatusVM { get; }

	bool SlideOnStageDisplayOnly { get; }

	ICommand CancelGotoNextCommand { get; }

	ICommand CancelSlideOnStageDisplayOnlyCommand { get; }
}
