using System;
using System.Runtime.CompilerServices;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record VisualPlaylistActiveRequest : PlaylistRequest<Playlist<MediaCue>>, IVisualPlaylistEvent, IApplicationEvent, IPlaylistActiveEvent
{
	public VisualPlaylistActiveRequest(Action<Playlist<MediaCue>> Callback)
		: base(Callback)
	{
	}

	public static void Publish(Action<Playlist<MediaCue>> callback)
	{
		ApplicationEventPublisher.Publish(new VisualPlaylistActiveRequest(callback));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected VisualPlaylistActiveRequest(VisualPlaylistActiveRequest original)
		: base((PlaylistRequest<Playlist<MediaCue>>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out Action<Playlist<MediaCue>> Callback)
	{
		Callback = base.Callback;
	}
}
