using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Reversibility;

namespace Pro.DO.Token;

public class TokenCollection<T> : ImmutableObservableCollection<T>, ITokenCollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged where T : TokenBase
{
	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			base.Collection.ForEach(delegate(T t)
			{
				t.UndoStack = value;
			});
		}
	}

	public event Action? CollectionModified;

	public TokenCollection()
	{
		base.CollectionChanged += delegate
		{
			OnCollectionModified();
		};
	}

	public bool Add(T token)
	{
		return Insert(base.Count, token);
	}

	public bool Insert(int index, T token)
	{
		token.DataModified += OnCollectionModified;
		token.UndoStack = UndoStack;
		base.Collection.Insert(index, token);
		OnInsert(index, token);
		UndoStack?.Commit(UndoActionTypes.InsertToken.ToAction(), delegate
		{
			Remove(token);
		}, delegate
		{
			Insert(index, token);
		}, null, null, autoFinalize: true);
		return true;
	}

	protected virtual void OnInsert(int index, T token)
	{
	}

	public bool Remove(T token)
	{
		token.DataModified -= OnCollectionModified;
		int itemIndex = base.Collection.IndexOf(token);
		base.Collection.Remove(token);
		OnRemove(token, itemIndex);
		UndoStack?.Commit(UndoActionTypes.RemoveToken.ToAction(), delegate
		{
			Insert(base.Collection.ClampIndexExclusive(itemIndex), token);
		}, delegate
		{
			Remove(token);
		}, null, null, autoFinalize: true);
		return true;
	}

	protected virtual void OnRemove(T token, int index)
	{
	}

	public void SortTokens(IEnumerable<T> referenceItems)
	{
		int num = 0;
		if (base.Collection.ContainsAll(referenceItems))
		{
			T[] array = referenceItems.ToArray();
			foreach (T targetItem in array)
			{
				base.Collection.MoveTo(targetItem, num++);
			}
		}
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(delegate(T t)
		{
			Remove(t);
		});
	}

	protected void OnCollectionModified()
	{
		this.CollectionModified?.Invoke();
	}
}
