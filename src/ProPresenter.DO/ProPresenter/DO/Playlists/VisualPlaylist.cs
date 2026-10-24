using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

public class VisualPlaylist : Playlist<MediaCue>, ICutPasteCollection<MediaCue>, ICutCollection<MediaCue>
{
	protected IApp App { get; }

	protected ITransitionDescriptionCollection TransitionDescriptions { get; }

	protected IMediaImportService ImportService { get; }

	protected IMediaFactory MediaFactory { get; }

	protected IFlagService FlagService { get; }

	public override IEnumerable<MediaCue> FilteredItems { get; } = Enumerable.Empty<MediaCue>();

	public override IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist)
	{
		IPlaylist.Types.IChildrenType.IItems items = playlist.ChildrenType.Value as IPlaylist.Types.IChildrenType.IItems;
		if (items == null)
		{
			items = entityFactory.Create<IPlaylist.Types.IChildrenType.IItems>();
			playlist.ChildrenType.Set(items);
		}
		ObjectBinder<VisualPlaylist, IPlaylist> objectBinder = new ObjectBinder<VisualPlaylist, IPlaylist>(this, playlist);
		Playlist<MediaCue>.Bind(objectBinder);
		IReadOnlyObjectBinder<IPlaylist<MediaCue>, IComplexCollection<IPlaylistItem>> itemsBinder = BindItems(scheduler, entityFactory, actionBinderFactory, items.Value.Items);
		objectBinder.DoOnInitializeLeftFromRight(itemsBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(itemsBinder.InitializeRightFromLeft).RegisterChildDisposable(() => itemsBinder);
		return objectBinder;
	}

	public override IReadOnlyObjectBinder<IPlaylist<MediaCue>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items)
	{
		ObjectBinder<VisualPlaylist, IComplexCollection<IPlaylistItem>> objectBinder = new ObjectBinder<VisualPlaylist, IComplexCollection<IPlaylistItem>>(this, items);
		objectBinder.Bind((VisualPlaylist l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylistItem> r) => r.WhenCollectionChanges, delegate(VisualPlaylist l, IComplexCollection<IPlaylistItem> r)
		{
			r.SynchronizeFrom(l.Items, (MediaCue m, IPlaylistItem e) => m.ID == e.Uuid.Value, delegate(MediaCue m)
			{
				IPlaylistItem playlistItem = entityFactory.Create<IPlaylistItem>();
				IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlistItem);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlistItem.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlistItem;
			});
		}, delegate(IComplexCollection<IPlaylistItem> r, VisualPlaylist l)
		{
			r.Items.SynchronizeTo(l, (IPlaylistItem e, MediaCue m) => m.ID == e.Uuid.Value, delegate(IPlaylistItem e, int i)
			{
				MediaCue mediaCue = new MediaCue(l.ContainerId);
				IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> readOnlyObjectBinder2 = mediaCue.Bind(scheduler, entityFactory, actionBinderFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.InsertItem(mediaCue, null, i, isReversible: false);
			}, l.Collection.Move, delegate(int i)
			{
				MediaCue mediaCue2 = l.ElementAtOrDefault(i);
				if (mediaCue2 != null)
				{
					l.RemoveCues(new global::_003C_003Ez__ReadOnlySingleElementList<MediaCue>(mediaCue2), isReversible: false);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public VisualPlaylist(IApp app, IMediaImportService importService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, UndoStack? undoStack = null, string name = "")
		: base(undoStack, name, isTemplate: false)
	{
		App = app;
		ImportService = importService;
		MediaFactory = mediaFactory;
		TransitionDescriptions = transitionDescriptions;
		FlagService = flagService;
	}

	public override IPlaylist<MediaCue> Clone()
	{
		return CopyProperties(new VisualPlaylist(App, ImportService, MediaFactory, TransitionDescriptions, FlagService, base.UndoStack, Name));
	}

	public void SortItems(VisualSortType sortType, bool ascending = true)
	{
		List<MediaCue> source = base.Collection.ToList();
		IEnumerable<MediaCue> sortedItems = null;
		switch (sortType)
		{
		case VisualSortType.Name:
			sortedItems = (ascending ? source.OrderBy((MediaCue a) => a.Name) : source.OrderByDescending((MediaCue a) => a.Name));
			break;
		case VisualSortType.Kind:
		case VisualSortType.Format:
			sortedItems = (ascending ? source.OrderBy((MediaCue a) => a.MediaAction?.FileMedia?.SourceFile.Extension) : source.OrderByDescending((MediaCue a) => a.MediaAction?.FileMedia?.SourceFile.Extension));
			break;
		case VisualSortType.Path:
			sortedItems = (ascending ? source.OrderBy((MediaCue a) => a.MediaAction?.FileMedia?.SourceFile.Filename) : source.OrderByDescending((MediaCue a) => a.MediaAction?.FileMedia?.SourceFile.Filename));
			break;
		case VisualSortType.Type:
			sortedItems = (ascending ? source.OrderBy((MediaCue a) => a.MediaAction?.Media.MediaType) : source.OrderByDescending((MediaCue a) => a.MediaAction?.Media.MediaType));
			break;
		case VisualSortType.Duration:
			sortedItems = (ascending ? source.OrderBy((MediaCue a) => a.MediaAction?.MediaDuration) : source.OrderByDescending((MediaCue a) => a.MediaAction?.MediaDuration));
			break;
		case VisualSortType.Length:
			sortedItems = (ascending ? source.OrderBy((MediaCue a) => a.MediaAction?.FileMedia?.Metadata.Duration) : source.OrderByDescending((MediaCue a) => a.MediaAction?.FileMedia?.Metadata.Duration));
			break;
		}
		MediaCue[] collection = base.Collection.ToArray();
		if (sortedItems != null && !base.Collection.ContentsMatchExactly(sortedItems))
		{
			base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.SortMediaItems), delegate
			{
				ReplacePlaylistWith(collection);
			}, delegate
			{
				ReplacePlaylistWith(sortedItems);
			}, null, null, autoFinalize: true);
			ReplacePlaylistWith(sortedItems);
		}
	}

	public void InsertFiles(IEnumerable<RelativePath> filenames, bool manageMedia, bool userInitiated, MediaCue? targetCue = null, bool insertBefore = false, bool isReversible = true)
	{
		int num = ((targetCue != null && base.Collection.Contains(targetCue)) ? base.Collection.IndexOf(targetCue) : base.Collection.Count);
		num = (insertBefore ? num : (num + 1));
		AddFiles(filenames, manageMedia, userInitiated, num, isReversible);
	}

	public override void ImportMedia(RelativePath file)
	{
		AddFile(file, userInitiated: true);
	}

	public void AddMediaItem(FileMediaBase media, bool userInitiated, int index = -1, bool isReversible = true, bool applyImportSettings = true)
	{
		try
		{
			MediaAction mediaAction = new MediaAction(media, App, TransitionDescriptions);
			MediaCue mediaCue = new MediaCue(mediaAction);
			if (applyImportSettings)
			{
				ApplyImportSettings(mediaCue);
			}
			InsertItem(mediaCue, null, (index == -1) ? base.Collection.Count : index, isReversible);
			media.MetadataLoadSuccessful += VisualMediaMetadataLoadSuccessful;
			media.MetadataLoadFailed += VisualMetadataLoadFailed;
			if (media.MetadataLoaded)
			{
				media.MetadataLoadSuccessful -= VisualMediaMetadataLoadSuccessful;
				media.MetadataLoadFailed -= VisualMetadataLoadFailed;
				if (media.IsValid)
				{
					VisualMediaMetadataLoadSuccessful(media);
				}
				else
				{
					VisualMetadataLoadFailed(media);
				}
			}
			mediaAction.Name = media.SourceFile.Name;
			mediaCue.Name = mediaAction.Name;
		}
		catch
		{
			Log.Error(string.Format("Failed to load media [{0}]", media.SourceFile.FullPath ?? "(null)"));
		}
	}

	private void AddFiles(IEnumerable<RelativePath> filenames, bool manageMedia, bool userInitiated, int index = -1, bool isReversible = true)
	{
		int insertIndex = index;
		ImportService.Import(filenames, manageMedia, delegate(string _, string n, FileMediaBase? createdMedia)
		{
			if (createdMedia != null)
			{
				AddMediaItem(createdMedia, userInitiated, insertIndex, isReversible);
			}
			else
			{
				AddFile((RelativePath)n, userInitiated, insertIndex, isReversible);
			}
			if (index >= 0)
			{
				insertIndex++;
			}
		}, Type, base.ContainerId);
	}

	public void AddFile(RelativePath filename, bool userInitiated, int index = -1, bool isReversible = true, bool applyImportSettings = true)
	{
		FileMediaBase media = MediaFactory.CreateMedia(filename, base.ContainerId, null);
		AddMediaItem(media, userInitiated, index, isReversible, applyImportSettings);
	}

	protected virtual void ApplyImportSettings(MediaCue mediaCue)
	{
		MediaHelper.ApplyImportSettings(mediaCue);
	}

	public void RemoveCues(IEnumerable<MediaCue> items, bool isReversible)
	{
		List<MediaCue> deletedItems = new List<MediaCue>(items);
		if (!isReversible && !FlagService.IsFlagEnabled(Flag.Cloud))
		{
			items.ForEach(delegate(MediaCue i)
			{
				RelativePath relativePath = i.MediaAction?.FileMedia?.SourceFile;
				if ((object)relativePath != null && relativePath.IsValid && !FileHelper.MoveToRecycleBin(relativePath))
				{
					deletedItems.Remove(i);
				}
			});
		}
		RemoveItems(deletedItems, isReversible);
	}

	private void VisualMetadataLoadFailed(FileMediaBase media)
	{
		media.MetadataLoadFailed -= VisualMetadataLoadFailed;
		media.MetadataLoadSuccessful -= VisualMediaMetadataLoadSuccessful;
		MediaCue mediaCue = base.Collection.FirstOrDefault((MediaCue c) => c.MediaAction?.Media == media);
		if (mediaCue != null)
		{
			RemoveItems(new MediaCue[1] { mediaCue }, isReversible: false);
		}
	}

	private void VisualMediaMetadataLoadSuccessful(FileMediaBase mediaSource)
	{
		mediaSource.MetadataLoadSuccessful -= VisualMediaMetadataLoadSuccessful;
		mediaSource.MetadataLoadFailed -= VisualMetadataLoadFailed;
	}

	public override void CutFrom(IEnumerable<MediaCue> items)
	{
		KeyValuePair<int, MediaCue>[] itemIndices = (from i in items.ToDictionary((MediaCue i) => base.Collection.IndexOf(i), (MediaCue i) => i)
			orderby i.Key
			select i).ToArray();
		ITrackedMedia[] mediaToRemove = items.Select((MediaCue x) => x.MediaAction?.Media).OfType<ITrackedMedia>().ToArray();
		RemoveAction();
		base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.CutMediaItems), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, MediaCue> i)
			{
				base.Collection.Insert(i.Key, i.Value);
			});
			mediaToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated: true);
			});
		}, delegate
		{
			RemoveAction();
		}, null, base.OnDataModified, autoFinalize: true);
		void RemoveAction()
		{
			mediaToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, MediaCue> i)
			{
				base.Collection.RemoveAt(i.Key);
			});
			OnDataModified();
		}
	}

	public override void PasteInto(IEnumerable<MediaCue> items, int index)
	{
		ITrackedMedia[] itemsToAdd = (from x in items
			where (object)x.MediaAction?.FileMedia?.SourceFile != null
			select x.MediaAction.Media).OfType<ITrackedMedia>().ToArray();
		DoInsert();
		base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.PasteMediaItems), DoRemove, DoInsert, null, base.OnDataModified, autoFinalize: true);
		OnDataModified();
		void DoInsert()
		{
			itemsToAdd.ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated: true);
			});
			base.Collection.InsertRange(index, items, ignoreDuplicates: true, capIndex: true);
		}
		void DoRemove()
		{
			itemsToAdd.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
			base.Collection.RemoveRange(items);
		}
	}

	public void OnDeserializeVisualPlaylist(Playlist data, ApplicationData? applicationData)
	{
		ProtoDeserialize(data, applicationData);
		OnDeserializeVisualPlaylistItems(data, applicationData);
	}

	protected virtual void OnDeserializeVisualPlaylistItems(Playlist data, ApplicationData? applicationData)
	{
		MediaBinHelper.DeserializePlaylistItems(base.Collection, data.Items.Items, base.CueChanged, applicationData, base.ContainerId);
	}
}
