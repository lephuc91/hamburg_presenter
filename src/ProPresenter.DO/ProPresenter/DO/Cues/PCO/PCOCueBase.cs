using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.PCO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Extensions;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Cues.PCO;

public abstract class PCOCueBase : ProPresenterCue, IDocumentCue, IFileResource, INotifyPropertyChanged, IActionRepoContainer, IHasMediaContainerId, IMediaCue, ILinkableCue
{
	private readonly IMediaFactory _mediaFactory;

	private readonly LibraryCollection? _libraries;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private PCOItem? _pcoItem;

	public override string Name
	{
		get
		{
			return DocumentAction?.Name ?? MediaAction?.Name ?? PCOItem?.Name ?? string.Empty;
		}
		set
		{
		}
	}

	public override CueType Type => CueType.PCO;

	public abstract PCOItemType PCOItemType { get; }

	public PCOItem? PCOItem
	{
		get
		{
			return _pcoItem;
		}
		set
		{
			SetValue("PCOItem", ref _pcoItem, value, (System.Action)delegate
			{
				OnPropertyChanged("Name");
				OnPropertyChanged("Song");
			}, (Predicate<PCOItem>?)null, referenceComparison: false);
		}
	}

	public DateTime? UpdatedAt { get; set; }

	public string? PlanID { get; protected set; }

	public string ServiceID { get; protected set; }

	public PCOActionBase? PCOAction => base.Actions.FirstOrDefault() as PCOActionBase;

	public IDocumentAction? DocumentAction => PCOAction?.DocumentAction;

	public string? LibraryName => DocumentAction?.LibraryName;

	public MediaAction? MediaAction => PCOAction?.MediaAction;

	public bool IsLinked
	{
		get
		{
			PCOActionBase? pCOAction = PCOAction;
			if (pCOAction == null)
			{
				return false;
			}
			return pCOAction.LinkState == PCOLinkStates.Linked;
		}
	}

	private List<PCOUpdateInformation> UploadRequests { get; } = new List<PCOUpdateInformation>();

	public PCOSongDetails? Song => (PCOItem as PCOPlanSong)?.Song;

	public RelativePath? Path
	{
		get
		{
			object obj = DocumentAction?.Presentation?.SourceFile;
			if (obj == null)
			{
				MediaAction? mediaAction = MediaAction;
				if (mediaAction == null)
				{
					return null;
				}
				FileMediaBase? fileMedia = mediaAction.FileMedia;
				if (fileMedia == null)
				{
					return null;
				}
				obj = fileMedia.SourceFile;
			}
			return (RelativePath?)obj;
		}
	}

	public Playlist<ProPresenterCue>? PlaylistParent { get; set; }

	public static event Action<PCOCueBase>? ItemLinked;

