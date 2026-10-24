using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements;

public class LineFillMask : NotifyPropertyChangedBase, IRenderEquatable<LineFillMask>, IRenderHashable, ICloneable<LineFillMask>
{
	private bool _isEnabled;

	private LineMaskStyle _maskStyle;

	private double _heightOffset;

	private double _verticalOffset;

	private double _widthOffset;

	private double _horizontalOffset;

	public UndoStack? UndoStack { get; set; }

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			SetValue("IsEnabled", ref _isEnabled, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.LineFillMaskEnabled.ToAction(), this, "IsEnabled", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public LineMaskStyle MaskStyle
	{
		get
		{
			return _maskStyle;
		}
		set
		{
			SetValue("MaskStyle", ref _maskStyle, value, delegate(LineMaskStyle o, LineMaskStyle n)
			{
				UndoStack?.Commit(UndoActionTypes.LineFillMaskStyle.ToAction(), this, "MaskStyle", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public double HeightOffset
	{
		get
		{
			return _heightOffset;
		}
		set
		{
			SetValue("HeightOffset", ref _heightOffset, value, delegate(double o, double n)
			{
				UndoStack?.Commit(UndoActionTypes.LineFillMaskHeightOffset.ToAction(), this, "HeightOffset", o, n);
			});
		}
	}

	public double VerticalOffset
	{
		get
		{
			return _verticalOffset;
		}
		set
		{
			SetValue("VerticalOffset", ref _verticalOffset, value, delegate(double o, double n)
			{
				UndoStack?.Commit(UndoActionTypes.LineFillMaskVerticalOffset.ToAction(), this, "VerticalOffset", o, n);
			});
		}
	}

	public double WidthOffset
	{
		get
		{
			return _widthOffset;
		}
		set
		{
			SetValue("WidthOffset", ref _widthOffset, value, delegate(double o, double n)
			{
				UndoStack?.Commit(UndoActionTypes.LineFillMaskWidthOffset.ToAction(), this, "WidthOffset", o, n);
			});
		}
	}

	public double HorizontalOffset
	{
		get
		{
			return _horizontalOffset;
		}
		set
		{
			SetValue("HorizontalOffset", ref _horizontalOffset, value, delegate(double o, double n)
			{
				UndoStack?.Commit(UndoActionTypes.LineFillMaskHorizontalOffset.ToAction(), this, "HorizontalOffset", o, n);
			});
		}
	}

	public bool RenderEquals([NotNullWhen(true)] LineFillMask? other)
	{
		if (other != null && _isEnabled == other._isEnabled && _maskStyle == other._maskStyle && _heightOffset == other._heightOffset && _verticalOffset == other._verticalOffset && _widthOffset == other._widthOffset)
		{
			return _horizontalOffset == other._horizontalOffset;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_isEnabled, _maskStyle, _heightOffset, _verticalOffset, _widthOffset, _horizontalOffset);
	}

	public LineFillMask Clone()
	{
		return new LineFillMask
		{
			_isEnabled = _isEnabled,
			_maskStyle = _maskStyle,
			_heightOffset = _heightOffset,
			_verticalOffset = _verticalOffset,
			_widthOffset = _widthOffset,
			_horizontalOffset = _horizontalOffset
		};
	}

	public Graphics.Types.Text.Types.LineFillMask Serialize()
	{
		return new Graphics.Types.Text.Types.LineFillMask
		{
			Enabled = _isEnabled,
			MaskStyle = _maskStyle.ToProtoLineMaskStyle(),
			HeightOffset = _heightOffset,
			VerticalOffset = _verticalOffset,
			WidthOffset = _widthOffset,
			HorizontalOffset = _horizontalOffset
		};
	}

	public void Deserialize(Graphics.Types.Text.Types.LineFillMask protoLineFillMask)
	{
		if (protoLineFillMask != null)
		{
			_isEnabled = protoLineFillMask.Enabled;
			_maskStyle = protoLineFillMask.MaskStyle.ToLineMaskStyle();
			_heightOffset = protoLineFillMask.HeightOffset;
			_verticalOffset = protoLineFillMask.VerticalOffset;
			_widthOffset = protoLineFillMask.WidthOffset;
			_horizontalOffset = protoLineFillMask.HorizontalOffset;
		}
	}
}
