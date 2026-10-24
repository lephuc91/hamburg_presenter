using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels;

public interface IPlaylistTemplateItemVM
{
	GeneralPlaylist Template { get; }

	string Name { get; set; }
}
