using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Extensions;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

public static class PlaylistLibraryHelper
{
	public static void DeserializePlaylists(ObservableCollection<IPlaylist<ProPresenterCue>> collection, IEnumerable<Playlist> protoPlaylists, System.Action dataModified, UndoStack? undoStack, GeneralGroupPlaylist? parent, ApplicationData? applicationData, IProPresenterResourceService resourceService, IImportProcessFactory importProcessFactory, ILogger logger, IProPresenterCueFactory cueFactory, IMediaFactory mediaFactory, bool removeExisting = true)
	{
		collection.DeserializeCollection(protoPlaylists, (IPlaylist<ProPresenterCue> p, Playlist n) => p.ID == n.Uuid.ToGuid(), (Playlist n) => ConstructPlaylist(n, undoStack, resourceService, importProcessFactory, logger, cueFactory, mediaFactory), delegate(IPlaylist<ProPresenterCue> p)
		{
			AddPlaylist(collection, p, parent);
		}, delegate(IPlaylist<ProPresenterCue> p)
		{
			if (removeExisting)
			{
				RemovePlaylist(collection, p, dataModified);
			}
		}, delegate(IPlaylist<ProPresenterCue> p, Playlist n)
		{
			DeserializePlaylist(p, n, dataModified, applicationData, removeExisting);
		});
	}

	public static void DeserializePlaylistItems(ObservableCollection<ProPresenterCue> collection, IEnumerable<PlaylistItem> protoPlaylistItems, ApplicationData? applicationData, IApp app, IProPresenterResourceService resources, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IProPresenterCueFactory cueFactory, string containerId, bool removeExisting = true)
	{
		collection.DeserializeCollection(protoPlaylistItems, (ProPresenterCue i, PlaylistItem c) => i?.ID == c.Uuid.ToGuid(), (PlaylistItem proto) => ConstructPlaylistItem(proto, app, resources, mediaFactory, transitionDescriptions, cueFactory), delegate(ProPresenterCue i)
		{
			if (i != null)
			{
				collection.Add(i);
			}
		}, delegate(ProPresenterCue i)
		{
			if (i != null && removeExisting)
			{
				collection.Remove(i);
			}
		}, delegate(ProPresenterCue i, PlaylistItem n)
		{
			if (i != null)
			{
				i.ProtoDeserializePlaylistItem(n, applicationData, containerId);
				int num = protoPlaylistItems.IndexOf(n);
				int num2 = collection.IndexOf(i);
				if (num != -1 && num != num2)
				{
					collection.MoveTo(i.ToEnumerable(), num);
				}
			}
		});
	}

	private static void RemovePlaylist(ObservableCollection<IPlaylist<ProPresenterCue>> collection, IPlaylist<ProPresenterCue> playlist, System.Action dataModified)
	{
		playlist.DataModified -= dataModified;
		collection.Remove(playlist);
	}

	public static IPlaylist<ProPresenterCue> ConstructPlaylist(Playlist protoPlaylist, UndoStack? undoStack, IProPresenterResourceService resourceService, IImportProcessFactory importProcessFactory, ILogger logger, IProPresenterCueFactory cueFactory, IMediaFactory mediaFactory)
	{
		if (protoPlaylist.Items != null)
		{
			if (protoPlaylist.PcoPlan == null)
			{
				return new GeneralPlaylist(logger, cueFactory, undoStack);
			}
			return new PCOPlaylist(resourceService, importProcessFactory, new PCOPlan(), undoStack, cueFactory, mediaFactory);
		}
		if (protoPlaylist.Playlists != null)
		{
			return new GeneralGroupPlaylist(resourceService, importProcessFactory, logger, cueFactory, mediaFactory, undoStack);
		}
		throw new NotSupportedException();
	}

	private static void AddPlaylist(ObservableCollection<IPlaylist<ProPresenterCue>> collection, IPlaylist<ProPresenterCue> playlist, GeneralGroupPlaylist? parent)
	{
		playlist.PlaylistParent = parent;
		collection.Add(playlist);
	}

	private static void DeserializePlaylist(IPlaylist<ProPresenterCue> playlist, Playlist protoPlaylist, System.Action dataModified, ApplicationData? applicationData, bool removeExisting)
	{
		playlist.DataModified -= dataModified;
		playlist.ProtoDeserialize(protoPlaylist, applicationData, removeExisting);
		playlist.DataModified += dataModified;
	}

	private static ProPresenterCue? ConstructPlaylistItem(PlaylistItem? playlistItem, IApp app, IProPresenterResourceService resources, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IProPresenterCueFactory cueFactory)
	{
		if (playlistItem != null)
		{
			if (playlistItem.Header != null)
			{
				return new HeaderCue(new HeaderAction());
			}
			if (playlistItem.Placeholder != null)
			{
				return new PlaceholderCue(app, resources, mediaFactory, transitionDescriptions);
			}
			if (playlistItem.Cue != null)
			{
				Pro.SerializationInterop.RVProtoData.Action action = playlistItem.Cue.Actions.FirstOrDefault();
				Pro.SerializationInterop.RVProtoData.Action.Types.ActionType? actionType = action?.Type;
				if (actionType.HasValue && actionType == Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media)
				{
					return new MediaCue(app, null, transitionDescriptions);
				}
				Log.Warning($"Failed to parse action type {action?.Type.ToString() ?? "(null)"} from playlist item named {playlistItem.Name ?? "(null)"}. Ignoring it.");
				return null;
			}
			if (playlistItem.Presentation != null)
			{
				ProPresenterCue proPresenterCue = (ProPresenterCue)(resources.LibraryCollection.FindDocument(new RelativePath(playlistItem.Presentation.DocumentPath))?.Clone());
				if (proPresenterCue == null)
				{
					proPresenterCue = new DocumentCue(new RelativePath(playlistItem.Presentation.DocumentPath));
				}
				return proPresenterCue;
			}
			if (playlistItem.PlanningCenter?.Item != null)
			{
				string serviceID = IdExtensions.FromProto(playlistItem.PlanningCenter.Item.ServiceIdStr, playlistItem.PlanningCenter.Item.ServiceIdNum);
				PCOItem pCOItem = playlistItem.PlanningCenter.Item.ItemType switch
				{
					PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Item => new PCOPlanItem(playlistItem.PlanningCenter.Item, serviceID), 
					PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Header => new PCOPlanHeader(playlistItem.PlanningCenter.Item, serviceID), 
					PlanningCenterPlan.Types.PlanItem.Types.PlanItemType.Media => new PCOPlanMedia(playlistItem.PlanningCenter.Item, serviceID), 
					_ => new PCOPlanSong(playlistItem.PlanningCenter.Item, serviceID), 
				};
				return cueFactory.CreatePCOCue(pCOItem, pCOItem.PlanID, serviceID);
			}
		}
		Log.Warning("Failed to parse playlist item named " + (playlistItem?.Name ?? "(null)") + ". Ignoring it.");
		return null;
	}
}
