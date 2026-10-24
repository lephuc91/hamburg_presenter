namespace ProPresenter.DO.Actions;

public interface IPlaylistActionValidatorFactory
{
	IPlaylistActionValidator Create(PlaylistAction playlistAction);
}
