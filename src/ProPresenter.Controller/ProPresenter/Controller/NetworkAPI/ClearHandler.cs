using System;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.Controller.NetworkAPI;

public static class ClearHandler
{
	private static IClearGroupIconRenderer _renderer;

	public static void SetGroupIconRenderer(IClearGroupIconRenderer renderer)
	{
		if (_renderer != null)
		{
			throw new InvalidOperationException("Renderer can only be set once.");
		}
		_renderer = renderer;
	}

	internal static NetworkAPI_v1 Handle(ClearGroupCollection clearGroups, ITriggering triggering, IUiDispatcher dispatcher, API_v1_Clear_Request request, IEntityFactory entityFactory)
	{
		if (request != null)
		{
			API_v1_Clear_Request.Types.ClearLayer clearLayer = request.ClearLayer;
			if (clearLayer != null)
			{
				return ClearLayer(triggering, clearLayer);
			}
			if (request.GetGroups != null)
			{
				return Groups(clearGroups);
			}
			API_v1_Clear_Request.Types.CreateGroup createGroup = request.CreateGroup;
			if (createGroup != null)
			{
				return CreateClearGroup(clearGroups, dispatcher, createGroup);
			}
			API_v1_Clear_Request.Types.GetGroup getGroup = request.GetGroup;
			if (getGroup != null)
			{
				return GetGroup(clearGroups, getGroup.Id);
			}
			API_v1_Clear_Request.Types.GetGroupIcon getGroupIcon = request.GetGroupIcon;
			if (getGroupIcon != null)
			{
				return GetIcon(clearGroups, getGroupIcon);
			}
			API_v1_Clear_Request.Types.PutGroup putGroup = request.PutGroup;
			if (putGroup != null)
			{
				return UpdateGroup(clearGroups, dispatcher, putGroup);
			}
			API_v1_Clear_Request.Types.PutGroupIcon putGroupIcon = request.PutGroupIcon;
			if (putGroupIcon != null)
			{
				return PutGroupIcon(clearGroups, dispatcher, putGroupIcon);
			}
			API_v1_Clear_Request.Types.DeleteGroup deleteGroup = request.DeleteGroup;
			if (deleteGroup != null)
			{
				return DeleteGroup(clearGroups, dispatcher, deleteGroup);
			}
			API_v1_Clear_Request.Types.TriggerGroup triggerGroup = request.TriggerGroup;
			if (triggerGroup != null)
			{
				return TriggerGroup(clearGroups, triggering, triggerGroup);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 ClearLayer(ITriggering triggering, API_v1_Clear_Request.Types.ClearLayer layer)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			switch (layer.Layer)
			{
			case API_v1_LayerType.Audio:
				triggering.ClearAudio();
				break;
			case API_v1_LayerType.Props:
				triggering.ClearProps();
				break;
			case API_v1_LayerType.Messages:
				triggering.ClearMessages();
				break;
			case API_v1_LayerType.Slide:
				triggering.ClearSlide();
				break;
			case API_v1_LayerType.Announcements:
				triggering.ClearAnnouncement();
				break;
			case API_v1_LayerType.Media:
				triggering.ClearBackground();
				break;
			case API_v1_LayerType.VideoInput:
				triggering.ClearVideoInput();
				break;
			}
			v1.Action().ClearingResponse().ClearLayer = new API_v1_Clear_Response.Types.ClearLayer();
		});
	}

