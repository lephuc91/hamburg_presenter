using System;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Receive;

public class ReceiveService : IReceiveService
{
	private readonly IUiDispatcher _dispatcher;

	public event Action<Pro.SerializationInterop.RVProtoData.NetworkAPI>? CommandReceived;

	public ReceiveService(IProCoreInstance procore, IUiDispatcher dispatcher)
	{
		_dispatcher = dispatcher;
		procore.NetworkAPICallback = OnCommandReceived;
	}

	private void OnCommandReceived(Pro.SerializationInterop.RVProtoData.NetworkAPI protoNetworkAPI)
	{
		_dispatcher.InvokeAsync(delegate
		{
			Log.Info($"Command Received - {protoNetworkAPI}");
			this.CommandReceived?.Invoke(protoNetworkAPI);
		});
	}
}
