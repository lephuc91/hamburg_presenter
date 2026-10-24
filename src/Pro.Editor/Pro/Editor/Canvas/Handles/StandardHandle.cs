using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Editor.Canvas.Snapping;
using Pro.Editor.Canvas.Transforming;

namespace Pro.Editor.Canvas.Handles;

internal class StandardHandle : HandleBase
{
	private const double HandleBoxLength = 6.0;

	private const double HandleEdgeThickness = 0.5;

	private const double MinimumHandleSpacing = 15.0;

	private static readonly Pen BlackHandleEdgePen = new Pen(Brushes.Black, 0.5);

	private static readonly Pen WhiteHandleEdgePen = new Pen(Brushes.White, 0.5);

	private static readonly Pen LockedHandlePen = new Pen(Brushes.Transparent, 0.5);

	private readonly ICanvasElement _attachedElement;

	private readonly SnapController _snapController;

	private ITransform? _currentTransform;

	private bool _isEnabled = true;

	public HandleLocation HandleLocation { get; }

	public StandardHandle(HandleLocation handleLocation, ICanvasElement attachedElement, SnapController snapController)
	{
		HandleLocation = handleLocation;
		_attachedElement = attachedElement;
		_snapController = snapController;
	}

	protected internal override void OnUpdateLocation()
	{
		Rect<double> bounds = new Rect<double>(_attachedElement.Position, _attachedElement.Size);
		bool flag = false;
		double num = (15.0 / base.FixedParent?.LocationScale) ?? 1.0;
		if (bounds.Width < num)
		{
			bounds.Left -= (num - bounds.Width) / 2.0;
			bounds.Width = num;
			if (HandleLocation.AdjustsHeight())
			{
				flag = true;
			}
		}
		if (bounds.Height < num)
		{
			bounds.Top -= (num - bounds.Height) / 2.0;
			bounds.Height = num;
			if (HandleLocation.AdjustsWidth())
			{
				flag = true;
			}
		}
		if (!HandleLocation.IsCorner() && _isEnabled == flag)
		{
			_isEnabled = !flag;
			InvalidateVisual();
		}
		if (_isEnabled)
		{
			base.Location = HandleLocation.GetHandlePosition(bounds, _attachedElement.Rotation) * base.TransformMatrix;
		}
	}

	protected override void OnRenderHandle(DrawingContext dc)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		if (_isEnabled)
		{
			double num = 3.0;
			Rect rectangle = default(Rect);
			((Rect)(ref rectangle))._002Ector(0.0 - num, 0.0 - num, 6.0, 6.0);
			if (_attachedElement.IsLocked)
			{
				OnUpdateCursor();
				dc.DrawLine(LockedHandlePen, ((Rect)(ref rectangle)).TopLeft, ((Rect)(ref rectangle)).BottomRight);
				dc.DrawLine(LockedHandlePen, ((Rect)(ref rectangle)).TopRight, ((Rect)(ref rectangle)).BottomLeft);
			}
			else
			{
				dc.DrawRectangle(new SolidColorBrush
				{
					Color = _attachedElement.HandleColor
				}, _attachedElement.HandleColor.IsLuminous() ? BlackHandleEdgePen : WhiteHandleEdgePen, rectangle);
			}
		}
	}

	protected override ITooltipDataSource OnDragStarted(out ITransform activeTransform)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (_attachedElement.SupportsRotation && ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)1))
		{
			_currentTransform = new RotationTransform();
		}
		else
		{
			_currentTransform = new SizeTransform(HandleLocation);
		}
		_currentTransform.StartTransform(new ICanvasElement[1] { _attachedElement }, _snapController);
		activeTransform = _currentTransform;
		return _currentTransform;
	}

	protected override void OnDragEnded()
	{
		_currentTransform?.CompleteTransform();
		_currentTransform = null;
		OnUpdateLocation();
	}

	protected override void OnDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		_currentTransform?.TransformElements(startPoint, lastPoint, currentPoint, Keyboard.Modifiers);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		if (!_attachedElement.IsLocked)
		{
			base.OnMouseDown(e);
		}
	}

	protected override void OnUpdateCursor()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		if (_attachedElement.IsLocked)
		{
			base.Cursor = Cursors.Arrow;
			return;
		}
		double num = (((_currentTransform is SizeTransform sizeTransform) ? sizeTransform.EffectiveHandleLocation : HandleLocation).GetAngle() + base.Rotation + 22.5).Mod(180.0);
		bool flag = (_attachedElement.SupportsRotation && ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)1) && _currentTransform == null) || _currentTransform is RotationTransform;
		if (num <= 45.0)
		{
			base.Cursor = (flag ? Cursors.SizeNS : Cursors.SizeWE);
		}
		else if (num <= 90.0)
		{
			base.Cursor = (flag ? Cursors.SizeNESW : Cursors.SizeNWSE);
		}
		else if (num <= 135.0)
		{
			base.Cursor = (flag ? Cursors.SizeWE : Cursors.SizeNS);
		}
		else if (num <= 180.0)
		{
			base.Cursor = (flag ? Cursors.SizeNWSE : Cursors.SizeNESW);
		}
	}
}
