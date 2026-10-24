using System;
using System.Runtime.CompilerServices;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record AudioPlaylistActiveRequest : PlaylistRequest<Playlist<MediaCue>>, IAudioPlaylistEvent, IApplicationEvent, IPlaylistActiveEvent
{
	public AudioPlaylistActiveRequest(Action<Playlist<MediaCue>> Callback)
		: base(Callback)
	{
	}

	public static void Publish(Action<Playlist<MediaCue>> callback)
	{
		ApplicationEventPublisher.Publish(new AudioPlaylistActiveRequest(callback));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected AudioPlaylistActiveRequest(AudioPlaylistActiveRequest original)
		: base((PlaylistRequest<Playlist<MediaCue>>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out Action<Playlist<MediaCue>> Callback)
	{
		Callback = base.Callback;
	}
}
