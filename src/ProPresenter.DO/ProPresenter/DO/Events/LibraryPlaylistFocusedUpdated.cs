using System.Runtime.CompilerServices;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record LibraryPlaylistFocusedUpdated : PlaylistUpdated<ProPresenterCue>, ILibraryPlaylistEvent, IApplicationEvent, IPlaylistFocusedEvent
{
	public LibraryPlaylistFocusedUpdated(ProPresenterCue Item, Playlist<ProPresenterCue> Playlist)
		: base(Item, Playlist)
	{
	}

	public static void Publish(ProPresenterCue item, Playlist<ProPresenterCue> playlist)
	{
		ApplicationEventPublisher.Publish(new LibraryPlaylistFocusedUpdated(item, playlist));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected LibraryPlaylistFocusedUpdated(LibraryPlaylistFocusedUpdated original)
		: base((PlaylistUpdated<ProPresenterCue>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out ProPresenterCue Item, out Playlist<ProPresenterCue> Playlist)
	{
		Item = base.Item;
		Playlist = base.Playlist;
	}
}
