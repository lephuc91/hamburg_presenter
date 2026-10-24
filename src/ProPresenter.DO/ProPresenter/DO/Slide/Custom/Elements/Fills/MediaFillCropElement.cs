using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;
using Pro.Editor;
using Pro.Editor.Canvas;
using Pro.ssAPI;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class MediaFillCropElement : SimpleCanvasElement, IFilledElement
{
	public const double CropOpacity = 0.25;

	private readonly MediaFill? _fill;

	public BitmapSource? PreviewImage => _fill?.Media?.Drawing.PreviewImage;

	public IFill? Fill => _fill;

	public override ICanvasElement? CanvasParent { get; }

	public override bool IsLocked
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override bool IsHidden
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override bool IsAspectRatioLocked
	{
		get
		{
			return _fill?.IsAspectRatioLocked ?? false;
		}
		set
		{
			if (_fill != null)
			{
				_fill.IsAspectRatioLocked = value;
				_fill.ScaleType = ScaleBehavior.CustomFit;
			}
		}
	}

	public override bool IsAspectRatioLockForced => false;

	public override Vector2<double> Position
	{
		get
		{
			return FlipAdjustedPosition(_fill?.CropPosition ?? Vector2<double>.Zero);
		}
		set
		{
			if (_fill != null)
			{
				_fill.CropPosition = FlipAdjustedPosition(value);
				_fill.ScaleType = ScaleBehavior.CustomFit;
				OnPropertyChanged("Position");
			}
		}
	}

	public override Angle<double> Rotation
	{
		get
		{
			return FlipAdjustedRotation(_fill?.CropRotation ?? Angle<double>.Zero);
		}
		set
		{
			if (_fill != null)
			{
				_fill.CropRotation = FlipAdjustedRotation(value);
				_fill.ScaleType = ScaleBehavior.CustomFit;
				OnPropertyChanged("Rotation");
			}
		}
	}

	public override Vector2<double> Size
	{
		get
		{
			return _fill?.CropSize ?? new Vector2<double>(1.0);
		}
		set
		{
			if (_fill == null)
			{
				return;
			}
			Vector2<double> cropSize = this.EnsurePositiveSize(value);
			Vector2<double> zero = Vector2<double>.Zero;
			if (CanvasParent is SlideElementBase slideElementBase)
			{
				if (slideElementBase.FlipMode.HasFlag(ElementFlipMode.Horizontal))
				{
					zero.X = cropSize.X - _fill.CropSize.X;
				}
				if (slideElementBase.FlipMode.HasFlag(ElementFlipMode.Vertical))
				{
					zero.Y = cropSize.Y - _fill.CropSize.Y;
				}
			}
			_fill.CropSize = cropSize;
			_fill.ScaleType = ScaleBehavior.CustomFit;
			if (zero != Vector2<double>.Zero)
			{
				Position += zero;
			}
			OnPropertyChanged("Size");
		}
	}

	public override Rect<double> SnapBounds => new Rect<double>(Size) * this.GetGlobalTransformMatrix();

	public override Color HandleColor => Colors.Black;

	public override int ZOrder
	{
		get
		{
			return 0;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	private bool FlipHorizontally
	{
		get
		{
			SlideElementBase obj = CanvasParent as SlideElementBase;
			if (obj == null)
			{
				return false;
			}
			return obj.FlipMode.HasFlag(ElementFlipMode.Horizontal);
		}
	}

	private bool FlipVertically
	{
		get
		{
			SlideElementBase obj = CanvasParent as SlideElementBase;
			if (obj == null)
			{
				return false;
			}
			return obj.FlipMode.HasFlag(ElementFlipMode.Vertical);
		}
	}

	public MediaFillCropElement(MediaFill fill, ICanvasElement parent)
	{
		CanvasParent = parent;
		_fill = fill;
		if (_fill != null)
		{
			_fill.PropertyChanged += base.RaiseLinkedValues;
		}
		LinkProperties("CropPosition", new string[2] { "Position", "SnapBounds" });
		LinkProperties("CropSize", new string[2] { "Size", "SnapBounds" });
		LinkProperties("CropRotation", new string[2] { "Rotation", "SnapBounds" });
		LinkProperties("IsAspectRatioLockForced", "IsAspectRatioLockForced");
		LinkAction(new string[4] { "CropPosition", "CropSize", "CropRotation", "Media" }, base.OnVisualInvalidated);
	}

	private Vector2<double> FlipAdjustedPosition(Vector2<double> position)
	{
		Vector2<double> vector = CanvasParent?.Size ?? Vector2<double>.Zero;
		return new Vector2<double>(FlipHorizontally ? (vector.X - Size.X - position.X) : position.X, FlipVertically ? (vector.Y - Size.Y - position.Y) : position.Y);
	}

	private Angle<double> FlipAdjustedRotation(Angle<double> rotation)
	{
		if (FlipHorizontally == FlipVertically)
		{
			return rotation;
		}
		return -rotation;
	}
}
