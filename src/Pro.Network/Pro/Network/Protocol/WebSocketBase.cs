using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ProPresenterCore.ProCore.Interop;

namespace Pro.Network.Protocol;

public abstract class WebSocketBase<T> where T : new()
{
	private class Client
	{
		public ProNetworkEndpointType Endpoint { get; }

		public T Info { get; } = new T();

		public Client(ProNetworkEndpointType endpoint)
		{
			Endpoint = endpoint;
		}
	}

	private readonly WebSocketProviderBase _provider;

	private readonly List<ProNetworkEndpointType> _endpoints = new List<ProNetworkEndpointType>();

	private readonly ConcurrentDictionary<ulong, Client> _clients = new ConcurrentDictionary<ulong, Client>();

	public WebSocketBase(WebSocketProviderBase provider)
	{
		_provider = provider;
		AttachToProvider();
	}

	protected abstract string? OnMessageReceived(ProNetworkEndpointType endpoint, string message, T clientInfo);

	protected void RegisterEndpoint(ProNetworkEndpointType endpoint)
	{
		if (!_endpoints.Contains(endpoint))
		{
			_endpoints.Add(endpoint);
			_provider.RegisterService(endpoint);
		}
	}

	protected void UnregisterEndpoint(ProNetworkEndpointType endpoint)
	{
		if (_endpoints.Contains(endpoint))
		{
			_endpoints.Remove(endpoint);
			_provider.UnregisterService(endpoint);
		}
	}

	protected void Broadcast(ProNetworkEndpointType endpoint, string message, Predicate<T>? predicate = null)
	{
		foreach (KeyValuePair<ulong, Client> client in _clients)
		{
			if (client.Value.Endpoint == endpoint && (predicate == null || predicate(client.Value.Info)))
			{
				_provider.SendClient(client.Key, message);
			}
		}
	}

	private void AttachToProvider()
	{
		_provider.ClientConnected = ClientConnectedHandler;
		_provider.ClientDisconnected = ClientDisconnectedHandler;
		_provider.MessageRecieved = MessageRecievedHandler;
	}

	private bool ClientConnectedHandler(ulong handle, ProNetworkEndpointType endpoint)
	{
		if (!_endpoints.Contains(endpoint))
		{
			return false;
		}
		_clients.TryAdd(handle, new Client(endpoint));
		return true;
	}

	private void ClientDisconnectedHandler(ulong handle)
	{
		if (handle == ulong.MaxValue)
		{
			_clients.Clear();
		}
		else
		{
			_clients.TryRemove(handle, out Client _);
		}
	}

	private string? MessageRecievedHandler(ulong handle, string message)
	{
		if (_clients.TryGetValue(handle, out Client value))
		{
			return OnMessageReceived(value.Endpoint, message, value.Info);
		}
		return null;
	}
}
