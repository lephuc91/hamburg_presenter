using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class DragDropListBox<T> : ListBoxBase<T, ListBoxItem> where T : class
{
	private bool _canStartDrag;

	private Vector2<double> _mouseDownPos = Vector2<double>.Zero;

	private T? _dropTargetItem;

	private ListBoxItem? _dropTargetVisual;

	private bool _foundDropTarget;

	private int _dropIndex = -1;

	private bool _dropInside;

	public static readonly DependencyProperty SelectItemsOnDropProperty = DependencyProperty.Register("SelectItemsOnDrop", typeof(bool), typeof(DragDropListBox<T>), new PropertyMetadata((object)false));

	public static readonly DependencyProperty SelectItemsOnSelfDropProperty = DependencyProperty.Register("SelectItemsOnSelfDrop", typeof(bool), typeof(DragDropListBox<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CollectionDirectionProperty = DependencyProperty.Register("CollectionDirection", typeof(ListSortDirection), typeof(DragDropListBox<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ListSortDirection.Ascending));

	public static readonly DependencyProperty DragAutoScrollProperty = DependencyProperty.Register("DragAutoScroll", typeof(bool), typeof(DragDropListBox<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public bool IsDragging => DragSource.IsDragging;

	public bool SelectItemsOnDrop
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectItemsOnDropProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectItemsOnDropProperty, (object)value);
		}
	}

	public bool SelectItemsOnSelfDrop
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectItemsOnSelfDropProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectItemsOnSelfDropProperty, (object)value);
		}
	}

	public bool DragAutoScroll
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DragAutoScrollProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragAutoScrollProperty, (object)value);
		}
	}

	public ListSortDirection CollectionDirection
	{
		get
		{
			return (ListSortDirection)((DependencyObject)this).GetValue(CollectionDirectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollectionDirectionProperty, (object)value);
		}
	}

	protected abstract IDragDropCollection<T>? SourceCollection { get; }

	protected DragSource DragSource { get; }

	protected DropTarget DropTarget { get; }

	protected DragDropListBox()
	{
		DragSource = new DragSource((DependencyObject)(object)this);
		DropTarget = new DropTarget((DependencyObject)(object)this);
		base.AllowDrop = true;
	}

	protected Visual CreateDragVisual(T draggedItem, IEnumerable<T> selectedItems)
	{
		return ((Control)(object)base.ItemContainerGenerator.ContainerFromItem(draggedItem)).ToDragVisual(selectedItems.Count(), null);
	}

	protected virtual bool CanDrag()
	{
		return true;
	}

	protected int FindDropIndex(DragEventArgs e, bool insideOnly = false, bool canDropInside = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)e.GetPosition(this);
		DependencyObject val = VisualTreeHelper.HitTest(this, vector)?.VisualHit;
		if (val is DropIndicator)
		{
			return _dropIndex;
		}
		_dropTargetVisual = val?.FindVisualParent<ListBoxItem>();
		_foundDropTarget = _dropTargetVisual != null;
		if (!_foundDropTarget)
		{
			_dropTargetVisual = ((DependencyObject)(object)this).FindVisualChildren<ListBoxItem>().LastOrDefault();
		}
		int num = -1;
		if (_dropTargetVisual != null)
		{
			_dropTargetItem = (T)_dropTargetVisual.DataContext;
			num = SourceCollection?.IndexOf(_dropTargetItem) ?? (-1);
			Vector2<double> vector2 = (Vector2<double>)_dropTargetVisual.TranslatePoint(Vector2<double>.Zero, this);
			if (!insideOnly && ((_foundDropTarget && AdjustTargetIndex(canDropInside, (vector - vector2).Y, _dropTargetVisual.ActualHeight)) || (!_foundDropTarget && CollectionDirection == ListSortDirection.Ascending)))
			{
				num++;
			}
		}
		return num;
	}

	private bool AdjustTargetIndex(bool canDropInside, double yPosition, double targetHeight)
	{
		_dropInside = false;
		bool flag = (canDropInside ? (yPosition >= targetHeight * 0.75) : (yPosition > targetHeight / 2.0));
		bool flag2 = (canDropInside ? (yPosition <= targetHeight * 0.25) : (yPosition < targetHeight / 2.0));
		if (canDropInside && !flag && !flag2)
		{
			_dropInside = true;
		}
		else
		{
			switch (CollectionDirection)
			{
			case ListSortDirection.Ascending:
				return flag;
			case ListSortDirection.Descending:
				return flag2;
			}
		}
		return false;
	}

	protected void AddDropType<I>(Func<IEnumerable<I>, IEnumerable<T>>? convert = null, Func<IEnumerable<I>, DragEventArgs, bool>? validate = null, Func<IDragDropCollection<I>?, bool>? canDragFrom = null, Func<DraggedItems<I>, DragEventArgs, bool>? canCopy = null, Action<DraggedItems<I>, int, bool, DragEventArgs>? dropInside = null)
	{
		DropAction<DraggedItems<I>> dropAction = DropTarget.AddDropType<DraggedItems<I>>();
		bool canDropInside = dropInside != null;
		dropAction.SetIsValidDataPredicate((DraggedItems<I> source, DragEventArgs e) => SourceCollection != null && (validate?.Invoke(source.Items, e) ?? true));
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly: false, canDropInside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropIndex(insideOnly: false, canDropInside);
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly: false, canDropInside);
		});
		dropAction.SetCanCopyPredicate((DraggedItems<I> source, DragEventArgs e) => canCopy?.Invoke(source, e) ?? false);
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			if (canDropInside && _dropInside)
			{
				dropInside?.Invoke(source, _dropIndex, _dropInside, e);
			}
			else
			{
				DropHelper.DoDropData(source, SourceCollection, convert, _dropIndex, e, out IEnumerable<T> items, canDragFrom);
				if (SelectItemsOnSelfDrop)
				{
					UpdateSelection(items);
				}
			}
			Focus();
			ResetDropIndex(insideOnly: false, canDropInside);
		});
	}

	protected void AddDropType<X, Y>(Func<IEnumerable<X>, DragEventArgs, IEnumerable<Y>> convert, Func<IDragDropCollection<T>?, IDragDropCollection<Y>?> targetFinder, Func<DraggedItems<X>, DragEventArgs, bool>? validate = null, Func<DraggedItems<X>, DragEventArgs, bool>? canCopy = null, Action<DraggedItems<X>, int, bool, DragEventArgs>? dropOverride = null, bool insideOnly = false, bool canDropInside = false)
	{
		DropAction<DraggedItems<X>> dropAction = DropTarget.AddDropType<DraggedItems<X>>();
		dropAction.SetIsValidDataPredicate((DraggedItems<X> source, DragEventArgs e) => SourceCollection != null && (validate?.Invoke(source, e) ?? true));
		dropAction.SetCanCopyPredicate((DraggedItems<X> source, DragEventArgs e) => canCopy?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly, canDropInside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropIndex(insideOnly, canDropInside);
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly, canDropInside);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			if (dropOverride != null)
			{
				dropOverride(source, _dropIndex, _dropInside, e);
			}
			else
			{
				bool flag = e.Effects.HasFlag(DragDropEffects.Copy);
				if (!flag)
				{
					source.SourceCollection?.DraggedFrom(source.Items);
				}
				targetFinder(SourceCollection)?.DroppedInto(convert(source.Items, e), _dropIndex, flag);
			}
			ResetDropIndex(insideOnly, canDropInside);
		});
	}

	protected void AddDropType<X>(Action<DraggedTreeItemsCollection<X>, int, bool, DragEventArgs> drop, Func<DraggedTreeItemsCollection<X>, DragEventArgs, bool> validate, bool insideOnly = false, bool canDropInside = false) where X : IDragDropTreeCollection<X>, IIdentifiable
	{
		DropAction<DraggedTreeItemsCollection<X>> dropAction = DropTarget.AddDropType<DraggedTreeItemsCollection<X>>();
		dropAction.SetIsValidDataPredicate((DraggedTreeItemsCollection<X> source, DragEventArgs e) => SourceCollection != null && (validate?.Invoke(source, e) ?? true));
		dropAction.SetOnDataEnteredAction(delegate(DraggedTreeItemsCollection<X> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly, canDropInside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropIndex(insideOnly, canDropInside);
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedTreeItemsCollection<X> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly, canDropInside);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedTreeItemsCollection<X> source, DragEventArgs e)
		{
			drop(source, _dropIndex, _dropInside, e);
			ResetDropIndex(insideOnly, canDropInside);
		});
	}

	private void UpdateSelection(IEnumerable<T> items)
	{
		if (base.SelectionMode != 0)
		{
			base.SelectedListItems?.Clear();
			base.SelectedListItems?.AddRange(items);
		}
		((DependencyObject)this).SetCurrentValue(ListBoxBase<T, ListBoxItem>.SelectedListItemProperty, (object)items.FirstOrDefault());
	}

	protected void AddWebDropType(Action<FileInfo[], int, bool> onDataDropped, Func<FileInfo[], DragEventArgs, bool> isValid, bool canDropInside = false)
	{
		DropAction<FileInfo[]> dropAction = DropTarget.AddWebMediaDrop();
		dropAction.SetIsValidDataPredicate(isValid);
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly: false, canDropInside);
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			onDataDropped(source, _dropIndex, _dropInside);
		});
	}

	protected void AddFileDrop(Action<FileInfo[], int, bool> drop, Action<FileInfo[], DragEventArgs>? onDrag = null, Func<FileInfo[], DragEventArgs, bool>? validate = null, bool canDropInside = false)
	{
		DropAction<FileInfo[]> dropAction = DropTarget.AddFileDrop();
		dropAction.SetIsValidDataPredicate((FileInfo[] source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			if (onDrag != null)
			{
				onDrag(source, e);
			}
			else
			{
				UpdateDropIndex(e, insideOnly: false, canDropInside);
			}
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source, _dropIndex, _dropInside);
		});
	}

	protected void AddRemoteFileDrop(Action<IRemoteFile, int, bool> drop, Action<IRemoteFile, DragEventArgs>? onDrag = null, Func<IRemoteFile, DragEventArgs, bool>? validate = null, bool canDropInside = false)
	{
		DropAction<IRemoteFile> dropAction = DropTarget.AddDropType<IRemoteFile>();
		dropAction.SetIsValidDataPredicate((IRemoteFile source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			if (onDrag != null)
			{
				onDrag(source, e);
			}
			else
			{
				UpdateDropIndex(e, insideOnly: false, canDropInside);
			}
		});
		dropAction.SetOnDataDroppedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source, _dropIndex, _dropInside);
		});
	}

	protected void AddCustomDrop<C>(Action<DraggedItems<C>> drop, Action<DraggedItems<C>, DragEventArgs>? onDrag = null, Func<DraggedItems<C>, DragEventArgs, bool>? validate = null)
	{
		DropAction<DraggedItems<C>> dropAction = DropTarget.AddDropType<DraggedItems<C>>();
		dropAction.SetIsValidDataPredicate((DraggedItems<C> source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<C> source, DragEventArgs e)
		{
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<C> source, DragEventArgs e)
		{
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<C> source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source);
		});
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		object originalSource = e.OriginalSource;
		IEnumerable<DependencyObject> enumerable = ((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindAllVisualParents(typeof(CheckBox), typeof(Button), typeof(Slider), typeof(IntegerUpDown), typeof(FloatUpDown), typeof(DoubleUpDown), typeof(ColorPicker), typeof(ScrollBar), typeof(CloseButton), typeof(ToggleButton), typeof(RepeatButton), typeof(TimeSliceTextBox), typeof(PlaceholderTextBox));
		_mouseDownPos = (Vector2<double>)e.GetPosition(this);
		_canStartDrag = (enumerable == null || !enumerable.Any()) && !((DependencyObject)(object)this).FindVisualChildren<EditableTextBlock>().Any((EditableTextBlock b) => b.IsInEditMode) && !((DependencyObject)(object)this).FindVisualChildren<ColorPicker>().Any((ColorPicker b) => b.IsOpen) && VisualTreeHelper.HitTest(this, e.GetPosition(this))?.VisualHit.FindVisualParent<ListBoxItem>() != null;
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_canStartDrag = false;
		base.OnPreviewMouseLeftButtonUp(e);
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPos) && CanDrag())
		{
			ListBoxItem listBoxItem = VisualTreeHelper.HitTest(this, _mouseDownPos)?.VisualHit?.FindVisualParent<ListBoxItem>();
			if (!(listBoxItem?.DataContext is T val))
			{
				return;
			}
			IEnumerable<T> enumerable;
			if (base.SelectedListItems == null || !base.SelectedListItems.Any() || !base.SelectedListItems.Contains(val))
			{
				enumerable = val.ToEnumerable();
			}
			else
			{
				IEnumerable<T> selectedListItems = base.SelectedListItems;
				enumerable = selectedListItems;
			}
			IEnumerable<T> enumerable2 = enumerable;
			StartDrag(enumerable2.OrderBy((T i) => base.Items.IndexOf(i)).ToArray(), CreateDragVisual(val, enumerable2), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)TranslatePoint(_mouseDownPos, listBoxItem));
			_canStartDrag = false;
			e.Handled = true;
		}
		base.OnPreviewMouseMove(e);
	}

	protected override void OnPreviewDragOver(DragEventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (DragAutoScroll)
		{
			ScrollViewer scrollViewer = ((DependencyObject)(object)this).FindVisualChildren<ScrollViewer>().FirstOrDefault();
			if (scrollViewer == null)
			{
				return;
			}
			double num = 60.0;
			Point position = e.GetPosition(this);
			double y = ((Point)(ref position)).Y;
			double num2 = 20.0;
			if (y < num)
			{
				scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - num2);
			}
			else if (y > base.ActualHeight - num)
			{
				scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + num2);
			}
		}
		base.OnPreviewDragOver(e);
	}

	protected virtual void StartDrag(IEnumerable<T> items, Visual dragVisual, DragDropEffects effects, Vector2<double> offset)
	{
		DragSource.StartDrag(new DraggedItems<T>(SourceCollection, items.ToArray()), dragVisual, effects, offset);
	}

	protected void UpdateDropIndex(DragEventArgs e, bool insideOnly = false, bool canDropInside = false)
	{
		_dropIndex = FindDropIndex(e, insideOnly, canDropInside);
		UpdateDropIndicator(insideOnly, canDropInside);
	}

	protected void ResetDropIndex(bool insideOnly = false, bool canDropInside = false)
	{
		_dropIndex = -1;
		_dropInside = false;
		_dropTargetItem = null;
		_dropTargetVisual = null;
		_foundDropTarget = false;
		ClearDropIndicator(insideOnly, canDropInside);
	}

	private void ClearDropIndicator(bool insideOnly, bool canDropInside)
	{
		OnClearDropIndicator(insideOnly, canDropInside);
	}

	protected virtual void OnClearDropIndicator(bool insideOnly, bool canDropInside)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void UpdateDropIndicator(bool insideOnly, bool canDropInside)
	{
		ClearDropIndicator(insideOnly, canDropInside);
		OnUpdateDropIndicator(insideOnly, canDropInside, _dropIndex, _dropTargetItem, _dropInside);
	}

	protected virtual void OnUpdateDropIndicator(bool insideOnly, bool canDropInside, int dropIndex, T? dropTargetItem, bool dropInside)
	{
		OnUpdateDropIndicator(insideOnly, canDropInside, dropIndex, dropTargetItem, dropInside, _dropTargetVisual);
	}

	protected virtual void OnUpdateDropIndicator(bool insideOnly, bool canDropInside, int dropIndex, T? dropTargetItem, bool dropInside, ListBoxItem? _dropTargetVisual)
	{
		int targetItemIndex = ((dropTargetItem != null && SourceCollection != null) ? SourceCollection.IndexOf(dropTargetItem) : (-1));
		_dropTargetVisual?.ShowDropIndicator(GetAdornerPosition(dropIndex, targetItemIndex, insideOnly || (canDropInside && dropInside)));
	}

	private AdornerPosition GetAdornerPosition(int dropIndex, int targetItemIndex, bool insideOnly)
	{
		if (insideOnly)
		{
			return AdornerPosition.Inside;
		}
		if (!_foundDropTarget)
		{
			return AdornerPosition.Bottom;
		}
		bool flag = dropIndex < 0 || dropIndex > targetItemIndex;
		ListSortDirection collectionDirection = CollectionDirection;
		if (collectionDirection == ListSortDirection.Ascending || collectionDirection != ListSortDirection.Descending)
		{
			if (!flag)
			{
				return AdornerPosition.Top;
			}
			return AdornerPosition.Bottom;
		}
		if (!flag)
		{
			return AdornerPosition.Bottom;
		}
		return AdornerPosition.Top;
	}
}
