using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Receive;

public interface IReceiveService
{
	event Action<Pro.SerializationInterop.RVProtoData.NetworkAPI> CommandReceived;
}
