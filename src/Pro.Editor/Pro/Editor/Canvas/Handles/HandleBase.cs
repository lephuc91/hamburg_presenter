using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Transforming;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Handles;

public abstract class HandleBase : FixedControl
{
	private double _rotation;

	private bool _isActive;

	private Matrix<double> _transformMatrix = Matrix<double>.Identity;

	private bool _isDragging;

	private Vector2<double> _startDragPosition;

	private Vector2<double> _lastDragPosition;

	private Vector2<double> _dragOffset;

	private bool _isSelected;

	public static readonly DependencyProperty LayoutScaleProperty = DependencyProperty.Register("LayoutScale", typeof(double), typeof(HandleBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	protected internal double Rotation
	{
		get
		{
			return _rotation;
		}
		set
		{
			if (_rotation != value)
			{
				_rotation = value;
				InvalidateVisual();
			}
		}
	}

	internal bool IsActive
	{
		get
		{
			if (!_isActive)
			{
				return IsHandleActive();
			}
			return true;
		}
		set
		{
			_isActive = value;
		}
	}

	public virtual bool CanSelect => false;

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		internal set
		{
			if (_isSelected != value)
			{
				_isSelected = value;
				InvalidateVisual();
			}
		}
	}

	protected internal IEnumerable<HandleBase>? SelectedHandles { get; internal set; }

	protected Matrix<double> TransformMatrix => _transformMatrix;

	public double LayoutScale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LayoutScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutScaleProperty, (object)value);
		}
	}

	internal event Action<bool, ITransform?, ITooltipDataSource?>? TransformStateChanged;

	internal event Action<HandleBase>? OnClick;

	protected internal abstract void OnUpdateLocation();

	protected virtual ITooltipDataSource? OnDragStarted(out ITransform? activeTransform)
	{
		activeTransform = null;
		return null;
	}

	protected abstract void OnDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint);

	protected virtual void OnDragEnded()
	{
	}

	protected virtual void OnUpdateCursor()
	{
	}

	protected virtual bool IsHandleActive()
	{
		return false;
	}

	protected abstract void OnRenderHandle(DrawingContext dc);

	protected override void OnRender(DrawingContext dc)
	{
		dc.PushTransform(new RotateTransform(Rotation));
		OnRenderHandle(dc);
	}

	internal void UpdateLocation(Matrix<double> transformMatrix)
	{
		_transformMatrix = transformMatrix;
		OnUpdateLocation();
	}

	protected internal virtual bool DidHandleMove(PropertyChangedEventArgs e)
	{
		return e.PropertyName.IsAnyOf<string>(new string[3] { "Position", "Size", "Rotation" });
	}

	protected override void OnMouseClick(MouseButtonEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left)
		{
			_isDragging = true;
			_dragOffset = (Vector2<double>)e.GetPosition(this);
			_startDragPosition = GetMousePosition(e, _dragOffset) * TransformMatrix.Inverse();
			_lastDragPosition = _startDragPosition;
			CaptureMouse();
			ITransform activeTransform;
			ITooltipDataSource arg = OnDragStarted(out activeTransform);
			IsActive = true;
			this.TransformStateChanged?.Invoke(arg1: true, activeTransform, arg);
			this.OnClick?.Invoke(this);
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			_isDragging = false;
			IsActive = false;
			ReleaseMouseCapture();
			OnDragEnded();
			this.TransformStateChanged?.Invoke(arg1: false, null, null);
		}
		OnUpdateCursor();
		base.OnMouseUp(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (e.LeftButton == MouseButtonState.Pressed && base.IsMouseCaptured)
		{
			Vector2<double> vector = GetMousePosition(e, _dragOffset) * TransformMatrix.Inverse();
			OnDragged(_startDragPosition, _lastDragPosition, vector);
			_lastDragPosition = vector;
		}
		OnUpdateCursor();
		base.OnMouseMove(e);
		e.Handled = true;
	}

	internal void UpdateState()
	{
		OnUpdateCursor();
		if (_isDragging)
		{
			OnDragged(_startDragPosition, _lastDragPosition, _lastDragPosition);
		}
	}
}
