using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

public class SmartPlaylist : VisualPlaylist
{
	private readonly ISmartFolderRepo _repo;

	private ImportLayer _behavior;

	public override PlaylistType Type => PlaylistType.Smart;

	public ImportLayer Behavior
	{
		get
		{
			return _behavior;
		}
		set
		{
			SetValue("Behavior", ref _behavior, value, delegate(ImportLayer _, ImportLayer n)
			{
				base.Collection.ForEach(delegate(MediaCue c)
				{
					SetDefaults(n, c);
				});
				OnDataModified();
			});
		}
	}

	public string TargetPath => _repo.TargetPath;

	public SmartPlaylist(ISmartFolderRepo repo, UndoStack? undoStack, IApp app, IMediaImportService importService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, bool syncFiles = true)
		: base(app, importService, mediaFactory, transitionDescriptions, flagService, undoStack)
	{
		_repo = repo;
		_repo.FileCreated += Repo_FileCreated;
		_repo.FileDeleted += Repo_FileDeleted;
		_repo.FileRenamed += Repo_FileRenamed;
		_repo.FileChanged += Repo_FileChanged;
		_repo.FilesParsed += OnParseFiles;
		Name = _repo.Name;
		if (syncFiles)
		{
			_repo.ParseFiles();
		}
	}

	public SmartPlaylist(UndoStack? undoStack, IApp app, IMediaImportService importService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
		: this(new SmartFolderRepo(RelativePath.Empty()), undoStack, app, importService, mediaFactory, transitionDescriptions, flagService)
	{
	}

	public override IPlaylist<MediaCue> Clone()
	{
		ISmartFolderRepo smartFolderRepo = _repo.Clone();
		if (smartFolderRepo != null)
		{
			return (SmartPlaylist)CopyProperties(new SmartPlaylist(smartFolderRepo, base.UndoStack, base.App, base.ImportService, base.MediaFactory, base.TransitionDescriptions, base.FlagService, syncFiles: false)
			{
				Behavior = Behavior,
				Name = Name
			});
		}
		return new SmartPlaylist(base.UndoStack, base.App, base.ImportService, base.MediaFactory, base.TransitionDescriptions, base.FlagService);
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnCollectionChanged(e);
		(from MediaCue c in e.NewItems?
			select c.MediaAction).NotNull().ForEach(delegate(MediaAction a)
		{
			a.Media.SupportsSwappingSource = false;
		});
	}

	public void ImportFiles(IEnumerable<string> filenames)
	{
		_repo.ImportFiles(filenames);
	}

	public override Playlist ProtoSerialize()
	{
		Playlist playlist = base.ProtoSerialize();
		playlist.SmartDirectory = new Playlist.Types.FolderDirectory
		{
			SmartDirectory = _repo.Serialize()
		};
		switch (Behavior)
		{
		case ImportLayer.Background:
			playlist.SmartDirectory.ImportBehavior = Playlist.Types.FolderDirectory.Types.ImportBehavior.Background;
			break;
		case ImportLayer.Foreground:
			playlist.SmartDirectory.ImportBehavior = Playlist.Types.FolderDirectory.Types.ImportBehavior.Foreground;
			break;
		default:
			throw new NotSupportedException();
		}
		return playlist;
	}

	public override void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		base.ProtoDeserialize(data, applicationData, removeExisting);
		switch (data.SmartDirectory.ImportBehavior)
		{
		case Playlist.Types.FolderDirectory.Types.ImportBehavior.Background:
			Behavior = ImportLayer.Background;
			break;
		case Playlist.Types.FolderDirectory.Types.ImportBehavior.Foreground:
			Behavior = ImportLayer.Foreground;
			break;
		default:
			throw new NotSupportedException();
		}
		_repo.Deserialize(data.SmartDirectory);
	}

	protected override void OnDeserializeVisualPlaylistItems(Playlist data, ApplicationData? applicationData)
	{
		base.OnDeserializeVisualPlaylistItems(data, applicationData);
		_repo.ParseFiles();
	}

	private void OnParseFiles(IEnumerable<RelativePath> files)
	{
		List<MediaCue> list = base.Collection.Except(files, (MediaCue action) => action.MediaAction?.FileMedia?.SourceFile, (RelativePath file) => file).ToList();
		(from x in list.SelectMany((MediaCue x) => x.Actions.OfType<MediaAction>())
			select x.Media).OfType<ITrackedMedia>().ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		List<RelativePath> filenames = files.Except(base.Collection, (RelativePath file) => file, (MediaCue action) => action.MediaAction?.FileMedia?.SourceFile).ToList();
		RemoveItems(list, isReversible: false);
		InsertFiles(filenames, manageMedia: false, userInitiated: false, null, insertBefore: false, isReversible: false);
	}

	protected override void ApplyImportSettings(MediaCue mediaCue)
	{
		base.ApplyImportSettings(mediaCue);
		SetDefaults(Behavior, mediaCue);
	}

	private static void SetDefaults(ImportLayer importLayer, MediaCue mediaCue)
	{
		MediaAction mediaAction = mediaCue.MediaAction;
		if (mediaAction == null)
		{
			return;
		}
		MediaBase media = mediaAction.Media;
		switch (importLayer)
		{
		case ImportLayer.Background:
			mediaAction.TriggerLayer = TriggerLayer.Background;
			if (media is ITransportMedia transportMedia2)
			{
				transportMedia2.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
			}
			break;
		case ImportLayer.Foreground:
			mediaAction.TriggerLayer = TriggerLayer.Foreground;
			if (media is ITransportMedia transportMedia)
			{
				transportMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
			}
			break;
		}
	}

	private void Repo_FileCreated(RelativePath file)
	{
		if (!base.Collection.Any((MediaCue c) => c.MediaAction?.VisualMedia?.SourceFile.FullPath?.IsPathEqual(file) == true))
		{
			InsertFiles(new RelativePath[1] { file }, manageMedia: false, userInitiated: false, null, insertBefore: false, isReversible: false);
		}
	}

	private void Repo_FileDeleted(RelativePath file)
	{
		MediaCue[] array = base.Collection.Where((MediaCue i) => i.MediaAction?.VisualMedia?.SourceFile.FullPath?.PathContains(file) == true).ToArray();
		(from x in array.SelectMany((MediaCue x) => x.Actions.OfType<MediaAction>())
			select x.Media).OfType<ITrackedMedia>().ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		RemoveItems(array, isReversible: false);
	}

	private void Repo_FileRenamed(RelativePath oldFile, RelativePath newFile)
	{
		MediaCue[] array = base.Collection.Where((MediaCue item) => item.MediaAction?.VisualMedia?.SourceFile.FullPath?.IsPathEqual(oldFile) == true).ToArray();
		if (array.Length == 0)
		{
			return;
		}
		if (MediaHelper.IsValidMediaFilenameToHandle(newFile))
		{
			array.ForEach(delegate(MediaCue mediaItem)
			{
				mediaItem.Name = newFile.Name;
				if (mediaItem.MediaAction != null)
				{
					mediaItem.MediaAction.Name = newFile.Name;
					mediaItem.MediaAction.VisualMedia?.UpdateSource(userInitiated: false, newFile);
				}
			});
		}
		else
		{
			RemoveItems(array, isReversible: false);
		}
	}

	private void Repo_FileChanged(RelativePath file)
	{
		base.Collection.FirstOrDefault((MediaCue i) => i.MediaAction?.VisualMedia?.SourceFile == file)?.MediaAction?.VisualMedia?.UpdateSource(userInitiated: false, file);
	}
}
