using System;
using System.Collections;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;

namespace Pro.Text;

public class ListSettings : NotifyPropertyChangedBase, IEquatable<ListSettings>, ICloneable<ListSettings>
{
	private UndoStack? _undoStack;

	public LevelSettingsCollection Levels { get; }

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			UndoStack undoStack2 = (Levels.UndoStack = value);
			_undoStack = undoStack2;
		}
	}

	public event Action<ListSettings>? ListSettingsChanged;

	public ListSettings()
		: this(new LevelSettingsCollection())
	{
	}

	private ListSettings(LevelSettingsCollection levels)
	{
		Levels = levels;
		Levels.LevelSettingsChanged += delegate
		{
			this.ListSettingsChanged?.Invoke(this);
		};
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(new IEnumerable[1] { Levels });
	}

	public override bool Equals(object? obj)
	{
		if (obj is ListSettings other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(ListSettings? other)
	{
		if ((object)other != null)
		{
			return Levels.ContentsMatchExactly(other.Levels);
		}
		return false;
	}

	public ListSettings Clone()
	{
		return new ListSettings(Levels.Clone());
	}

	public static bool operator ==(ListSettings lhs, ListSettings rhs)
	{
		return lhs.NullableEquals<ListSettings>(rhs);
	}

	public static bool operator !=(ListSettings lhs, ListSettings rhs)
	{
		return !lhs.NullableEquals<ListSettings>(rhs);
	}
}
