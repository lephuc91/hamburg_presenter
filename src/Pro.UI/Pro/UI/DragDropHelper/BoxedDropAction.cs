using System;
using System.Windows;

namespace Pro.UI.DragDropHelper;

internal class BoxedDropAction
{
	public Func<object, DragEventArgs, bool> IsValidDataPredicate { get; set; } = (object data, DragEventArgs e) => true;

	public Func<object, DragEventArgs, bool> CanCopyPredicate { get; set; } = (object data, DragEventArgs e) => false;

	public Func<object, DragEventArgs, bool> CanMovePredicate { get; set; } = (object data, DragEventArgs e) => true;

	public Action<object, DragEventArgs>? OnDataEnteredAction { get; set; }

	public Action<object, DragEventArgs>? OnDataDraggedAction { get; set; }

	public Action<object, DragEventArgs>? OnDataLeftAction { get; set; }

	public Action<object, DragEventArgs>? OnDataDroppedAction { get; set; }
}
