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

public class ProPresenterResourceService : IProPresenterResourceService
{
	private readonly IThemeRepo _themes;

	private readonly IMacrosRepo _macros;

	private readonly ILibraryPlaylistRepo _libraryPlaylists;

	private readonly IVisualPlaylistRepo _visualPlaylists;

	public AudioPlaylistCollection AudioPlaylists => DataVault.AudioPlaylistCollection;

	public ITimerCollection Timers => TimerDocument.Timers;

	public TimerDocument TimerDocument => DataVault.TimerDocument;

	public LibraryPlaylistCollection LibraryPlaylists => _libraryPlaylists.LibraryPlaylists;

	public ILibraryCollection LibraryCollection => DataVault.LibraryCollection;

	public ThemeCollection Themes => _themes.Themes;

	public MacroCollection Macros => _macros.Macros;

	public MacroGroupCollection MacroGroups => _macros.MacroGroups;

	public IMacroSource MacroSource => _macros.MacroSource;

	public VisualPlaylistCollection VisualPlaylists => _visualPlaylists.Playlists;

	public ITransitionSet Transitions => DataVault.Transitions;

	public MessageCollection Messages => DataVault.Messages;

	public ClearGroupCollection ClearGroups => DataVault.ClearGroups;

	public IEventCalendar Calendar => DataVault.Calendar;

	public StagePresentation StagePresentation => DataVault.StagePresentation;

	public ICCLIPresentation CCLIPresentation => DataVault.CCLIPresentation;

	public IGroupLabelCollection GroupLabels => DataVault.GroupLabels;

	public ISlideLabelCollection SlideLabels => DataVault.SlideLabels;

	public IPropCueCollection PropCueCollection => DataVault.PropCueCollection;

	public IPropGroupCollection PropGroupCollection => DataVault.PropGroupCollection;

	public IPropSource PropSource => DataVault.PropSource;

	public PlaylistTemplateCollection PlaylistTemplates => DataVault.PlaylistTemplates;

	public IWorkspaceCollection Workspaces => CommonPaths.Workspaces;

	public ProPresenterResourceService(IThemeRepo themeRepo, IPropsRepo propsRepo, IMacrosRepo macrosRepo, ILibraryPlaylistRepo libraryPlaylistRepo, IVisualPlaylistRepo visualPlaylistRepo)
	{
		_themes = themeRepo;
		_macros = macrosRepo;
		_libraryPlaylists = libraryPlaylistRepo;
		_visualPlaylists = visualPlaylistRepo;
	}
}
