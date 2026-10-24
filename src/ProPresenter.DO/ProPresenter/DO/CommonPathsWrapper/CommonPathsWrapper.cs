using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.CommonPathsWrapper;

public class CommonPathsWrapper : ICommonPathsWrapper
{
	public string Base => CommonPaths.Base;

	public string LibraryPostfix => "Libraries";

	public string MediaPostfix => "Media";

	public string ThemesPostfix => "Themes";

	public string ConfigurationPostfix => "Configuration";

	public string PlaylistPostfix => "Playlists";

	public string PresetsPostFix => "Presets";

	public string DefaultLocalWorkspaces => CommonPaths.DefaultLocalWorkspaces;

	public string MediaAssets => CommonPaths.MediaAssets;

	public string EffectsPresets => CommonPaths.EffectsPresets;

	public string TransitionPresets => CommonPaths.TransitionPresets;

	public IWorkspaceCollection Workspaces => CommonPaths.Workspaces;

	public string TemplatesPostfix => "Templates";

	public string EffectsPostFix => "Effect";

	public string TransitionPostFix => "Transition";

	public string Themes => CommonPaths.Themes;

	public string Libraries => CommonPaths.Libraries;

	public string Configuration => CommonPaths.Configuration;
}
