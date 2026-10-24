using System;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Media.Services;

namespace ProPresenter.DO.Media;

public class AudioMedia : FileMediaBase, IAudioMedia, ITransportMedia
{
	private readonly IAsyncExecutor _executor;

	private AudioType _audioType;

	public override MediaType MediaType => MediaType.Audio;

	public AudioType AudioType
	{
		get
		{
			return _audioType;
		}
		set
		{
			SetValue("AudioType", ref _audioType, value, OnDataModified);
		}
	}

	public AudioProperties Audio { get; }

	public TransportProperties Transport { get; }

	public override string? Url => base.File.SourceFile?.FullPath;

	protected ITrackedMediaHelpers Helpers { get; }

	public override ObjectBinder<MediaBase, IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia right)
	{
		IMedia.Types.ITypeProperties.IAudio audio = right.TypeProperties.Value as IMedia.Types.ITypeProperties.IAudio;
		if (audio == null)
		{
			audio = entityFactory.Create<IMedia.Types.ITypeProperties.IAudio>();
			right.TypeProperties.Set(audio);
		}
		ObjectBinder<AudioMedia, IMedia.Types.IAudioTypeProperties> audioMediaBinder = new ObjectBinder<AudioMedia, IMedia.Types.IAudioTypeProperties>(this, audio.Value);
		audioMediaBinder.Bind((AudioMedia l) => l.WhenPropertyChanges("Audio"), (IMedia.Types.IAudioTypeProperties r) => r.Audio.WhenValueChanges, delegate(AudioMedia l, IMedia.Types.IAudioTypeProperties r)
		{
			r.Audio.Set(l.Audio.HandleAudioPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.IAudioTypeProperties r, AudioMedia l)
		{
			l.Audio.HandleAudioPropertiesCrdtChange(r.Audio.Value, scheduler, entityFactory);
		}).Bind((AudioMedia l) => l.WhenPropertyChanges("Transport"), (IMedia.Types.IAudioTypeProperties r) => r.Transport.WhenValueChanges, delegate(AudioMedia l, IMedia.Types.IAudioTypeProperties r)
		{
			r.Transport.Set(l.Transport.HandleTransportPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.IAudioTypeProperties r, AudioMedia l)
		{
			l.Transport.HandleTransportPropertiesCrdtChange(r.Transport.Value, scheduler, entityFactory);
		}).Bind((AudioMedia l) => l.WhenPropertyChanges("File"), (IMedia.Types.IAudioTypeProperties r) => r.File.WhenValueChanges, delegate(AudioMedia l, IMedia.Types.IAudioTypeProperties r)
		{
			r.File.Set(l.File.HandleFilePropertiesModelChange(entityFactory));
		}, delegate(IMedia.Types.IAudioTypeProperties r, AudioMedia l)
		{
			l.File.HandleFilePropertiesCrdtChange(r.File.Value);
			if ((object)l.File?.SourceFile != null && l.File.SourceFile.FullPath != l.SourceFile.FullPath)
			{
				l.UpdateSource(userInitiated: false, l.File.SourceFile);
			}
		});
		ObjectBinder<MediaBase, IMedia> objectBinder = base.CreateBinder(scheduler, entityFactory, right);
		objectBinder.DoOnInitializeRightFromLeft(audioMediaBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(audioMediaBinder.InitializeLeftFromRight).RegisterChildDisposable(() => audioMediaBinder);
		return objectBinder;
	}

	public static ObjectBinder<AudioMedia, IAction.Types.IMediaType.Types.IMediaType.IAudio> CreateMediaTypeBinder(AudioMedia? left, IAction.Types.IMediaType.Types.IMediaType.IAudio? right)
	{
		ObjectBinder<AudioMedia, IAction.Types.IMediaType.Types.IMediaType.IAudio> objectBinder = new ObjectBinder<AudioMedia, IAction.Types.IMediaType.Types.IMediaType.IAudio>(left, right);
		objectBinder.Bind((AudioMedia l) => l.WhenPropertyChanges("AudioType"), (IAction.Types.IMediaType.Types.IMediaType.IAudio r) => r.Value.AudioType.WhenValueChanges, delegate(AudioMedia l, IAction.Types.IMediaType.Types.IMediaType.IAudio r)
		{
			IObservableProperty<IAction.Types.IMediaType.Types.IAudio.Types.MediaActionAudioType> audioType = r.Value.AudioType;
			audioType.Set(l.AudioType switch
			{
				AudioType.AudioTrack => IAction.Types.IMediaType.Types.IAudio.Types.MediaActionAudioType.Tune, 
				AudioType.SoundEffect => IAction.Types.IMediaType.Types.IAudio.Types.MediaActionAudioType.Sound, 
				_ => IAction.Types.IMediaType.Types.IAudio.Types.MediaActionAudioType.Tune, 
			});
		}, delegate(IAction.Types.IMediaType.Types.IMediaType.IAudio r, AudioMedia l)
		{
			l.AudioType = r.Value.AudioType.Value switch
			{
				IAction.Types.IMediaType.Types.IAudio.Types.MediaActionAudioType.Tune => AudioType.AudioTrack, 
				IAction.Types.IMediaType.Types.IAudio.Types.MediaActionAudioType.Sound => AudioType.SoundEffect, 
				_ => AudioType.AudioTrack, 
			};
		});
		return objectBinder;
	}

	public AudioMedia(IMetadataLoader metadataLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IFlagService flagService, IAudioSetup audioSetup, string containerId, RelativePath? filename = null, Guid? overrideId = null)
		: this(new AudioProperties(audioSetup), null, null, metadataLoader, executor, mediaHelpers, flagService, containerId, filename, overrideId)
	{
		base.File.SourceFile = base.SourceFile;
	}

	private AudioMedia(AudioProperties audio, TransportProperties? transport, ProPresenter.DO.Media.Properties.FileProperties? file, IMetadataLoader metadataLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IFlagService flagService, string containerId, RelativePath? filename = null, Guid? overrideId = null)
		: base(filename ?? RelativePath.Empty(), metadataLoader, flagService, file ?? new ProPresenter.DO.Media.Properties.FileProperties(), containerId, overrideId)
	{
		Audio = audio;
		Transport = transport ?? new TransportProperties();
		_executor = executor;
		Helpers = mediaHelpers;
		Audio.DataModified += OnDataModified;
		Transport.DataModified += OnDataModified;
		base.File.DataModified += OnDataModified;
		if (base.SourceFile.IsValid)
		{
			LoadMetadata(isDeserializing: false);
		}
	}

	public override MediaBase Clone()
	{
		AudioProperties audio = Audio.Clone();
		TransportProperties transport = Transport.Clone();
		ProPresenter.DO.Media.Properties.FileProperties file = base.File.Clone();
		return CopyProperties(new AudioMedia(audio, transport, file, base.MetadataLoader, _executor, Helpers, base.FlagService, base.ContainerId, null, null)
		{
			AudioType = AudioType
		});
	}

	protected override void OnSourceFileChanged(RelativePath oldValue, RelativePath newValue)
	{
		if (base.File != null)
		{
			base.File.SourceFile = newValue;
		}
	}

	public Pro.SerializationInterop.RVProtoData.Media Serialize()
	{
		return ProtoSerialize();
	}

	protected internal override Pro.SerializationInterop.RVProtoData.Media ProtoSerialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media
		{
			Uuid = base.ID.ToUUID(),
			Metadata = base.Metadata?.ToProtoMetadata(),
			Url = base.SourceFile.Serialize(),
			Audio = new Pro.SerializationInterop.RVProtoData.Media.Types.AudioTypeProperties
			{
				Audio = Audio.Serialize(),
				Transport = Transport.Serialize(),
				File = base.File.Serialize()
			}
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Media protoMedia)
	{
		ProtoDeserialize(protoMedia);
	}

	protected internal override void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media protoMedia)
	{
		base.SuppressDataModifications = true;
		try
		{
			UpdateData(protoMedia.Uuid.ToGuid(), new RelativePath(protoMedia.Url));
			if (protoMedia.Audio != null)
			{
				Audio.Deserialize(protoMedia.Audio.Audio);
				Transport.Deserialize(protoMedia.Audio.Transport);
				base.File.Deserialize(protoMedia.Audio.File);
			}
			base.Metadata = FileMediaBase.LoadMetadataFromProtoMedia(protoMedia, supportsAlphaChannel: false);
			if (base.Metadata.Duration == TimeSlice.Zero || base.Metadata.Duration < Transport.OutPoint)
			{
				LoadMetadata(isDeserializing: true);
			}
			else
			{
				base.MetadataLoaded = true;
			}
		}
		finally
		{
			base.SuppressDataModifications = false;
		}
	}

	protected override void LoadMetadata(bool isDeserializing, bool shouldResolve = true)
	{
		base.LoadMetadata(isDeserializing, shouldResolve);
		_executor.ExecuteAsync(() => DoLoadMetadata(isDeserializing, GenerateMetadataRequest(isImport: true, fullSize: false, !isDeserializing)));
		async Task DoLoadMetadata(bool isDeserializing, MediaMetadataRequest request)
		{
			bool isDeserializing2 = isDeserializing;
			IMetadataLoader.IResult result = await base.MetadataLoader.LoadMetadataAsync(request);
			OnMetadataLoaded(isDeserializing2, result);
		}
	}

	protected override void OnWhenMediaReferenceChanged(IMetadataLoader.UuidIdentifiedResult data)
	{
		OnMetadataLoaded(isDeserializing: false, data.Result);
	}

	private void OnMetadataLoaded(bool isDeserializing, IMetadataLoader.IResult result)
	{
		if (result is IMetadataLoader.SuccessfulResult successfulResult)
		{
			MediaMetadata metadata = successfulResult.Metadata;
			base.Availability = metadata.Availability;
			if (!string.IsNullOrEmpty(metadata.SourceUrl) && metadata.SourceUrl != base.SourceFile.FullPath)
			{
				UpdateSource(userInitiated: false, (RelativePath)metadata.SourceUrl, didFileChange: false);
			}
			Transport.UpdateDuration(metadata.Duration, base.Metadata.Duration);
			base.MetadataLoaded = true;
			base.Metadata = metadata;
			Audio.InputChannelSet.Resize(metadata.AudioChannelCount);
			Transport.EndPoint = metadata.Duration;
			if (metadata.Duration.TotalSeconds < 10.0)
			{
				AudioType = AudioType.SoundEffect;
			}
			base.IsPending = false;
			if (!isDeserializing)
			{
				OnDataModified();
			}
			MetadataLoadSuccess();
		}
		else if (result is IMetadataLoader.PendingResult)
		{
			base.IsPending = true;
			if (!isDeserializing)
			{
				OnDataModified();
			}
			MetadataLoadSuccess();
		}
		else if (result is IMetadataLoader.FailedResult)
		{
			base.IsPending = false;
			MetadataLoadFail();
		}
	}

	protected override void UndoStackChanged(UndoStack? undoStack)
	{
		Audio.UndoStack = undoStack;
		Transport.UndoStack = undoStack;
	}

	public override void UpdateSource(bool userInitiated, RelativePath filename, bool didFileChange = true)
	{
		base.UpdateSource(userInitiated, filename, didFileChange);
		if (didFileChange)
		{
			LoadMetadata(isDeserializing: false);
		}
		OnPropertyChanged("Metadata");
	}

	public override void TransposeProperties(MediaBase media)
	{
		throw new NotImplementedException();
	}

	public override Task AddToMediaServiceAsync(bool userInitiated)
	{
		if (IsValid)
		{
			return Helpers.AddToMediaServiceAsync(new global::_003C_003Ez__ReadOnlySingleElementList<ITrackedMedia>(this), userInitiated, applyTransform: false);
		}
		return Task.CompletedTask;
	}

	public override void AddToMediaService(bool userInitiated)
	{
		if (IsValid)
		{
			Helpers.AddToMediaService(new global::_003C_003Ez__ReadOnlySingleElementList<ITrackedMedia>(this), userInitiated, applyTransform: false);
		}
	}

	public override void AddToMediaServiceAndApplyTransform(bool userInitiated)
	{
		if (IsValid || base.File.RemoteProperties is ProContentFileProperties)
		{
			Helpers.AddToMediaService(new global::_003C_003Ez__ReadOnlySingleElementList<ITrackedMedia>(this), userInitiated, applyTransform: true);
		}
	}

	public override Task RemoveFromMediaServiceAsync(bool deleteAssets)
	{
		return Helpers.RemoveFromMediaServiceAsync(new global::_003C_003Ez__ReadOnlySingleElementList<ITrackedMedia>(this), deleteAssets);
	}

	public override void RemoveFromMediaService(bool deleteAssets)
	{
		Helpers.RemoveFromMediaService(new global::_003C_003Ez__ReadOnlySingleElementList<ITrackedMedia>(this), deleteAssets);
	}
}
