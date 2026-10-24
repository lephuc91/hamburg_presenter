using System;
using System.Windows;

namespace Pro.UI.DragDropHelper;

public class DropAction<T>
{
	private readonly BoxedDropAction _boxedAction;

	internal DropAction(BoxedDropAction boxedAction)
	{
		_boxedAction = boxedAction;
	}

	public void SetIsValidDataPredicate(Func<T, DragEventArgs, bool> callback)
	{
		_boxedAction.IsValidDataPredicate = (object data, DragEventArgs e) => callback?.Invoke((T)data, e) ?? true;
	}

	public void SetCanCopyPredicate(Func<T, DragEventArgs, bool> callback)
	{
		_boxedAction.CanCopyPredicate = (object data, DragEventArgs e) => callback?.Invoke((T)data, e) ?? false;
	}

	public void SetCanMovePredicate(Func<T, DragEventArgs, bool> callback)
	{
		_boxedAction.CanMovePredicate = (object data, DragEventArgs e) => callback?.Invoke((T)data, e) ?? true;
	}

	public void SetOnDataEnteredAction(Action<T, DragEventArgs> callback)
	{
		_boxedAction.OnDataEnteredAction = delegate(object data, DragEventArgs e)
		{
			callback?.Invoke((T)data, e);
		};
	}

	public void SetOnDataDraggedAction(Action<T, DragEventArgs> callback)
	{
		_boxedAction.OnDataDraggedAction = delegate(object data, DragEventArgs e)
		{
			callback?.Invoke((T)data, e);
		};
	}

	public void SetOnDataLeftAction(Action<T, DragEventArgs> callback)
	{
		_boxedAction.OnDataLeftAction = delegate(object data, DragEventArgs e)
		{
			callback?.Invoke((T)data, e);
		};
	}

	public void SetOnDataDroppedAction(Action<T, DragEventArgs> callback)
	{
		_boxedAction.OnDataDroppedAction = delegate(object data, DragEventArgs e)
		{
			callback?.Invoke((T)data, e);
		};
	}
}
