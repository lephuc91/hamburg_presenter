using ProPresenter.DO.Playlists;

namespace ProPresenter.ViewModels.Library;

public interface IPlaylistTemplatesService
{
	PlaylistTemplateCollection Templates { get; }

	bool ShowSaveAsTemplateDialog(string name, out string newName);

	bool ResolveConflict(string name, out string newName);

	bool Exist(string name);
}