	public override IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right)
	{
		IPlaylistItem.Types.IItemType.IPlanningCenter planningCenter = right.ItemType.Value as IPlaylistItem.Types.IItemType.IPlanningCenter;
		if (planningCenter == null)
		{
			planningCenter = entityFactory.Create<IPlaylistItem.Types.IItemType.IPlanningCenter>();
			right.ItemType.Set(planningCenter);
		}
		IDisposable linkDataBinder = null;
		ObjectBinder<PCOCueBase, IPlaylistItem.Types.IPlanningCenter> planningCenterBinder = new ObjectBinder<PCOCueBase, IPlaylistItem.Types.IPlanningCenter>(this, planningCenter.Value);
		planningCenterBinder.Bind((PCOCueBase l) => l.WhenPropertyChanges("PCOItem"), (IPlaylistItem.Types.IPlanningCenter r) => r.Item.WhenAnyValueChanges, delegate(PCOCueBase l, IPlaylistItem.Types.IPlanningCenter r)
		{
			r.Item.Value.ItemType.Set(l.PCOItem?.PCOItemType.ToEntityPlanItemType() ?? IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Item);
			r.Item.Value.PcoIdNum.Set(l.PCOItem?.ID.ToUintId() ?? 0);
			r.Item.Value.PcoIdStr.Set(l.PCOItem?.ID ?? string.Empty);
			r.Item.Value.ServiceIdNum.Set(l.PCOItem?.ServiceId.ToUintId() ?? 0);
			r.Item.Value.ServiceIdStr.Set(l.PCOItem?.ServiceId ?? string.Empty);
			r.Item.Value.ParentIdNum.Set(l.PCOItem?.PlanID.ToUintId() ?? 0);
			r.Item.Value.ParentIdStr.Set(l.PCOItem?.PlanID ?? string.Empty);
			r.Item.Value.Name.Set(l.PCOItem?.Name ?? string.Empty);
			r.Item.Value.UpdateDate.Set(new Pro.Entity.Timestamp(l.UpdatedAt?.ToUnixTimestamp() ?? 0, 0));
		}, delegate(IPlaylistItem.Types.IPlanningCenter r, PCOCueBase l)
		{
			l.PCOItem = CreatePCOItem(r.Item.Value);
		}).RegisterChildDisposable(() => linkDataBinder);
		CreateLinkDataBinder(scheduler, entityFactory, actionBinderFactory, planningCenterBinder);
		ObjectBinder<PCOCueBase, IPlaylistItem> objectBinder = new ObjectBinder<PCOCueBase, IPlaylistItem>(this, right);
		objectBinder.Bind((PCOCueBase l) => l.WhenPropertyChanges("Name"), (IPlaylistItem r) => r.Name.WhenValueChanges, delegate(PCOCueBase l, IPlaylistItem r)
		{
			r.Name.Set(l.Name);
		}, delegate(IPlaylistItem r, PCOCueBase l)
		{
			l.Name = r.Name.Value;
		}).DoOnInitializeLeftFromRight(planningCenterBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(planningCenterBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => planningCenterBinder);
		return objectBinder;
	}

	protected virtual void CreateLinkDataBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, ObjectBinder<PCOCueBase, IPlaylistItem.Types.IPlanningCenter> cueBinder)
	{
		cueBinder.Bind((PCOCueBase l) => l.WhenPropertyChanges("IsLinked"), (IPlaylistItem.Types.IPlanningCenter r) => r.LinkedData.WhenValueChanges, delegate(PCOCueBase l, IPlaylistItem.Types.IPlanningCenter r)
		{
			if (IsLinked)
			{
				IPlaylistItem playlistItem = null;
				if (l.PCOAction?.DocumentAction != null)
				{
					playlistItem = entityFactory.Create<IPlaylistItem>();
					IPlaylistItem.Types.IItemType.IPresentation presentation = entityFactory.Create<IPlaylistItem.Types.IItemType.IPresentation>();
					IPlaylistItem.Types.IPresentation presentation2 = entityFactory.Create<IPlaylistItem.Types.IPresentation>();
					presentation.Set(presentation2);
					ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> objectBinder = l.PCOAction.DocumentAction.CreatePlaylistBinder(scheduler, entityFactory, presentation2);
					objectBinder.InitializeRightFromLeft();
					playlistItem.ItemType.Set(presentation);
					playlistItem.RegisterLinkedDisposable(objectBinder);
				}
				else if (l.PCOAction?.MediaAction != null)
				{
					playlistItem = entityFactory.Create<IPlaylistItem>();
					IPlaylistItem.Types.IItemType.ICue cue = entityFactory.Create<IPlaylistItem.Types.IItemType.ICue>();
					ICue cue2 = entityFactory.Create<ICue>();
					cue.Set(cue2);
					Pro.Entity.IAction action = entityFactory.Create<Pro.Entity.IAction>();
					cue2.Actions.Add(action);
					IReadOnlyObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> readOnlyObjectBinder = actionBinderFactory.CreateBinder(l.PCOAction.MediaAction, action);
					readOnlyObjectBinder.InitializeRightFromLeft();
					playlistItem.ItemType.Set(cue);
					playlistItem.RegisterLinkedDisposable(readOnlyObjectBinder);
				}
				r.LinkedData.Set(playlistItem);
			}
			else
			{
				r.LinkedData.Set(null);
			}
		}, delegate(IPlaylistItem.Types.IPlanningCenter r, PCOCueBase l)
		{
			if (l.PCOAction != null)
			{
				if (r.LinkedData.Value?.ItemType.Value is IPlaylistItem.Types.IItemType.IPresentation { Value: { } value } presentation3)
				{
					DocumentAction documentAction = new DocumentAction(presentation3);
					l.PCOAction.LinkDocument(documentAction);
					ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> objectBinder2 = documentAction.CreatePlaylistBinder(scheduler, entityFactory, value);
					objectBinder2.InitializeLeftFromRight();
					presentation3.RegisterLinkedDisposable(objectBinder2);
				}
				else if (r.LinkedData.Value?.ItemType.Value is IPlaylistItem.Types.IItemType.ICue { Value: { } value2 } cue3)
				{
					Pro.Entity.IAction action2 = value2.Actions.Items.FirstOrDefault();
					if (action2 != null && actionBinderFactory.CreateAction(action2, l.ContainerId) is MediaAction mediaAction)
					{
						l.PCOAction.LinkMedia(mediaAction);
						IReadOnlyObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> readOnlyObjectBinder2 = actionBinderFactory.CreateBinder(mediaAction, action2);
						readOnlyObjectBinder2.InitializeLeftFromRight();
						cue3.RegisterLinkedDisposable(readOnlyObjectBinder2);
					}
				}
				else
				{
					l.UnlinkItem();
				}
			}
		});
	}

	private static PCOItem? CreatePCOItem(IPlanningCenterPlan.Types.IPlanItem item)
	{
		string id = IdExtensions.FromProto(item.PcoIdStr.Value, item.PcoIdNum.Value);
		string planId = IdExtensions.FromProto(item.ParentIdStr.Value, item.ParentIdNum.Value);
		string serviceID = IdExtensions.FromProto(item.ServiceIdStr.Value, item.ServiceIdNum.Value);
		DateTime value = item.UpdateDate.Value.Seconds.FromUnixTimestamp();
		IPlanningCenterPlan.Types.IPlanItem.Types.ISongItem value2 = item.LinkedSong.Value;
		string songId = IdExtensions.FromProto(value2?.PcoIdStr.Value, value2?.PcoIdNum.Value ?? 0);
		string songArrangmentId = IdExtensions.FromProto(value2?.ArrangementIdStr.Value, value2?.ArrangementIdNum.Value ?? 0);
		return item.ItemType.Value switch
		{
			IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Item => new PCOPlanItem(id, item.Name.Value, planId, value, serviceID), 
			IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Header => new PCOPlanHeader(id, item.Name.Value, planId, value, serviceID), 
			IPlanningCenterPlan.Types.IPlanItem.Types.PlanItemType.Media => new PCOPlanMedia(id, item.Name.Value, planId, value, serviceID), 
			_ => new PCOPlanSong(id, item.Name.Value, planId, value, serviceID, songId, songArrangmentId), 
		};
	}

	protected PCOCueBase(IMediaFactory mediaFactory, ActionBase pcoAction, PCOItem pcoItem, string? planID, string serviceID, ITransitionDescriptionCollection transitionDescriptions, LibraryCollection? libraries = null)
	{
		_mediaFactory = mediaFactory;
		AddAction(pcoAction);
		PCOItem = pcoItem;
		PlanID = planID;
		ServiceID = serviceID;
		UpdatedAt = DateTime.Now;
		_libraries = libraries ?? DataVault.LibraryCollection;
		_transitionDescriptions = transitionDescriptions;
		LinkProperties("LinkState", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "Name", "IsLinked" }));
		LinkProperties("DocumentAction", "DocumentAction");
		LinkProperties("MediaAction", "MediaAction");
		pcoAction.DataModified += PCOCueBase_DataModified;
		pcoAction.PropertyChanged += base.RaiseLinkedValues;
	}

	public void LinkMedia(MediaBase? media, bool addUpdateRequest = true)
	{
		if (media != null)
		{
			if (PCOAction != null)
			{
				PCOAction.LinkState = PCOLinkStates.Linking;
			}
			OnLinkMedia(media, addUpdateRequest);
			if (MediaAction != null && string.IsNullOrEmpty(MediaAction.Name) && media is FileMediaBase fileMediaBase)
			{
				MediaAction.Name = fileMediaBase.SourceFile.Name;
			}
			OnPropertyChanged("Name");
		}
	}

	public void LinkDocument(ProPresenter.DO.Presentation.IPresentation? document, bool addUpdateRequest = true)
	{
		if (document != null)
		{
			if (PCOAction != null)
			{
				PCOAction.LinkState = PCOLinkStates.Linking;
			}
			OnLinkDocument(document, addUpdateRequest);
			OnPropertyChanged("Name");
		}
	}

	private void OnLinkMedia(MediaBase media, bool addUpdateRequest)
	{
		if (IsLinked)
		{
			throw new InvalidOperationException("Cannot link this item in it's current state.");
		}
		PCOAction?.LinkMedia(media, _transitionDescriptions);
		AddMediaUpdateRequest(media);
		if (addUpdateRequest)
		{
			PCOCueBase.ItemLinked?.Invoke(this);
		}
	}

	private void OnLinkDocument(ProPresenter.DO.Presentation.IPresentation document, bool addUpdateRequest)
	{
		if (IsLinked)
		{
			throw new InvalidOperationException("Cannot link this item in it's current state.");
		}
		PCOAction?.LinkDocument(document, PCOItem);
		AddPresentationUpdateRequest(document);
		if (addUpdateRequest)
		{
			PCOCueBase.ItemLinked?.Invoke(this);
		}
	}

	private void AddPresentationUpdateRequest(ProPresenter.DO.Presentation.IPresentation document)
	{
		if ((object)document.SourceFile != null)
		{
			RelativePath sourceFile = document.SourceFile;
			if (PCOItem != null)
			{
				AddUpdateRequest(new PCOUpdateInformation(PCOItem, sourceFile));
			}
		}
	}

	public void UnlinkItem()
	{
		if (IsLinked)
		{
			lock (UploadRequests)
			{
				UploadRequests.Clear();
			}
			PCOAction?.Unlink();
			PlaceholderUnlinkEvent.Publish();
		}
	}

	private void AddMediaUpdateRequest(MediaBase media)
	{
		if (media is FileMediaBase fileMediaBase && !string.IsNullOrWhiteSpace(fileMediaBase.SourceFile.FullPath))
		{
			string fullPath = fileMediaBase.SourceFile.FullPath;
			if (PCOItem != null)
			{
				AddUpdateRequest(new PCOUpdateInformation(PCOItem, fullPath));
			}
		}
	}

	private void AddUpdateRequest(PCOUpdateInformation updateInformation)
	{
		lock (UploadRequests)
		{
			UploadRequests.RemoveAll((PCOUpdateInformation u) => u.Item == updateInformation.Item && u.FileAttachmentPath == updateInformation.FileAttachmentPath);
			UploadRequests.Add(updateInformation);
		}
	}

	public void ReEnqueueUpdateRequest(PCOUpdateInformation updateInformation)
	{
		lock (UploadRequests)
		{
			if (!UploadRequests.Any((PCOUpdateInformation u) => u.Item == updateInformation.Item && u.FileAttachmentPath == updateInformation.FileAttachmentPath))
			{
				UploadRequests.Add(updateInformation);
			}
		}
	}

	public List<PCOUpdateInformation> GetUpdateRequests()
	{
		List<PCOUpdateInformation> list = new List<PCOUpdateInformation>();
		lock (UploadRequests)
		{
			list.AddRange(UploadRequests);
			UploadRequests.Clear();
			return list;
		}
	}

	private void PCOCueBase_DataModified()
	{
		UpdatedAt = DateTime.Now;
	}

	public void UpdateDetails(string oldDetailsID, IPCOContent newDetails)
	{
		PCOItem?.UpdateDetails(oldDetailsID, newDetails);
	}

	protected override void OnProtoSerializePlaylistItem(PlaylistItem playlistItem)
	{
		playlistItem.PlanningCenter = new PlaylistItem.Types.PlanningCenter
		{
			Item = PCOItem?.Serialize(),
			LinkedData = ((ProPresenterCue)(((object)PCOAction?.DocumentAction?.ToCue()) ?? ((object)PCOAction?.MediaAction?.ToCue())))?.ProtoSerializePlaylistItem()
		};
	}

	protected override void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		PCOItem?.Deserialize(playlistItem.PlanningCenter.Item);
		if (playlistItem.PlanningCenter.LinkedData?.Presentation != null)
		{
			if (_libraries != null)
			{
				PCOAction?.DeserializeLinkDocument(playlistItem.PlanningCenter.LinkedData.Presentation, _libraries);
			}
			DocumentAction?.OnProtoDeserializePlaylistItem(playlistItem.PlanningCenter.LinkedData);
			return;
		}
		Pro.SerializationInterop.RVProtoData.Action action = playlistItem.PlanningCenter.LinkedData?.Cue?.Actions.FirstOrDefault();
		if (action != null)
		{
			if (action.Type != Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media)
			{
				throw new NotSupportedException();
			}
			MediaBase mediaBase = action.Media.MediaTypeCase switch
			{
				Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.MediaTypeOneofCase.Audio => _mediaFactory.CreateAudioMedia(containerId, null), 
				Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.MediaTypeOneofCase.Image => _mediaFactory.CreateVisualMedia(containerId, null), 
				Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.MediaTypeOneofCase.Video => _mediaFactory.CreateVideoMedia(containerId, null), 
				_ => throw new NotImplementedException(), 
			};
			if (mediaBase.MediaType.IsAnyOf(MediaType.Image, MediaType.Video, MediaType.Audio))
			{
				LinkMedia(mediaBase, addUpdateRequest: false);
				MediaAction?.Deserialize(action, applicationData, containerId);
			}
		}
	}

	public void Insert(IEnumerable<IActionRepository> newRepos, IActionRepository? repo, bool insertBefore)
	{
		if (DocumentAction?.Presentation is CustomPresentation customPresentation)
		{
			customPresentation.InsertCues(newRepos.OfType<SlideCue>(), repo as SlideCue, DocumentAction.ActiveArrangement, insertBefore);
		}
	}
}
