using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;

namespace ProPresenter.UI.Utility;

public class DragItemWrapper<TControl, TData> where TControl : FrameworkElement where TData : class
{
	private bool _canStartDrag;

	private Vector2<double> _mouseDownPosition;

	private readonly DragSource _dragSource;

	private readonly UIElement _source;

	public DragItemWrapper(UIElement source)
	{
		_source = source;
		_dragSource = new DragSource((DependencyObject)(object)source);
	}

	public void EnableDragging()
	{
		_source.PreviewMouseLeftButtonDown += DragItemSource_PreviewMouseLeftButtonDown;
		_source.PreviewMouseMove += DragItemSource_PreviewMouseMove;
		_source.PreviewMouseLeftButtonUp += DragItemSource_PreviewMouseLeftButtonUp;
	}

	public void DisableDragging()
	{
		_source.PreviewMouseLeftButtonDown -= DragItemSource_PreviewMouseLeftButtonDown;
		_source.PreviewMouseMove -= DragItemSource_PreviewMouseMove;
		_source.PreviewMouseLeftButtonUp -= DragItemSource_PreviewMouseLeftButtonUp;
	}

	private void DragItemSource_PreviewMouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		object originalSource = e.OriginalSource;
		IEnumerable<DependencyObject> source = ((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindAllVisualParents(typeof(Button)) ?? Enumerable.Empty<DependencyObject>();
		_mouseDownPosition = (Vector2<double>)e.GetPosition(_source);
		_canStartDrag = !source.Any();
	}

	private void DragItemSource_PreviewMouseMove(object? sender, MouseEventArgs e)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.CanDrag(_source, _mouseDownPosition))
		{
			HitTestResult hitTestResult = VisualTreeHelper.HitTest(_source, _mouseDownPosition);
			object obj;
			if (hitTestResult == null)
			{
				obj = null;
			}
			else
			{
				DependencyObject visualHit = hitTestResult.VisualHit;
				obj = ((visualHit != null) ? visualHit.FindVisualParent<TControl>() : null);
			}
			TControl val = (TControl)obj;
			if (val?.DataContext is TData val2)
			{
				_dragSource.StartDrag(new DraggedItems<TData>(null, new TData[1] { val2 }), val.ToDragVisual(1, null), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)_source.TranslatePoint(_mouseDownPosition, val));
				_canStartDrag = false;
				e.Handled = true;
			}
		}
	}

	private void DragItemSource_PreviewMouseLeftButtonUp(object? sender, MouseButtonEventArgs e)
	{
		_mouseDownPosition = Vector2<double>.Zero;
		_canStartDrag = false;
	}
}