	private static NetworkAPI_v1 Groups(ClearGroupCollection clearGroups)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			uint index = 0u;
			v1.Action().ClearingResponse().GetGroups = new API_v1_Clear_Response.Types.GetGroups
			{
				Groups = { clearGroups.Select((ClearGroup g) => g.ToAPIClearGroup(index++)) }
			};
		});
	}

	private static NetworkAPI_v1 CreateClearGroup(ClearGroupCollection clearGroups, IUiDispatcher dispatcher, API_v1_Clear_Request.Types.CreateGroup group)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			ClearGroup newGroup = new ClearGroup();
			newGroup.UpdateGroup(group.Group);
			dispatcher.Invoke(delegate
			{
				clearGroups.AddClearGroup(newGroup);
			});
			int index = clearGroups.Count - 1;
			v1.Action().ClearingResponse().CreateGroup = new API_v1_Clear_Response.Types.CreateGroup
			{
				Group = newGroup.ToAPIClearGroup((uint)index)
			};
		});
	}

	private static NetworkAPI_v1 GetGroup(ClearGroupCollection clearGroups, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(clearGroups, id, out ItemPacket<ClearGroup> packet))
			{
				v1.Action().ClearingResponse().GetGroup = new API_v1_Clear_Response.Types.GetGroup
				{
					Group = packet.Item.ToAPIClearGroup(packet.Index)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 GetIcon(ClearGroupCollection clearGroups, API_v1_Clear_Request.Types.GetGroupIcon getGroupIcon)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(clearGroups, getGroupIcon.Id, out ItemPacket<ClearGroup> packet))
			{
				v1.Action().ClearingResponse().GetGroupIcon = new API_v1_Clear_Response.Types.GetGroupIcon
				{
					Icon = _renderer.Render(packet.Item),
					ContentType = ((packet.Item.ImageType == ImageType.Custom) ? "image/png" : "image/svg+xml")
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 UpdateGroup(ClearGroupCollection clearGroups, IUiDispatcher dispatcher, API_v1_Clear_Request.Types.PutGroup putGroup)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(clearGroups, putGroup.Id, out ItemPacket<ClearGroup> group))
			{
				dispatcher.Invoke(delegate
				{
					group.Item.UpdateGroup(putGroup.Group);
				});
				v1.Action().ClearingResponse().PutGroup = new API_v1_Clear_Response.Types.PutGroup
				{
					Group = group.Item.ToAPIClearGroup(group.Index)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 PutGroupIcon(ClearGroupCollection clearGroups, IUiDispatcher dispatcher, API_v1_Clear_Request.Types.PutGroupIcon putGroupIcon)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(clearGroups, putGroupIcon.Id, out ItemPacket<ClearGroup> packet))
			{
				ClearGroup group = packet.Item;
				dispatcher.Invoke(delegate
				{
					group.ImageType = ImageType.Custom;
					group.Icon = putGroupIcon.Icon.ToBitmapSource();
				});
				v1.Action().ClearingResponse().PutGroupIcon = new API_v1_Clear_Response.Types.PutGroupIcon();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 DeleteGroup(ClearGroupCollection clearGroups, IUiDispatcher dispatcher, API_v1_Clear_Request.Types.DeleteGroup deleteGroup)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(clearGroups, deleteGroup.Id, out ItemPacket<ClearGroup> group))
			{
				dispatcher.Invoke(delegate
				{
					clearGroups.RemoveClearGroup(group.Item);
				});
				v1.Action().ClearingResponse().DeleteGroup = new API_v1_Clear_Response.Types.DeleteGroup();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 TriggerGroup(ClearGroupCollection clearGroups, ITriggering triggering, API_v1_Clear_Request.Types.TriggerGroup triggerGroup)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(clearGroups, triggerGroup.Id, out ItemPacket<ClearGroup> packet))
			{
				triggering.TriggerClearGroup(packet.Item);
				v1.Action().ClearingResponse().TriggerGroup = new API_v1_Clear_Response.Types.TriggerGroup();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static API_v1_Clear_Response ClearingResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.ClearingResponse = new API_v1_Clear_Response();
	}

	private static API_v1_ClearGroup ToAPIClearGroup(this ClearGroup group, uint index)
	{
		bool flag = group.Icon?.Format.HasTransparency() ?? true;
		return new API_v1_ClearGroup
		{
			Id = Common.ID(group.ID, group.Name, index),
			Icon = group.ImageType.ToString(),
			Tint = ((group.IsIconTinted && flag) ? group.IconTint.ToProtoColor() : null),
			StopTimelineAnnouncements = group.TimelineTargets.Contains(OutputDestination.Announcement),
			StopTimelinePresentation = group.TimelineTargets.Contains(OutputDestination.Presentation),
			ClearNextPresentation = group.ClearNextSlide,
			Layers = { group.ClearTargets.Select((ClearType l) => l.ToProtoAPILayerType()) }
		};
	}

	private static void UpdateGroup(this ClearGroup group, API_v1_ClearGroup protoGroup)
	{
		group.Name = protoGroup.Id.Name;
		group.ImageType = Enum.GetValues<ImageType>().FirstOrDefault((ImageType i) => i.ToString().ToLower() == protoGroup.Icon.ToLower());
		group.Icon = null;
		group.IsIconTinted = protoGroup.Tint != null;
		group.IconTint = protoGroup.Tint.ToColor();
		group.ClearNextSlide = protoGroup.ClearNextPresentation;
		group.ClearTargetLayers();
		protoGroup.Layers.ForEach(delegate(API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType l)
		{
			group.ToggleClearTarget(l.ToClearType());
		});
		group.ClearTimelineTargets();
		if (protoGroup.StopTimelineAnnouncements)
		{
			group.ToggleTimelineTarget(OutputDestination.Announcement);
		}
		if (protoGroup.StopTimelinePresentation)
		{
			group.ToggleTimelineTarget(OutputDestination.Presentation);
		}
	}
}
