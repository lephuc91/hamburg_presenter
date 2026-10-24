using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Handles;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.Handles;

public class TextOverflowHandle : HandleBase
{
	private const double HandleRadius = 6.5;

	private const double HandleOffset = 20.0;

	private const double PlusMargin = 2.0;

	private static readonly Brush HandleBrush;

	private static readonly Pen HandlePen;

	private static readonly Pen PlusPen;

	private readonly ClosedBezierPath _attachedElement;

	static TextOverflowHandle()
	{
		HandleBrush = Brushes.SlateBlue;
		HandlePen = new Pen(HandleBrush, 1.0);
		PlusPen = new Pen(Brushes.White, 1.0);
		((Freezable)HandlePen).Freeze();
		((Freezable)PlusPen).Freeze();
	}

	public TextOverflowHandle(ClosedBezierPath attachedElement)
	{
		base.DataContext = (_attachedElement = attachedElement);
	}

	protected override void OnMouseClick(MouseButtonEventArgs e)
	{
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
	}

	protected override void OnUpdateLocation()
	{
		Rect<double> rect = new Rect<double>(_attachedElement.Position, _attachedElement.Size);
		Vector2<double> point = rect.BottomCenter + new Vector2<double>(0.0, 20.0 / (base.FixedParent?.LocationScale ?? 0.0));
		base.Location = point.Rotate(rect.Center, _attachedElement.Rotation.InvertedCartesianValue) * base.TransformMatrix;
	}

	protected override void OnDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint)
	{
	}

	protected override void OnRenderHandle(DrawingContext dc)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		if (_attachedElement.IsTextOverflowing && !_attachedElement.IsEditModeActive)
		{
			TextDocument displayText = _attachedElement.DisplayText;
			if ((object)displayText == null || displayText.Settings.ScaleMode != ScaleMode.AdjustContainerHeight)
			{
				dc.DrawLine(HandlePen, Vector2<double>.Zero, new Vector2<double>(0.0, -20.0));
				dc.DrawEllipse(HandleBrush, null, Vector2<double>.Zero, 6.5, 6.5);
				dc.DrawLine(PlusPen, new Vector2<double>(0.0, -4.5), new Vector2<double>(0.0, 4.5));
				dc.DrawLine(PlusPen, new Vector2<double>(-4.5, 0.0), new Vector2<double>(4.5, 0.0));
			}
		}
	}
}
