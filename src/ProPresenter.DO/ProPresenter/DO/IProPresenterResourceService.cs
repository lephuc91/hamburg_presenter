using Pro.DO.Transitions;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Label;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO;

public interface IProPresenterResourceService
{
	AudioPlaylistCollection AudioPlaylists { get; }

	ITimerCollection Timers { get; }

	TimerDocument TimerDocument { get; }

	LibraryPlaylistCollection LibraryPlaylists { get; }

	ILibraryCollection LibraryCollection { get; }

	ThemeCollection Themes { get; }

	MacroCollection Macros { get; }

	MacroGroupCollection MacroGroups { get; }

	IMacroSource? MacroSource { get; }

	VisualPlaylistCollection VisualPlaylists { get; }

	ITransitionSet Transitions { get; }

	MessageCollection Messages { get; }

	ClearGroupCollection ClearGroups { get; }

	IEventCalendar Calendar { get; }

	StagePresentation StagePresentation { get; }

	ICCLIPresentation CCLIPresentation { get; }

	IGroupLabelCollection GroupLabels { get; }

	ISlideLabelCollection SlideLabels { get; }

	IPropCueCollection PropCueCollection { get; }

	IPropGroupCollection PropGroupCollection { get; }

	IPropSource PropSource { get; }

	IWorkspaceCollection Workspaces { get; }

	PlaylistTemplateCollection PlaylistTemplates { get; }
}
