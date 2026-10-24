using System.Linq;
using System.Windows.Data;
using Pro.Common.Collections;
using ProPresenter.DO.Slide.Custom.Elements.Handles;

namespace ProPresenter.UI.SlideEditor.Handles;

public class BezierHandleSetProvider
{
	private readonly BezierHandleSetData _setData;

	private bool _isActive;

	public BezierPointHandle[] Handles { get; }

	public bool IsActive
	{
		get
		{
			if (!_isActive)
			{
				return Handles.Any((BezierPointHandle h) => h.IsSelected);
			}
			return true;
		}
	}

	public BezierHandleSetProvider(BezierHandleSetData setData)
	{
		_setData = setData;
		BezierPointHandle bezierPointHandle = new BezierPointHandle(_setData.Element, _setData.Point, this);
		Handles = new BezierPointHandle[3]
		{
			bezierPointHandle,
			new BezierControlPointHandle(_setData.Element, _setData.Point, this, BezierControlPointType.Q0),
			new BezierControlPointHandle(_setData.Element, _setData.Point, this, BezierControlPointType.Q1)
		};
		_setData.SetStartBezierPointDrag(bezierPointHandle.StartBezierPointDrag);
		_setData.SetStartControlPointDrag(bezierPointHandle.StartControlPointDrag);
		_setData.SetUpdateDrag(bezierPointHandle.InvalidateVisual);
		bezierPointHandle.SetBinding(BezierPointHandle.ShowPreviewProperty, new Binding("ShowPreview")
		{
			Source = _setData
		});
		Handles.ForEach(delegate(BezierPointHandle handle)
		{
			handle.DragStarted += OnHandleDragStarted;
			handle.Dragged += OnHandleDragged;
			handle.DragCompleted += OnHandleDragCompleted;
			handle.PointToggleStarted += OnPointToggleStarted;
			handle.PointToggleCompleted += OnPointToggleCompleted;
		});
	}

	public void UnhookEventHandlers()
	{
		_setData.SetStartBezierPointDrag(null);
		_setData.SetStartControlPointDrag(null);
		_setData.SetUpdateDrag(null);
		Handles.ForEach(delegate(BezierPointHandle handle)
		{
			handle.DragStarted -= OnHandleDragStarted;
			handle.Dragged -= OnHandleDragged;
			handle.DragCompleted -= OnHandleDragCompleted;
			handle.PointToggleStarted -= OnPointToggleStarted;
			handle.PointToggleCompleted -= OnPointToggleCompleted;
		});
	}

	private void OnHandleDragStarted(BezierPointHandle handle)
	{
		_isActive = true;
		_setData.Element.HandleDragStarted(handle.Point);
	}

	private void OnHandleDragged(BezierPointHandle handle)
	{
		Handles.ForEach(delegate(BezierPointHandle v)
		{
			v.InvalidateLines();
		});
		_setData.Element.HandleDragged(handle.Point);
	}

	private void OnHandleDragCompleted(BezierPointHandle handle)
	{
		_isActive = false;
		_setData.Element.HandleDragCompleted(handle.Point);
	}

	private void OnPointToggleStarted(BezierPointHandle handle)
	{
		_setData.Element.PointToggleStarted(handle.Point);
	}

	private void OnPointToggleCompleted(BezierPointHandle handle)
	{
		_setData.Element.PointToggleCompleted(handle.Point);
	}
}
