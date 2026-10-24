using System;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Editor.Canvas.Handles;

namespace ProPresenter.DO.Slide.Custom.Elements.Handles;

public class BezierHandleSetData : NotifyPropertyChangedBase, IHandleData
{
	private bool _showPreview;

	private Action<MouseEventArgs>? _startBezierPointDrag;

	private Action<MouseEventArgs>? _startControlPointDrag;

	private Action? _updateDrag;

	public BezierPath Element { get; }

	public BezierPoint Point { get; }

	public bool ShowPreview
	{
		get
		{
			return _showPreview;
		}
		set
		{
			SetValue("ShowPreview", ref _showPreview, value);
		}
	}

	public BezierHandleSetData(BezierPath element, BezierPoint point)
	{
		Element = element;
		Point = point;
	}

	public void SetStartBezierPointDrag(Action<MouseEventArgs>? startBezierPointDrag)
	{
		_startBezierPointDrag = startBezierPointDrag;
	}

	public void StartBezierPointDrag(MouseEventArgs args)
	{
		_startBezierPointDrag?.Invoke(args);
	}

	public void SetStartControlPointDrag(Action<MouseEventArgs>? startControlPointDrag)
	{
		_startControlPointDrag = startControlPointDrag;
	}

	public void StartControlPointDrag(MouseEventArgs args)
	{
		_startControlPointDrag?.Invoke(args);
	}

	public void SetUpdateDrag(Action? updateDrag)
	{
		_updateDrag = updateDrag;
	}

	public void UpdateDrag()
	{
		_updateDrag?.Invoke();
	}
}
