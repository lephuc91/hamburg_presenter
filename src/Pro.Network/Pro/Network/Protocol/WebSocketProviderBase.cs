using System;
using ProPresenterCore.ProCore.Interop;

namespace Pro.Network.Protocol;

public abstract class WebSocketProviderBase
{
	public delegate bool ClientConnectedDelegate(ulong handle, ProNetworkEndpointType endpoint);

	public delegate void ClientDisconnectedDelegate(ulong handle);

	public delegate string? MessageRecievedDelegate(ulong handle, string message);

	private ClientConnectedDelegate? _clientConnected;

	private ClientDisconnectedDelegate? _clientDisconnected;

	private MessageRecievedDelegate? _messageRecieved;

	public ClientConnectedDelegate? ClientConnected
	{
		get
		{
			return _clientConnected;
		}
		set
		{
			if (_clientConnected != null)
			{
				throw new InvalidOperationException();
			}
			_clientConnected = value;
		}
	}

	public ClientDisconnectedDelegate? ClientDisconnected
	{
		get
		{
			return _clientDisconnected;
		}
		set
		{
			if (_clientDisconnected != null)
			{
				throw new InvalidOperationException();
			}
			_clientDisconnected = value;
		}
	}

	public MessageRecievedDelegate? MessageRecieved
	{
		get
		{
			return _messageRecieved;
		}
		set
		{
			if (_messageRecieved != null)
			{
				throw new InvalidOperationException();
			}
			_messageRecieved = value;
		}
	}

	public abstract void CloseClient(ulong handle);

	public abstract void SendClient(ulong handle, string message);

	public virtual void RegisterService(ProNetworkEndpointType endpoint)
	{
	}

	public virtual void UnregisterService(ProNetworkEndpointType endpoint)
	{
	}
}
