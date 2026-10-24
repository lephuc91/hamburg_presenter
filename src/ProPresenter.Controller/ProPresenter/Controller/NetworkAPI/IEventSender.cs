using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

internal interface IEventSender
{
	event Action<NetworkAPI_v1?>? Send;
}
