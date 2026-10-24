using System.Linq;
using System.Windows.Media;
using Pro.DO.Label;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.NetworkAPI;

internal static class GroupHandler
{
	internal static NetworkAPI_v1 Handle(IAPIv1Service service, API_v1_Groups_Request request)
	{
		if (request != null)
		{
			if (request.GroupsRequest != null)
			{
				return GetGroups(service);
			}
			API_v1_Groups_Request.Types.TriggerGroup triggerGroup = request.TriggerGroup;
			if (triggerGroup != null)
			{
				return TriggerGroup(service, triggerGroup.Id);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 GetGroups(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			uint index = 0u;
			v1.Action().GroupResponse().Groups = new API_v1_Groups_Response.Types.GroupsRequest
			{
				Groups = { service.Groups.Select((GroupLabel g) => new API_v1_Groups_Response.Types.GroupsRequest.Types.Group
				{
					Id = Common.ID(g, index++),
					Color = (g.Color ?? Colors.Transparent).ToProtoColor()
				}) }
			};
		});
	}

	private static NetworkAPI_v1 TriggerGroup(IAPIv1Service service, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(service.Groups, id, out ItemPacket<GroupLabel> packet))
			{
				if (service.Triggering.ActivePlaylistItem is IDocumentCue documentCue)
				{
					IDocumentAction documentAction = documentCue.DocumentAction;
					if (documentAction != null)
					{
						IArrangement activeArrangement = documentAction.ActiveArrangement;
						if (activeArrangement != null)
						{
							ArrangedCue cue = activeArrangement.ArrangedCues.FirstOrDefault((ArrangedCue c) => c.GroupLabel?.MasterLabel == packet.Item);
							if (cue != null)
							{
								service.Dependencies.UiDispatcher.Invoke(delegate
								{
									service.Triggering.TriggerSlide(cue);
								});
							}
						}
					}
				}
				v1.Action().GroupResponse().TriggerGroup = new API_v1_Groups_Response.Types.TriggerGroup();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static API_v1_Groups_Response GroupResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.GroupsResponse ?? (action.GroupsResponse = new API_v1_Groups_Response());
	}
}
