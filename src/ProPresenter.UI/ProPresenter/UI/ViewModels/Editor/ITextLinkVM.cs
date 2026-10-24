using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ITextLinkVM : INotifyPropertyChanged
{
	IClockTextLinkVM ClockTextLinkVM { get; }

	ITimerTextLinkVM TimerTextLinkVM { get; }

	IVideoCountdownLinkVM VideoCountdownLinkVM { get; }

	IStageMessageTextLinkVM StageMessageTextLinkVM { get; }

	ISlideTextLinkVM SlideTextLinkVM { get; }

	IGroupNameTextLinkVM GroupNameTextLinkVM { get; }

	IPlaylistItemTextLinkVM PlaylistItemTextLinkVM { get; }

	IAutoAdvanceTextLinkVM AutoAdvanceTextLinkVM { get; }

	ICaptureTextLinkVM CaptureTextLinkVM { get; }

	IFileFeedLinkVM FileFeedLinkVM { get; }

	IRssFeedLinkVM RssFeedLinkVM { get; }

	CustomSlide? SelectedSlide { get; set; }

	EditMode EditMode { get; set; }

	IImmutableObservableCollection<TimerData> AvailableTimerCollection { get; }

	IEnumerable<ClosedBezierPath>? AvailableElementsCollection { get; }

	bool IsTextLinkEnabled { get; }

	LinkedTextType LinkedTextType { get; set; }

	CompositeCollection AvailableLinkedTextTypes { get; }

	TimerLinkedObject? SelectedTimerTextLink { get; }

	ElementTextLinkedObject? SelectedElementTextLink { get; }

	ICommand<TimerData> TimerTextLinkCommand { get; }

	ICommand<ClosedBezierPath> ElementTextLinkCommand { get; }

	ICommand<LinkedTextType> TextLinkCommand { get; }

	bool DisablePreserveFormatControls { get; }

	bool AllowTextFill { get; }
}
