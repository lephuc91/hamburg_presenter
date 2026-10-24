using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Events;

public record VisualPlaylistFocusedProtoRequest : PlaylistProtoRequest<API_v1_Media_Response.Types.GetFocusedPlaylist>, IVisualPlaylistEvent, IApplicationEvent, IPlaylistFocusedEvent
{
	public VisualPlaylistFocusedProtoRequest(Action<API_v1_Media_Response.Types.GetFocusedPlaylist> Callback)
		: base(Callback)
	{
	}

	public static void Publish(Action<API_v1_Media_Response.Types.GetFocusedPlaylist> callback)
	{
		ApplicationEventPublisher.Publish(new VisualPlaylistFocusedProtoRequest(callback));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected VisualPlaylistFocusedProtoRequest(VisualPlaylistFocusedProtoRequest original)
		: base((PlaylistProtoRequest<API_v1_Media_Response.Types.GetFocusedPlaylist>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out Action<API_v1_Media_Response.Types.GetFocusedPlaylist> Callback)
	{
		Callback = base.Callback;
	}
}
