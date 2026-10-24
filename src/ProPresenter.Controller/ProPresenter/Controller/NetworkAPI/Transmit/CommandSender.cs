using System;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit;

public class CommandSender : ICommandSender
{
	private readonly IProCoreInstance _procore;

	public CommandSender(IProCoreInstance procore)
	{
		_procore = procore;
	}

	public void SendCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI? command)
	{
		_procore.SendNetworkAPICommand(command);
	}

	public void SendCommand(ProLink.Types.ClientAction action)
	{
		_procore.SendLinkAction(action);
	}

	public void SendConfiguration(ProApiNetworkConfiguration config)
	{
		_procore.NetSendConfigurationMessage(new ProNetworkConfigurationMessage
		{
			Configuration = config
		});
	}

	public void SendReconnect()
	{
		_procore.NetSendConfigurationMessage(new ProNetworkConfigurationMessage
		{
			RestartNetwork = new ProNetworkConfigurationMessage.Types.RestartNetwork()
		});
	}

	public void SetLinkCallback(Func<ProLink.Types.HandlerIn, ProApiOut?> onLinkCallback)
	{
		_procore.LinkCallback = onLinkCallback;
	}
}
