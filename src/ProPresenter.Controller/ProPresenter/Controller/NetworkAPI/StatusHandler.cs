using System;
using System.Linq;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.Controller.NetworkAPI;

public static class StatusHandler
{
	public static NetworkAPI_v1 Handle(IAPIv1Service service, API_v1_Status_Request request)
	{
		if (request != null)
		{
			if (request.GetAudienceScreens != null)
			{
				return GetAudienceScreens(service);
			}
			API_v1_Status_Request.Types.PutAudienceScreens putAudienceScreens = request.PutAudienceScreens;
			if (putAudienceScreens != null)
			{
				return PutAudienceScreens(service, putAudienceScreens.Enabled);
			}
			if (request.GetStageScreens != null)
			{
				return GetStageScreens(service);
			}
			API_v1_Status_Request.Types.PutStageScreens putStageScreens = request.PutStageScreens;
			if (putStageScreens != null)
			{
				return PutStageScreens(service, putStageScreens.Enabled);
			}
			if (request.GetSlide != null)
			{
				return GetSlide(service);
			}
			if (request.GetLayers != null)
			{
				return GetLayers();
			}
			if (request.GetScreens != null)
			{
				return GetScreens(service);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 GetAudienceScreens(IAPIv1Service service)
	{
		return AudienceScreenUpdate(service.Triggering.AudienceEnable);
	}

	internal static NetworkAPI_v1 AudienceScreenUpdate(bool enabled)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/status/audience_screens").StatusResponse().GetAudienceScreens = new API_v1_Status_Response.Types.GetAudienceScreens
			{
				Enabled = enabled
			};
		});
	}

	private static NetworkAPI_v1 PutAudienceScreens(IAPIv1Service service, bool enabled)
	{
		service.Dependencies.UiDispatcher.Invoke(delegate
		{
			if (enabled)
			{
				service.Triggering.ShowAudienceScreens();
			}
			else
			{
				service.Triggering.HideAudienceScreens();
			}
		});
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().StatusResponse().PutAudienceScreens = new API_v1_Status_Response.Types.PutAudienceScreens();
		});
	}

	private static NetworkAPI_v1 PutStageScreens(IAPIv1Service service, bool enabled)
	{
		service.Dependencies.UiDispatcher.Invoke(delegate
		{
			if (enabled)
			{
				service.Triggering.ShowStageScreens();
			}
			else
			{
				service.Triggering.HideStageScreens();
			}
		});
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().StatusResponse().PutStageScreens = new API_v1_Status_Response.Types.PutStageScreens();
		});
	}

	private static NetworkAPI_v1 GetStageScreens(IAPIv1Service service)
	{
		return StageScreenUpdate(service.Triggering.StageEnable);
	}

	internal static NetworkAPI_v1 StageScreenUpdate(bool enabled)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/status/stage_screens").StatusResponse().GetStageScreens = new API_v1_Status_Response.Types.GetStageScreens
			{
				Enabled = enabled
			};
		});
	}

	internal static NetworkAPI_v1 GetScreens(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/status/screens").StatusResponse().GetScreens = new API_v1_Status_Response.Types.GetScreens
			{
				Screens = { service.AudienceScreens.Concat(service.StageScreens).Select((ScreenArrangementBase s, int index) => s.ToApiV1ScreenInfo((uint)index)) }
			};
		});
	}

	private static API_v1_ScreenConfig ToApiV1ScreenInfo(this ScreenArrangementBase screen, uint index)
	{
		API_v1_ScreenConfig aPI_v1_ScreenConfig = new API_v1_ScreenConfig();
		aPI_v1_ScreenConfig.Id = Common.ID(screen.ID, screen.Name, index);
		aPI_v1_ScreenConfig.Size = screen.TotalSize.ToSize();
		API_v1_ScreenConfig aPI_v1_ScreenConfig2 = aPI_v1_ScreenConfig;
		aPI_v1_ScreenConfig2.ScreenType = screen.ScreenTargetType switch
		{
			ScreenTargetType.Audience => API_v1_ScreenType.Audience, 
			ScreenTargetType.Stage => API_v1_ScreenType.Stage, 
			_ => throw new NotImplementedException(), 
		};
		return aPI_v1_ScreenConfig;
	}

	private static NetworkAPI_v1 GetSlide(IAPIv1Service service)
	{
		return SlidesUpdated(service.Triggering.ActivePresentationSlide?.Source, service.Triggering.NextPresentationSlide?.Source);
	}

	internal static NetworkAPI_v1 SlidesUpdated(SlideCue? currentSlide, SlideCue? nextSlide)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/status/slide").StatusResponse().GetSlide = new API_v1_Status_Response.Types.GetSlide
			{
				Current = new API_v1_SlideDisplayDetails
				{
					Uuid = (currentSlide?.ID.ToString() ?? string.Empty),
					Text = string.Join(Environment.NewLine, currentSlide?.SlideAction?.Slide?.GetAllText() ?? Array.Empty<string>()),
					Notes = (currentSlide?.SlideAction?.Slide?.Note?.AllText ?? string.Empty)
				},
				Next = new API_v1_SlideDisplayDetails
				{
					Uuid = (nextSlide?.ID.ToString() ?? string.Empty),
					Text = string.Join(Environment.NewLine, nextSlide?.SlideAction?.Slide.GetAllText() ?? Array.Empty<string>()),
					Notes = (nextSlide?.SlideAction?.Slide?.Note?.AllText ?? string.Empty)
				}
			};
		});
	}

	private static NetworkAPI_v1 GetLayers()
	{
		LayerStatus current = LayerStatus.None;
		LayerStatusRequest.Publish(delegate(LayerStatus v)
		{
			current = v;
		});
		return LayerStatusChanged(current);
	}

	internal static NetworkAPI_v1 LayerStatusChanged(LayerStatus status)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/status/layers").StatusResponse().GetLayers = new API_v1_Status_Response.Types.GetLayers
			{
				VideoInput = status.HasFlag(LayerStatus.VideoInput),
				Slide = status.HasFlag(LayerStatus.Slide),
				Media = status.HasFlag(LayerStatus.Media),
				Announcements = status.HasFlag(LayerStatus.Announcements),
				Props = status.HasFlag(LayerStatus.Prop),
				Messages = status.HasFlag(LayerStatus.Messages),
				Audio = status.HasFlag(LayerStatus.Audio)
			};
		});
	}

	private static API_v1_Status_Response StatusResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.StatusResponse = new API_v1_Status_Response();
	}
}
