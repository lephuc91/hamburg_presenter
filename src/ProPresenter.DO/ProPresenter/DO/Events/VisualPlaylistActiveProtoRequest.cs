using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Events;

public record VisualPlaylistActiveProtoRequest : PlaylistProtoRequest<API_v1_Media_Response.Types.GetActivePlaylist>, IVisualPlaylistEvent, IApplicationEvent, IPlaylistActiveEvent
{
	public VisualPlaylistActiveProtoRequest(Action<API_v1_Media_Response.Types.GetActivePlaylist> Callback)
		: base(Callback)
	{
	}

	public static void Publish(Action<API_v1_Media_Response.Types.GetActivePlaylist> callback)
	{
		ApplicationEventPublisher.Publish(new VisualPlaylistActiveProtoRequest(callback));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected VisualPlaylistActiveProtoRequest(VisualPlaylistActiveProtoRequest original)
		: base((PlaylistProtoRequest<API_v1_Media_Response.Types.GetActivePlaylist>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out Action<API_v1_Media_Response.Types.GetActivePlaylist> Callback)
	{
		Callback = base.Callback;
	}
}
