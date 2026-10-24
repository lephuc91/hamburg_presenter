using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Editor.Canvas;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Handles;

namespace ProPresenter.UI.SlideEditor.Pens;

public class OpenBezierPathPen : IPenTool
{
	private OpenBezierPath? _path;

	private BezierHandleSetData? _lastAddedHandleSet;

	private bool _handleNeedsMouse;

	public Cursor MouseCursor => Cursors.Pen;

	private BezierHandleSetData? LastAddedHandleSet
	{
		get
		{
			return _lastAddedHandleSet;
		}
		set
		{
			if (_lastAddedHandleSet != null)
			{
				_lastAddedHandleSet.ShowPreview = false;
			}
			_lastAddedHandleSet = value;
		}
	}

	public event Action? DeactivatePen;

	public event Action<BezierPath, bool>? DrawingStarted;

	public event Action? DrawingCompleted;

	public event Action<OpenBezierPath>? ClosePath;

	public void Unload()
	{
		if (_path != null)
		{
			_path.ClosePath -= this.ClosePath;
			_path.LeftEditMode -= this.DeactivatePen;
			_path.PropertyChanged -= PathPropertyChanged;
			_path.CustomHandles.CollectionChanged -= PathHandlesCollectionChanged;
		}
	}

	public void MouseDown(Vector2<double> point, MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			bool flag = _path == null;
			if (flag)
			{
				_path = new OpenBezierPath();
				_path.ClosePath += this.ClosePath;
				_path.LeftEditMode += this.DeactivatePen;
				_path.PropertyChanged += PathPropertyChanged;
				_path.CustomHandles.CollectionChanged += PathHandlesCollectionChanged;
			}
			AddPoint(point);
			this.DrawingStarted?.Invoke(_path, flag);
		}
	}

	public void MouseMove(Vector2<double> point, MouseEventArgs e)
	{
		if (LastAddedHandleSet == null)
		{
			return;
		}
		if (_handleNeedsMouse && e.LeftButton == MouseButtonState.Pressed)
		{
			LastAddedHandleSet.StartControlPointDrag(e);
		}
		else if (e.LeftButton != MouseButtonState.Pressed)
		{
			if (!LastAddedHandleSet.ShowPreview)
			{
				LastAddedHandleSet.ShowPreview = true;
			}
			else
			{
				LastAddedHandleSet.UpdateDrag();
			}
		}
		_handleNeedsMouse = false;
	}

	public void MouseUp(Vector2<double> point, MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			this.DrawingCompleted?.Invoke();
		}
	}

	private void AddPoint(Vector2<double> point)
	{
		_path.ThrowWhenNull("_path");
		BezierPoint newBezierPoint = _path.AddPoint(point);
		LastAddedHandleSet = _path.CustomHandles.OfType<BezierHandleSetData>().FirstOrDefault((BezierHandleSetData s) => s.Point == newBezierPoint);
		if (LastAddedHandleSet != null)
		{
			_handleNeedsMouse = true;
		}
	}

	private void PathPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsLocked")
		{
			this.DeactivatePen?.Invoke();
		}
	}

	private void PathHandlesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		_path.ThrowWhenNull("_path");
		LastAddedHandleSet = _path.CustomHandles.OfType<BezierHandleSetData>().LastOrDefault();
		if (LastAddedHandleSet != null)
		{
			LastAddedHandleSet.ShowPreview = true;
		}
	}
}
