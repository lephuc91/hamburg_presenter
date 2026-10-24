using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class DragDropTreeViewBase<T, I> : TreeViewBase<T, I> where T : class, ITreeNode<T>, IIdentifiable, IDragDropTreeCollection<T> where I : TreeViewItem<I>, new()
{
	private const double DropAboveThreshold = 8.0;

	private static readonly TimeSlice DragOverThreshold = TimeSlice.FromSeconds(SystemParameters.MouseHoverTime.TotalSeconds);

	private bool _canStartDrag;

	private Vector2<double> _mouseDownPos = Vector2<double>.Zero;

	private int _dropIndex = -1;

	private bool _dropInside;

	private IDragDropTreeCollection<T>? _dropCollection;

	private bool _lastDropSucceeded;

	private readonly Dictionary<I, bool> _dragOverExpandedItems = new Dictionary<I, bool>();

	private readonly Clock _dragOverClock = new Clock();

	private readonly DispatcherTimer _dragResetTimer = new DispatcherTimer
	{
		Interval = DragOverThreshold
	};

	protected abstract IDragDropTreeCollection<T>? SourceTreeCollection { get; }

	protected DragSource DragSource { get; }

	protected DropTarget DropTarget { get; }

	protected I? TargetItem { get; private set; }

	protected int DropIndex => _dropIndex;

	protected DragDropTreeViewBase()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		Pro.UI.DragDropHelper.DragSource.DragCompleted += delegate(DragResult r)
		{
			_lastDropSucceeded = r.WasDataAccepted && !r.WasDragCanceled;
			_dragOverClock.Stop();
			ResetDragOverExpansions();
			((DependencyObject)(object)this).ResetDropIndicator();
		};
		DragSource = new DragSource((DependencyObject)(object)this);
		DropTarget = new DropTarget((DependencyObject)(object)this);
		base.AllowDrop = true;
		_dragResetTimer.Tick += delegate
		{
			OnResetDragOverExpansions();
		};
	}

	private Visual CreateDragVisual(I draggedItem, IEnumerable<T> selectedItems)
	{
		return draggedItem.ToDragVisual(selectedItems.Count(), null);
	}

	protected virtual bool AllowsDropInside(T item)
	{
		return false;
	}

	protected void AddDropType<X, Y>(Func<IEnumerable<X>, IEnumerable<Y>> convert, Func<IDragDropTreeCollection<T>?, IDragDropCollection<Y>?> targetFinder, Func<IEnumerable<X>, DragEventArgs, bool>? validate = null, Func<IDragDropCollection<X>?, bool>? canDragFrom = null, Func<DraggedItems<X>, DragEventArgs, bool>? canCopy = null, Func<DraggedItems<X>, DragEventArgs, bool>? canMove = null)
	{
		DropAction<DraggedItems<X>> dropAction = DropTarget.AddDropType<DraggedItems<X>>();
		dropAction.SetIsValidDataPredicate((DraggedItems<X> source, DragEventArgs e) => SourceTreeCollection != null && (validate?.Invoke(source.Items, e) ?? true));
		dropAction.SetCanCopyPredicate((DraggedItems<X> source, DragEventArgs e) => canCopy?.Invoke(source, e) ?? false);
		dropAction.SetCanMovePredicate((DraggedItems<X> source, DragEventArgs e) => canMove?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			UpdateDropLocation(e, onlyInside: true);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropPosition();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			UpdateDropPosition(e, onlyInside: true);
			if (_dropCollection == null || targetFinder(_dropCollection) == null)
			{
				e.Effects = DragDropEffects.None;
				ResetDropPosition();
			}
			UpdateDropIndicator(showInside: false);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<X> source, DragEventArgs e)
		{
			IDragDropCollection<Y> dragDropCollection = targetFinder(_dropCollection);
			bool flag = e.Effects.HasFlag(DragDropEffects.Copy);
			Func<IDragDropCollection<X>?, bool>? func = canDragFrom;
			if ((func == null || func(source.SourceCollection)) && !flag)
			{
				source.SourceCollection?.DraggedFrom(source.Items);
			}
			dragDropCollection?.DroppedInto(convert(source.Items), -1, flag);
			ResetDragOverExpansions();
			ResetDropPosition();
			Focus();
			DeselectAll();
		});
	}

	protected void AddDropType(Func<DraggedTreeItemsCollection<T>, DragEventArgs, bool>? validate = null)
	{
		DropAction<DraggedTreeItemsCollection<T>> dropAction = DropTarget.AddDropType<DraggedTreeItemsCollection<T>>();
		dropAction.SetIsValidDataPredicate(delegate(DraggedTreeItemsCollection<T> source, DragEventArgs e)
		{
			if (SourceTreeCollection != null)
			{
				Func<DraggedTreeItemsCollection<T>, DragEventArgs, bool>? func = validate;
				if (func == null || func(source, e))
				{
					return CanDropToFolder(source, e);
				}
			}
			return false;
		});
		dropAction.SetOnDataEnteredAction(delegate(DraggedTreeItemsCollection<T> source, DragEventArgs e)
		{
			UpdateDropLocation(e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropPosition();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedTreeItemsCollection<T> source, DragEventArgs e)
		{
			UpdateDropLocation(e);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedTreeItemsCollection<T> source, DragEventArgs e)
		{
			if (_dropCollection != null)
			{
				if (_dropIndex < 0)
				{
					_dropIndex = ClampDropIndex(_dropCollection, source.DraggedTrees);
				}
				DraggedTreeItems<T>[] draggedTrees = source.DraggedTrees;
				foreach (DraggedTreeItems<T> draggedTreeItems in draggedTrees)
				{
					if (_dropCollection == draggedTreeItems.SourceTreeCollection)
					{
						_dropCollection.MoveTo(draggedTreeItems.Items, _dropIndex);
					}
					else if (!draggedTreeItems.Items.Contains(_dropCollection as T))
					{
						bool flag = e.Effects.HasFlag(DragDropEffects.Copy);
						if (!flag)
						{
							draggedTreeItems.SourceTreeCollection?.DraggedFrom(draggedTreeItems.Items);
						}
						_dropCollection.DroppedInto(draggedTreeItems.Items, _dropIndex, flag);
					}
				}
				SetSelection(source.DraggedTrees.SelectMany((DraggedTreeItems<T> t) => t.Items));
				((DependencyObject)this).SetCurrentValue(TreeViewBase<T, I>.ActiveItemProperty, (object)source.DraggedTrees.SelectMany((DraggedTreeItems<T> t) => t.Items).LastOrDefault());
			}
			ResetDragOverExpansions();
			ResetDropPosition();
			Focus();
		});
	}

	protected void AddDropType<TDragData>(Action<DraggedItems<TDragData>, DragEventArgs> drop, Action<DraggedItems<TDragData>, DragEventArgs>? onDrag = null, Func<DraggedItems<TDragData>, DragEventArgs, bool>? validate = null)
	{
		DropAction<DraggedItems<TDragData>> dropAction = DropTarget.AddDropType<DraggedItems<TDragData>>();
		dropAction.SetIsValidDataPredicate((DraggedItems<TDragData> source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<TDragData> source, DragEventArgs e)
		{
			UpdateDropLocation(e, onlyInside: true);
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<TDragData> source, DragEventArgs e)
		{
			UpdateDropLocation(e, onlyInside: true);
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<TDragData> source, DragEventArgs e)
		{
			drop?.Invoke(source, e);
			ResetDragOverExpansions();
			ResetDropPosition();
			Focus();
		});
	}

	protected void AddWebDropType(Action<FileInfo[], DragEventArgs> onDataDropped, Func<FileInfo[], DragEventArgs, bool> isValid, bool canDropInside = false)
	{
		DropAction<FileInfo[]> dropAction = DropTarget.AddWebMediaDrop();
		dropAction.SetIsValidDataPredicate(isValid);
		dropAction.SetOnDataEnteredAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropLocation(e, FileDropOnlyInside(source.Select((FileInfo f) => f.FullName)));
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropLocation(e, FileDropOnlyInside(source.Select((FileInfo f) => f.FullName)));
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			onDataDropped(source, e);
			ResetDragOverExpansions();
			ResetDropPosition();
			Focus();
		});
	}

	protected void AddFileDrop(Action<FileInfo[], DragEventArgs>? drop, Action<FileInfo[], DragEventArgs>? onDrag = null, Func<FileInfo[], DragEventArgs, bool>? validate = null)
	{
		DropAction<FileInfo[]> dropAction = DropTarget.AddFileDrop();
		dropAction.SetIsValidDataPredicate((FileInfo[] source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropLocation(e, FileDropOnlyInside(source.Select((FileInfo f) => f.FullName)));
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropLocation(e, FileDropOnlyInside(source.Select((FileInfo f) => f.FullName)));
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			drop?.Invoke(source, e);
			ResetDragOverExpansions();
			ResetDropPosition();
			Focus();
		});
	}

	protected void AddRemoteFileDrop(Action<IRemoteFile, DragEventArgs> drop, Action<IRemoteFile, DragEventArgs>? onDrag = null, Func<IRemoteFile, DragEventArgs, bool>? validate = null)
	{
		DropAction<IRemoteFile> dropAction = DropTarget.AddDropType<IRemoteFile>();
		dropAction.SetIsValidDataPredicate((IRemoteFile source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			UpdateDropLocation(e, FileDropOnlyInside(new string[1] { source.Filename }));
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			UpdateDropLocation(e, FileDropOnlyInside(new string[1] { source.Filename }));
			onDrag?.Invoke(source, e);
		});
		dropAction.SetOnDataDroppedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			drop?.Invoke(source, e);
			ResetDragOverExpansions();
			ResetDropPosition();
			Focus();
		});
	}

	private bool CanDropToFolder(DraggedTreeItemsCollection<T> source, DragEventArgs e)
	{
		I dropTarget = GetDropTarget(e);
		if (dropTarget != null)
		{
			return CanDropToFolder(source.DraggedTrees.SelectMany((DraggedTreeItems<T> d) => d.Items).ToArray(), dropTarget.DataContext as T);
		}
		return true;
	}

	private I? GetDropTarget(DragEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)e.GetPosition(this);
		DependencyObject val = VisualTreeHelper.HitTest(this, vector)?.VisualHit;
		if (val is DropIndicator)
		{
			return null;
		}
		if (val == null)
		{
			return null;
		}
		return val.FindVisualParent<I>();
	}

	protected bool CanDropToFolder(T[]? items, T? target)
	{
		if (target != null)
		{
			return items?.All((T i) => i != target && CanDropToFolder(((ITreeNode<T>)i).Children?.ToArray(), target)) ?? true;
		}
		return false;
	}

	protected virtual bool FileDropOnlyInside(IEnumerable<string> filenames)
	{
		return true;
	}

	protected void UpdateDropPosition(DragEventArgs e, bool onlyInside)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)e.GetPosition(this);
		I dropTarget = GetDropTarget(e);
		if (dropTarget == null)
		{
			return;
		}
		ResetDragOverExpansions();
		ResetDropPosition();
		I val = ((DependencyObject)(object)dropTarget).FindVisualParent<I>(includeSelf: false);
		if (dropTarget != TargetItem || !_dragOverClock.IsRunning)
		{
			_dragOverClock.Restart();
		}
		bool flag = _dragOverClock.ElapsedTime >= DragOverThreshold;
		if (flag)
		{
			if (!_dragOverExpandedItems.ContainsKey(dropTarget))
			{
				_dragOverExpandedItems.Add(dropTarget, dropTarget.IsExpanded);
			}
			dropTarget.IsExpanded = true;
			_dragOverClock.Stop();
		}
		TargetItem = ((val != null && !val.IsExpanded) ? null : dropTarget);
		if (TargetItem != null)
		{
			T val2 = (T)TargetItem.DataContext;
			if (onlyInside && CanSelectOnDragOver(val2))
			{
				SetSelection(new T[1] { val2 });
				if (flag)
				{
					((DependencyObject)this).SetCurrentValue(TreeViewBase<T, I>.ActiveItemProperty, (object)val2);
				}
			}
			else
			{
				DeselectAll();
			}
			_dropIndex = (val?.ItemContainerGenerator ?? base.ItemContainerGenerator).IndexFromContainer((DependencyObject)(object)TargetItem);
			Vector2<double> vector2 = (Vector2<double>)TargetItem.TranslatePoint(Vector2<double>.Zero, this);
			Vector2<double> vector3 = vector - vector2;
			Size desiredSize = TargetItem.DesiredSize;
			double height = ((Size)(ref desiredSize)).Height;
			if (!onlyInside && AllowsDropInside(val2))
			{
				if (vector3.Y > 8.0)
				{
					_dropIndex = -1;
					_dropInside = true;
					_dropCollection = (T)dropTarget.DataContext;
				}
			}
			else if (vector3.Y > height / 2.0)
			{
				_dropIndex++;
			}
			if (onlyInside)
			{
				_dropInside = true;
				_dropCollection = val2;
			}
			else if (_dropCollection == null)
			{
				IDragDropTreeCollection<T> dragDropTreeCollection = val?.DataContext as T;
				_dropCollection = dragDropTreeCollection ?? SourceTreeCollection;
			}
		}
		else if (!onlyInside)
		{
			_dropIndex = -1;
			_dropInside = false;
			_dropCollection = SourceTreeCollection;
		}
	}

	private void ResetDropPosition()
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		_dropIndex = -1;
		_dropInside = false;
		_dropCollection = null;
	}

	private void UpdateDropLocation(DragEventArgs e, bool onlyInside = false)
	{
		UpdateDropPosition(e, onlyInside);
		UpdateDropIndicator(!onlyInside);
	}

	private void ResetDragOverExpansions()
	{
		_dragResetTimer.Stop();
		_dragResetTimer.Start();
	}

	private void OnResetDragOverExpansions()
	{
		_dragOverClock.Stop();
		_dragResetTimer.Stop();
		_dragOverExpandedItems.ForEach(delegate(KeyValuePair<I, bool> kv)
		{
			kv.Key.IsExpanded = kv.Value;
		});
		_dragOverExpandedItems.Clear();
		if (!_lastDropSucceeded)
		{
			return;
		}
		I val = TargetItem;
		bool flag = _dropInside;
		while (val != null)
		{
			if (flag)
			{
				val.IsExpanded = true;
			}
			val = ((DependencyObject)(object)val).FindVisualParent<I>(includeSelf: false);
			flag = true;
		}
	}

	protected virtual int ClampDropIndex(IDragDropTreeCollection<T> sourceCollection, DraggedTreeItems<T>[] draggedTrees)
	{
		return sourceCollection.Children?.Count() ?? 0;
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement frameworkElement = e.OriginalSource as FrameworkElement;
		IEnumerable<DependencyObject> enumerable = ((DependencyObject)(object)frameworkElement)?.FindAllVisualParents(typeof(ScrollBar), typeof(ExpanderToggleButton), typeof(Button));
		_canStartDrag = enumerable != null && !enumerable.Any() && !((DependencyObject)(object)this).FindVisualChildren<EditableTextBlock>().Any((EditableTextBlock b) => b.IsInEditMode) && IsDraggableItem(frameworkElement.DataContext as T);
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPos))
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
				obj = ((visualHit != null) ? visualHit.FindVisualParent<I>() : null);
			}
			I val = (I)obj;
			if (!(val?.DataContext is T val2))
			{
				return;
			}
			T[] array = base.SelectedTreeItems?.ToArray() ?? new T[1] { base.SelectedTreeItem };
			T[] draggedItems = ((array.Any() && array.Contains(val2)) ? array : new T[1] { val2 });
			IEnumerable<DraggedTreeItems<T>> source = (from i in draggedItems
				where !draggedItems.Contains<T>(i.Parent)
				group i by i.Parent).Collect(delegate(IGrouping<T, T> g)
			{
				IDragDropTreeCollection<T> key = g.Key;
				return new DraggedTreeItems<T>(key ?? SourceTreeCollection, g.ToArray());
			});
			DragSource.StartDrag(new DraggedTreeItemsCollection<T>(source.ToArray()), CreateDragVisual(val, draggedItems), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)TranslatePoint(_mouseDownPos, val));
			_canStartDrag = false;
			e.Handled = true;
		}
		base.OnPreviewMouseMove(e);
	}

	private void UpdateDropIndicator(bool showInside)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (_dropCollection == null)
		{
			_dropCollection = SourceTreeCollection;
		}
		IDragDropTreeCollection<T> dropCollection = _dropCollection;
		AdornerPosition? adornerPosition = null;
		if (!_dropInside)
		{
			IEnumerable<T> source = dropCollection?.Children ?? Enumerable.Empty<T>();
			int num = ((_dropIndex < 0 || _dropIndex > source.Count()) ? source.Count() : _dropIndex);
			if (num == source.Count())
			{
				IDragDropTreeCollection<T> dragDropTreeCollection = source.ElementAtOrDefault(num - 1);
				dropCollection = dragDropTreeCollection ?? _dropCollection;
				adornerPosition = AdornerPosition.Bottom;
			}
			else
			{
				dropCollection = source.ElementAt(num);
				adornerPosition = AdornerPosition.Top;
			}
		}
		else if (showInside)
		{
			adornerPosition = AdornerPosition.Inside;
		}
		if (adornerPosition.HasValue)
		{
			((DependencyObject)(object)this).FindVisualChild((I t) => t.DataContext == dropCollection)?.ShowDropIndicator(adornerPosition.Value);
		}
	}

	protected virtual bool IsDraggableItem(T? item)
	{
		return true;
	}

	protected virtual bool CanSelectOnDragOver(T targetItemData)
	{
		return true;
	}
}
