using System.Collections.Generic;
using Pro.DO.Label;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
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

public class APIv1Service : IAPIv1Service
{
	public record SlideIndex(ArrangedCue Slide, int Index);

	private readonly IOutputConfiguration _outputConfig;

	public AudioPlaylistCollection AudioPlaylists => DataVault.AudioPlaylistCollection;

	public IAudienceLookCollection Looks { get; }

	public MessageCollection Messages => DataVault.Messages;

	public LiveAudienceLook LiveLook { get; }

	public IMacroSource MacroSource => DataVault.MacroSource;

	public IPropSource Props => DataVault.PropSource;

	public IMaskCollection Masks => _outputConfig.Masks;

	public ClearGroupCollection ClearGroups => DataVault.ClearGroups;

	public LibraryPlaylistCollection LibraryPlaylists => DataVault.LibraryPlaylistCollection;

	public LibraryCollection Libraries => DataVault.LibraryCollection;

	public StagePresentation StageLayouts => DataVault.StagePresentation;

	public ScreenArrangementCollectionBase StageScreens => _outputConfig.StageArrangementScreens;

	public ScreenArrangementCollectionBase AudienceScreens => _outputConfig.AudienceArrangementScreens;

	public StageScreenLayoutMap ScreenLayoutMap => _outputConfig.StageScreenLayoutMap;

	public VisualPlaylistCollection VisualPlaylists => DataVault.VisualPlaylistCollection;

	public LiveVideoPlaylist LiveVideoPlaylist => DataVault.VisualPlaylistCollection.LiveVideoPlaylist;

	public TimerCollection Timers => DataVault.TimerDocument.Timers;

	public IThemeCollection Themes => DataVault.Themes;

	public IEnumerable<GroupLabel> Groups => DataVault.GroupLabels;

	public SlideIndex? ActiveAnnouncementsSlideInfo => ActiveSlideInfo[OutputDestination.Announcement];

	public SlideIndex? ActivePresentationSlideInfo => ActiveSlideInfo[OutputDestination.Presentation];

	public SlideIndex? LastAnnouncementsSlideInfo => LastSlideInfo[OutputDestination.Announcement];

	public SlideIndex? LastPresentationSlideInfo => LastSlideInfo[OutputDestination.Presentation];

	private Dictionary<OutputDestination, SlideIndex?> ActiveSlideInfo { get; } = new Dictionary<OutputDestination, SlideIndex>();

	private Dictionary<OutputDestination, SlideIndex?> LastSlideInfo { get; } = new Dictionary<OutputDestination, SlideIndex>();

	public ProPresenterCue? FocusedPresenterCue { get; private set; }

	public PlaylistItemIndexTracker LibraryPlaylistNonFocusedIndexTracker { get; }

	public IAPIv1Dependencies Dependencies { get; }

	public ITriggering Triggering { get; }

	public APIv1Service(IAPIv1Dependencies dependencies, IOutputConfiguration outputConfiguration, ITriggering triggering)
	{
		_outputConfig = outputConfiguration;
		Dependencies = dependencies;
		Triggering = triggering;
		Looks = outputConfiguration.AudienceLooks;
		LiveLook = outputConfiguration.LiveLook;
		triggering.SlideTriggered += Triggering_SlideTriggered;
		triggering.SlideCleared += Triggering_SlideCleared;
		triggering.PresentationCueFocusChanged += TriggeringOnPresentationCueFocusChanged;
		ActiveSlideInfo[OutputDestination.Announcement] = null;
		ActiveSlideInfo[OutputDestination.Presentation] = null;
		LastSlideInfo[OutputDestination.Announcement] = null;
		LastSlideInfo[OutputDestination.Presentation] = null;
		LibraryPlaylistNonFocusedIndexTracker = new PlaylistItemIndexTracker();
		DataVault.Messages.CollectionChanged += delegate
		{
			MessagesUpdated.Publish();
		};
	}

	private void TriggeringOnPresentationCueFocusChanged(ProPresenterCue? newCue)
	{
		FocusedPresenterCue = newCue;
	}

	private void Triggering_SlideCleared(OutputDestination destination)
	{
		if (!(ActiveSlideInfo[destination] == null))
		{
			LastSlideInfo[destination] = ActiveSlideInfo[destination];
			ActiveSlideInfo[destination] = null;
		}
	}

	private void Triggering_SlideTriggered(ArrangedCue slide, int buildIndex, OutputDestination destination)
	{
		if (slide.Source.ParentPresentation != null)
		{
			ActiveSlideInfo[destination] = new SlideIndex(slide, slide.Index - 1);
			LastSlideInfo[destination] = null;
		}
	}
}
