using System.Runtime.CompilerServices;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record AudioPlaylistActiveUpdated : PlaylistUpdated<MediaCue>, IAudioPlaylistEvent, IApplicationEvent, IPlaylistActiveEvent
{
	public AudioPlaylistActiveUpdated(MediaCue? Item, Playlist<MediaCue>? Playlist)
		: base(Item, Playlist)
	{
	}

	public static void Publish(MediaCue? item, Playlist<MediaCue>? playlist)
	{
		ApplicationEventPublisher.Publish(new AudioPlaylistActiveUpdated(item, playlist));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected AudioPlaylistActiveUpdated(AudioPlaylistActiveUpdated original)
		: base((PlaylistUpdated<MediaCue>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out MediaCue? Item, out Playlist<MediaCue>? Playlist)
	{
		Item = base.Item;
		Playlist = base.Playlist;
	}
}
