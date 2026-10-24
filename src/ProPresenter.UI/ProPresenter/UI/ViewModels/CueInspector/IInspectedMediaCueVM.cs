using System.ComponentModel;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface IInspectedMediaCueVM : INotifyPropertyChanged
{
	MediaCue MediaCue { get; }

	bool ShowTransitionTab { get; }

	bool ShowEffectsTab { get; }

	bool ShowAudioTab { get; }

	bool ShowMarkersTab { get; }

	bool SupportsAudioNextBehavior { get; }

	InlineType ActiveInlineView { get; }

	bool ShowRetriggeringBehaviorField { get; }
}
