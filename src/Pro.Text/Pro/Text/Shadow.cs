using System;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class Shadow : NotifyPropertyChangedBase, IEquatable<Shadow>, ICloneable<Shadow>
{
	private bool _isEnabled;

	private double _blurRadius = 5.0;

	private double _opacity = 0.75;

	private Color _color = Colors.Black;

	private Angle<double> _angle = new Angle<double>(45.0);

	private double _offset = 5.0;

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
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TextShadowEnabled), this, "IsEnabled", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public double BlurRadius
	{
		get
		{
			return _blurRadius;
		}
		set
		{
			SetValue("BlurRadius", ref _blurRadius, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TextShadowBlurRadius), this, "BlurRadius", o, n);
			});
		}
	}

	public double Opacity
	{
		get
		{
			return _opacity;
		}
		set
		{
			SetValue("Opacity", ref _opacity, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TextShadowOpacity), this, "Opacity", o, n);
			});
		}
	}

	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			SetValue("Color", ref _color, value, delegate(Color o, Color n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TextShadowColor), this, "Color", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public Angle<double> Angle
	{
		get
		{
			return _angle;
		}
		set
		{
			SetValue("Angle", ref _angle, value, delegate(Angle<double> o, Angle<double> n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TextShadowAngle), this, "Angle", o, n);
			});
		}
	}

	public double Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			SetValue("Offset", ref _offset, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TextShadowOffset), this, "Offset", o, n);
			});
		}
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_isEnabled, _blurRadius, _opacity, _color, _angle, _offset);
	}

	public override bool Equals(object? obj)
	{
		if (obj is Shadow other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Shadow? other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (!_isEnabled && !other._isEnabled)
		{
			return true;
		}
		if (_isEnabled == other._isEnabled && _blurRadius == other._blurRadius && _opacity == other._opacity && _color == other._color && _angle == other._angle)
		{
			return _offset == other._offset;
		}
		return false;
	}

	public Shadow Clone()
	{
		return new Shadow
		{
			_isEnabled = _isEnabled,
			_blurRadius = _blurRadius,
			_opacity = _opacity,
			_color = _color,
			_angle = _angle,
			_offset = _offset
		};
	}

	public static bool operator ==(Shadow lhs, Shadow rhs)
	{
		return lhs.NullableEquals<Shadow>(rhs);
	}

	public static bool operator !=(Shadow lhs, Shadow rhs)
	{
		return !lhs.NullableEquals<Shadow>(rhs);
	}
}
