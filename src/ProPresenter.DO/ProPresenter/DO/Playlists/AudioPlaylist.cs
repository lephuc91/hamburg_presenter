using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

public class AudioPlaylist : Playlist<MediaCue>, IAudioPlaylist, IPlaylist<MediaCue>, ITriggerable, IIdentifiable, INotifyPropertyChanged, ICloneable<IPlaylist<MediaCue>>, IDragDropTreeCollection<IPlaylist<MediaCue>>, ITreeNode<IPlaylist<MediaCue>>, IEnumerable<MediaCue>, IEnumerable, IDragDropNotifyEnumerableChanged<MediaCue>, INotifyEnumerableChanged<MediaCue>, INotifyCollectionChanged, IDragDropCollection<MediaCue>
{
	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IAsyncFileImporter _mediaImporter;

	private readonly IMediaFactory _mediaFactory;

	private readonly IFlagService _flagService;

	private AudioSortType _sortType;

	private int _insertIndex;

	private bool _shouldSortFiles;

	public override IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist)
	{
		IPlaylist.Types.IChildrenType.IItems items = playlist.ChildrenType.Value as IPlaylist.Types.IChildrenType.IItems;
		if (items == null)
		{
			items = entityFactory.Create<IPlaylist.Types.IChildrenType.IItems>();
			playlist.ChildrenType.Set(items);
		}
		ObjectBinder<AudioPlaylist, IPlaylist> objectBinder = new ObjectBinder<AudioPlaylist, IPlaylist>(this, playlist);
		Playlist<MediaCue>.Bind(objectBinder);
		IReadOnlyObjectBinder<IPlaylist<MediaCue>, IComplexCollection<IPlaylistItem>> itemsBinder = BindItems(scheduler, entityFactory, actionBinderFactory, items.Value.Items);
		objectBinder.DoOnInitializeLeftFromRight(itemsBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(itemsBinder.InitializeRightFromLeft).RegisterChildDisposable(() => itemsBinder);
		return objectBinder;
	}

	public override IReadOnlyObjectBinder<IPlaylist<MediaCue>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items)
	{
		ObjectBinder<AudioPlaylist, IComplexCollection<IPlaylistItem>> objectBinder = new ObjectBinder<AudioPlaylist, IComplexCollection<IPlaylistItem>>(this, items);
		objectBinder.Bind((AudioPlaylist l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylistItem> r) => r.WhenCollectionChanges, delegate(AudioPlaylist l, IComplexCollection<IPlaylistItem> r)
		{
			r.SynchronizeFrom(l.Items, (MediaCue m, IPlaylistItem e) => m.ID == e.Uuid.Value, delegate(MediaCue m)
			{
				IPlaylistItem playlistItem = entityFactory.Create<IPlaylistItem>();
				IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlistItem);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlistItem.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlistItem;
			});
		}, delegate(IComplexCollection<IPlaylistItem> r, AudioPlaylist l)
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
					l.RemoveAudioItems(new global::_003C_003Ez__ReadOnlySingleElementList<MediaCue>(mediaCue2), isReversible: false);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public AudioPlaylist(IApp app, IAsyncFileImporter mediaImporter, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, UndoStack? undoStack = null, string name = "")
		: base(undoStack, name, isTemplate: false)
	{
		_app = app;
		_mediaImporter = mediaImporter;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_flagService = flagService;
	}

	public override IPlaylist<MediaCue> Clone()
	{
		return CopyProperties(new AudioPlaylist(_app, _mediaImporter, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack, Name));
	}

	public void SortAudioPlaylistItems(AudioSortType sortType, bool isReversible = false)
	{
		AudioSortType oldSortType = _sortType;
		_sortType = sortType;
		Resort(sortType);
		if (isReversible)
		{
			base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.SortAudioItems), delegate
			{
				Resort(oldSortType);
			}, delegate
			{
				Resort(sortType);
			}, null, null, autoFinalize: true);
		}
		OnDataModified();
	}

	private void Resort(AudioSortType sortType)
	{
		IEnumerable<MediaCue> enumerable = null;
		MediaCue[] source = base.Collection.ToArray();
		switch (sortType)
		{
		case AudioSortType.Artist:
			enumerable = source.OrderBy((MediaCue a) => a.MediaAction?.AudioMedia?.Metadata.Artist);
			break;
		case AudioSortType.Duration:
			enumerable = source.OrderBy((MediaCue a) => a.MediaAction?.MediaDuration);
			break;
		case AudioSortType.Name:
		{
			NaturalStringComparer comparer = new NaturalStringComparer();
			enumerable = source.OrderBy((MediaCue a) => a.Name, comparer);
			break;
		}
		default:
			throw new NotImplementedException(sortType.ToString() + " is not yet implemented");
		}
		ReplacePlaylistWith(enumerable);
	}

	public void RemoveAudioItems(IEnumerable<MediaCue> items, bool isReversible)
	{
		if (!isReversible && !_flagService.IsFlagEnabled(Flag.Cloud))
		{
			items.Select((MediaCue c) => c.MediaAction?.Media).OfType<FileMediaBase>().ForEach(delegate(FileMediaBase i)
			{
				RelativePath sourceFile = i.SourceFile;
				if (sourceFile.IsValid)
				{
					FileHelper.MoveToRecycleBin(sourceFile);
				}
			});
		}
		using ((!isReversible) ? null : base.UndoStack?.Transaction(UndoActionTypes.RemovePlaylistItems.ToAction(), null, null, autoFinalize: true))
		{
			ITrackedMedia[] itemsToRemove = items.Select((MediaCue x) => x.MediaAction?.Media).OfType<ITrackedMedia>().ToArray();
			itemsToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(!isReversible);
			});
			RemoveItems(items, isReversible);
			if (!isReversible)
			{
				return;
			}
			base.UndoStack?.Commit(delegate
			{
				itemsToRemove.ForEach(delegate(ITrackedMedia x)
				{
					x.AddToMediaServiceAndApplyTransform(userInitiated: true);
				});
			}, delegate
			{
				itemsToRemove.ForEach(delegate(ITrackedMedia x)
				{
					x.RemoveFromMediaService(deleteAssets: false);
				});
			});
		}
	}

	public Task AddAudioFile(string filename, bool userInitiated)
	{
		return AddAudioFiles(new string[1] { filename }, userInitiated);
	}

	public Task AddAudioFiles(string[] filenames, bool userInitiated)
	{
		return InsertAudioFiles(filenames, userInitiated, base.Collection.Count, shouldSort: true);
	}

	public async Task InsertAudioFiles(string[] fileNames, bool userInitiated, int index = -1, bool shouldSort = false)
	{
		_insertIndex = index;
		_shouldSortFiles = shouldSort || index < 0;
		if (!fileNames.Any())
		{
			return;
		}
		foreach (string file in fileNames)
		{
			(string, string, FileMediaBase) obj = await _mediaImporter.ImportMediaFileAsync(file, base.ContainerId);
			string item = obj.Item2;
			FileMediaBase item2 = obj.Item3;
			FileMediaBase fileMediaBase = item2 ?? _mediaFactory.CreateAudioMedia(base.ContainerId, null);
			fileMediaBase.MetadataLoadSuccessful += AudioMedia_MetadataLoadSuccessful;
			fileMediaBase.MetadataLoadFailed += AudioMedia_MetadataLoadFailed;
			if (fileMediaBase.MetadataLoaded)
			{
				fileMediaBase.MetadataLoadSuccessful -= AudioMedia_MetadataLoadSuccessful;
				fileMediaBase.MetadataLoadFailed -= AudioMedia_MetadataLoadFailed;
				if (fileMediaBase.IsValid)
				{
					AudioMedia_MetadataLoadSuccessful(fileMediaBase);
				}
				else
				{
					AudioMedia_MetadataLoadFailed(fileMediaBase);
				}
			}
			if (item2 == null)
			{
				fileMediaBase.UpdateSource(userInitiated, (RelativePath)item);
			}
		}
	}

	private void AudioMedia_MetadataLoadSuccessful(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= AudioMedia_MetadataLoadSuccessful;
		AudioMedia audioMedia = (AudioMedia)media;
		MediaCue audioCue = new MediaCue(_app, audioMedia, _transitionDescriptions)
		{
			Name = audioMedia.SourceFile.Filename
		};
		MediaHelper.ApplyImportSettings(audioCue);
		if (_insertIndex < 0 || _insertIndex > base.Collection.Count)
		{
			_insertIndex = base.Collection.Count;
		}
		base.Collection.Insert(_insertIndex++, audioCue);
		if (_shouldSortFiles)
		{
			SortAudioPlaylistItems(AudioSortType.Name);
		}
		audioCue.DataModified += base.CueChanged;
		base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddAudioFiles), delegate
		{
			audioMedia.RemoveFromMediaService(deleteAssets: false);
			base.Collection.Remove(audioCue);
		}, delegate
		{
			audioMedia.AddToMediaServiceAndApplyTransform(userInitiated: true);
			base.Collection.Add(audioCue);
		}, null, null, autoFinalize: true);
		OnDataModified();
	}

	private void AudioMedia_MetadataLoadFailed(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= AudioMedia_MetadataLoadSuccessful;
		media.MetadataLoadFailed -= AudioMedia_MetadataLoadFailed;
	}

	public override void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		base.ProtoDeserialize(data, applicationData, removeExisting);
		AudioBinHelper.DeserializePlaylistItems(base.Collection, data.Items.Items, base.CueChanged, applicationData, MediaContainerIds.Playlist(base.ID));
	}
}
