using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Events;

public record AudioPlaylistFocusedProtoRequest : PlaylistProtoRequest<API_v1_Audio_Response.Types.FocusedPlaylist>, IAudioPlaylistEvent, IApplicationEvent, IPlaylistFocusedEvent
{
	public AudioPlaylistFocusedProtoRequest(Action<API_v1_Audio_Response.Types.FocusedPlaylist> Callback)
		: base(Callback)
	{
	}

	public static void Publish(Action<API_v1_Audio_Response.Types.FocusedPlaylist> callback)
	{
		ApplicationEventPublisher.Publish(new AudioPlaylistFocusedProtoRequest(callback));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected AudioPlaylistFocusedProtoRequest(AudioPlaylistFocusedProtoRequest original)
		: base((PlaylistProtoRequest<API_v1_Audio_Response.Types.FocusedPlaylist>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out Action<API_v1_Audio_Response.Types.FocusedPlaylist> Callback)
	{
		Callback = base.Callback;
	}
}
