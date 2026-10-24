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

public abstract class ReorderTabControl<T> : TabControl
{
	private readonly DragSource _dragSource;

	private readonly DropTarget _dropTarget;

	private bool _canStartDrag;

	private Vector2<double> _mouseDownPos = Vector2<double>.Zero;

	private int _dropIndex = -1;

	protected abstract IDragDropCollection<T>? SourceCollection { get; }

	protected virtual bool CanReorder => true;

	protected ReorderTabControl()
	{
		_dragSource = new DragSource((DependencyObject)(object)this);
		_dropTarget = new DropTarget((DependencyObject)(object)this);
		DropAction<T> dropAction = _dropTarget.AddDropType<T>();
		dropAction.SetIsValidDataPredicate((T t, DragEventArgs e) => SourceCollection != null);
		dropAction.SetOnDataEnteredAction(OnDragEnter);
		dropAction.SetOnDataLeftAction(OnDragLeft);
		dropAction.SetOnDataDraggedAction(OnDrag);
		dropAction.SetOnDataDroppedAction(OnDrop);
		base.AllowDrop = true;
	}

	private void OnDragEnter(T item, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnDragLeft(T item, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnDrag(T? item, DragEventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		((DependencyObject)(object)this).ResetDropIndicator();
		if (item != null)
		{
			e.Effects = DragDropEffects.Move;
			Vector2<double> vector = (Vector2<double>)e.GetPosition(this);
			DependencyObject val = VisualTreeHelper.HitTest(this, vector)?.VisualHit;
			DependencyObject val2 = base.ItemContainerGenerator.ContainerFromItem(item);
			_dropIndex = -1;
			if (!(val is DropIndicator))
			{
				TabItem tabItem = val?.FindVisualParent<TabItem>();
				if (tabItem != null && tabItem.DataContext is T item2 && val2 != tabItem)
				{
					Point val3 = tabItem.TranslatePoint(Vector2<double>.Zero, this);
					Vector val4 = (Point)vector - val3;
					bool flag = ((Vector)(ref val4)).X <= tabItem.ActualWidth / 2.0;
					_dropIndex = (SourceCollection?.IndexOf(item2) + ((!flag) ? 1 : 0)) ?? (-1);
					tabItem.ShowDropIndicator((!flag) ? AdornerPosition.Right : AdornerPosition.Left);
					e.Handled = true;
				}
			}
		}
		else
		{
			e.Effects = DragDropEffects.None;
		}
	}

	private void OnDrop(T? item, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (item != null && _dropIndex >= 0)
		{
			SourceCollection?.MoveTo(item.ToEnumerable(), _dropIndex);
			((DependencyObject)this).SetCurrentValue(Selector.SelectedItemProperty, (object)item);
			e.Handled = true;
		}
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		_mouseDownPos = (Vector2<double>)e.GetPosition(this);
		_canStartDrag = CanReorder && VisualTreeHelper.HitTest(this, e.GetPosition(this))?.VisualHit.FindVisualParent<TabItem>() != null;
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_canStartDrag = false;
		base.OnPreviewMouseLeftButtonUp(e);
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPos))
		{
			_canStartDrag = false;
			TabItem tabItem = e.FindHitElement<TabItem>(this);
			if (tabItem == null || !(tabItem.DataContext is T val))
			{
				return;
			}
			_dragSource.StartDrag(val, CreateDragVisual(val), DragDropEffects.Move, (Vector2<double>)e.GetPosition(tabItem));
			e.Handled = true;
		}
		base.OnPreviewMouseMove(e);
	}

	protected Visual CreateDragVisual(T draggedItem)
	{
		return ((Control)(object)base.ItemContainerGenerator.ContainerFromItem(draggedItem)).ToDragVisual(1, null);
	}
}
