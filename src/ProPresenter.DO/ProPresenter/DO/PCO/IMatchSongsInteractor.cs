using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.PCO;

public interface IMatchSongsInteractor
{
	void Execute(PCOPlan plan, PCOPlaylist playlist);
}
