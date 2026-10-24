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

public abstract class DragDropItemsControl<T, C> : ItemsControlBase where T : class where C : FrameworkElement, new()
{
	private bool _canStartDrag;

	private Vector2<double> _mouseDownPos = Vector2<double>.Zero;

	private int _dropIndex = -1;

	private T? _dropTargetItem;

	private C? _dropTargetVisual;

	private bool _foundDropTarget;

	public static readonly DependencyProperty CollectionDirectionProperty = DependencyProperty.Register("CollectionDirection", typeof(ListSortDirection), typeof(DragDropItemsControl<T, C>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ListSortDirection.Ascending));

	public bool IsDragging => DragSource.IsDragging;

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

	protected DragDropItemsControl()
	{
		DragSource = new DragSource((DependencyObject)(object)this);
		DropTarget = new DropTarget((DependencyObject)(object)this);
		base.AllowDrop = true;
	}

	protected Visual CreateDragVisual(T draggedItem, IEnumerable<T> selectedItems)
	{
		return ((ContentPresenter)(object)base.ItemContainerGenerator.ContainerFromItem(draggedItem)).ToDragVisual(selectedItems.Count(), null);
	}

	protected virtual bool CanDrag()
	{
		return true;
	}

	protected int FindDropIndex(DragEventArgs e, bool insideOnly = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)e.GetPosition(this);
		DependencyObject val = VisualTreeHelper.HitTest(this, vector)?.VisualHit;
		if (val is DropIndicator)
		{
			return _dropIndex;
		}
		_dropTargetVisual = ((val != null) ? val.FindVisualParent<C>() : null);
		_foundDropTarget = _dropTargetVisual != null;
		if (!_foundDropTarget)
		{
			_dropTargetVisual = ((DependencyObject)(object)this).FindVisualChildren<C>().LastOrDefault();
		}
		int num = -1;
		if (_dropTargetVisual != null)
		{
			_dropTargetItem = (T)_dropTargetVisual.DataContext;
			num = SourceCollection?.IndexOf(_dropTargetItem) ?? (-1);
			Vector2<double> vector2 = (Vector2<double>)_dropTargetVisual.TranslatePoint(Vector2<double>.Zero, this);
			if (!insideOnly && ((_foundDropTarget && AdjustTargetIndex((vector - vector2).Y, _dropTargetVisual.ActualHeight)) || (!_foundDropTarget && CollectionDirection == ListSortDirection.Ascending)))
			{
				num++;
			}
		}
		return num;
	}

	private bool AdjustTargetIndex(double yPosition, double targetHeight)
	{
		return CollectionDirection switch
		{
			ListSortDirection.Ascending => yPosition > targetHeight / 2.0, 
			ListSortDirection.Descending => yPosition < targetHeight / 2.0, 
			_ => false, 
		};
	}

	protected void AddDropType<I>(Func<IEnumerable<I>, IEnumerable<T>>? convert = null, Func<IEnumerable<I>, DragEventArgs, bool>? validate = null, Func<IDragDropCollection<I>?, bool>? canDragFrom = null, Func<DraggedItems<I>, DragEventArgs, bool>? canCopy = null)
	{
		DropAction<DraggedItems<I>> dropAction = DropTarget.AddDropType<DraggedItems<I>>();
		dropAction.SetIsValidDataPredicate((DraggedItems<I> source, DragEventArgs e) => SourceCollection != null && (validate?.Invoke(source.Items, e) ?? true));
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			UpdateDropIndex(e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropIndex();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			UpdateDropIndex(e);
		});
		dropAction.SetCanCopyPredicate((DraggedItems<I> source, DragEventArgs e) => canCopy?.Invoke(source, e) ?? false);
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			DropHelper.DoDropData(source, SourceCollection, convert, _dropIndex, e, out IEnumerable<T> _, canDragFrom);
			Focus();
			ResetDropIndex();
		});
	}

	protected void AddDropType<X, Y>(Func<IEnumerable<X>, DragEventArgs, IEnumerable<Y>> convert, Func<IDragDropCollection<T>?, IDragDropCollection<Y>?> targetFinder, Func<DraggedItems<X>, DragEventArgs, bool>? validate = null, Func<DraggedItems<X>, DragEventArgs, bool>? canCopy = null, Action<DraggedItems<X>, int, DragEventArgs>? dropOverride = null, bool insideOnly = false)
	{
		DropAction<DraggedItems<X>> dropAction = DropTarget.AddDropType<DraggedItems<X>>();
		dropAction.SetIsValidDataPredicate((DraggedItems<X> source, DragEventArgs e) => SourceCollection != null && (validate?.Invoke(source, e) ?? true));
		dropAction.SetCanCopyPredicate((DraggedItems<X> source, DragEventArgs e) => canCopy?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropIndex(insideOnly);
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			UpdateDropIndex(e, insideOnly);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			if (dropOverride != null)
			{
				dropOverride(source, _dropIndex, e);
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
			ResetDropIndex(insideOnly);
		});
	}

	protected void AddFileDrop(Action<FileInfo[]> drop, Action<FileInfo[], DragEventArgs>? onDrag = null, Func<FileInfo[], DragEventArgs, bool>? validate = null)
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
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source);
		});
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		object originalSource = e.OriginalSource;
		IEnumerable<DependencyObject> enumerable = ((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindAllVisualParents(typeof(CheckBox), typeof(Button), typeof(Slider), typeof(IntegerUpDown), typeof(DoubleUpDown), typeof(ColorPicker), typeof(ScrollBar), typeof(CloseButton), typeof(ToggleButton), typeof(RepeatButton), typeof(TimeSliceTextBox), typeof(PlaceholderTextBox), typeof(TextBox));
		_canStartDrag = (enumerable == null || !enumerable.Any()) && !((DependencyObject)(object)this).FindVisualChildren<EditableTextBlock>().Any((EditableTextBlock b) => b.IsInEditMode);
		_mouseDownPos = (Vector2<double>)e.GetPosition(this);
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
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPos) && CanDrag())
		{
			HitTestResult hitTestResult = VisualTreeHelper.HitTest(this, _mouseDownPos);
			object obj;
			if (hitTestResult == null)
			{
				obj = null;
			}
			else
			{
				DependencyObject visualHit = hitTestResult.VisualHit;
				obj = ((visualHit != null) ? visualHit.FindVisualParent<C>() : null);
			}
			C val = (C)obj;
			if (!(val?.DataContext is T val2))
			{
				return;
			}
			IEnumerable<T> enumerable = val2.ToEnumerable();
			DragSource.StartDrag(new DraggedItems<T>(SourceCollection, enumerable.OrderBy((T i) => base.Items.IndexOf(i)).ToArray()), CreateDragVisual(val2, enumerable), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)TranslatePoint(_mouseDownPos, val));
			_canStartDrag = false;
			e.Handled = true;
		}
		base.OnPreviewMouseMove(e);
	}

	private void UpdateDropIndex(DragEventArgs e, bool insideOnly = false)
	{
		_dropIndex = FindDropIndex(e, insideOnly);
		UpdateDropIndicator(insideOnly);
	}

	private void ResetDropIndex(bool insideOnly = false)
	{
		_dropIndex = -1;
		_dropTargetItem = null;
		_dropTargetVisual = null;
		_foundDropTarget = false;
		UpdateDropIndicator(insideOnly);
	}

	private void UpdateDropIndicator(bool insideOnly)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		int targetItemIndex = ((_dropTargetItem != null && SourceCollection != null) ? SourceCollection.IndexOf(_dropTargetItem) : (-1));
		_dropTargetVisual?.ShowDropIndicator(GetAdornerPosition(_dropIndex, targetItemIndex, insideOnly));
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
