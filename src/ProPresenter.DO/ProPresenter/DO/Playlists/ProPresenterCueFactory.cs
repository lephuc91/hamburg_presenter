using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Extensions;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.DO.Playlists;

public class ProPresenterCueFactory : IProPresenterCueFactory
{
	private readonly IApp _app;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public ProPresenterCueFactory(IApp app, IProPresenterResourceService resourceService, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_app = app;
		_resourceService = resourceService;
		_factoryProvider = factoryProvider;
		_mediaFactory = factoryProvider.MediaFactory;
		_transitionDescriptions = transitionDescriptions;
	}

	public void Deserialize(ObservableCollection<ProPresenterCue> collection, IEnumerable<PlaylistItem> items, ApplicationData? applicationData, bool removeExisting, string containerId)
	{
		PlaylistLibraryHelper.DeserializePlaylistItems(collection, items, applicationData, _app, _resourceService, _mediaFactory, _transitionDescriptions, this, containerId, removeExisting);
	}

	public ProPresenterCue CreateHeader(string name)
	{
		return new HeaderCue(new HeaderAction(name, new TimerAction(_resourceService.Timers?.FirstOrDefault()?.ID ?? Guid.Empty)));
	}

	public ProPresenterCue CreatePlaceholder(string name)
	{
		return new PlaceholderCue(name, _app, _resourceService, _mediaFactory, _transitionDescriptions);
	}

	public ProPresenterCue CreateDocumentCue(IDocumentAction action, bool clone)
	{
		return new DocumentCue(action, clone);
	}

	public ProPresenterCue? CreateDocumentCue(IPlaylistItem.Types.IItemType.IPresentation documentItem)
	{
		return new DocumentCue(new DocumentAction(documentItem));
	}

	public ProPresenterCue CreateMediaCue(MediaBase? media)
	{
		MediaCue mediaCue = new MediaCue(_app, media, _transitionDescriptions);
		MediaAction? mediaAction = mediaCue.MediaAction;
		if (mediaAction != null)
		{
			mediaAction.ToForeground();
			return mediaCue;
		}
		return mediaCue;
	}

	public ProPresenterCue CreateMediaCue(string file, string containerId)
	{
		return CreateMediaCue(_mediaFactory.CreateMedia(file, containerId, null));
	}

	public ProPresenterCue? CreateMediaCue(IAction.Types.IActionTypeData.IMedia entityMedia, string containerId)
	{
		IMedia value = entityMedia.Value.Element.Value;
		MediaBase media = null;
		if (value.TypeProperties.Value is IMedia.Types.ITypeProperties.IAudio)
		{
			media = _mediaFactory.CreateAudioMedia(containerId, null);
		}
		else if (value.TypeProperties.Value is IMedia.Types.ITypeProperties.IImage)
		{
			media = _mediaFactory.CreateVisualMedia(containerId, null);
		}
		else if (value.TypeProperties.Value is IMedia.Types.ITypeProperties.IVideo)
		{
			media = _mediaFactory.CreateVideoMedia(containerId, null);
		}
		else if (value.TypeProperties.Value is IMedia.Types.ITypeProperties.ILiveVideo)
		{
			media = _mediaFactory.CreateLiveVideoMedia();
		}
		return CreateMediaCue(media);
	}

	public ProPresenterCue CreateSlideCue()
	{
		return new SlideCue(_factoryProvider, new CustomSlide(_factoryProvider, _transitionDescriptions), _transitionDescriptions);
	}

	public PCOCueBase CreatePCOCue(PCOItem item, string? planID, string serviceID)
	{
		if (!(item is PCOPlanItem planItem))
		{
			if (!(item is PCOPlanHeader planHeader))
			{
				if (!(item is PCOPlanSong planSong))
				{
					if (item is PCOPlanMedia planMedia)
					{
						return new PCOMediaCue(planMedia, planID, serviceID, _app, _mediaFactory, _transitionDescriptions);
					}
					throw new NotSupportedException("Unknown PCO-item type.");
				}
				return new PCOSongCue(planSong, planID, serviceID, _app, _mediaFactory, _transitionDescriptions);
			}
			return new PCOHeaderCue(planHeader, planID, serviceID, _mediaFactory, _transitionDescriptions);
		}
		return new PCOPlanCue(planItem, planID, serviceID, _app, _mediaFactory, _transitionDescriptions);
	}

	public ProPresenterCue? CreateCue(IPlaylistItem entityPlaylistItem, string containerId)
	{
		if (entityPlaylistItem.ItemType.Value is IPlaylistItem.Types.IItemType.ICue cue)
		{
			if (cue.Value.Actions.Items.FirstOrDefault()?.ActionTypeData.Value is IAction.Types.IActionTypeData.IMedia entityMedia)
			{
				return CreateMediaCue(entityMedia, containerId);
			}
			return null;
		}
		if (entityPlaylistItem.ItemType.Value is IPlaylistItem.Types.IItemType.IHeader)
		{
			return CreateHeader(entityPlaylistItem.Name.Value);
		}
		if (entityPlaylistItem.ItemType.Value is IPlaylistItem.Types.IItemType.IPlaceholder)
		{
			return CreatePlaceholder(entityPlaylistItem.Name.Value);
		}
		if (entityPlaylistItem.ItemType.Value is IPlaylistItem.Types.IItemType.IPresentation documentItem)
		{
			return CreateDocumentCue(documentItem);
		}
		if (entityPlaylistItem.ItemType.Value is IPlaylistItem.Types.IItemType.IPlanningCenter planningCenter)
		{
			IPlanningCenterPlan.Types.IPlanItem value = planningCenter.Value.Item.Value;
			string id = IdExtensions.FromProto(value.PcoIdStr.Value, value.PcoIdNum.Value);
			string text = IdExtensions.FromProto(value.ParentIdStr.Value, value.ParentIdNum.Value);
			string serviceID = IdExtensions.FromProto(value.ServiceIdStr.Value, value.ServiceIdNum.Value);
			DateTime value2 = value.UpdateDate.Value.Seconds.FromUnixTimestamp();
			IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem value3 = planningCenter.Value.Item.Value.LinkedSong.Value;
			string songId = IdExtensions.FromProto(value3?.PcoIdStr.Value, value3?.PcoIdNum.Value ?? 0);
			string songArrangmentId = IdExtensions.FromProto(value3?.ArrangementIdStr.Value, value3?.ArrangementIdNum.Value ?? 0);
			return CreatePCOCue(planningCenter.Value.Item.Value.ItemType.Value switch
			{
				IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Item => new PCOPlanItem(id, value.Name.Value, text, value2, serviceID), 
				IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Header => new PCOPlanHeader(id, value.Name.Value, text, value2, serviceID), 
				IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Media => new PCOPlanMedia(id, value.Name.Value, text, value2, serviceID), 
				_ => new PCOPlanSong(id, value.Name.Value, text, value2, serviceID, songId, songArrangmentId), 
			}, text, serviceID);
		}
		return null;
	}
}
