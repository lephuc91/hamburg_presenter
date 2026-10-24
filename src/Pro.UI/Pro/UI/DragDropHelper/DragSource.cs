using System;
using System.Windows;
using System.Windows.Media;
using Pro.Common.ErrorReporting;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Common.Win32;
using Pro.UI.DependencyInjection;

namespace Pro.UI.DragDropHelper;

public class DragSource
{
	private readonly DependencyObject _attachedObject;

	private readonly IErrorReporter _errorReporter;

	private DragResult _result = DragResult.DefaultResult;

	private DragDropEffects _effects;

	private Vector2<double> _offset;

	private DragVisualWindow? _dragVisualWindow;

	public bool IsDragging { get; private set; }

	public static event Action<DependencyObject>? DragStarted;

	public static event Action<DragResult>? DragCompleted;

	public DragSource(DependencyObject attachedObject)
	{
		_attachedObject = attachedObject;
		_errorReporter = UIServiceProvider.GetService<IErrorReporter>();
		DragDrop.AddGiveFeedbackHandler(_attachedObject, OnGiveFeedback);
		DragDrop.AddQueryContinueDragHandler(_attachedObject, OnQueryContinueDrag);
	}

	public DragResult StartDrag<T>(T data, Visual? dragVisual, DragDropEffects allowedEffects, Vector2<double> offset)
	{
		IsDragging = true;
		DragSource.DragStarted?.Invoke(_attachedObject);
		_offset = offset;
		GenerateDragVisual(dragVisual);
		_effects = allowedEffects;
		_result = DragResult.DefaultResult;
		try
		{
			DragDrop.DoDragDrop(_attachedObject, new DataObject(typeof(T), data), allowedEffects);
		}
		catch (Exception e)
		{
			_errorReporter.Error(e, "Failed to drag from - {0}", _attachedObject);
			_result = new DragResult(wasDragCanceled: true, wasDataAccepted: false);
		}
		finally
		{
			_dragVisualWindow?.Hide();
			_dragVisualWindow = null;
			DragSource.DragCompleted?.Invoke(_result);
			IsDragging = false;
		}
		return _result;
	}

	protected virtual void OnGiveFeedback(object? sender, GiveFeedbackEventArgs e)
	{
		_result.WasDataAccepted = _effects.HasFlag(e.Effects);
		e.UseDefaultCursors = true;
		e.Handled = true;
	}

	protected virtual void OnQueryContinueDrag(object? sender, QueryContinueDragEventArgs e)
	{
		SetDragVisualPosition();
		if (e.EscapePressed)
		{
			e.Action = DragAction.Cancel;
			_result.WasDragCanceled = true;
		}
		else if (!e.KeyStates.HasFlag(DragDropKeyStates.LeftMouseButton))
		{
			e.Action = DragAction.Drop;
			_result.WasDragCanceled = false;
		}
		else
		{
			e.Action = DragAction.Continue;
		}
		e.Handled = true;
	}

	private void SetDragVisualPosition()
	{
		if (_dragVisualWindow != null)
		{
			POINT pt = default(POINT);
			WindowsFunctions.GetCursorPos(ref pt);
			_dragVisualWindow.Left = ((double)pt.X - _offset.X) / _dragVisualWindow.GetDpiScaleFactor().X;
			_dragVisualWindow.Top = ((double)pt.Y - _offset.Y) / _dragVisualWindow.GetDpiScaleFactor().Y;
		}
	}

	private void GenerateDragVisual(Visual? dragVisual)
	{
		if (dragVisual is FrameworkElement frameworkElement)
		{
			_dragVisualWindow = new DragVisualWindow();
			_dragVisualWindow.Content = frameworkElement;
			_dragVisualWindow.Height = frameworkElement.Height;
			_dragVisualWindow.Width = frameworkElement.Width;
			SetDragVisualPosition();
			_dragVisualWindow.Show();
		}
	}
}
