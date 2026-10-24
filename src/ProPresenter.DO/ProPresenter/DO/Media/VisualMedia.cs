using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.ssAPI;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Media.Services;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Media;

public class VisualMedia : FileMediaBase, IDrawMedia, ITextFillMedia, INotifyPropertyChanged, ICloneable<ITextFillMedia>, IEquatable<ITextFillMedia>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private MediaMetadataRequest? _inFlightMetadataRequest;

	private bool _nativeRotationInitialized;

	public override MediaType MediaType => MediaType.Image;

	public TimelineItemType TimelineItemType => TimelineItemType.VisualMedia;

	public DrawingProperties Drawing { get; }

	public bool SupportsScaleAndBlur { get; set; } = true;

	public bool SupportsCustomScale { get; set; }

	public bool SupportsAudio { get; set; } = true;

	public virtual TimeSlice ThumbnailPosition => TimeSlice.FromSeconds(-1.0);

	protected bool FullSize { get; set; }

	public BitmapSource? PreviewImage => Drawing?.PreviewImage;

	public BitmapSource? FullSizeImage => Drawing?.PreviewImage;

	public ScaleBehavior ScaleBehavior => Drawing?.ScaleBehavior ?? ScaleBehavior.StretchToFill;

	protected IRemoteFileLoader RemoteFileLoader { get; }

	protected IAsyncExecutor Executor { get; }

	public override string? Url => base.SourceFile.FullPath;

	public ITrackedMediaHelpers Helpers { get; }

	public event Action<ITextFillMedia>? TextFillDataModified;

	public override ObjectBinder<MediaBase, IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia right)
	{
		IMedia.Types.ITypeProperties.IImage image = right.TypeProperties.Value as IMedia.Types.ITypeProperties.IImage;
		if (image == null)
		{
			image = entityFactory.Create<IMedia.Types.ITypeProperties.IImage>();
			right.TypeProperties.Set(image);
		}
		ObjectBinder<VisualMedia, IMedia.Types.IImageTypeProperties> visualMediaBinder = new ObjectBinder<VisualMedia, IMedia.Types.IImageTypeProperties>(this, image.Value);
		visualMediaBinder.Bind((VisualMedia l) => l.WhenPropertyChanges("Drawing"), (IMedia.Types.IImageTypeProperties r) => r.Drawing.WhenValueChanges, delegate(VisualMedia l, IMedia.Types.IImageTypeProperties r)
		{
			r.Drawing.Set(l.Drawing.HandleDrawingPropertiesModelChange(scheduler, entityFactory));
		}, delegate(IMedia.Types.IImageTypeProperties r, VisualMedia l)
		{
			l.Drawing.HandleDrawingPropertiesCrdtChange(r.Drawing.Value, scheduler, entityFactory);
		}).Bind((VisualMedia l) => l.WhenPropertyChanges("File"), (IMedia.Types.IImageTypeProperties r) => r.File.WhenValueChanges, delegate(VisualMedia l, IMedia.Types.IImageTypeProperties r)
		{
			r.File.Set(l.File.HandleFilePropertiesModelChange(entityFactory));
		}, delegate(IMedia.Types.IImageTypeProperties r, VisualMedia l)
		{
			l.File.HandleFilePropertiesCrdtChange(r.File.Value);
			if ((object)l.File?.SourceFile != null && l.File.SourceFile.FullPath != l.SourceFile.FullPath)
			{
				l.UpdateSource(userInitiated: false, l.File.SourceFile);
			}
		});
		ObjectBinder<MediaBase, IMedia> objectBinder = base.CreateBinder(scheduler, entityFactory, right);
		objectBinder.DoOnInitializeRightFromLeft(visualMediaBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(visualMediaBinder.InitializeLeftFromRight).RegisterChildDisposable(() => visualMediaBinder);
		return objectBinder;
	}

	public virtual void SerializeToEntity(IEntityFactory entityFactory, IMedia media)
	{
		media.Uuid.Set(base.ID);
		if (media.TypeProperties is IMedia.Types.ITypeProperties.IImage image)
		{
			Drawing.SerializeToEntity(entityFactory, image.Value.Drawing.Value);
			base.File.SerializeToEntity(image.Value.File.Value);
		}
	}

	public virtual void DeserializeEntity(IMedia media)
	{
		base.ID = media.Uuid.Value;
		if (media.TypeProperties is IMedia.Types.ITypeProperties.IImage image)
		{
			Drawing.DeserializeEntity(image.Value.Drawing.Value);
			base.File.DeserializeEntity(image.Value.File.Value);
		}
	}

	public VisualMedia(IMetadataLoader metadataLoader, IRemoteFileLoader remoteFileLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IFlagService flagService, IReadOnlyList<EffectDescription> availableEffects, string containerId, RelativePath? filename = null, Guid? overrideId = null)
		: this(new DrawingProperties(availableEffects), new ProPresenter.DO.Media.Properties.FileProperties(), metadataLoader, remoteFileLoader, executor, mediaHelpers, flagService, containerId, filename ?? RelativePath.Empty(), overrideId)
	{
	}

	protected VisualMedia(DrawingProperties drawing, ProPresenter.DO.Media.Properties.FileProperties file, IMetadataLoader metadataLoader, IRemoteFileLoader remoteFileLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IFlagService flagService, string containerId, RelativePath? filename = null, Guid? overrideId = null)
		: base(filename ?? RelativePath.Empty(), metadataLoader, flagService, file, containerId, overrideId)
	{
		RemoteFileLoader = remoteFileLoader;
		Executor = executor;
		Drawing = drawing;
		base.File.SourceFile = base.SourceFile;
		Helpers = mediaHelpers;
		Drawing.DataModified += Drawing_DataModified;
		base.File.DataModified += OnDataModified;
		Drawing.RefreshThumbnail += RefreshThumbnail;
		Drawing.PreviewImageUpdated += delegate
		{
			OnPropertyChanged("PreviewImage");
		};
		if (base.SourceFile.IsValid && MediaType == MediaType.Image && (!flagService.IsFlagEnabled(Flag.Cloud) || !string.IsNullOrEmpty(containerId)))
		{
			LoadMetadata(isDeserializing: false, shouldResolve: false);
		}
	}

	ITextFillMedia ICloneable<ITextFillMedia>.Clone()
	{
		return (VisualMedia)Clone();
	}

	public override MediaBase Clone()
	{
		DrawingProperties drawing = Drawing.Clone();
		ProPresenter.DO.Media.Properties.FileProperties file = base.File.Clone();
		return CopyProperties(CreateNewVisualMedia(drawing, file));
	}

	protected override MediaBase CopyProperties(MediaBase newMedia)
	{
		if (newMedia is VisualMedia visualMedia)
		{
			visualMedia.FullSize = FullSize;
			visualMedia.SupportsCustomScale = SupportsCustomScale;
		}
		return base.CopyProperties(newMedia);
	}

	protected virtual VisualMedia CreateNewVisualMedia(DrawingProperties drawing, ProPresenter.DO.Media.Properties.FileProperties file)
	{
		return new VisualMedia(drawing, file, base.MetadataLoader, RemoteFileLoader, Executor, Helpers, base.FlagService, base.ContainerId, null, null);
	}

	public override void UpdateSource(bool userInitiated, RelativePath filename, bool didFileChange = true)
	{
		RelativePath originalFile = base.SourceFile;
		base.UpdateSource(userInitiated, filename, didFileChange);
		if (!didFileChange)
		{
			return;
		}
		base.MetadataLoaded = false;
		_nativeRotationInitialized = false;
		Executor.ExecuteAsync(async delegate
		{
			if (!string.IsNullOrEmpty(originalFile))
			{
				try
				{
					await RemoveFromMediaServiceAsync(deleteAssets: false);
					await OnLoadMetadata(!userInitiated, isImport: false, FullSize, applyTransform: true);
					return;
				}
				catch (Exception)
				{
					MetadataLoadFail();
					throw;
				}
			}
			LoadMetadata(!userInitiated);
		});
	}

	protected override void OnSourceFileChanged(RelativePath oldValue, RelativePath newValue)
	{
		if (base.File != null)
		{
			base.File.SourceFile = newValue;
		}
	}

	protected override MediaMetadataRequest GenerateMetadataRequest(bool isImport, bool fullSize, bool userInitiated)
	{
		string containerId = base.ContainerId;
		Guid iD = base.ID;
		string filename = base.SourceFile;
		TimeSlice thumbnailPosition = ThumbnailPosition;
		EffectsCollection effects = Drawing.Effects;
		CropInsets insets = (Drawing.CropEnable ? Drawing.CropInsets : new CropInsets());
		bool flipVertically = Drawing.FlipVertically;
		bool flipHorizontally = Drawing.FlipHorizontally;
		NativeRotation nativeRotation = Drawing.NativeRotation;
		bool nativeRotationInitialized = _nativeRotationInitialized;
		AlphaType alphaType = Drawing.AlphaType;
		bool wasRequestUserInitiated = userInitiated;
		string proContentDownloadId = ((base.File.RemoteProperties is ProContentFileProperties proContentFileProperties) ? proContentFileProperties.DownloadId : null);
		return new MediaMetadataRequest(containerId, iD, filename, thumbnailPosition, effects, insets, flipVertically, flipHorizontally, nativeRotation, isImport, nativeRotationInitialized, fullSize, alphaType, null, wasRequestUserInitiated, proContentDownloadId);
	}

	protected override void LoadMetadata(bool isDeserializing, bool shouldResolve = true)
	{
		OnPropertyChanged("Metadata");
		base.MetadataLoaded = false;
		base.LoadMetadata(isDeserializing, shouldResolve);
		Executor.ExecuteAsync(() => OnLoadMetadata(isDeserializing, isImport: false, FullSize));
	}

	private async Task OnLoadMetadata(bool isDeserializing, bool isImport = false, bool fullSize = false, bool applyTransform = false)
	{
		_inFlightMetadataRequest = null;
		MediaMetadataRequest metadataRequest = (_inFlightMetadataRequest = GenerateMetadataRequest(isImport, fullSize, !isDeserializing));
		IMetadataLoader.IResult result = await base.MetadataLoader.LoadMetadataAsync(metadataRequest, applyTransform).ConfigureAwait(continueOnCapturedContext: true);
		if (!(result is IMetadataLoader.PendingResult))
		{
			_inFlightMetadataRequest = null;
		}
		OnMetadataLoaded(isDeserializing, result, metadataRequest);
	}

	protected virtual void OnMetadataLoaded(bool isDeserializing, IMetadataLoader.IResult result, MediaMetadataRequest? request)
	{
		Drawing.RefreshThumbnail -= RefreshThumbnail;
		if (result is IMetadataLoader.SuccessfulResult successfulResult)
		{
			MediaMetadata metadata = successfulResult.Metadata;
			base.Availability = metadata.Availability;
			if (!string.IsNullOrEmpty(metadata.SourceUrl) && metadata.SourceUrl != base.SourceFile.FullPath)
			{
				UpdateSource(userInitiated: false, (RelativePath)metadata.SourceUrl, didFileChange: false);
			}
			if (request != null && !request.NativeRotationInitialized)
			{
				request.NativeRotation = metadata.Rotation;
			}
			if (!base.MetadataLoaded)
			{
				base.MetadataLoaded = true;
				base.Metadata = metadata;
				if (Drawing.NaturalSize.X <= 0 && Drawing.NaturalSize.Y <= 0)
				{
					Drawing.CropPosition = Vector2<double>.Zero;
					Drawing.CropSize = base.Metadata.Size.Cast<double>();
					Drawing.NaturalSize = base.Metadata.Size;
				}
				_nativeRotationInitialized = true;
				if (request != null && !request.NativeRotationInitialized && Drawing.UpdateWithNewMediaSizeAndRotation(base.Metadata.Size, base.Metadata.Rotation))
				{
					OnLoadMetadata(isDeserializing, isImport: false, FullSize);
					return;
				}
			}
			if (result is IMetadataLoader.SuccessfulResult successfulResult2)
			{
				Drawing.PreviewImage = successfulResult2.Thumbnail;
			}
			base.IsPending = false;
			if (!isDeserializing)
			{
				OnDataModified();
			}
			MetadataLoadSuccess();
			OnVisualInvalidated();
			_inFlightMetadataRequest = null;
		}
		else if (result is IMetadataLoader.PendingResult)
		{
			base.IsPending = true;
		}
		else
		{
			base.IsPending = false;
			MetadataLoadFail();
		}
		Drawing.RefreshThumbnail += RefreshThumbnail;
	}

	protected override void OnWhenMediaReferenceChanged(IMetadataLoader.UuidIdentifiedResult data)
	{
		base.MetadataLoaded = false;
		OnMetadataLoaded(isDeserializing: false, data.Result, _inFlightMetadataRequest);
	}

	protected internal override Pro.SerializationInterop.RVProtoData.Media ProtoSerialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media
		{
			Uuid = base.ID.ToUUID(),
			Metadata = base.Metadata.ToProtoMetadata(base.File.RemoteProperties?.GetManufacture() ?? string.Empty),
			Url = base.SourceFile.Serialize(),
			Image = new Pro.SerializationInterop.RVProtoData.Media.Types.ImageTypeProperties
			{
				Drawing = Drawing.Serialize(),
				File = base.File.Serialize()
			}
		};
	}

	protected internal override void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media? protoMedia)
	{
		base.SuppressDataModifications = true;
		try
		{
			if (protoMedia != null)
			{
				Drawing.RefreshThumbnail -= RefreshThumbnail;
				UpdateData(protoMedia.Uuid.ToGuid(), new RelativePath(protoMedia.Url));
				Drawing.DataModified -= Drawing_DataModified;
				Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties drawingProperties = protoMedia.Image?.Drawing ?? protoMedia.Video?.Drawing;
				if (drawingProperties != null)
				{
					Drawing.Deserialize(drawingProperties);
				}
				Pro.SerializationInterop.RVProtoData.FileProperties fileProperties = protoMedia.Image?.File ?? protoMedia.Video?.File;
				if (fileProperties != null)
				{
					base.File.Deserialize(fileProperties);
				}
				_nativeRotationInitialized = drawingProperties != null;
				Drawing.DataModified += Drawing_DataModified;
				LoadMetadata(isDeserializing: true);
				OnVisualInvalidated();
				Drawing.RefreshThumbnail += RefreshThumbnail;
			}
		}
		finally
		{
			base.SuppressDataModifications = false;
		}
	}

	protected override void UndoStackChanged(UndoStack? undoStack)
	{
		Drawing.UndoStack = undoStack;
	}

	protected void Drawing_DataModified()
	{
		OnVisualInvalidated();
		OnDataModified();
	}

	public virtual void RefreshThumbnail(bool userInitiated)
	{
		if (base.SourceFile.IsEmpty)
		{
			return;
		}
		Executor.ExecuteAsync(async delegate
		{
			try
			{
				await OnLoadMetadata(isDeserializing: false, isImport: false, FullSize, applyTransform: true);
			}
			catch (Exception)
			{
				MetadataLoadFail();
				throw;
			}
		});
	}

	public void SetThumbnailToFullSize()
	{
		if (!FullSize)
		{
			FullSize = true;
			if (base.MetadataLoaded)
			{
				RefreshThumbnail(userInitiated: true);
			}
		}
	}

	public override void TransposeProperties(MediaBase media)
	{
		if (media is VisualMedia visualMedia)
		{
			Drawing.RefreshThumbnail -= RefreshThumbnail;
			Drawing.TransposeProperties(visualMedia.Drawing);
			Drawing.RefreshThumbnail += RefreshThumbnail;
		}
		RefreshThumbnail(userInitiated: false);
	}

	protected override void OnDataModified()
	{
		base.OnDataModified();
		if (!base.SuppressDataModifications)
		{
			this.TextFillDataModified?.Invoke(this);
		}
		if (!base.MetadataLoaded)
		{
			TryLoadThumbnail();
		}
	}

	private void TryLoadThumbnail()
	{
		IRemoteFileLoader remoteFileLoader = RemoteFileLoader;
		if (remoteFileLoader == null || base.File.RemoteProperties == null)
		{
			return;
		}
		remoteFileLoader.LoadThumbnailAsync(base.File.RemoteProperties).ContinueWith(delegate(Task<BitmapSource?> loadTask)
		{
			BitmapSource result = loadTask.Result;
			if (Drawing.PreviewImage == null)
			{
				Drawing.PreviewImage = result;
			}
		}).ExecuteAsync();
	}

	public virtual Pro.SerializationInterop.RVProtoData.Media Serialize()
	{
		return ProtoSerialize();
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Media media)
	{
		ProtoDeserialize(media);
	}

	public override void UpdateValidity()
	{
		base.UpdateValidity();
		if (Drawing.PreviewImage == null)
		{
			LoadMetadata(isDeserializing: false);
		}
	}

	public bool Equals(ITextFillMedia? other)
	{
		if (!(other is VisualMedia visualMedia))
		{
			return false;
		}
		if (base.SourceFile.FullPath == visualMedia.SourceFile.FullPath && IsValid == visualMedia.IsValid)
		{
			return Drawing.RenderEquals(visualMedia.Drawing);
		}
		return false;
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
