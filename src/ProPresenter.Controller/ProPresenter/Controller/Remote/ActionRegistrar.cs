using Pro.Network.Protocol;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.Remote;

internal class ActionRegistrar
{
	public delegate void RegisterHandlerDelegate(string action, ActionWebSocketBase<RemoteClient, string, Newtonsoft.Json.Linq.JObject>.ActionHandlerDelegate handler);

	private readonly RegisterHandlerDelegate _registerHandler;

	public ProNetworkEndpointType Endpoint { get; }

	public ActionRegistrar(ProNetworkEndpointType endpoint, RegisterHandlerDelegate registerHandler)
	{
		Endpoint = endpoint;
		_registerHandler = registerHandler;
	}

	public void Register(string action, ActionWebSocketBase<RemoteClient, string, Newtonsoft.Json.Linq.JObject>.ActionHandlerDelegate handler)
	{
		_registerHandler(action, handler);
	}
}
