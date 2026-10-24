using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Pro.Common.Components;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Time;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Media.Properties.File;

namespace ProPresenter.DO.Media;

public abstract class FileMediaBase : MediaBase, IFileMedia, ITrackedMedia, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private MediaMetadata _metadata;

	private bool _metadataLoaded;

	private RelativePath _sourceFile = RelativePath.Empty();

	private WatcherReference? _watcher;

	private bool _watchSourceFile;

	private bool _isPending = true;

	private MediaAvailability _availability;

	private IDisposable? _mediaReferenceChangedSubscription;

	public MediaMetadata Metadata
	{
		get
		{
			return _metadata;
		}
		protected set
		{
			_metadata = value;
			OnPropertyChanged("Metadata");
		}
	}

	public bool MetadataLoaded
	{
		get
		{
			return _metadataLoaded;
		}
		protected set
		{
			SetValue("MetadataLoaded", ref _metadataLoaded, value);
		}
	}

	public bool IsPending
	{
		get
		{
			return _isPending;
		}
		protected set
		{
			SetValue("IsPending", ref _isPending, value);
		}
	}

	public RelativePath SourceFile
	{
		get
		{
			return _sourceFile;
		}
		private set
		{
			_sourceFile.PropertyChanged -= SourceFile_PropertyChanged;
			if (_watchSourceFile)
			{
				StopWatching();
			}
			OnSourceFileChanged(_sourceFile, value);
			_sourceFile = value;
			_sourceFile.PropertyChanged += SourceFile_PropertyChanged;
			if (_watchSourceFile)
			{
				StartWatching(_sourceFile);
			}
			OnPropertyChanged("SourceFile");
			OnPropertyChanged("IsValid");
			OnPropertyChanged("Availability");
		}
	}

	public override bool IsValid => Availability != MediaAvailability.Missing;

	public ProPresenter.DO.Media.Properties.FileProperties File { get; }

	protected IMetadataLoader MetadataLoader { get; }

	protected IFlagService FlagService { get; }

	public bool IsRemoteMedia => File?.RemoteProperties != null;

	public MediaAvailability Availability
	{
		get
		{
			if (_availability != 0)
			{
				return _availability;
			}
			RelativePath sourceFile = SourceFile;
			if ((object)sourceFile == null || !sourceFile.IsValid)
			{
				return MediaAvailability.Missing;
			}
			return MediaAvailability.Ready;
		}
		protected set
		{
			SetValue("Availability", ref _availability, value, null, false, "IsValid");
		}
	}

	public string ContainerId { get; protected set; }

	public abstract string? Url { get; }

	public event Action<FileMediaBase>? MetadataLoadSuccessful;

	public event Action<FileMediaBase>? MetadataLoadFailed;

	protected FileMediaBase(RelativePath filename, IMetadataLoader metadataLoader, IFlagService flagService, ProPresenter.DO.Media.Properties.FileProperties file, string containerId, Guid? overrideId = null)
	{
		SourceFile = filename;
		MetadataLoader = metadataLoader;
		FlagService = flagService;
		File = file;
		if (FlagService.IsFlagEnabled(Flag.Cloud))
		{
			ContainerId = containerId;
		}
		else
		{
			ContainerId = string.Empty;
		}
		if (overrideId.HasValue)
		{
			base.ID = overrideId.Value;
		}
		_metadata = MediaMetadata.Empty;
		_mediaReferenceChangedSubscription = metadataLoader.WhenMediaReferenceChanged.Subscribe(OnWhenAnyMediaReferenceChanged);
	}

	private void OnWhenAnyMediaReferenceChanged(IMetadataLoader.IIdentifiedResult data)
	{
		if (data is IMetadataLoader.UuidIdentifiedResult uuidIdentifiedResult && (uuidIdentifiedResult.ContainerId == null || uuidIdentifiedResult.ContainerId == ContainerId) && uuidIdentifiedResult.Identifier == base.ID)
		{
			if (uuidIdentifiedResult.Result is IMetadataLoader.SuccessfulResult)
			{
				OnWhenMediaReferenceChanged(uuidIdentifiedResult);
			}
			else if (uuidIdentifiedResult.Result is IMetadataLoader.ImportedResult importedResult)
			{
				UpdateSource(userInitiated: true, (RelativePath)importedResult.FinalUrl, didFileChange: false);
			}
		}
	}

	protected virtual void OnWhenMediaReferenceChanged(IMetadataLoader.UuidIdentifiedResult data)
	{
	}

	protected override MediaBase CopyProperties(MediaBase newMedia)
	{
		if (newMedia is FileMediaBase fileMediaBase)
		{
			fileMediaBase.SourceFile = SourceFile.Clone();
			if (Metadata != null)
			{
				fileMediaBase.Metadata = Metadata._003CClone_003E_0024();
			}
			fileMediaBase.MetadataLoaded = MetadataLoaded;
			fileMediaBase.IsPending = IsPending;
			fileMediaBase.ContainerId = ContainerId;
		}
		return newMedia;
	}

	public virtual void UpdateSource(bool userInitiated, RelativePath filename, bool didFileChange = true)
	{
		SourceFile = filename;
	}

	public void StartObservingSourceFile()
	{
		if (!_watchSourceFile)
		{
			_watchSourceFile = true;
			StartWatching(SourceFile);
		}
	}

	private void StartWatching(RelativePath path)
	{
		if ((object)path != null && !path.IsEmpty)
		{
			WatcherReference watcherReference = MetadataLoader.StartWatchingMediaFile(path);
			if (watcherReference != null)
			{
				_watcher = watcherReference;
				_watcher.Created += UpdateValidity;
				_watcher.Deleted += UpdateValidity;
				_watcher.Renamed += UpdateValidity;
			}
		}
	}

	public void StopObservingSourceFile()
	{
		if (_watchSourceFile)
		{
			_watchSourceFile = false;
			StopWatching();
		}
	}

	private void StopWatching()
	{
		if (_watcher != null)
		{
			_watcher.Created -= UpdateValidity;
			_watcher.Deleted -= UpdateValidity;
			_watcher.Renamed -= UpdateValidity;
			_watcher.Dispose();
			_watcher = null;
		}
	}

	public MediaMetadataRequest GenerateMetadataRequest(bool userInitiated)
	{
		return GenerateMetadataRequest(isImport: false, fullSize: false, userInitiated);
	}

	protected virtual MediaMetadataRequest GenerateMetadataRequest(bool isImport, bool fullSize, bool userInitiated)
	{
		string containerId = ContainerId;
		Guid iD = base.ID;
		string filename = SourceFile;
		TimeSlice zero = TimeSlice.Zero;
		CropInsets insets = new CropInsets();
		bool wasRequestUserInitiated = userInitiated;
		string proContentDownloadId = ((File.RemoteProperties is ProContentFileProperties proContentFileProperties) ? proContentFileProperties.DownloadId : null);
		return new MediaMetadataRequest(containerId, iD, filename, zero, null, insets, flipVertically: false, flipHorizontally: false, NativeRotation.RotateStandard, isImport, nativeRotationInitialized: true, fullSize, AlphaType.Straight, null, wasRequestUserInitiated, proContentDownloadId);
	}

	private void SourceFile_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged("SourceFile");
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("FullPath"))
		{
			LoadMetadata(isDeserializing: false);
			if (_watchSourceFile)
			{
				StartWatching(SourceFile);
			}
		}
	}

	protected virtual void LoadMetadata(bool isDeserializing, bool shouldResolve = true)
	{
		if (shouldResolve)
		{
			SourceFile.UpdateValidity();
		}
	}

	protected void UpdateData(Guid id, RelativePath filename)
	{
		base.ID = id;
		SourceFile = filename;
	}

	protected static MediaMetadata LoadMetadataFromProtoMedia(Pro.SerializationInterop.RVProtoData.Media protoMedia, bool supportsAlphaChannel)
	{
		return MediaMetadata.FromProtoMedia(protoMedia, supportsAlphaChannel);
	}

	protected void MetadataLoadSuccess()
	{
		this.MetadataLoadSuccessful?.Invoke(this);
	}

	protected void MetadataLoadFail()
	{
		this.MetadataLoadFailed?.Invoke(this);
	}

	protected virtual void OnSourceFileChanged(RelativePath oldValue, RelativePath newValue)
	{
	}

	public override void UpdateValidity()
	{
		SourceFile?.UpdateValidity();
		base.UpdateValidity();
		OnPropertyChanged("IsRemoteMedia");
		OnPropertyChanged("Availability");
	}

	public void DisconnectMediaNotifications()
	{
		_mediaReferenceChangedSubscription?.Dispose();
		_mediaReferenceChangedSubscription = null;
	}

	public void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media protoMedia, string containerId)
	{
		ContainerId = containerId;
		ProtoDeserialize(protoMedia);
	}

	public void UpdateContainerId(string containerId)
	{
		if (!(containerId == ContainerId) && FlagService.IsFlagEnabled(Flag.Cloud))
		{
			RemoveFromMediaService(deleteAssets: false);
			ContainerId = containerId;
			LoadMetadata(isDeserializing: false, shouldResolve: false);
		}
	}

	public abstract Task AddToMediaServiceAsync(bool userInitiated);

	public abstract void AddToMediaService(bool userInitiated);

	public abstract void AddToMediaServiceAndApplyTransform(bool userInitiated);

	public abstract Task RemoveFromMediaServiceAsync(bool deleteAssets);

	public abstract void RemoveFromMediaService(bool deleteAssets);
}
