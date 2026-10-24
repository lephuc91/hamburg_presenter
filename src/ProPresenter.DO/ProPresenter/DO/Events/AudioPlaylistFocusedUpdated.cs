using System.Runtime.CompilerServices;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record AudioPlaylistFocusedUpdated : PlaylistUpdated<MediaCue>, IAudioPlaylistEvent, IApplicationEvent, IPlaylistFocusedEvent
{
	public AudioPlaylistFocusedUpdated(Playlist<MediaCue> Playlist)
		: base((MediaCue?)null, Playlist)
	{
	}

	public static void Publish(Playlist<MediaCue> playlist)
	{
		ApplicationEventPublisher.Publish(new AudioPlaylistFocusedUpdated(playlist));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected AudioPlaylistFocusedUpdated(AudioPlaylistFocusedUpdated original)
		: base((PlaylistUpdated<MediaCue>)original)
	{
	}

	[CompilerGenerated]
	public void Deconstruct(out Playlist<MediaCue> Playlist)
	{
		Playlist = base.Playlist;
	}
}
