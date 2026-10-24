using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reactive.Linq;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Media.Properties;

public class DrawingProperties : NotifyPropertyChangedBase, ICloneable<DrawingProperties>
{
	private BitmapSource? _previewImage;

	private ScaleBehavior _scaleBehavior;

	private ScaleAlignment _scaleAlignment = ScaleAlignment.MiddleCenter;

	private bool _flipHorizontally;

	private bool _flipVertically;

	private Vector2<int> _naturalSize;

	private NativeRotation _nativeRotation;

	private bool _cropEnable;

	private AlphaType _alphaType = AlphaType.Straight;

	private Vector2<double> _cropPosition = Vector2<double>.Zero;

	private Vector2<double> _cropSize = Vector2<double>.Zero;

	private bool _isDeserializing;

	private readonly IReadOnlyList<EffectDescription> _availableEffects;

	public BitmapSource? PreviewImage
	{
		get
		{
			return _previewImage;
		}
		set
		{
			SetValue("PreviewImage", ref _previewImage, value, OnPreviewImageUpdated);
		}
	}

	public ScaleBehavior ScaleBehavior
	{
		get
		{
			return _scaleBehavior;
		}
		set
		{
			SetValue("ScaleBehavior", ref _scaleBehavior, value, delegate(ScaleBehavior o, ScaleBehavior n)
			{
				UndoStack?.Commit(UndoActionTypes.MediaScaleBehavior.ToAction(), this, "ScaleBehavior", o, n, null, null, autoFinalize: true);
				OnPreviewImageUpdated();
				OnDataModified();
			});
		}
	}

	public ScaleAlignment ScaleAlignment
	{
		get
		{
			return _scaleAlignment;
		}
		set
		{
			SetValue("ScaleAlignment", ref _scaleAlignment, value, delegate(ScaleAlignment o, ScaleAlignment n)
			{
				UndoStack?.Commit(UndoActionTypes.MediaScreenPosition.ToAction(), this, "ScaleAlignment", o, n, null, null, autoFinalize: true);
				OnPreviewImageUpdated();
				OnDataModified();
				OnPropertyChanged("EffectiveScaleAlignment");
			});
		}
	}

	public ScaleAlignment EffectiveScaleAlignment
	{
		get
		{
			ScaleAlignment scaleAlignment = ScaleAlignment;
			if (FlipHorizontally)
			{
				switch (scaleAlignment)
				{
				case ScaleAlignment.TopLeft:
					scaleAlignment = ScaleAlignment.TopRight;
					break;
				case ScaleAlignment.MiddleLeft:
					scaleAlignment = ScaleAlignment.MiddleRight;
					break;
				case ScaleAlignment.BottomLeft:
					scaleAlignment = ScaleAlignment.BottomRight;
					break;
				case ScaleAlignment.TopRight:
					scaleAlignment = ScaleAlignment.TopLeft;
					break;
				case ScaleAlignment.MiddleRight:
					scaleAlignment = ScaleAlignment.MiddleLeft;
					break;
				case ScaleAlignment.BottomRight:
					scaleAlignment = ScaleAlignment.BottomLeft;
					break;
				}
			}
			if (FlipVertically)
			{
				switch (scaleAlignment)
				{
				case ScaleAlignment.TopLeft:
					scaleAlignment = ScaleAlignment.BottomLeft;
					break;
				case ScaleAlignment.TopCenter:
					scaleAlignment = ScaleAlignment.BottomCenter;
					break;
				case ScaleAlignment.TopRight:
					scaleAlignment = ScaleAlignment.BottomRight;
					break;
				case ScaleAlignment.BottomLeft:
					scaleAlignment = ScaleAlignment.TopLeft;
					break;
				case ScaleAlignment.BottomCenter:
					scaleAlignment = ScaleAlignment.TopCenter;
					break;
				case ScaleAlignment.BottomRight:
					scaleAlignment = ScaleAlignment.TopRight;
					break;
				}
			}
			return scaleAlignment;
		}
	}

