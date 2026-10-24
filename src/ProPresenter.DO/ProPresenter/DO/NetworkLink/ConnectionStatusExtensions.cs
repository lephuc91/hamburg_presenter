using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.NetworkLink;

public static class ConnectionStatusExtensions
{
	public static ConnectionStatus ToConnectionStatus(this ProLink.Types.MemberStatus.Types.ConnectionStatus protoConnectionStatus)
	{
		return protoConnectionStatus switch
		{
			ProLink.Types.MemberStatus.Types.ConnectionStatus.Connected => ConnectionStatus.Connected, 
			ProLink.Types.MemberStatus.Types.ConnectionStatus.Disconnected => ConnectionStatus.Disconnected, 
			_ => ConnectionStatus.Unknown, 
		};
	}

	public static ProLink.Types.MemberStatus.Types.ConnectionStatus ToProtoConnectionStatus(this ConnectionStatus connectionStatus)
	{
		return connectionStatus switch
		{
			ConnectionStatus.Connected => ProLink.Types.MemberStatus.Types.ConnectionStatus.Connected, 
			ConnectionStatus.Disconnected => ProLink.Types.MemberStatus.Types.ConnectionStatus.Disconnected, 
			_ => ProLink.Types.MemberStatus.Types.ConnectionStatus.Unknown, 
		};
	}
}
