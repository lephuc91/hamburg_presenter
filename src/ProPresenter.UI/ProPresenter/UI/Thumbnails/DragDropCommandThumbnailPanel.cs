using System.Collections.Generic;
using System.Windows;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

public abstract class DragDropCommandThumbnailPanel<T, I> : DragDropThumbnailPanel<T>, IDragDropCollection<T> where T : class, IThumbnailSource
{
	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(I), typeof(DragDropCommandThumbnailPanel<T, I>));

	public static readonly DependencyProperty DraggedFromCommandProperty = DependencyProperty.Register("DraggedFromCommand", typeof(ICommand<DragDropCommandParameters<T, I>>), typeof(DragDropCommandThumbnailPanel<T, I>));

	public static readonly DependencyProperty DroppedIntoCommandProperty = DependencyProperty.Register("DroppedIntoCommand", typeof(ICommand<DragDropCommandParameters<T, I>>), typeof(DragDropCommandThumbnailPanel<T, I>));

	public static readonly DependencyProperty MoveToCommandProperty = DependencyProperty.Register("MoveToCommand", typeof(ICommand<DragDropCommandParameters<T, I>>), typeof(DragDropCommandThumbnailPanel<T, I>));

	protected override IDragDropCollection<T> SourceCollection => this;

	public I? Source
	{
		get
		{
			return (I)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public ICommand<DragDropCommandParameters<T, I>?>? DraggedFromCommand
	{
		get
		{
			return (ICommand<DragDropCommandParameters<T, I>>)((DependencyObject)this).GetValue(DraggedFromCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DraggedFromCommandProperty, (object)value);
		}
	}

	public ICommand<DragDropCommandParameters<T, I>?> DroppedIntoCommand
	{
		get
		{
			return (ICommand<DragDropCommandParameters<T, I>>)((DependencyObject)this).GetValue(DroppedIntoCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DroppedIntoCommandProperty, (object)value);
		}
	}

	public ICommand<DragDropCommandParameters<T, I>?>? MoveToCommand
	{
		get
		{
			return (ICommand<DragDropCommandParameters<T, I>>)((DependencyObject)this).GetValue(MoveToCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MoveToCommandProperty, (object)value);
		}
	}

	protected virtual void OnMoveTo(IEnumerable<T> items, int index)
	{
	}

	public int IndexOf(T item)
	{
		return base.Items?.IndexOf(item) ?? (-1);
	}

	public void DraggedFrom(IEnumerable<T> items)
	{
		DraggedFromCommand?.Invoke<DragDropCommandParameters<T, I>>(new DragDropCommandParameters<T, I>(Source, items, null, -1, droppedBefore: false, droppedOutside: false, base.IsCopying));
	}

	public void DroppedInto(IEnumerable<T> items, int index, bool isCopy)
	{
		DroppedIntoCommand?.Invoke<DragDropCommandParameters<T, I>>(new DragDropCommandParameters<T, I>(Source, items, base.TargetItem, base.DropIndex, base.DroppedBefore, base.DroppedOutside, base.IsCopying));
	}

	public void MoveTo(IEnumerable<T> items, int index)
	{
		MoveToCommand?.Invoke<DragDropCommandParameters<T, I>>(new DragDropCommandParameters<T, I>(Source, items, base.TargetItem, base.DropIndex, base.DroppedBefore, base.DroppedOutside || base.InDeadSpace, base.IsCopying));
		OnMoveTo(items, index);
	}
}
