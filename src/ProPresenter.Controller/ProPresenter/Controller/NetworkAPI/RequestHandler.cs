using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Analytics;

namespace ProPresenter.Controller.NetworkAPI;

public class RequestHandler
{
	private readonly IAPIv1Service _service;

	public RequestHandler(IAPIv1Service service)
	{
		_service = service;
	}

	public ProApiOut? Handle(NetworkAPI_v1 v1)
	{
		MessageReceived.Publish();
		NetworkAPI_v1 networkAPI_v = _service.Dependencies.UiDispatcher.Invoke(delegate
		{
			NetworkAPI_v1.Types.Action action = v1?.Action;
			if (action != null)
			{
				API_v1_Announcement_Request announcementRequest = action.AnnouncementRequest;
				if (announcementRequest != null)
				{
					return PresentationHandler.Handle(_service, announcementRequest);
				}
				API_v1_Audio_Request audioRequest = action.AudioRequest;
				if (audioRequest != null)
				{
					return AudioHandler.Handle(_service, audioRequest);
				}
				API_v1_Capture_Request captureRequest = action.CaptureRequest;
				if (captureRequest != null)
				{
					return CaptureHandler.Handle(_service.Dependencies.CaptureService, _service.Dependencies.ResiService, _service.Dependencies.UiDispatcher, captureRequest);
				}
				API_v1_Clear_Request clearingRequest = action.ClearingRequest;
				if (clearingRequest != null)
				{
					return ClearHandler.Handle(_service.ClearGroups, _service.Triggering, _service.Dependencies.UiDispatcher, clearingRequest, _service.Dependencies.FactoryProvider.EntityFactory);
				}
				API_v1_Groups_Request groupsRequest = action.GroupsRequest;
				if (groupsRequest != null)
				{
					return GroupHandler.Handle(_service, groupsRequest);
				}
				API_v1_Library_Request libraryRequest = action.LibraryRequest;
				if (libraryRequest != null)
				{
					return LibraryHandler.Handle(_service, libraryRequest);
				}
				if (action.LinkRequest != null)
				{
					return (NetworkAPI_v1)null;
				}
				API_v1_Looks_Request looksRequest = action.LooksRequest;
				if (looksRequest != null)
				{
					return LookHandler.Handle(_service.Looks, _service.LiveLook, _service.Triggering, _service.Dependencies.UiDispatcher, looksRequest, _service.Themes, _service.Masks);
				}
				API_v1_Macro_Request macroRequest = action.MacroRequest;
				if (macroRequest != null)
				{
					return MacroHandler.Handle(_service, macroRequest);
				}
				API_v1_Masks_Request masksRequest = action.MasksRequest;
				if (masksRequest != null)
				{
					return MaskHandler.Handle(_service.Masks, masksRequest);
				}
				API_v1_Media_Request mediaRequest = action.MediaRequest;
				if (mediaRequest != null)
				{
					return MediaHandler.Handle(_service, mediaRequest);
				}
				API_v1_Message_Request messageRequest = action.MessageRequest;
				if (messageRequest != null)
				{
					return MessageHandler.Handle(_service, messageRequest);
				}
				API_v1_Miscellaneous_Request miscellaneousRequest = action.MiscellaneousRequest;
				if (miscellaneousRequest != null)
				{
					return MiscHandler.Handle(_service.Dependencies.UiDispatcher, miscellaneousRequest);
				}
				API_v1_Playlist_Request playlistRequest = action.PlaylistRequest;
				if (playlistRequest != null)
				{
					return LibraryPlaylistHandler.Handle(_service, playlistRequest);
				}
				if (action.PrerollRequest != null)
				{
					return (NetworkAPI_v1)null;
				}
				API_v1_Presentation_Request presentationRequest = action.PresentationRequest;
				if (presentationRequest != null)
				{
					return PresentationHandler.Handle(_service, presentationRequest);
				}
				API_v1_Prop_Request propRequest = action.PropRequest;
				if (propRequest != null)
				{
					return PropHandler.Handle(_service.Props, _service.Triggering, _service.Dependencies.UiDispatcher, propRequest);
				}
				API_v1_Stage_Request stageRequest = action.StageRequest;
				if (stageRequest != null)
				{
					return StageHandler.Handle(_service, stageRequest);
				}
				API_v1_Status_Request statusRequest = action.StatusRequest;
				if (statusRequest != null)
				{
					return StatusHandler.Handle(_service, statusRequest);
				}
				API_v1_Theme_Request themeRequest = action.ThemeRequest;
				if (themeRequest != null)
				{
					return ThemeHandler.Handle(_service, themeRequest);
				}
				API_v1_Timer_Request timerRequest = action.TimerRequest;
				if (timerRequest != null)
				{
					return TimerHandler.Handle(_service.Timers, _service.Triggering, _service.Dependencies.UiDispatcher, _service.Dependencies.FactoryProvider, timerRequest);
				}
				API_v1_Transport_Request transportRequest = action.TransportRequest;
				if (transportRequest != null)
				{
					return TransportHandler.Handle(_service, transportRequest);
				}
				API_v1_Trigger_Request triggerRequest = action.TriggerRequest;
				if (triggerRequest != null)
				{
					return TriggerHandler.Handle(_service, triggerRequest);
				}
				API_v1_Video_Inputs_Request videoInputsRequest = action.VideoInputsRequest;
				if (videoInputsRequest != null)
				{
					return VideoInputHandler.Handle(_service, videoInputsRequest);
				}
			}
			return (NetworkAPI_v1)null;
		});
		if (networkAPI_v == null)
		{
			return null;
		}
		return new ProApiOut
		{
			NetworkApiV1 = networkAPI_v
		};
	}
}
