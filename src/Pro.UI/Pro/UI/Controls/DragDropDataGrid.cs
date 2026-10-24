using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class DragDropDataGrid<T> : DataGridBase<T, DataGridRow> where T : class
{
	private readonly DragSource _dragSource;

	private readonly DropTarget _dropTarget;

	private bool _canStartDrag;

	private Vector2<double> _mouseDownPos = Vector2<double>.Zero;

	private DataGridRow? _selectedRow;

	protected abstract IDragDropCollection<T>? SourceCollection { get; }

	protected DragSource DragSource => _dragSource;

	protected DropTarget DropTarget => _dropTarget;

	protected DataGridRow? SelectedRow => _selectedRow;

	protected int DropIndex { get; private set; }

	protected T? TargetItem => TargetRow?.DataContext as T;

	protected bool DroppedBefore { get; private set; }

	protected DataGridRow? TargetRow { get; private set; }

	protected DragDropDataGrid()
	{
		_dragSource = new DragSource((DependencyObject)(object)this);
		_dropTarget = new DropTarget((DependencyObject)(object)this);
		base.AllowDrop = true;
	}

	static DragDropDataGrid()
	{
		DataGrid.IsReadOnlyProperty.OverrideMetadata(typeof(DragDropDataGrid<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	protected void AddDropType<I>(Func<IEnumerable<I>, IEnumerable<T>> convert, Func<IEnumerable<I>, DragEventArgs, bool>? validate = null, Func<DraggedItems<I>, DragEventArgs, bool>? canCopy = null)
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
			DropHelper.DoDropData(source, SourceCollection, convert, DropIndex, e, out IEnumerable<T> items);
			ResetDropIndex();
			SetSelection(items);
			Focus();
		});
	}

	protected void AddFileDrop(Action<FileInfo[]> drop, Func<FileInfo[], DragEventArgs, bool>? validate = null)
	{
		DropAction<FileInfo[]> dropAction = DropTarget.AddFileDrop();
		dropAction.SetIsValidDataPredicate((FileInfo[] source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropIndex(e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropIndex(e);
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source);
		});
	}

	protected void AddRemoteFileDrop(Action<IRemoteFile> drop, Func<IRemoteFile, DragEventArgs, bool>? validate = null)
	{
		DropAction<IRemoteFile> dropAction = DropTarget.AddDropType<IRemoteFile>();
		dropAction.SetIsValidDataPredicate((IRemoteFile source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			UpdateDropIndex(e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			UpdateDropIndex(e);
		});
		dropAction.SetOnDataDroppedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source);
		});
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		_selectedRow = e.FindHitElement<DataGridRow>(this);
		object originalSource = e.OriginalSource;
		DependencyObject val = (DependencyObject)((originalSource is DependencyObject) ? originalSource : null);
		IEnumerable<DependencyObject> enumerable = val?.FindAllVisualParents(typeof(CheckBox), typeof(Button), typeof(Slider), typeof(IntegerUpDown), typeof(DoubleUpDown), typeof(ColorPicker), typeof(TextBox));
		_canStartDrag = val != null && _selectedRow != null && val.FindVisualParent<DataGrid>() != null && (enumerable == null || !enumerable.Any());
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
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPos))
		{
			DataGridRow dataGridRow = VisualTreeHelper.HitTest(this, _mouseDownPos)?.VisualHit?.FindVisualParent<DataGridRow>();
			if (!(dataGridRow?.DataContext is T val) || _selectedRow != dataGridRow)
			{
				return;
			}
			IEnumerable<T> enumerable;
			if (base.SelectedDataGridItems == null || !base.SelectedDataGridItems.Any() || !base.SelectedDataGridItems.Contains(val))
			{
				enumerable = val.ToEnumerable();
			}
			else
			{
				IEnumerable<T> selectedDataGridItems = base.SelectedDataGridItems;
				enumerable = selectedDataGridItems;
			}
			IEnumerable<T> source = enumerable;
			DragSource.StartDrag(new DraggedItems<T>(SourceCollection, source.ToArray()), CreateDragVisual(val, source.Count()), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)TranslatePoint(_mouseDownPos, dataGridRow));
			_canStartDrag = false;
			e.Handled = true;
		}
		base.OnPreviewMouseMove(e);
	}

	private Visual CreateDragVisual(T draggedItem, int count)
	{
		return ((Control)(object)base.ItemContainerGenerator.ContainerFromItem(draggedItem)).ToDragVisual(count, null);
	}

	protected int FindDropIndex(Vector2<double> dropPos)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		DroppedBefore = false;
		DependencyObject val = VisualTreeHelper.HitTest(this, dropPos)?.VisualHit;
		int num = base.Items.Count;
		if (val is DropIndicator)
		{
			return DropIndex;
		}
		TargetRow = val?.FindVisualParent<DataGridRow>() ?? ((DependencyObject)(object)this).FindVisualChildren<DataGridRow>().LastOrDefault();
		if (TargetRow != null)
		{
			num = GetTargetItemIndex();
			Vector2<double> vector = (Vector2<double>)TargetRow.TranslatePoint(Vector2<double>.Zero, this);
			Vector2<double> vector2 = dropPos - vector;
			double y = vector2.Y;
			Size desiredSize = TargetRow.DesiredSize;
			DroppedBefore = y < ((Size)(ref desiredSize)).Height / 2.0;
			if (num < 0)
			{
				return base.Items.Count;
			}
		}
		if (!DroppedBefore)
		{
			return num + 1;
		}
		return num;
	}

	private void UpdateDropIndex(DragEventArgs e)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		DropIndex = FindDropIndex((Vector2<double>)e.GetPosition(this));
		UpdateDropIndicator();
	}

	private void ResetDropIndex()
	{
		DropIndex = -1;
		TargetRow = null;
		UpdateDropIndicator();
	}

	private void UpdateDropIndicator()
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		TargetRow?.ShowDropIndicator((DropIndex >= 0 && DropIndex <= GetTargetItemIndex()) ? AdornerPosition.Top : AdornerPosition.Bottom);
	}

	private int GetTargetItemIndex()
	{
		if (TargetItem == null || SourceCollection == null)
		{
			return -1;
		}
		return SourceCollection.IndexOf(TargetItem);
	}
}
