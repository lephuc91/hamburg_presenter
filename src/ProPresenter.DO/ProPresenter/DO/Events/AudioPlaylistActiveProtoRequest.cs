using System;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Events;

public record AudioPlaylistActiveProtoRequest : PlaylistProtoRequest<API_v1_Audio_Response.Types.ActivePlaylist>, IAudioPlaylistEvent, IApplicationEvent, IPlaylistActiveEvent
{
	public AudioPlaylistActiveProtoRequest(Action<API_v1_Audio_Response.Types.ActivePlaylist> Callback)
		: base(Callback)
	{
	}

	public static void Publish(Action<API_v1_Audio_Response.Types.ActivePlaylist> callback)
	{
		ApplicationEventPublisher.Publish(new AudioPlaylistActiveProtoRequest(callback));
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected AudioPlaylistActiveProtoRequest(AudioPlaylistActiveProtoRequest original)
		: base((PlaylistProtoRequest<API_v1_Audio_Response.Types.ActivePlaylist>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out Action<API_v1_Audio_Response.Types.ActivePlaylist> Callback)
	{
		Callback = base.Callback;
	}
}
