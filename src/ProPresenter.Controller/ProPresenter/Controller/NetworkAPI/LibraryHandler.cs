using System.Collections.Generic;
using System.Linq;
using Pro.Common.Nullability;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;

namespace ProPresenter.Controller.NetworkAPI;

public static class LibraryHandler
{
	internal static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Library_Request request)
	{
		if (request != null)
		{
			if (request.Libraries != null)
			{
				return GetLibraries(service);
			}
			API_v1_Library_Request.Types.Library library = request.Library;
			if (library != null)
			{
				return GetLibrary(service, library);
			}
			API_v1_Library_Request.Types.Trigger trigger = request.Trigger;
			if (trigger != null)
			{
				return TriggerLibrary(service, trigger);
			}
		}
		return null;
	}

	private static NetworkAPI_v1 GetLibraries(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().LibraryResponse().Libraries = new API_v1_Library_Response.Types.Libraries
			{
				Libraries_ = { service.Libraries.ToIdentifiers() }
			};
		});
	}

	private static NetworkAPI_v1? GetLibrary(IAPIv1Service service, API_v1_Library_Request.Types.Library getLibrary)
	{
		if (!Common.TryFindItem(service.Libraries, getLibrary.Id, out ItemPacket<ILibrary> packet))
		{
			return null;
		}
		return LibraryUpdated(packet.Item, API_v1_Library_Response.Types.Library.Types.UpdateType.All, packet.Item);
	}

	private static NetworkAPI_v1 TriggerLibrary(IAPIv1Service service, API_v1_Library_Request.Types.Trigger r)
	{
		if (Common.TryFindItem(service.Libraries, r.LibraryId, out ItemPacket<ILibrary> packet) && Common.TryFindItem(packet.Item, r.PresentationId, out ItemPacket<DocumentCue> packet2))
		{
			DocumentCue item = packet2.Item;
			item.DocumentAction.Presentation.ThrowWhenNull("documentCue.DocumentAction.Presentation");
			service.Dependencies.UiDispatcher.Invoke(item.DocumentAction.Presentation.EnsureLoaded);
			if (!item.DocumentAction.Presentation.IsAvailable)
			{
				return Common.Build(delegate(NetworkAPI_v1 v1)
				{
					v1.Action().Unauthorized();
				});
			}
			ArrangedCue cue = item.DocumentAction.ActiveArrangement?.ArrangedCues.ElementAtOrDefault((int)r.Index);
			if (cue != null)
			{
				SlideTriggerOptions option = new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, null, null, item);
				service.Dependencies.UiDispatcher.Invoke(delegate
				{
					service.Triggering.TriggerSlide(cue, option);
				});
				return Common.Build(delegate(NetworkAPI_v1 v1)
				{
					v1.Action().LibraryResponse().Triggger = new API_v1_Library_Response.Types.Trigger();
				});
			}
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	internal static NetworkAPI_v1 LibraryUpdated(ILibrary library, API_v1_Library_Response.Types.Library.Types.UpdateType type, IEnumerable<DocumentCue> items)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (library != null)
			{
				v1.StreamingAction("/v1/library/" + library.Name).LibraryResponse().Library = new API_v1_Library_Response.Types.Library
				{
					Items = { items.ToIdentifiers() },
					UpdateType = type
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static API_v1_Library_Response LibraryResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.LibraryResponse = new API_v1_Library_Response();
	}
}
