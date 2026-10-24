using System;
using Pro.DO.Triggering;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Actions;

public class PlaylistActionValidatorFactory : IPlaylistActionValidatorFactory
{
	private readonly IProPresenterResourceService _resources;

	public PlaylistActionValidatorFactory(IProPresenterResourceService resources)
	{
		_resources = resources;
	}

	public IPlaylistActionValidator Create(PlaylistAction playlistAction)
	{
		return new PlaylistActionValidator(playlistAction, playlistAction.ActionType switch
		{
			ActionType.VisualPlaylist => new TargetPlaylistCollection<MediaCue>(_resources.VisualPlaylists), 
			ActionType.AudioPlaylist => new TargetPlaylistCollection<MediaCue>(_resources.AudioPlaylists), 
			ActionType.LibraryPlaylist => new TargetPlaylistCollection<ProPresenterCue>(_resources.LibraryPlaylists), 
			_ => throw new ArgumentOutOfRangeException("playlistAction", playlistAction, "Action type is not supported"), 
		});
	}
}
