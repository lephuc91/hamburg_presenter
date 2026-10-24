using System.Runtime.CompilerServices;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record VisualPlaylistFocusedUpdated : PlaylistUpdated<MediaCue>, IVisualPlaylistEvent, IApplicationEvent, IPlaylistFocusedEvent
{
	public VisualPlaylistFocusedUpdated(Playlist<MediaCue> Playlist)
		: base((MediaCue?)null, Playlist)
	{
	}

	public static void Publish(Playlist<MediaCue> playlist)
	{
		ApplicationEventPublisher.Publish(new VisualPlaylistFocusedUpdated(playlist));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected VisualPlaylistFocusedUpdated(VisualPlaylistFocusedUpdated original)
		: base((PlaylistUpdated<MediaCue>)original)
	{
	}

	[CompilerGenerated]
	public void Deconstruct(out Playlist<MediaCue> Playlist)
	{
		Playlist = base.Playlist;
	}
}
