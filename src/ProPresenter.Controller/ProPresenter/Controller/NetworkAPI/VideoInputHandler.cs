using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

public static class VideoInputHandler
{
	private static ProPresenter.DO.Playlists.LiveVideoPlaylist VideoInputs => DataVault.VisualPlaylistCollection.LiveVideoPlaylist;

	internal static NetworkAPI_v1 Handle(IAPIv1Service service, API_v1_Video_Inputs_Request request)
	{
		if (request != null)
		{
			if (request.GetAll != null)
			{
				return GetAllInputs();
			}
			API_v1_Video_Inputs_Request.Types.Trigger trigger = request.Trigger;
			if (trigger != null)
			{
				return TriggerVideoInput(service, trigger.Id);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 GetAllInputs()
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().VideoInputResponse().GetAll = new API_v1_Video_Inputs_Response.Types.GetAll
			{
				Inputs = { VideoInputs.ToIdentifiers() }
			};
		});
	}

	private static NetworkAPI_v1 TriggerVideoInput(IAPIv1Service service, string stringID)
	{
		ProPresenter.DO.Playlists.LiveVideoPlaylist liveVideoPlaylist = service.LiveVideoPlaylist;
		ITriggering triggering = service.Triggering;
		if (liveVideoPlaylist == null)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().InternalError();
			});
		}
		if (Common.TryFindItem(liveVideoPlaylist, stringID, out ItemPacket<MediaCue> packet))
		{
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				triggering.TriggerBackground(packet.Item, liveVideoPlaylist);
			});
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().VideoInputResponse().Trigger = new API_v1_Video_Inputs_Response.Types.Trigger();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static API_v1_Video_Inputs_Response VideoInputResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.VideoInputsResponse = new API_v1_Video_Inputs_Response();
	}
}
