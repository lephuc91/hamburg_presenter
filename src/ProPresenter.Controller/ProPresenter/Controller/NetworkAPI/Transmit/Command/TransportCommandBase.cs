using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public abstract class TransportCommandBase : INetworkCommand
{
	private readonly ProLayerIndex _layer;

	public TransportCommandBase(ProLayerIndex layer)
	{
		_layer = layer;
	}

	public Pro.SerializationInterop.RVProtoData.NetworkAPI GetCommandProto()
	{
		Pro.SerializationInterop.RVProtoData.NetworkAPI networkAPI = ProtoCommandExtensions.Build(delegate(Pro.SerializationInterop.RVProtoData.NetworkAPI c)
		{
			c.Transport(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.None, ToProtoTransportLayer(_layer));
		});
		OnTransportCommand(networkAPI.Action.Transport);
		return networkAPI;
	}

	protected virtual void OnTransportCommand(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport protoTransport)
	{
	}

	private static Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer ToProtoTransportLayer(ProLayerIndex layer)
	{
		return layer switch
		{
			ProLayerIndex.PresentationBackground => Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Presentation, 
			ProLayerIndex.AnnouncementsBackground => Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Announcement, 
			ProLayerIndex.AnnouncementsForeground => Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Announcement, 
			ProLayerIndex.Music => Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Audio, 
			_ => Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Unknown, 
		};
	}
}
