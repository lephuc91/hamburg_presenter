using System;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class Bar : NotifyPropertyChangedBase, IEquatable<Bar>, ICloneable<Bar>
{
	private BarType _type;

	private BarStyle _style;

	private Color _color = Colors.Black;

	private bool _byWord;

	private int? _hashCode;

	public UndoStack? UndoStack { get; set; }

	public BarType Type
	{
		get
		{
			return _type;
		}
		set
		{
			SetValue("Type", ref _type, value, delegate(BarType o, BarType n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.BarType), this, "Type", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public BarStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			SetValue("Style", ref _style, value, delegate(BarStyle o, BarStyle n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.BarStyle), this, "Style", o, n, null, null, autoFinalize: true);
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
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.BarColor), this, "Color", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public bool ByWord
	{
		get
		{
			return _byWord;
		}
		set
		{
			SetValue("ByWord", ref _byWord, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.BarByWord), this, "ByWord", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(_type, _style, _color, _byWord);
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Bar other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Bar? other)
	{
		if ((object)other != null && _type == other._type && _style == other._style && _color == other._color)
		{
			return _byWord == other._byWord;
		}
		return false;
	}

	public Bar Clone()
	{
		return new Bar
		{
			_type = _type,
			_style = _style,
			_color = _color,
			_byWord = _byWord
		};
	}

	public static bool operator ==(Bar lhs, Bar rhs)
	{
		return lhs.NullableEquals<Bar>(rhs);
	}

	public static bool operator !=(Bar lhs, Bar rhs)
	{
		return !lhs.NullableEquals<Bar>(rhs);
	}
}
