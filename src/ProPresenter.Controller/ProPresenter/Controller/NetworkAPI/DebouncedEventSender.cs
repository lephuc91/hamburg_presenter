using System;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Events;

namespace ProPresenter.Controller.NetworkAPI;

internal abstract class DebouncedEventSender : DebouncedEventHandler, IEventSender
{
	private NetworkAPI_v1? _lastSentMessage;

	public event Action<NetworkAPI_v1?>? Send;

	protected void OnSend(NetworkAPI_v1? v1)
	{
		if (!object.Equals(_lastSentMessage, v1))
		{
			_lastSentMessage = v1;
			this.Send?.Invoke(v1);
		}
	}

	protected void OnSend(params NetworkAPI_v1[] msgs)
	{
		msgs.ForEach(OnSend);
	}
}
internal abstract class DebouncedEventSender<T> : DebouncedEventHandler<T>, IEventSender where T : IApplicationEvent
{
	public event Action<NetworkAPI_v1>? Send;

	protected void OnSend(NetworkAPI_v1 v1)
	{
		this.Send?.Invoke(v1);
	}

	protected void OnSend(params NetworkAPI_v1[] msgs)
	{
		msgs.ForEach(OnSend);
	}
}
