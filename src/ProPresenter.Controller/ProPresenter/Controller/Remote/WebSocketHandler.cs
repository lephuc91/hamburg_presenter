using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Pro.Network.Protocol;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.Remote;

internal class WebSocketHandler : JsonActionWebSocketBase<RemoteClient>
{
	private class ProCoreWSProvider : WebSocketProviderBase
	{
		private IProCoreInstance _proCore;

		public ProCoreWSProvider(IProCoreInstance proCore)
		{
			_proCore = proCore;
			_proCore.ConnectedWSCallback = OnConnected;
			_proCore.DisconnectedWSCallback = OnDisconnected;
			_proCore.MessagesWSCallback = OnMessage;
		}

		private bool OnConnected(ulong clientHandle, ProNetworkEndpointType endpoint)
		{
			return base.ClientConnected?.Invoke(clientHandle, endpoint) ?? false;
		}

		private void OnDisconnected(ulong clientHandle)
		{
			base.ClientDisconnected?.Invoke(clientHandle);
		}

		private string OnMessage(ulong clientHandle, string message)
		{
			return base.MessageRecieved?.Invoke(clientHandle, message) ?? string.Empty;
		}

		public override void CloseClient(ulong handle)
		{
			_proCore.NetWSCloseClient(handle);
		}

		public override void SendClient(ulong handle, string message)
		{
			_proCore.NetWSSendClient(handle, message);
		}
	}

	private class EndpointInfo
	{
		public string ActionKey { get; }

		public bool IsEnabled { get; set; }

		public EndpointInfo(string actionKey)
		{
			ActionKey = actionKey;
			IsEnabled = false;
		}
	}

	private Dictionary<ProNetworkEndpointType, EndpointInfo> _endpointMap = new Dictionary<ProNetworkEndpointType, EndpointInfo>();

	public WebSocketHandler(IProCoreInstance proCore)
		: base((WebSocketProviderBase)new ProCoreWSProvider(proCore))
	{
	}

	protected override string GetActionKey(ProNetworkEndpointType endpoint)
	{
		return _endpointMap[endpoint].ActionKey;
	}

	public ActionRegistrar RegisterEndpoint(ProNetworkEndpointType endpoint, string actionKey, bool isEnabled)
	{
		if (_endpointMap.ContainsKey(endpoint))
		{
			throw new InvalidOperationException();
		}
		_endpointMap.Add(endpoint, new EndpointInfo(actionKey));
		if (isEnabled)
		{
			EnableEndpoint(endpoint);
		}
		return new ActionRegistrar(endpoint, delegate(string a, ActionHandlerDelegate h)
		{
			RegisterAction(endpoint, a, h);
		});
	}

	public void EnableEndpoint(ProNetworkEndpointType endpoint)
	{
		EndpointInfo endpointInfo = _endpointMap[endpoint];
		if (!endpointInfo.IsEnabled)
		{
			endpointInfo.IsEnabled = true;
			RegisterEndpoint(endpoint);
		}
	}

	public void DisableEndpoint(ProNetworkEndpointType endpoint)
	{
		EndpointInfo endpointInfo = _endpointMap[endpoint];
		if (endpointInfo.IsEnabled)
		{
			endpointInfo.IsEnabled = false;
			UnregisterEndpoint(endpoint);
		}
	}

	public void Broadcast(ProNetworkEndpointType endpoint, string action, JObject data, Predicate<RemoteClient>? predicate = null)
	{
		BroadcastMessage(endpoint, action, data, predicate);
	}
}
