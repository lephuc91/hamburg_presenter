using System;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

internal abstract class EventSender : IEventSender
{
	public event Action<NetworkAPI_v1?>? Send;

	protected void OnSend(NetworkAPI_v1? v1)
	{
		this.Send?.Invoke(v1);
	}

	protected void OnSend(params NetworkAPI_v1[] msgs)
	{
		msgs.ForEach(OnSend);
	}
}
