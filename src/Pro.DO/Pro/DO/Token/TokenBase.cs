using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Reversibility;

namespace Pro.DO.Token;

public abstract class TokenBase : LinkedNotifyPropertyChangedBase, ICloneable<TokenBase>
{
	private int _index;

	private UndoStack? _undoStack;

	public abstract string Content { get; }

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			OnUndoStackChanged(value);
		}
	}

	public int Index
	{
		get
		{
			return _index;
		}
		set
		{
			SetValue("Index", ref _index, value, delegate(int o, int n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveToken), this, "Index", o, n);
				OnIndexChanged(o, n);
				OnDataModified();
			});
		}
	}

	public event Action? DataModified;

	public abstract TokenBase Clone();

	protected virtual TokenBase CopyProperties(TokenBase token)
	{
		token.Index = Index;
		return token;
	}

	protected virtual void OnIndexChanged(int oldValue, int newValue)
	{
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void AdjustIndex(int index, bool resetInitial)
	{
		if (resetInitial)
		{
			UndoStack?.StartIgnoring();
		}
		Index = index;
		if (resetInitial)
		{
			UndoStack?.StopIgnoring();
		}
	}

	protected virtual void OnUndoStackChanged(UndoStack? value)
	{
	}
}
