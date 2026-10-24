using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Events;

public record LibraryPlaylistFocusedProtoRequest : PlaylistProtoRequest<API_v1_Playlist_Response.Types.GetFocusedPlaylist>, ILibraryPlaylistEvent, IApplicationEvent, IPlaylistFocusedEvent
{
	public LibraryPlaylistFocusedProtoRequest(Action<API_v1_Playlist_Response.Types.GetFocusedPlaylist> Callback)
		: base(Callback)
	{
	}

	public static void Publish(Action<API_v1_Playlist_Response.Types.GetFocusedPlaylist> callback)
	{
		ApplicationEventPublisher.Publish(new LibraryPlaylistFocusedProtoRequest(callback));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected LibraryPlaylistFocusedProtoRequest(LibraryPlaylistFocusedProtoRequest original)
		: base((PlaylistProtoRequest<API_v1_Playlist_Response.Types.GetFocusedPlaylist>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out Action<API_v1_Playlist_Response.Types.GetFocusedPlaylist> Callback)
	{
		Callback = base.Callback;
	}
}
