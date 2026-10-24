using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Transforming;
using Pro.UI.Controls;

namespace ProPresenter.UI.CueInspector.Crop;

public class CropHandle : FixedControl
{
	private const double HandleBoxLength = 6.0;

	private const double HandleEdgeThickness = 0.5;

	private static readonly Pen WhiteHandleEdgePen = new Pen(Brushes.White, 0.5);

	private bool _isDragging;

	private Vector2<double> _dragOffset;

	public HandleLocation HandleLocation { get; }

	internal Vector2<double> StartMousePosition { get; private set; }

	internal Vector2<double> CurrentMousePosition { get; private set; }

	public event Action<CropHandle>? DragStarted;

	public event Action<CropHandle>? Dragged;

	public event Action<CropHandle>? DragEnded;

	public CropHandle(HandleLocation handleLocation)
	{
		HandleLocation = handleLocation;
		base.Width = 6.0;
		base.Height = 6.0;
		base.Cursor = GetCursor();
	}

	internal void UpdateLocation(Rect<double> bounds)
	{
		Vector2<double> handlePosition = HandleLocation.GetHandlePosition(bounds, Angle<double>.Zero);
		double x = (HandleLocation.IsLeft() ? 0.0 : (HandleLocation.IsRight() ? 6.0 : 3.0));
		double y = (HandleLocation.IsTop() ? 0.0 : (HandleLocation.IsBottom() ? 6.0 : 3.0));
		base.Location = handlePosition - new Vector2<double>(x, y);
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		dc.DrawRectangle(Brushes.Black, WhiteHandleEdgePen, new Rect(new Size(base.ActualWidth, base.ActualHeight)));
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		base.OnMouseDown(e);
		if (e.ChangedButton == MouseButton.Left)
		{
			_isDragging = true;
			_dragOffset = (Vector2<double>)e.GetPosition(this);
			StartMousePosition = base.FixedParent?.GetMousePosition(e, _dragOffset) ?? Vector2<double>.Zero;
			CaptureMouse();
			this.DragStarted?.Invoke(this);
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		base.OnMouseUp(e);
		if (e.ChangedButton == MouseButton.Left)
		{
			_isDragging = false;
			ReleaseMouseCapture();
			this.DragEnded?.Invoke(this);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (_isDragging)
		{
			CurrentMousePosition = base.FixedParent?.GetMousePosition(e, _dragOffset) ?? Vector2<double>.Zero;
			this.Dragged?.Invoke(this);
		}
	}

	private Cursor GetCursor()
	{
		switch (HandleLocation)
		{
		case HandleLocation.TopLeft:
		case HandleLocation.BottomRight:
			return Cursors.SizeNWSE;
		case HandleLocation.TopCenter:
		case HandleLocation.BottomCenter:
			return Cursors.SizeNS;
		case HandleLocation.TopRight:
		case HandleLocation.BottomLeft:
			return Cursors.SizeNESW;
		case HandleLocation.RightCenter:
		case HandleLocation.LeftCenter:
			return Cursors.SizeWE;
		default:
			throw new NotSupportedException();
		}
	}
}
