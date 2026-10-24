using System;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class ChordPro : NotifyPropertyChangedBase, IEquatable<ChordPro>, ICloneable<ChordPro>
{
	public static readonly Color DefaultColor = System.Windows.Media.Color.FromArgb(byte.MaxValue, 251, 182, 13);

	private bool _enabled;

	private ChordProNotationType _notation;

	private Color? _color;

	public UndoStack? UndoStack { get; set; }

	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			SetValue("Enabled", ref _enabled, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ChordProEnabled), this, "Enabled", o, n);
			});
		}
	}

	public ChordProNotationType Notation
	{
		get
		{
			return _notation;
		}
		set
		{
			SetValue("Notation", ref _notation, value, delegate(ChordProNotationType o, ChordProNotationType n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ChordProNotation), this, "Notation", o, n);
			});
		}
	}

	public Color? Color
	{
		get
		{
			return _color;
		}
		set
		{
			SetValue("Color", ref _color, value, delegate(Color? o, Color? n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ChordProColor), this, "Color", o, n);
			});
		}
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_enabled, _notation, _color);
	}

	public override bool Equals(object? obj)
	{
		if (obj is ChordPro other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(ChordPro? other)
	{
		if ((object)other != null && _enabled == other._enabled && _notation == other._notation)
		{
			Color? color = _color;
			Color? color2 = other._color;
			if (color.HasValue != color2.HasValue)
			{
				return false;
			}
			if (!color.HasValue)
			{
				return true;
			}
			return color.GetValueOrDefault() == color2.GetValueOrDefault();
		}
		return false;
	}

	public ChordPro Clone()
	{
		return new ChordPro
		{
			_enabled = _enabled,
			_notation = _notation,
			_color = _color
		};
	}

	public static bool operator ==(ChordPro lhs, ChordPro rhs)
	{
		return lhs.NullableEquals<ChordPro>(rhs);
	}

	public static bool operator !=(ChordPro lhs, ChordPro rhs)
	{
		return !lhs.NullableEquals<ChordPro>(rhs);
	}
}
