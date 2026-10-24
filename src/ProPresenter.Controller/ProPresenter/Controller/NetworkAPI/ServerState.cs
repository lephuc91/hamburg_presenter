using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class ServerState : NotifyPropertyChangedBase
{
	private int _connectedPort;

	private int _tcpConnectedPort;

	private string? _publicIPAddress;

	private string? _localIPAddress;

	public int ConnectedPort
	{
		get
		{
			return _connectedPort;
		}
		private set
		{
			SetValue("ConnectedPort", ref _connectedPort, value);
		}
	}

	public string? PublicIPAddress
	{
		get
		{
			return _publicIPAddress;
		}
		private set
		{
			SetValue("PublicIPAddress", ref _publicIPAddress, value);
		}
	}

	public string? LocalIPAddress
	{
		get
		{
			return _localIPAddress;
		}
		private set
		{
			SetValue("LocalIPAddress", ref _localIPAddress, value);
		}
	}

	public int TcpConnectedPort
	{
		get
		{
			return _tcpConnectedPort;
		}
		private set
		{
			SetValue("TcpConnectedPort", ref _tcpConnectedPort, value);
		}
	}

	public void Deserialize(ProLink.Types.HandlerIn.Types.ServerState protoServerState)
	{
		if (protoServerState != null)
		{
			ConnectedPort = (int)protoServerState.Port;
			PublicIPAddress = protoServerState.PublicIp;
			LocalIPAddress = protoServerState.LocalIp;
			TcpConnectedPort = (int)protoServerState.TcpStreamPort;
		}
	}
}
