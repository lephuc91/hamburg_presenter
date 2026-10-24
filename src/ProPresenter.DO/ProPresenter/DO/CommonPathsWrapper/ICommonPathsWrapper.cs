using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.CommonPathsWrapper;

public interface ICommonPathsWrapper
{
	string Base { get; }

	string LibraryPostfix { get; }

	string MediaPostfix { get; }

	string ThemesPostfix { get; }

	string ConfigurationPostfix { get; }

	string PlaylistPostfix { get; }

	string PresetsPostFix { get; }

	string DefaultLocalWorkspaces { get; }

	string MediaAssets { get; }

	string EffectsPresets { get; }

	string TransitionPresets { get; }

	IWorkspaceCollection Workspaces { get; }

	string TemplatesPostfix { get; }

	string EffectsPostFix { get; }

	string TransitionPostFix { get; }

	string Themes { get; }

	string Libraries { get; }

	string Configuration { get; }
}
