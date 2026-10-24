using System.ComponentModel;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Settings;

namespace ProPresenter.UI.ViewModels;

public interface ITelestratorVM : INotifyPropertyChanged
{
	IImmutableObservableCollection<ArrangedCue>? Slides { get; }

	ArrangedCue? ActiveSlide { get; }

	TelestratorPreferences Settings { get; }

	ICommand<ArrangedCue> TriggerSlideCommand { get; }
}