	public bool FlipHorizontally
	{
		get
		{
			return _flipHorizontally;
		}
		set
		{
			SetValue("FlipHorizontally", ref _flipHorizontally, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.MediaFlipHorizontally.ToAction(), this, "FlipHorizontally", o, n, null, null, autoFinalize: true);
				FlipCropHorizontally();
				OnDataModified();
				OnRefreshThumbnail();
				OnPropertyChanged("EffectiveScaleAlignment");
			});
		}
	}

	public bool FlipVertically
	{
		get
		{
			return _flipVertically;
		}
		set
		{
			SetValue("FlipVertically", ref _flipVertically, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.MediaFlipVertically.ToAction(), this, "FlipVertically", o, n, null, null, autoFinalize: true);
				FlipCropVertically();
				OnDataModified();
				OnRefreshThumbnail();
				OnPropertyChanged("EffectiveScaleAlignment");
			});
		}
	}

	public Vector2<int> NaturalSize
	{
		get
		{
			return _naturalSize;
		}
		set
		{
			Vector2<int> value2 = value.Max(0);
			SetValue("NaturalSize", ref _naturalSize, value2, (System.Action)delegate
			{
				OnDataModified();
				OnPropertyChanged("EffectiveSize");
			}, (Predicate<Vector2<int>>?)null, referenceComparison: false);
		}
	}

	public Vector2<double> EffectiveSize => ((NativeRotation.GetValue() / 90.0).IsOdd() ? NaturalSize.Reflect() : NaturalSize).Cast<double>();

	public NativeRotation NativeRotation
	{
		get
		{
			return _nativeRotation;
		}
		set
		{
			SetNativeRotation(value, rotateCropInsets: true);
		}
	}

	public EffectsCollection Effects { get; private set; }

	public bool CropEnable
	{
		get
		{
			return _cropEnable;
		}
		set
		{
			SetValue("CropEnable", ref _cropEnable, value, (System.Action)delegate
			{
				OnDataModified();
				OnRefreshThumbnail();
			}, (Predicate<bool>?)null, referenceComparison: false);
		}
	}

	public Vector2<double> CropPosition
	{
		get
		{
			return _cropPosition;
		}
		set
		{
			SetValue("CropPosition", ref _cropPosition, value, (System.Action)delegate
			{
				OnDataModified();
				OnRefreshThumbnail();
			}, (Predicate<Vector2<double>>?)null, referenceComparison: false);
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
			Vector2<double> value2 = value.Max(0.0);
			SetValue("CropSize", ref _cropSize, value2, (System.Action)delegate
			{
				OnDataModified();
				OnRefreshThumbnail();
			}, (Predicate<Vector2<double>>?)null, referenceComparison: false);
		}
	}

	public CropInsets CropInsets => new CropInsets(CropPosition.X, CropPosition.Y, EffectiveSize.X - (CropPosition.X + CropSize.X), EffectiveSize.Y - (CropPosition.Y + CropSize.Y));

	public AlphaType AlphaType
	{
		get
		{
			return _alphaType;
		}
		set
		{
			SetValue("AlphaType", ref _alphaType, value, delegate(AlphaType o, AlphaType n)
			{
				UndoStack?.Commit(UndoActionTypes.MediaAlphaType.ToAction(), this, "AlphaType", o, n, null, null, autoFinalize: true);
				OnDataModified();
				OnRefreshThumbnail();
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public event System.Action? PreviewImageUpdated;

	public event Action<bool>? RefreshThumbnail;

	public ObjectBinder<DrawingProperties, IMedia.Types.IDrawingProperties> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia.Types.IDrawingProperties right)
	{
		ObjectBinder<DrawingProperties, IMedia.Types.IDrawingProperties> objectBinder = new ObjectBinder<DrawingProperties, IMedia.Types.IDrawingProperties>(this, right);
		ObjectBinder<EffectsCollection, IComplexCollection<IEffect>> effectsBinder = EffectsCollection.CreateBinder(scheduler, entityFactory, _availableEffects, Effects, right.Effects);
		ObjectBinder<EffectsCollection, IMedia.Types.IDrawingProperties> selectedEffectsPresetBinder = new ObjectBinder<EffectsCollection, IMedia.Types.IDrawingProperties>(Effects, right).Bind((EffectsCollection l) => l.WhenPropertyChanges("ID"), (IMedia.Types.IDrawingProperties r) => r.SelectedEffectPresetUuid.WhenValueChanges, delegate(EffectsCollection l, IMedia.Types.IDrawingProperties r)
		{
			r.SelectedEffectPresetUuid.Set(l.ID);
		}, delegate(IMedia.Types.IDrawingProperties r, EffectsCollection l)
		{
			l.ID = r.SelectedEffectPresetUuid.ToGuidOrEmpty();
		});
		objectBinder.Bind((DrawingProperties l) => l.WhenPropertyChanges("FlipHorizontally"), (IMedia.Types.IDrawingProperties r) => r.FlippedHorizontally.WhenValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
		{
			r.FlippedHorizontally.Set(l.FlipHorizontally);
		}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
		{
			l.FlipHorizontally = r.FlippedHorizontally.Value;
		}).Bind((DrawingProperties l) => l.WhenPropertyChanges("FlipVertically"), (IMedia.Types.IDrawingProperties r) => r.FlippedVertically.WhenValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
		{
			r.FlippedVertically.Set(l.FlipVertically);
		}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
		{
			l.FlipVertically = r.FlippedVertically.Value;
		}).Bind((DrawingProperties l) => l.WhenPropertyChanges("NaturalSize"), (IMedia.Types.IDrawingProperties r) => r.NaturalSize.WhenValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
		{
			r.NaturalSize.Set(l.NaturalSize.Cast<double>().ToSize());
		}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
		{
			l.NaturalSize = r.NaturalSize.Value.ToVector2d().Cast<int>();
		})
			.Bind((DrawingProperties l) => l.WhenPropertyChanges("ScaleAlignment"), (IMedia.Types.IDrawingProperties r) => r.ScaleAlignment.WhenValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
			{
				r.ScaleAlignment.Set(l.ScaleAlignment.ToEntityScaleAlignment());
			}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
			{
				l.ScaleAlignment = r.ScaleAlignment.Value.ToScaleAlignment();
			})
			.Bind((DrawingProperties l) => l.WhenPropertyChanges("ScaleBehavior"), (IMedia.Types.IDrawingProperties r) => r.ScaleBehavior.WhenValueChanges.ToUnit().Merge(r.IsBlurred.WhenValueChanges.ToUnit()), delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
			{
				r.ScaleBehavior.Set(l.ScaleBehavior.ToEntityScaleBehavior(out var isBlurred));
				r.IsBlurred.Set(isBlurred);
			}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
			{
				l.ScaleBehavior = r.ScaleBehavior.Value.ToScaleBehavior(r.IsBlurred.Value);
			})
			.Bind((DrawingProperties l) => l.WhenPropertyChanges("CropEnable"), (IMedia.Types.IDrawingProperties r) => r.CropEnable.WhenValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
			{
				r.CropEnable.Set(l.CropEnable);
			}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
			{
				l.CropEnable = r.CropEnable.Value;
			})
			.Bind((DrawingProperties l) => l.WhenPropertyChanges("CropPosition").ToUnit().Merge(l.WhenPropertyChanges("CropSize").ToUnit()), (IMedia.Types.IDrawingProperties r) => r.CropInsets.WhenAnyValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
			{
				IGraphics.Types.IEdgeInsets edgeInsets = r.CropInsets.Value ?? entityFactory.Create<IGraphics.Types.IEdgeInsets>();
				edgeInsets.Left.Set(l.CropInsets.Left);
				edgeInsets.Top.Set(l.CropInsets.Top);
				edgeInsets.Right.Set(l.CropInsets.Right);
				edgeInsets.Bottom.Set(l.CropInsets.Bottom);
				if (r.CropInsets.Value == null)
				{
					r.CropInsets.Set(edgeInsets);
				}
			}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
			{
				IGraphics.Types.IEdgeInsets value = r.CropInsets.Value;
				if (value != null)
				{
					l.CropPosition = new Vector2<double>(value.Left.Value, value.Top.Value);
					Vector2<double> vector = new Vector2<double>(value.Right.Value, value.Bottom.Value);
					l.CropSize = l.EffectiveSize - (l.CropPosition + vector);
				}
				else
				{
					l.CropPosition = Vector2<double>.Zero;
					l.CropSize = l.EffectiveSize;
				}
			})
			.Bind((DrawingProperties l) => l.WhenPropertyChanges("NativeRotation"), (IMedia.Types.IDrawingProperties r) => r.NativeRotation.WhenValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
			{
				r.NativeRotation.Set(l.NativeRotation.ToEntityNativeRotationType());
			}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
			{
				l.NativeRotation = r.NativeRotation.Value.ToNativeRotation();
			})
			.Bind((DrawingProperties l) => l.WhenPropertyChanges("AlphaType"), (IMedia.Types.IDrawingProperties r) => r.AlphaType.WhenValueChanges, delegate(DrawingProperties l, IMedia.Types.IDrawingProperties r)
			{
				r.AlphaType.Set(l.AlphaType.ToEntityAlphaType());
			}, delegate(IMedia.Types.IDrawingProperties r, DrawingProperties l)
			{
				l.AlphaType = r.AlphaType.Value.ToAlphaType();
			})
			.DoOnInitializeLeftFromRight(delegate
			{
				selectedEffectsPresetBinder.InitializeLeftFromRight();
				effectsBinder.InitializeLeftFromRight();
			})
			.DoOnInitializeRightFromLeft(delegate
			{
				selectedEffectsPresetBinder.InitializeRightFromLeft();
				effectsBinder.InitializeRightFromLeft();
			})
			.RegisterChildDisposable(() => new global::_003C_003Ez__ReadOnlyArray<IDisposable>(new IDisposable[2] { effectsBinder, selectedEffectsPresetBinder }));
		return objectBinder;
	}

	public void SerializeToEntity(IEntityFactory entityFactory, IMedia.Types.IDrawingProperties drawing)
	{
		drawing.FlippedVertically.Set(FlipVertically);
		drawing.FlippedHorizontally.Set(FlipHorizontally);
		drawing.NaturalSize.Set(NaturalSize.Cast<double>().ToSize());
		drawing.ScaleAlignment.Set(ScaleAlignment.ToEntityScaleAlignment());
		drawing.ScaleBehavior.Set(ScaleBehavior.ToEntityScaleBehavior(out var isBlurred));
		drawing.IsBlurred.Set(isBlurred);
		drawing.CropEnable.Set(CropEnable);
		drawing.SelectedEffectPresetUuid.Set(Effects.ID);
		IGraphics.Types.IEdgeInsets edgeInsets = entityFactory.Create<IGraphics.Types.IEdgeInsets>();
		edgeInsets.Left.Set(CropInsets.Left);
		edgeInsets.Top.Set(CropInsets.Top);
		edgeInsets.Right.Set(CropInsets.Right);
		edgeInsets.Bottom.Set(CropInsets.Bottom);
		drawing.CropInsets.Set(edgeInsets);
		drawing.NativeRotation.Set(NativeRotation.ToEntityNativeRotationType());
		drawing.AlphaType.Set(AlphaType.ToEntityAlphaType());
		Effects.SerializeToEntity(entityFactory, drawing.Effects);
	}

	public void DeserializeEntity(IMedia.Types.IDrawingProperties drawing)
	{
		FlipVertically = drawing.FlippedVertically.Value;
		FlipHorizontally = drawing.FlippedHorizontally.Value;
		NaturalSize = drawing.NaturalSize.Value.ToVector2d().Cast<int>();
		ScaleAlignment = drawing.ScaleAlignment.Value.ToScaleAlignment();
		ScaleBehavior = drawing.ScaleBehavior.Value.ToScaleBehavior(drawing.IsBlurred.Value);
		CropEnable = drawing.CropEnable.Value;
		CropPosition = new Vector2<double>(drawing.CropInsets.Value?.Left.Value ?? 0.0, drawing.CropInsets.Value?.Top.Value ?? 0.0);
		Vector2<double> vector = new Vector2<double>(drawing.CropInsets.Value?.Right.Value ?? 0.0, drawing.CropInsets.Value?.Bottom.Value ?? 0.0);
		CropSize = EffectiveSize - (CropPosition + vector);
		NativeRotation = drawing.NativeRotation.Value.ToNativeRotation();
		AlphaType = drawing.AlphaType.Value.ToAlphaType();
		Effects.DeserializeEntity(drawing.Effects, _availableEffects);
	}

	internal void TransposeProperties(DrawingProperties drawing)
	{
		if (drawing != null)
		{
			ScaleBehavior = drawing.ScaleBehavior;
			ScaleAlignment = drawing.ScaleAlignment;
			NaturalSize = drawing.NaturalSize;
			NativeRotation = drawing.NativeRotation;
			FlipHorizontally = drawing.FlipHorizontally;
			FlipVertically = drawing.FlipVertically;
			CropSize = drawing.CropSize;
			CropPosition = drawing.CropPosition;
			CropEnable = drawing.CropEnable;
			Effects = drawing.Effects;
		}
	}

	public DrawingProperties(IReadOnlyList<EffectDescription> availableEffects)
		: this(new EffectsCollection(), availableEffects)
	{
	}

	private DrawingProperties(EffectsCollection effects, IReadOnlyList<EffectDescription> availableEffects)
	{
		_availableEffects = availableEffects;
		Effects = effects ?? new EffectsCollection();
		Effects.CollectionChanged += Effects_CollectionChanged;
		Effects.ParametersDataModified += delegate
		{
			OnDataModified();
			OnRefreshThumbnail();
		};
		Effects.DataModified += delegate
		{
			OnDataModified();
		};
	}

	public DrawingProperties Clone()
	{
		return new DrawingProperties(Effects.Clone(), _availableEffects)
		{
			_previewImage = PreviewImage,
			_scaleBehavior = _scaleBehavior,
			_scaleAlignment = _scaleAlignment,
			_flipHorizontally = _flipHorizontally,
			_flipVertically = _flipVertically,
			_naturalSize = _naturalSize,
			_nativeRotation = _nativeRotation,
			_cropEnable = _cropEnable,
			_cropPosition = _cropPosition,
			_cropSize = _cropSize,
			_alphaType = _alphaType
		};
	}

	public bool UpdateWithNewMediaSizeAndRotation(Vector2<int> newNaturalSize, NativeRotation newNativeRotation)
	{
		bool result = false;
		Vector2<double> effectiveSize = EffectiveSize;
		Vector2<double> cropPosition = CropPosition;
		Vector2<double> cropSize = CropSize;
		NaturalSize = newNaturalSize;
		SetNativeRotation(newNativeRotation, rotateCropInsets: false);
		if (EffectiveSize != effectiveSize && effectiveSize.X > 0.0 && effectiveSize.Y > 0.0)
		{
			Vector2<double> scale = EffectiveSize.ComponentwiseQuotient(effectiveSize);
			CropPosition = cropPosition.ComponentwiseProduct(scale);
			CropSize = cropSize.ComponentwiseProduct(scale);
			result = CropEnable;
		}
		return result;
	}

	private void SetNativeRotation(NativeRotation newNativeRotation, bool rotateCropInsets)
	{
		Vector2<double> size = EffectiveSize;
		SetValue("NativeRotation", ref _nativeRotation, newNativeRotation, delegate(NativeRotation o, NativeRotation n)
		{
			if (rotateCropInsets)
			{
				RotateCropInsets((int)((n.GetValue() - o.GetValue()) / 90.0), size);
			}
			OnDataModified();
			OnRefreshThumbnail();
			OnPropertyChanged("EffectiveSize");
		});
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private void OnPreviewImageUpdated()
	{
		this.PreviewImageUpdated?.Invoke();
	}

	private void OnRefreshThumbnail()
	{
		this.RefreshThumbnail?.Invoke(!_isDeserializing);
	}

	public Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties drawingProperties = new Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties();
		drawingProperties.FlippedHorizontally = FlipHorizontally;
		drawingProperties.FlippedVertically = FlipVertically;
		drawingProperties.NaturalSize = NaturalSize.ToProtoSize();
		drawingProperties.ScaleAlignment = ScaleAlignment.ToProtoScaleAlignment();
		drawingProperties.ScaleBehavior = ScaleBehavior.ToProtoScaleBehavior(out var isBlurred);
		drawingProperties.IsBlurred = isBlurred;
		drawingProperties.SelectedEffectPresetUuid = Effects.ID.ToUUID();
		drawingProperties.CropEnable = CropEnable;
		drawingProperties.CropInsets = SerializeCropInsets();
		drawingProperties.NativeRotation = _nativeRotation.ToProtoNativeRotationType();
		drawingProperties.AlphaType = AlphaType.ToProtoAlphaType();
		drawingProperties.Effects.AddRange(Effects.SerializeEffects());
		return drawingProperties;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties drawing)
	{
		if (drawing == null)
		{
			return;
		}
		_isDeserializing = true;
		try
		{
			FlipHorizontally = drawing.FlippedHorizontally;
			FlipVertically = drawing.FlippedVertically;
			NaturalSize = drawing.NaturalSize?.ToVector().Cast<int>() ?? Vector2<int>.Zero;
			ScaleAlignment = drawing.ScaleAlignment.ToScaleAlignment();
			ScaleBehavior = drawing.ScaleBehavior.ToScaleBehavior(drawing.IsBlurred);
			AlphaType = drawing.AlphaType.ToAlphaType();
			Effects.CollectionChanged -= Effects_CollectionChanged;
			Effects.DeserializeEffects(drawing.SelectedEffectPresetUuid?.ToGuid() ?? Guid.Empty, drawing.Effects, _availableEffects);
			Effects.CollectionChanged += Effects_CollectionChanged;
			MediaBinHelper.CheckEffectsPresetHasChanges(Effects);
			CropEnable = drawing.CropEnable;
			NativeRotation = drawing.NativeRotation.ToNativeRotation();
			CropPosition = new Vector2<double>(drawing.CropInsets?.Left ?? 0.0, drawing.CropInsets?.Top ?? 0.0);
			Vector2<double> vector = new Vector2<double>(drawing.CropInsets?.Right ?? 0.0, drawing.CropInsets?.Bottom ?? 0.0);
			CropSize = EffectiveSize - (CropPosition + vector);
		}
		finally
		{
			_isDeserializing = false;
		}
	}

	internal Graphics.Types.EdgeInsets SerializeCropInsets()
	{
		CropInsets cropInsets = CropInsets;
		return new Graphics.Types.EdgeInsets
		{
			Top = cropInsets.Top,
			Left = cropInsets.Left,
			Right = cropInsets.Right,
			Bottom = cropInsets.Bottom
		};
	}

	private void Effects_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
		OnRefreshThumbnail();
	}

	private void FlipCropHorizontally()
	{
		GetCropInsets(out var left, out var top, out var right, out var bottom, EffectiveSize);
		UpdateCropFromInsets(top, right, bottom, left, EffectiveSize);
	}

	private void FlipCropVertically()
	{
		GetCropInsets(out var left, out var top, out var right, out var bottom, EffectiveSize);
		UpdateCropFromInsets(bottom, left, top, right, EffectiveSize);
	}

	private void RotateCropInsets(int cardinalShifts, Vector2<double> size)
	{
		cardinalShifts = cardinalShifts.Mod(4);
		if (cardinalShifts == 0)
		{
			return;
		}
		int num = cardinalShifts.Sign();
		if (FlipVertically && cardinalShifts.IsOdd())
		{
			cardinalShifts += 2 * num;
		}
		if (FlipHorizontally && cardinalShifts.IsOdd())
		{
			cardinalShifts += 2 * num;
		}
		GetCropInsets(out var left, out var top, out var right, out var bottom, size);
		double[] array = new double[4] { top, right, bottom, left };
		if (cardinalShifts > 0)
		{
			for (int i = 0; i < cardinalShifts; i++)
			{
				double num2 = array[^1];
				for (int num3 = array.Length - 1; num3 > 0; num3--)
				{
					array[num3] = array[num3 - 1];
				}
				array[0] = num2;
			}
		}
		else
		{
			for (int j = 0; j < cardinalShifts.Abs(); j++)
			{
				double num4 = array[0];
				for (int k = 0; k < array.Length - 1; k++)
				{
					array[k] = array[k + 1];
				}
				array[^1] = num4;
			}
		}
		top = array[0];
		right = array[1];
		bottom = array[2];
		left = array[3];
		UpdateCropFromInsets(top, left, bottom, right, EffectiveSize);
	}

	private void GetCropInsets(out double left, out double top, out double right, out double bottom, Vector2<double> size)
	{
		left = CropPosition.X;
		top = CropPosition.Y;
		right = size.X - (left + CropSize.X);
		bottom = size.Y - (top + CropSize.Y);
	}

	private void UpdateCropFromInsets(double top, double left, double bottom, double right, Vector2<double> size)
	{
		_cropPosition = new Vector2<double>(left, top);
		_cropSize = new Vector2<double>(size.X - left - right, size.Y - top - bottom);
		OnPropertyChanged("CropPosition");
		OnPropertyChanged("CropSize");
	}

	public bool RenderEquals(DrawingProperties? otherDrawing)
	{
		if (otherDrawing == null)
		{
			return false;
		}
		if (ScaleBehavior == otherDrawing.ScaleBehavior && ScaleAlignment == otherDrawing.ScaleAlignment && FlipHorizontally == otherDrawing.FlipHorizontally && FlipVertically == otherDrawing.FlipVertically && NativeRotation == otherDrawing.NativeRotation && CropEnable == otherDrawing.CropEnable && CropPosition == otherDrawing.CropPosition && CropSize == otherDrawing.CropSize && Effects.ContentsMatchExactly(otherDrawing.Effects, (EffectParameters lhs, EffectParameters rhs) => lhs.IsEnabled == rhs.IsEnabled && lhs == rhs))
		{
			return PreviewImage == otherDrawing.PreviewImage;
		}
		return false;
	}

	public void UpdateCrop(Vector2<double> cropPosition, Vector2<double> cropSize)
	{
		if (_cropPosition != cropPosition || _cropSize != cropSize)
		{
			_cropPosition = cropPosition;
			_cropSize = cropSize;
			OnDataModified();
			OnRefreshThumbnail();
		}
	}
}
