using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI.Transmit;

public interface ICommandSender
{
	void SendCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI? command);

	void SendCommand(ProLink.Types.ClientAction action);

	void SendConfiguration(ProApiNetworkConfiguration config);

	void SendReconnect();

	void SetLinkCallback(Func<ProLink.Types.HandlerIn, ProApiOut?> onLinkCallback);
}
