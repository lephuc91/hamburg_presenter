using System.Collections.Generic;
using Pro.DO.Label;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.NetworkAPI;

public interface IAPIv1Service
{
	APIv1Service.SlideIndex? ActiveAnnouncementsSlideInfo { get; }

	APIv1Service.SlideIndex? ActivePresentationSlideInfo { get; }

	ScreenArrangementCollectionBase AudienceScreens { get; }

	AudioPlaylistCollection AudioPlaylists { get; }

	ClearGroupCollection ClearGroups { get; }

	ProPresenterCue? FocusedPresenterCue { get; }

	IEnumerable<GroupLabel> Groups { get; }

	APIv1Service.SlideIndex? LastAnnouncementsSlideInfo { get; }

	APIv1Service.SlideIndex? LastPresentationSlideInfo { get; }

	LibraryCollection Libraries { get; }

	LibraryPlaylistCollection LibraryPlaylists { get; }

	LiveAudienceLook LiveLook { get; }

	LiveVideoPlaylist LiveVideoPlaylist { get; }

	IAudienceLookCollection Looks { get; }

	IMacroSource MacroSource { get; }

	IMaskCollection Masks { get; }

	MessageCollection Messages { get; }

	IPropSource Props { get; }

	StageScreenLayoutMap ScreenLayoutMap { get; }

	StagePresentation StageLayouts { get; }

	ScreenArrangementCollectionBase StageScreens { get; }

	IThemeCollection Themes { get; }

	TimerCollection Timers { get; }

	ITriggering Triggering { get; }

	VisualPlaylistCollection VisualPlaylists { get; }

	PlaylistItemIndexTracker LibraryPlaylistNonFocusedIndexTracker { get; }

	IAPIv1Dependencies Dependencies { get; }
}
