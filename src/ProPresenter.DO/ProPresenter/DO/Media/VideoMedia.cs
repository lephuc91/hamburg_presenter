using System;
using System.Collections.Generic;
using Pro.Common.Background;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Media.Services;

namespace ProPresenter.DO.Media;

public class VideoMedia : VisualMedia, IAudioMedia, ITransportMedia, IVideoMedia
{
	public override MediaType MediaType => MediaType.Video;

	public AudioProperties Audio { get; }

	public TransportProperties Transport { get; }

	public VideoProperties Video { get; }

	public override TimeSlice ThumbnailPosition => TimeSlice.FromSeconds(Video?.ThumbnailPosition ?? (-1.0));

	public override ObjectBinder<MediaBase, IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia right)
	{
		IMedia.Types.ITypeProperties.IVideo video = right.TypeProperties.Value as IMedia.Types.ITypeProperties.IVideo;
		if (video == null)
		{
			video = entityFactory.Create<IMedia.Types.ITypeProperties.IVideo>();
			right.TypeProperties.Set(video);
		}
		ObjectBinder<VideoMedia, IMedia.Types.IVideoTypeProperties> videoMediaBinder = new ObjectBinder<VideoMedia, IMedia.Types.IVideoTypeProperties>(this, video.Value);
		videoMediaBinder.Bind((VideoMedia l) => l.WhenPropertyChanges("Audio"), (IMedia.Types.IVideoTypeProperties r) => r.Audio.WhenValueChanges, delegate(VideoMedia l, IMedia.Types.IVideoTypeProperties r)
		{
			r.Audio.Set(l.Audio.HandleAudioPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.IVideoTypeProperties r, VideoMedia l)
		{
			l.Audio.HandleAudioPropertiesCrdtChange(r.Audio.Value, scheduler, entityFactory);
		}).Bind((VideoMedia l) => l.WhenPropertyChanges("Drawing"), (IMedia.Types.IVideoTypeProperties r) => r.Drawing.WhenValueChanges, delegate(VideoMedia l, IMedia.Types.IVideoTypeProperties r)
		{
			r.Drawing.Set(l.Drawing.HandleDrawingPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.IVideoTypeProperties r, VideoMedia l)
		{
			l.Drawing.HandleDrawingPropertiesCrdtChange(r.Drawing.Value, scheduler, entityFactory);
		}).Bind((VideoMedia l) => l.WhenPropertyChanges("Transport"), (IMedia.Types.IVideoTypeProperties r) => r.Transport.WhenValueChanges, delegate(VideoMedia l, IMedia.Types.IVideoTypeProperties r)
		{
			r.Transport.Set(l.Transport.HandleTransportPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.IVideoTypeProperties r, VideoMedia l)
		{
			l.Transport.HandleTransportPropertiesCrdtChange(r.Transport.Value, scheduler, entityFactory);
		})
			.Bind((VideoMedia l) => l.WhenPropertyChanges("File"), (IMedia.Types.IVideoTypeProperties r) => r.File.WhenValueChanges, delegate(VideoMedia l, IMedia.Types.IVideoTypeProperties r)
			{
				r.File.Set(l.File.HandleFilePropertiesModelChange(entityFactory));
			}, delegate(IMedia.Types.IVideoTypeProperties r, VideoMedia l)
			{
				l.File.HandleFilePropertiesCrdtChange(r.File.Value);
			})
			.Bind((VideoMedia l) => l.WhenPropertyChanges("Video"), (IMedia.Types.IVideoTypeProperties r) => r.Video.WhenValueChanges, delegate(VideoMedia l, IMedia.Types.IVideoTypeProperties r)
			{
				IMedia.Types.IVideoProperties videoProperties = entityFactory.Create<IMedia.Types.IVideoProperties>();
				r.Video.Set(videoProperties);
				ObjectBinder<VideoProperties, IMedia.Types.IVideoProperties> objectBinder = VideoProperties.CreateBinder(Video, videoProperties);
				objectBinder.InitializeRightFromLeft();
				videoProperties.RegisterLinkedDisposable(objectBinder);
			}, delegate(IMedia.Types.IVideoTypeProperties r, VideoMedia l)
			{
				ObjectBinder<VideoProperties, IMedia.Types.IVideoProperties> objectBinder2 = VideoProperties.CreateBinder(Video, r.Video.Value);
				objectBinder2.InitializeLeftFromRight();
				r.Video.Value.RegisterLinkedDisposable(objectBinder2);
			});
		return Bind(scheduler, entityFactory, right).DoOnInitializeRightFromLeft(videoMediaBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(videoMediaBinder.InitializeLeftFromRight).RegisterChildDisposable(() => videoMediaBinder);
	}

	public override void SerializeToEntity(IEntityFactory entityFactory, IMedia media)
	{
		media.Uuid.Set(base.ID);
		if (media.TypeProperties is IMedia.Types.ITypeProperties.IVideo video)
		{
			base.Drawing.SerializeToEntity(entityFactory, video.Value.Drawing.Value);
			base.File.SerializeToEntity(video.Value.File.Value);
			Audio.SerializeToEntity(entityFactory, video.Value.Audio.Value);
			Transport.SerializeToEntity(entityFactory, video.Value.Transport.Value);
			Video.SerializeToEntity(entityFactory, video.Value.Video.Value);
		}
	}

	public override void DeserializeEntity(IMedia media)
	{
		base.ID = media.Uuid.Value;
		if (media.TypeProperties is IMedia.Types.ITypeProperties.IVideo video)
		{
			base.Drawing.DeserializeEntity(video.Value.Drawing.Value);
			base.File.DeserializeEntity(video.Value.File.Value);
			Audio.DeserializeEntity(video.Value.Audio.Value);
			Transport.DeserializeEntity(video.Value.Transport.Value);
			Video.DeserializeEntity(video.Value.Video.Value);
		}
	}

	public VideoMedia(IMetadataLoader metadataLoader, IRemoteFileLoader remoteFileLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IFlagService flagService, IAudioSetup audioSetup, IReadOnlyList<EffectDescription> availableEffects, string containerId, RelativePath? filename = null, Guid? overrideId = null)
		: this(new DrawingProperties(availableEffects), new ProPresenter.DO.Media.Properties.FileProperties(), new AudioProperties(audioSetup), new TransportProperties(), new VideoProperties(), metadataLoader, remoteFileLoader, executor, mediaHelpers, flagService, containerId, filename, overrideId)
	{
	}

	protected VideoMedia(DrawingProperties drawing, ProPresenter.DO.Media.Properties.FileProperties file, AudioProperties audio, TransportProperties transport, VideoProperties video, IMetadataLoader metadataLoader, IRemoteFileLoader remoteFileLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IFlagService flagService, string containerId, RelativePath? filename = null, Guid? overrideId = null)
		: base(drawing, file, metadataLoader, remoteFileLoader, executor, mediaHelpers, flagService, containerId, filename ?? RelativePath.Empty(), overrideId)
	{
		Audio = audio;
		Transport = transport;
		Video = video;
		Audio.DataModified += OnDataModified;
		Transport.DataModified += OnDataModified;
		Video.DataModified += OnDataModified;
		if (base.SourceFile.IsValid)
		{
			LoadMetadata(isDeserializing: false);
		}
	}

	public override MediaBase Clone()
	{
		DrawingProperties drawing = base.Drawing.Clone();
		AudioProperties audio = Audio.Clone();
		TransportProperties transport = Transport.Clone();
		VideoProperties video = Video.Clone();
		ProPresenter.DO.Media.Properties.FileProperties file = base.File.Clone();
		return CopyProperties(CreateNewVideoMedia(drawing, file, audio, transport, video));
	}

	protected virtual MediaBase CreateNewVideoMedia(DrawingProperties drawing, ProPresenter.DO.Media.Properties.FileProperties file, AudioProperties audio, TransportProperties transport, VideoProperties video)
	{
		return new VideoMedia(drawing, file, audio, transport, video, base.MetadataLoader, base.RemoteFileLoader, base.Executor, base.Helpers, base.FlagService, base.ContainerId, null, null);
	}

	protected override void OnMetadataLoaded(bool isDeserializing, IMetadataLoader.IResult result, MediaMetadataRequest? request)
	{
		if (result is IMetadataLoader.SuccessfulResult successfulResult)
		{
			MediaMetadata metadata = successfulResult.Metadata;
			Transport.UpdateDuration(metadata.Duration, base.Metadata.Duration);
			Audio.InputChannelSet.Resize(metadata.AudioChannelCount);
			Transport.EndPoint = metadata.Duration;
			Video.FrameRate = metadata.FPS;
		}
		if (!(result is IMetadataLoader.PendingResult))
		{
			base.OnMetadataLoaded(isDeserializing, result, request);
		}
	}

	protected internal override Pro.SerializationInterop.RVProtoData.Media ProtoSerialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media
		{
			Uuid = base.ID.ToUUID(),
			Metadata = base.Metadata.ToProtoMetadata(base.File.RemoteProperties?.GetManufacture()),
			Url = base.SourceFile.Serialize(),
			Video = new Pro.SerializationInterop.RVProtoData.Media.Types.VideoTypeProperties
			{
				Audio = Audio.Serialize(),
				Drawing = base.Drawing.Serialize(),
				File = base.File.Serialize(),
				Transport = Transport.Serialize(),
				Video = Video.Serialize()
			}
		};
	}

	protected internal override void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media? protoMedia)
	{
		Video.DataModified -= OnDataModified;
		if (protoMedia != null)
		{
			Video.Deserialize(protoMedia.Video.Video);
		}
		Audio.DataModified -= OnDataModified;
		Transport.DataModified -= OnDataModified;
		if (protoMedia != null)
		{
			Audio.Deserialize(protoMedia.Video.Audio);
			Transport.Deserialize(protoMedia.Video.Transport);
		}
		Audio.DataModified += OnDataModified;
		Transport.DataModified += OnDataModified;
		Video.DataModified += OnDataModified;
		base.ProtoDeserialize(protoMedia);
	}

	protected override void UndoStackChanged(UndoStack? undoStack)
	{
		Audio.UndoStack = undoStack;
		base.Drawing.UndoStack = undoStack;
		Transport.UndoStack = undoStack;
		Video.UndoStack = undoStack;
	}

	public override void TransposeProperties(MediaBase media)
	{
		if (media is VideoMedia videoMedia)
		{
			Audio.TransposeProperties(videoMedia.Audio);
			Transport.TransposeProperties(videoMedia.Transport, base.Metadata.Duration);
			Video.TransposeProperties(videoMedia.Video, base.Metadata.Duration);
		}
		base.TransposeProperties(media);
	}
}
