using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Editor;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class MediaFill : FillBase
{
	private readonly IMediaFactory _mediaFactory;

	private VisualMedia? _media;

	private Vector2<double> _parentSize = Vector2<double>.Zero;

	private Vector2<double> _cropPosition = Vector2<double>.Zero;

	private Vector2<double> _cropSize = Vector2<double>.Zero;

	private Angle<double> _cropRotation = Angle<double>.Zero;

	private Vector2<double> _previousCustomFitCropPosition = Vector2<double>.Zero;

	private Vector2<double> _previousCustomFitCropSize = Vector2<double>.Zero;

	private Angle<double> _previousCustomFitCropRotation = Angle<double>.Zero;

	private bool _startObserveSourceFile;

	public override FillType Type => FillType.Media;

	public override string DisplayName => Media?.SourceFile.Filename ?? string.Empty;

	public override bool IsAspectRatioLockForced => CropRotation.InvertedCartesianValue.Mod(90.0) != 0.0;

	public bool IsValid
	{
		get
		{
			if (IsEnabled)
			{
				if (Media != null)
				{
					return Media.IsValid;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsRemoteMedia => Media?.IsRemoteMedia ?? false;

	public MediaAvailability Availability => Media?.Availability ?? MediaAvailability.Unset;

	public bool IsPending => Media?.IsPending ?? false;

	public ScaleBehavior ScaleType
	{
		get
		{
			return _media?.Drawing.ScaleBehavior ?? ScaleBehavior.ScaleToFit;
		}
		set
		{
			if (_media != null && _media.Drawing.ScaleBehavior != value)
			{
				ScaleBehavior scaleBehavior = _media.Drawing.ScaleBehavior;
				base.UndoStack?.Commit(UndoActionTypes.ElementMediaFillScaleType.ToAction(), this, "ScaleType", scaleBehavior, value);
				_media.Drawing.ScaleBehavior = value;
				if (value == ScaleBehavior.CustomFit)
				{
					SetupCustomFit();
				}
				OnPropertyChanged("ScaleType");
			}
		}
	}

	public ScaleAlignment Alignment
	{
		get
		{
			return _media?.Drawing.ScaleAlignment ?? ScaleAlignment.MiddleCenter;
		}
		set
		{
			if (_media != null && _media.Drawing.ScaleAlignment != value)
			{
				ScaleAlignment scaleAlignment = _media.Drawing.ScaleAlignment;
				base.UndoStack?.Commit(UndoActionTypes.ElementMediaFillScaleAlignment.ToAction(), this, "Alignment", scaleAlignment, value);
				_media.Drawing.ScaleAlignment = value;
				OnPropertyChanged("Alignment");
			}
		}
	}

	public VisualMedia? Media
	{
		get
		{
			return _media;
		}
		set
		{
			SetValue<VisualMedia>("Media", ref _media, value, delegate(VisualMedia o, VisualMedia n)
			{
				using (base.UndoStack?.Transaction(UndoActionTypes.ElementMediaFillMedia.ToAction()))
				{
					base.UndoStack?.Commit(UndoActionTypes.ElementMediaFillMedia.ToAction(), this, "Media", o, n);
					if (o != null)
					{
						o.PropertyChanged -= base.RaiseLinkedValues;
						o.Drawing.PropertyChanged -= base.RaiseLinkedValues;
						o.DataModified -= Media_DataModified;
						o.MetadataLoadSuccessful -= OnMediaLoaded;
						o.Drawing.PreviewImageUpdated -= ThumbnailUpdated;
						o.StopObservingSourceFile();
					}
					if (n != null)
					{
						n.UpdateContainerId(base.ContainerId);
						n.SupportsCustomScale = true;
						n.PropertyChanged += base.RaiseLinkedValues;
						n.Drawing.PropertyChanged += base.RaiseLinkedValues;
						n.Drawing.PreviewImageUpdated += ThumbnailUpdated;
						if (!n.MetadataLoaded)
						{
							n.MetadataLoadSuccessful += OnMediaLoaded;
						}
						else
						{
							OnMediaLoaded(n);
						}
						n.SetThumbnailToFullSize();
						if (_startObserveSourceFile)
						{
							n.StartObservingSourceFile();
						}
					}
					OnPropertyChanged("IsValid");
					OnPropertyChanged("IsPending");
					OnPropertyChanged("ImageSize");
					OnPropertyChanged("DisplayName");
					OnPropertyChanged("ScaleType");
					OnPropertyChanged("Alignment");
					OnVisualInvalidated();
					OnDataModified();
				}
			});
		}
	}

	public Vector2<double> ImageSize => _media?.Metadata?.Size.Cast<double>() ?? Vector2<double>.Zero;

	public Vector2<double> CropPosition
	{
		get
		{
			return _cropPosition;
		}
		set
		{
			SetValue("CropPosition", ref _cropPosition, value, delegate(Vector2<double> o, Vector2<double> n)
			{
				base.UndoStack?.Commit(UndoActionTypes.MediaCropPosition.ToAction(), this, "CropPosition", o, n);
				if (ScaleType == ScaleBehavior.CustomFit)
				{
					_previousCustomFitCropPosition = n;
				}
				OnDataModified();
				OnVisualInvalidated();
			});
		}
	}

	public Vector2<double> CropSize
	{
		get
		{
			return _cropSize;
		}
		set
		{
			SetValue("CropSize", ref _cropSize, value, delegate(Vector2<double> o, Vector2<double> n)
			{
				base.UndoStack?.Commit(UndoActionTypes.MediaCropSize.ToAction(), this, "CropSize", o, n);
				if (ScaleType == ScaleBehavior.CustomFit)
				{
					_previousCustomFitCropSize = n;
				}
				OnDataModified();
				OnVisualInvalidated();
			});
		}
	}

	public Angle<double> CropRotation
	{
		get
		{
			return _cropRotation;
		}
		set
		{
			SetValue("CropRotation", ref _cropRotation, value, delegate(Angle<double> o, Angle<double> n)
			{
				base.UndoStack?.Commit(UndoActionTypes.MediaCropRotation.ToAction(), this, "CropRotation", o, n);
				if (ScaleType == ScaleBehavior.CustomFit)
				{
					_previousCustomFitCropRotation = n;
				}
				OnDataModified();
				OnVisualInvalidated();
				OnPropertyChanged("IsAspectRatioLockForced");
			});
		}
	}

	public static ObjectBinder<MediaFill, IGraphics.Types.IFill.Types.IFillType.IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, MediaFill left, IGraphics.Types.IFill.Types.IFillType.IMedia right)
	{
		ObjectBinder<MediaFill, IGraphics.Types.IFill.Types.IFillType.IMedia> objectBinder = new ObjectBinder<MediaFill, IGraphics.Types.IFill.Types.IFillType.IMedia>(left, right);
		objectBinder.Bind((MediaFill l) => l.WhenPropertyChanges("Media"), (IGraphics.Types.IFill.Types.IFillType.IMedia r) => r.WhenValueChanges, delegate(MediaFill l, IGraphics.Types.IFill.Types.IFillType.IMedia r)
		{
			if (l.Media != null)
			{
				IMedia media = entityFactory.Create<IMedia>();
				r.Set(media);
				ObjectBinder<MediaBase, IMedia> objectBinder2 = l.Media.CreateBinder(scheduler, entityFactory, media);
				objectBinder2.InitializeRightFromLeft();
				media.RegisterLinkedDisposable(objectBinder2);
			}
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IMedia r, MediaFill l)
		{
			VisualMedia visualMedia2 = (l.Media = l._mediaFactory.CreateMedia(r.Value, l.ContainerId, null) as VisualMedia);
			if (visualMedia2 != null)
			{
				ObjectBinder<MediaBase, IMedia> objectBinder3 = visualMedia2.CreateBinder(scheduler, entityFactory, r.Value);
				objectBinder3.InitializeLeftFromRight();
				r.Value.RegisterLinkedDisposable(objectBinder3);
			}
		});
		return objectBinder;
	}

	public MediaFill(IMediaFactory mediaFactory, string containerId)
	{
		LinkProperties("IsValid", "IsValid");
		LinkProperties("IsPending", "IsPending");
		LinkProperties("IsRemoteMedia", "IsRemoteMedia");
		LinkProperties("Availability", "Availability");
		LinkProperties("ScaleBehavior", "ScaleType");
		LinkProperties("ScaleAlignment", "Alignment");
		LinkAction("ScaleBehavior", delegate
		{
			Normalize(ScaleType);
		});
		LinkAction("ScaleAlignment", delegate
		{
			Normalize(ScaleType);
		});
		UpdateContainerId(containerId);
		_mediaFactory = mediaFactory;
	}

	public override bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (base.RenderEquals(other) && other is MediaFill mediaFill && _media?.SourceFile?.FullPath == mediaFill._media?.SourceFile?.FullPath)
		{
			VisualMedia? media = _media;
			if (media != null && media.Drawing.RenderEquals(mediaFill._media?.Drawing) && _cropPosition == mediaFill._cropPosition && _cropSize == mediaFill._cropSize && _cropRotation == mediaFill._cropRotation)
			{
				return IsPending == mediaFill.IsPending;
			}
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(base.GetRenderHashCode(), _media?.SourceFile?.FullPath, _cropPosition, _cropSize, _cropRotation, IsPending);
	}

	public override System.Windows.Media.Color Sample()
	{
		return Colors.DarkGray;
	}

	public override IFill Clone()
	{
		if (ScaleType == ScaleBehavior.CustomFit)
		{
			SetupCustomFit();
		}
		MediaFill mediaFill = new MediaFill(_mediaFactory, base.ContainerId)
		{
			Media = (_media?.Clone() as VisualMedia),
			_parentSize = _parentSize,
			CropPosition = _cropPosition,
			CropSize = _cropSize,
			CropRotation = _cropRotation,
			_previousCustomFitCropPosition = _previousCustomFitCropPosition,
			_previousCustomFitCropSize = _previousCustomFitCropSize,
			_previousCustomFitCropRotation = _previousCustomFitCropRotation
		};
		CopyProperties(mediaFill);
		return mediaFill;
	}

	protected override void OnEnabledChanged()
	{
		OnPropertyChanged("IsValid");
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		if (_media != null)
		{
			Pro.SerializationInterop.RVProtoData.Media media = _media.ProtoSerialize();
			Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties drawingProperties = media.Image?.Drawing ?? media.Video?.Drawing;
			if (drawingProperties != null)
			{
				drawingProperties.CustomImageAspectLocked = base.IsAspectRatioLocked;
				drawingProperties.CustomImageRotation = CropRotation.ToProtoAngle();
				drawingProperties.CustomImageBounds = new Rect<double>(CropPosition, CropSize).ToProtoRect();
			}
			protoFill.Media = media;
		}
	}

	protected override void OnDeserialize(Graphics.Types.Fill protoFill, string containerId)
	{
		Pro.SerializationInterop.RVProtoData.Media media = protoFill.Media;
		Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties drawingProperties = media?.Image?.Drawing ?? media?.Video?.Drawing;
		if (drawingProperties != null && media != null)
		{
			Media = createMedia();
			Media.ProtoDeserialize(media, containerId);
			CropRotation = drawingProperties.CustomImageRotation.ToAngle();
			CropPosition = drawingProperties.CustomImageBounds.ToRect().Position;
			CropSize = drawingProperties.CustomImageBounds.ToRect().Size;
			base.IsAspectRatioLocked = drawingProperties.CustomImageAspectLocked;
		}
		VisualMedia createMedia()
		{
			return protoFill.Media.TypePropertiesCase switch
			{
				Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.Image => _mediaFactory.CreateVisualMedia(containerId, null), 
				Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.Video => _mediaFactory.CreateVideoMedia(containerId, null), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	public override ICanvasElement[] GetEditableChildren(ICanvasElement parent)
	{
		return new ICanvasElement[1]
		{
			new MediaFillCropElement(this, parent)
		};
	}

	public override void OnSizeChanged(Vector2<double> oldSize, Vector2<double> newSize)
	{
		_parentSize = newSize;
		if (ScaleType != ScaleBehavior.CustomFit)
		{
			Normalize(ScaleType);
			return;
		}
		Vector2<double> vector = newSize.ComponentwiseQuotient(oldSize);
		if (IsAspectRatioLockForced)
		{
			CropSize = CropSize.ComponentwiseProduct(vector);
			CropPosition = CropPosition.ComponentwiseProduct(vector);
		}
		else
		{
			Vector2<double> vector2 = (CropPosition + CropSize * 0.5).ComponentwiseQuotient(_parentSize.ComponentwiseQuotient(vector) * 0.5).ComponentwiseProduct(_parentSize * 0.5);
			CropSize = CropSize.ComponentwiseProduct(vector.Rotate(Vector2<double>.Zero, CropRotation.InvertedCartesianValue).Abs());
			CropPosition = vector2 - CropSize / 2.0;
		}
	}

	private void Normalize(ScaleBehavior scaleBehavior)
	{
		if (_media != null && scaleBehavior != ScaleBehavior.CustomFit)
		{
			base.UndoStack?.StartIgnoring();
			CropRotation = Angle<double>.Zero;
			CropPosition = Vector2<double>.Zero;
			NativeRotation nativeRotation = _media.Drawing.NativeRotation;
			Vector2<double> size = new Rect<double>(Vector2<double>.Zero, ImageSize).Rotate(ImageSize / 2.0, nativeRotation switch
			{
				NativeRotation.Rotate90 => 90.0, 
				NativeRotation.Rotate270 => 270.0, 
				_ => 0.0, 
			}).Size;
			Vector2<double> vector = (_media.Drawing.CropEnable ? new Vector2<double>(_media.Drawing.CropInsets.Left + _media.Drawing.CropInsets.Right, _media.Drawing.CropInsets.Top + _media.Drawing.CropInsets.Bottom) : Vector2<double>.Zero);
			size -= vector;
			CropSize = MediaScaleHelper.Scale(size, _parentSize, scaleBehavior);
			if (scaleBehavior == ScaleBehavior.ScaleToFill || scaleBehavior == ScaleBehavior.ScaleToFit || scaleBehavior == ScaleBehavior.ScaleAndBlur)
			{
				ScaleAlignment alignment = ((scaleBehavior == ScaleBehavior.ScaleAndBlur) ? ScaleAlignment.MiddleCenter : Alignment);
				CropPosition = ScaleAlignmentHelper.GetAlignedPosition(alignment, _media.Drawing.FlipHorizontally, _media.Drawing.FlipVertically, _parentSize.Abs() - CropSize);
			}
			base.UndoStack?.StopIgnoring();
		}
	}

	private void SetupCustomFit()
	{
		if (_previousCustomFitCropSize != Vector2<double>.Zero)
		{
			base.UndoStack?.StartIgnoring();
			CropPosition = _previousCustomFitCropPosition;
			CropSize = _previousCustomFitCropSize;
			CropRotation = _previousCustomFitCropRotation;
			base.UndoStack?.StopIgnoring();
		}
	}

	private void OnMediaLoaded(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= OnMediaLoaded;
		media.DataModified += Media_DataModified;
		ThumbnailUpdated();
	}

	private void ThumbnailUpdated()
	{
		Normalize(ScaleType);
		OnVisualInvalidated();
	}

	private void Media_DataModified(MediaBase media)
	{
		OnDataModified();
	}

	public void StopObservingSourceFile()
	{
		_startObserveSourceFile = false;
		Media?.StopObservingSourceFile();
	}

	public void StartObservingSourceFile()
	{
		_startObserveSourceFile = true;
		Media?.StartObservingSourceFile();
	}

	public void TransposeProperties(MediaFill mediaFill)
	{
		if (mediaFill.ScaleType == ScaleBehavior.CustomFit)
		{
			CropPosition = mediaFill.CropPosition;
			CropSize = mediaFill.CropSize;
			CropRotation = mediaFill.CropRotation;
		}
	}

	public override void UpdateContainerId(string containerId)
	{
		base.UpdateContainerId(containerId);
		((ICanReceiveMediaContainerIdUpdates)Media)?.UpdateContainerId(containerId);
	}
}
