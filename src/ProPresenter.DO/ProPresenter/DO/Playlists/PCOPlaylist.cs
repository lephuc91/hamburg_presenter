using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;

namespace ProPresenter.DO.Playlists;

public class PCOPlaylist : Playlist<ProPresenterCue>, ILibraryPlaylist<ProPresenterCue>, IEnumerable<ProPresenterCue>, IEnumerable
{
	private bool _hasUpdates;

	private PCOPlan? _pcoPlan;

	private readonly List<IPCOContent> _pendingLinkItems = new List<IPCOContent>();

	private readonly IProPresenterResourceService _resources;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IProPresenterCueFactory _cueFactory;

	private readonly IMediaFactory _mediaFactory;

	public override PlaylistType Type => PlaylistType.PCO;

	public PCOPlan? PCOPlan
	{
		get
		{
			return _pcoPlan;
		}
		set
		{
			SetValue<PCOPlan>("PCOPlan", ref _pcoPlan, value, delegate(PCOPlan o, PCOPlan n)
			{
				if (o != null)
				{
					o.PropertyChanged -= PCOPlan_PropertyChanged;
					o.DataModified -= PCOPlan_DataModified;
				}
				if (n != null)
				{
					n.PropertyChanged += PCOPlan_PropertyChanged;
					n.DataModified += PCOPlan_DataModified;
				}
			});
		}
	}

	public bool HasUpdates
	{
		get
		{
			return _hasUpdates;
		}
		set
		{
			SetValue("HasUpdates", ref _hasUpdates, value);
		}
	}

	public bool UnlinkedItemsExist => this.Any(delegate(ProPresenterCue c)
	{
		PCOCueBase obj = c as PCOCueBase;
		return obj != null && !obj.IsLinked;
	});

