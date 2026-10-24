using System.ComponentModel;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.ssAPI;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Import;

public interface IImportSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	ScaleBehavior BackgroundScaleBehavior { get; set; }

	ScaleBehavior ForegroundScaleBehavior { get; set; }

	ImportLayerInternal ImageLayer { get; set; }

	ImportDurationTypeInternal ImportDurationType { get; set; }

	TimeSlice ImageDurationTime { get; set; }

	int RandomMinTime { get; set; }

	int RandomMaxTime { get; set; }

	bool IsImageNextBehaviorEnabled { get; }

	CompletionTargetType ImageNextBehavior { get; set; }

	ImportLayerInternal VideoLayer { get; set; }

	PlaybackBehaviorType VideoPlaybackBehavior { get; set; }

	bool IsVideoEndAndNextBehaviorEnabled { get; }

	EndBehaviorType VideoEndBehavior { get; set; }

	CompletionTargetType VideoNextBehavior { get; set; }

	AudioBehaviorType AudioPlaybackBehavior { get; set; }
}
