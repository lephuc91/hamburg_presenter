using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Receive.Command;

public class TransportCommandHandler : CommandHandlerBase
{
	private readonly ITransportStatus _transportStatus;

	public TransportCommandHandler(ITriggering triggering)
		: base(triggering)
	{
		_transportStatus = triggering.TransportStatus;
	}

	public override void Handle(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action command)
	{
		Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport transport = command.Transport;
		switch (transport.TransportActionCase)
		{
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.Play:
			Play(transport.Layer);
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.Pause:
			Pause(transport.Layer);
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.SkipBackward:
			SkipBackward(transport.Layer, transport.SkipBackward.Seconds);
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.SkipForward:
			SkipForward(transport.Layer, transport.SkipForward.Seconds);
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.GoToEnd:
			GoToEnd(transport.Layer, transport.GoToEnd.SecondsToEnd);
			break;
		}
	}

	private void Play(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer layer)
	{
		base.Triggering.Play(ToProLayerIndex(layer), sendToNetwork: false);
	}

	private void Pause(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer layer)
	{
		base.Triggering.Pause(ToProLayerIndex(layer), sendToNetwork: false);
	}

	private void SkipBackward(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer layer, int seconds)
	{
		ProLayerIndex proLayerIndex = ToProLayerIndex(layer);
		TransportStatusEntry status = _transportStatus.GetStatus(proLayerIndex);
		if ((object)status != null)
		{
			base.Triggering.SkipToTime(proLayerIndex, (int)status.Elapsed - seconds);
		}
	}

	private void SkipForward(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer layer, int seconds)
	{
		ProLayerIndex proLayerIndex = ToProLayerIndex(layer);
		TransportStatusEntry status = _transportStatus.GetStatus(proLayerIndex);
		if ((object)status != null)
		{
			base.Triggering.SkipToTime(proLayerIndex, (int)status.Elapsed + seconds);
		}
	}

	private void GoToEnd(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer layer, int secondsToEnd)
	{
		ProLayerIndex proLayerIndex = ToProLayerIndex(layer);
		TransportStatusEntry status = _transportStatus.GetStatus(proLayerIndex);
		if ((object)status != null)
		{
			double num = status.Elapsed + status.Remaining;
			base.Triggering.SkipToTime(proLayerIndex, (int)num - secondsToEnd);
		}
	}

	private ProLayerIndex ToProLayerIndex(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer layer)
	{
		return layer switch
		{
			Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Presentation => ProLayerIndex.PresentationBackground, 
			Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Announcement => ProLayerIndex.AnnouncementsBackground, 
			Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer.Audio => ProLayerIndex.Music, 
			_ => ProLayerIndex.Invalid, 
		};
	}
}
