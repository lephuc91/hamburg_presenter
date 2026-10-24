using System;
using System.ComponentModel;
using Pro.CoreApplication.Media;
using Pro.DO.Storage;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Settings;

public interface IAdvanced : INotifyPropertyChanged, IManageMediaAutoMaticallyProvider
{
	ForegroundMediaAudioBehavior AnnouncementForegroundMediaAudioBehavior { get; set; }

	bool EnableSearchRoots { get; set; }

	bool IgnoreBackgroundColors { get; set; }

	string NDIExtraIPs { get; set; }

	string NDIInputGroups { get; set; }

	bool NDIShowLocalSources { get; set; }

	ForegroundMediaAudioBehavior PresentationForegroundMediaAudioBehavior { get; set; }

	ISearchRootCollection SearchRoots { get; }

	bool ShowScreenStats { get; set; }

	bool SuppressVideoStart { get; set; }

	void RegisterIgnoreBackgroundColorsChangedAction(Action action);
}
