using System.ComponentModel;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IPlaybackMarkerLinkVM : INotifyPropertyChanged
{
	PlaybackMarkerIdentifierType PlaybackMarkerIdentifierType { get; set; }

	string PlaybackMarkerIdentifierName { get; set; }

	PlaybackMarkerTextType PlaybackMarkerTextType { get; set; }

	TimerFormatData PlaybackMarkerTimerFormat { get; set; }

	bool PlaybackMarkerUsesMarkerColor { get; set; }
}