	public override IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist)
	{
		IPlaylist.Types.IChildrenType.IItems items = playlist.ChildrenType.Value as IPlaylist.Types.IChildrenType.IItems;
		if (items == null)
		{
			items = entityFactory.Create<IPlaylist.Types.IChildrenType.IItems>();
			playlist.ChildrenType.Set(items);
		}
		ObjectBinder<PCOPlaylist, IPlaylist> objectBinder = new ObjectBinder<PCOPlaylist, IPlaylist>(this, playlist);
		Playlist<ProPresenterCue>.Bind(objectBinder);
		objectBinder.Bind((PCOPlaylist l) => l.WhenPropertyChanges("PCOPlan"), (IPlaylist r) => r.LinkData.WhenValueChanges, delegate(PCOPlaylist l, IPlaylist r)
		{
			if (l.PCOPlan != null)
			{
				IPlaylist.Types.ILinkData.IPcoPlan pcoPlan = entityFactory.Create<IPlaylist.Types.ILinkData.IPcoPlan>();
				ProPresenter.DO.PCO.PCOPlan.CreateBinder(l.PCOPlan, pcoPlan.Value).InitializeRightFromLeft();
				pcoPlan.RegisterLinkedDisposable(pcoPlan);
				r.LinkData.Set(pcoPlan);
			}
		}, delegate(IPlaylist r, PCOPlaylist l)
		{
			if (r.LinkData.Value is IPlaylist.Types.ILinkData.IPcoPlan pcoPlan2)
			{
				PCOPlan pCOPlan = new PCOPlan();
				ObjectBinder<PCOPlan, IPlanningCenterPlan> objectBinder2 = ProPresenter.DO.PCO.PCOPlan.CreateBinder(pCOPlan, pcoPlan2.Value);
				objectBinder2.InitializeLeftFromRight();
				pcoPlan2.RegisterLinkedDisposable(objectBinder2);
				l.PCOPlan = pCOPlan;
			}
		});
		IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> itemsBinder = BindItems(scheduler, entityFactory, actionBinderFactory, items.Value.Items);
		playlist.RegisterLinkedDisposable(itemsBinder);
		objectBinder.DoOnInitializeLeftFromRight(itemsBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(itemsBinder.InitializeRightFromLeft).RegisterChildDisposable(() => itemsBinder);
		return objectBinder;
	}

	public override IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items)
	{
		ObjectBinder<PCOPlaylist, IComplexCollection<IPlaylistItem>> objectBinder = new ObjectBinder<PCOPlaylist, IComplexCollection<IPlaylistItem>>(this, items);
		objectBinder.Bind((PCOPlaylist l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylistItem> r) => r.WhenCollectionChanges, delegate(PCOPlaylist l, IComplexCollection<IPlaylistItem> r)
		{
			r.SynchronizeFrom(l.Items, (ProPresenterCue m, IPlaylistItem e) => m.ID == e.Uuid.Value, delegate(ProPresenterCue m)
			{
				IPlaylistItem playlistItem = entityFactory.Create<IPlaylistItem>();
				IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlistItem);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlistItem.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlistItem;
			});
		}, delegate(IComplexCollection<IPlaylistItem> r, PCOPlaylist l)
		{
			r.Items.SynchronizeTo(l, (IPlaylistItem e, ProPresenterCue m) => m?.ID == e.Uuid.Value, delegate(IPlaylistItem e, int i)
			{
				ProPresenterCue proPresenterCue = _cueFactory.CreateCue(e, l.ContainerId);
				if (proPresenterCue != null)
				{
					IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> readOnlyObjectBinder2 = proPresenterCue.Bind(scheduler, entityFactory, actionBinderFactory, e);
					readOnlyObjectBinder2.InitializeLeftFromRight();
					e.RegisterLinkedDisposable(readOnlyObjectBinder2);
					l.InsertItem(proPresenterCue, null, i, isReversible: false);
				}
			}, l.Collection.Move, delegate(int i)
			{
				ProPresenterCue proPresenterCue2 = l.ElementAtOrDefault(i);
				if (proPresenterCue2 != null)
				{
					l.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue>(proPresenterCue2), isReversible: false);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public PCOPlaylist(IProPresenterResourceService resources, IImportProcessFactory importProcessFactory, PCOPlan pcoPlan, UndoStack? undoStack, IProPresenterCueFactory cueFactory, IMediaFactory mediaFactory)
		: base(undoStack, "", isTemplate: false)
	{
		PCOPlaylist pCOPlaylist = this;
		_resources = resources;
		_importProcessFactory = importProcessFactory;
		_cueFactory = cueFactory;
		_mediaFactory = mediaFactory;
		base.CollectionChanged += PCOPlaylist_CollectionChanged;
		if (pcoPlan != null)
		{
			PCOPlan = pcoPlan;
			pcoPlan.Name.ThrowWhenNull("pcoPlan.Name");
			Name = pcoPlan.Name;
			pcoPlan.ID.ThrowWhenNull("pcoPlan.ID");
			pcoPlan.PlanItems?.ForEach(delegate(PCOItem i)
			{
				pCOPlaylist.AddPCOItem(i, pcoPlan.ID, pcoPlan.ServiceTypeID);
			});
		}
		if (resources.LibraryCollection != null)
		{
			resources.LibraryCollection.LibraryCollectionChanged += Library_CollectionChanged;
		}
	}

	private void PCOPlaylist_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IDocumentCue>().ForEach(delegate(IDocumentCue d)
		{
			d.PlaylistParent = null;
		});
		e.NewItems?.OfType<IDocumentCue>().ForEach(delegate(IDocumentCue d)
		{
			d.PlaylistParent = this;
		});
	}

	public override IPlaylist<ProPresenterCue> Clone()
	{
		PCOPlaylist pCOPlaylist = new PCOPlaylist(_resources, _importProcessFactory, new PCOPlan(), base.UndoStack, _cueFactory, _mediaFactory);
		pCOPlaylist.ProtoDeserialize(ProtoSerialize(), null);
		return pCOPlaylist;
	}

	public HeaderCue AddHeaderPlaylistItem(string name, int index)
	{
		HeaderCue headerCue = new HeaderCue(new HeaderAction(name, new TimerAction(DataVault.TimerDocument?.Timers.FirstOrDefault()?.ID ?? Guid.Empty)));
		InsertItem(headerCue, UndoActionTypes.AddHeaderPlaylistItem.ToAction(), index);
		return headerCue;
	}

	public ProPresenterCue AddPlaceholderPlaylistItem(string name, int index)
	{
		ProPresenterCue proPresenterCue = _cueFactory.CreatePlaceholder(name);
		InsertItem(proPresenterCue, UndoActionTypes.AddPlaceholderPlaylistItem.ToAction(), index);
		return proPresenterCue;
	}

	public void AddPresentationItem(DocumentCue cue)
	{
		InsertItem(cue, UndoActionTypes.AddPresentationPlaylistItem.ToAction());
	}

	public void AddPresentationItem(IEnumerable<ProPresenterCue> cues, int pos)
	{
		InsertItems(cues, null, pos);
	}

	public void InsertMediaItem(string file, int index)
	{
		TaggedUndoAction<UndoActionTypes> taggedUndoAction = new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddMediaItem);
		ProPresenterCue cue = _cueFactory.CreateMediaCue(file, _isTemplate ? "PlaylistTemplate" : MediaContainerIds.Playlist(base.ID));
		InsertItem(cue, taggedUndoAction, index);
	}

	public void InsertMediaItem(MediaBase media, int index)
	{
		TaggedUndoAction<UndoActionTypes> taggedUndoAction = new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddMediaItem);
		ProPresenterCue cue = _cueFactory.CreateMediaCue(media);
		InsertItem(cue, taggedUndoAction, index);
	}

	private void Library_CollectionChanged(ProPresenter.DO.Librarian.ILibrary library, NotifyCollectionChangedEventArgs e)
	{
		LinkPendingPresentations(library);
	}

	private void PCOPlan_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			Name = PCOPlan?.Name ?? string.Empty;
		}
	}

	private void PCOPlan_DataModified(PCOPlan pcoPlan)
	{
		OnDataModified();
	}

	private void AddPCOItem(PCOItem item, string planID, string serviceID)
	{
		base.Collection.Add(_cueFactory.CreatePCOCue(item, planID, serviceID));
	}

	public void CheckUpdates(DateTime? planUpdatedAt)
	{
		if (planUpdatedAt.HasValue)
		{
			HasUpdates = PCOPlan?.LastUpdated < planUpdatedAt.Value;
		}
	}

	public void Refresh(PCOPlan plan)
	{
		HasUpdates = false;
		List<PCOCueBase> list = base.Collection.OfType<PCOCueBase>().ToList();
		for (int i = 0; i < plan.PlanItems?.Length; i++)
		{
			PCOItem planItem = plan.PlanItems[i];
			PCOCueBase pCOCueBase = list.FirstOrDefault((PCOCueBase c) => c.PCOItem?.ID == planItem.ID);
			int num = ((pCOCueBase != null) ? base.Collection.IndexOf(pCOCueBase) : (-1));
			if (pCOCueBase == null || pCOCueBase.PCOItemType != planItem.PCOItemType)
			{
				if (pCOCueBase != null)
				{
					list.Remove(pCOCueBase);
					base.Collection.Remove(pCOCueBase);
				}
				plan.ID.ThrowWhenNull("plan.ID");
				PCOCueBase pCOCueBase2 = _cueFactory.CreatePCOCue(planItem, plan.ID, plan.ServiceTypeID);
				if (pCOCueBase != null)
				{
					pCOCueBase2.LinkDocument(pCOCueBase.DocumentAction?.Presentation);
					pCOCueBase2.LinkMedia(pCOCueBase.MediaAction?.Media);
				}
				int num2 = -1;
				for (int j = i + 1; j < plan.PlanItems.Length; j++)
				{
					PCOItem nextPlanItem = plan.PlanItems[j];
					num2 = base.Collection.FindIndex((ProPresenterCue c) => c is PCOCueBase pCOCueBase3 && pCOCueBase3.PCOItem?.ID == nextPlanItem.ID);
					if (num2 >= 0)
					{
						break;
					}
				}
				int index = ((num >= 0) ? num : ((num2 >= 0) ? num2 : base.Collection.Count));
				InsertItem(pCOCueBase2, null, index);
			}
			else
			{
				PCOItem previousPlanItem = plan.PlanItems.ElementAtOrDefault(i - 1);
				int num3 = ((previousPlanItem != null) ? base.Collection.FindIndex((ProPresenterCue c) => c is PCOCueBase pCOCueBase4 && pCOCueBase4.PCOItem?.ID == previousPlanItem.ID) : (-1));
				if (num3 >= 0 && num < num3)
				{
					base.Collection.Move(num, num3);
				}
				pCOCueBase.PCOItem = planItem;
				list.Remove(pCOCueBase);
			}
		}
		base.Collection.RemoveRange(list);
	}

	public void HandleDownloadedFiles(IEnumerable<PCOAttachmentDetails> pcoContents, ProPresenter.DO.Librarian.ILibrary? targetLibrary)
	{
		if (pcoContents.Empty())
		{
			return;
		}
		_pendingLinkItems.Clear();
		_pendingLinkItems.AddRange(pcoContents);
		string[] source = pcoContents.Where((PCOAttachmentDetails p) => p.LocalDownloadPath?.Filename.IsProDocumentFile() ?? false).Select((Func<PCOAttachmentDetails, string>)((PCOAttachmentDetails d) => d.LocalDownloadPath ?? RelativePath.Empty())).ToArray();
		string?[] source2 = (from m in pcoContents.Where(delegate(PCOAttachmentDetails p)
			{
				RelativePath? localDownloadPath = p.LocalDownloadPath;
				return ((object)localDownloadPath != null && localDownloadPath.Filename.IsVisualMediaFile()) || (p.LocalDownloadPath?.Filename.IsAudioFile() ?? false);
			})
			select m.LocalDownloadPath?.FullPath).ToArray();
		List<FileImportRequest> requests = new List<FileImportRequest>();
		source2.ForEach(delegate(string m)
		{
			requests.Add(new FileImportRequest(m, delegate(string _, string n, FileMediaBase? createdMedia)
			{
				OnMediaImported(n, createdMedia);
			})
			{
				ForceManageMedia = true
			});
		});
		source.ForEach(delegate(string d)
		{
			requests.Add(new FileImportRequest(d));
		});
		IImportProcess importProcess = _importProcessFactory.Create(requests);
		importProcess.SelectedLibrary = targetLibrary;
		importProcess.SelectedPlaylist = this;
		importProcess.ImportComplete += Process_ImportComplete;
		importProcess.StartImport();
	}

	private void OnMediaImported(string mediaFile, FileMediaBase? createdMedia)
	{
		FileMediaBase fileMediaBase = createdMedia ?? _mediaFactory.CreateEmptyFileMedia(mediaFile, _isTemplate ? "PlaylistTemplate" : MediaContainerIds.Playlist(base.ID), null);
		IPCOContent pending = _pendingLinkItems.FirstOrDefault((IPCOContent p) => mediaFile.Contains(Path.GetFileNameWithoutExtension(p.Filename)));
		PCOCueBase pCOCueBase = base.Collection.OfType<PCOCueBase>().FirstOrDefault((PCOCueBase i) => i.PCOItem?.ID == pending?.PCOItemID);
		if (pCOCueBase != null && !pCOCueBase.IsLinked)
		{
			pCOCueBase.LinkMedia(fileMediaBase, addUpdateRequest: false);
		}
		if (createdMedia == null)
		{
			fileMediaBase.UpdateSource(userInitiated: true, (RelativePath)mediaFile);
		}
		if (pending != null)
		{
			_pendingLinkItems.Remove(pending);
		}
	}

	private void Process_ImportComplete(IImportProcess process)
	{
		process.ImportComplete -= Process_ImportComplete;
		LinkPendingPresentations(process.SelectedLibrary);
	}

	private void LinkPendingPresentations(ProPresenter.DO.Librarian.ILibrary? library)
	{
		if (library == null)
		{
			return;
		}
		IPCOContent[] array = _pendingLinkItems.ToArray();
		foreach (IPCOContent item in array)
		{
			PCOCueBase pCOCueBase = base.Collection.FirstOrDefaultOf((PCOCueBase i) => i.PCOItem?.ID == item.PCOItemID);
			if (pCOCueBase != null && !pCOCueBase.IsLinked)
			{
				DocumentCue documentCue = library.FirstOrDefault((DocumentCue p) => (object)item.LocalDownloadPath != null && p.Name == Path.GetFileNameWithoutExtension(item.LocalDownloadPath));
				if (documentCue != null)
				{
					pCOCueBase.LinkDocument(documentCue.DocumentAction.Presentation);
					_pendingLinkItems.Remove(item);
				}
			}
		}
	}

	public override Playlist ProtoSerialize()
	{
		Playlist playlist = base.ProtoSerialize();
		playlist.PcoPlan = PCOPlan?.ProtoSerialize();
		return playlist;
	}

	public override void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		base.ProtoDeserialize(data, applicationData, removeExisting);
		if (PCOPlan != null)
		{
			PCOPlan.DataModified -= PCOPlan_DataModified;
			PCOPlan.ProtoDeserialize(data.PcoPlan);
			PCOPlan.DataModified += PCOPlan_DataModified;
		}
		_cueFactory.Deserialize(base.Collection, data.Items.Items, applicationData, removeExisting, MediaContainerIds.Playlist(base.ID));
	}
}
