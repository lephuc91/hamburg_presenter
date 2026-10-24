using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Transforming;
using Pro.UI.Controls;

namespace ProPresenter.UI.CueInspector.Crop;

internal class CropWindow : FixedControl
{
	private Vector2<double>? _mousePosition;

	private Vector2<double> _startLocation = Vector2<double>.Zero;

	private CropHandle? _activeHandle;

	private Rect<double> _originalCrop = Rect<double>.Empty;

	private readonly CropHandle[] _handles = new CropHandle[8]
	{
		new CropHandle(HandleLocation.TopLeft),
		new CropHandle(HandleLocation.TopCenter),
		new CropHandle(HandleLocation.TopRight),
		new CropHandle(HandleLocation.RightCenter),
		new CropHandle(HandleLocation.BottomRight),
		new CropHandle(HandleLocation.BottomCenter),
		new CropHandle(HandleLocation.BottomLeft),
		new CropHandle(HandleLocation.LeftCenter)
	};

	public Vector2<double> CropSize { get; set; }

	public Vector2<double> MediaSize { get; set; }

	public event Action<Vector2<double>, Vector2<double>>? WindowMoved;

	public CropWindow()
	{
		base.Focusable = true;
		CropHandle[] handles = _handles;
		foreach (CropHandle cropHandle in handles)
		{
			cropHandle.DragStarted += OnDragStarted;
			cropHandle.Dragged += OnHandleDragged;
			cropHandle.DragEnded += OnDragEnded;
			base.Children.Add(cropHandle);
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		dc.DrawRectangle(Brushes.Transparent, null, new Rect(base.RenderSize));
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		Rect<double> bounds = new Rect<double>(0.0, 0.0, base.Width, base.Height);
		_handles.ForEach(delegate(CropHandle h)
		{
			h.UpdateLocation(bounds);
		});
		return base.ArrangeOverride(finalSize);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			CaptureMouse();
			_mousePosition = GetMousePosition(e);
			_startLocation = base.Location;
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			ReleaseMouseCapture();
			_mousePosition = null;
		}
		base.OnMouseUp(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (_mousePosition.HasValue)
		{
			Vector2<double> a = GetMousePosition(e) - _mousePosition.Value + _startLocation;
			this.WindowMoved?.Invoke(a.Max(Vector2<double>.Zero).Min(MediaSize - CropSize), CropSize);
		}
		base.OnMouseMove(e);
	}

	private void OnDragStarted(CropHandle handle)
	{
		Focus();
		_activeHandle = handle;
		_originalCrop = new Rect<double>(base.Location, CropSize);
	}

	private void OnHandleDragged(CropHandle handle)
	{
		UpdateHandleDrag();
	}

	private void OnDragEnded(CropHandle handle)
	{
		_activeHandle = null;
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		UpdateHandleDrag();
	}

	protected override void OnPreviewKeyUp(KeyEventArgs e)
	{
		UpdateHandleDrag();
	}

	private void UpdateHandleDrag()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (_activeHandle == null)
		{
			return;
		}
		ModifierKeys modifiers = Keyboard.Modifiers;
		bool isMirroring = ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
		bool flag = ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)4);
		HandleLocation handleLocation = _activeHandle.HandleLocation;
		Vector2<double> point = _activeHandle.CurrentMousePosition - _activeHandle.StartMousePosition;
		if (flag)
		{
			Vector2<double> size = _originalCrop.Size;
			bool num = (handleLocation.IsCorner() ? (size.X > size.Y) : handleLocation.AdjustsWidth());
			double num2 = (num ? (size.Y / size.X) : (size.X / size.Y));
			if (num)
			{
				point.Y = point.X * num2;
				if (handleLocation.IsTop() ^ handleLocation.IsLeft())
				{
					point.Y *= -1.0;
				}
			}
			else
			{
				point.X = point.Y * num2;
				if (handleLocation.IsTop() ^ handleLocation.IsLeft())
				{
					point.X *= -1.0;
				}
			}
		}
		Vector2<double> vector = point.ComponentwiseProduct(handleLocation.GetPositionScalar(isMirroring, flag));
		Vector2<double> vector2 = point.ComponentwiseProduct(handleLocation.GetSizeScalar(isMirroring, flag));
		Rect<double> rect = new Rect<double>(_originalCrop.Position + vector, _originalCrop.Size + vector2).Abs();
		Vector2<double> vector3 = rect.Position.Min(Vector2<double>.Zero);
		rect.Position = rect.Position.Max(Vector2<double>.Zero);
		rect.Size = (rect.Size + vector3).Min(MediaSize - rect.Position);
		this.WindowMoved?.Invoke(rect.Position, rect.Size);
	}
}
