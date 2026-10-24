using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls;

internal class SelectionBorder : FixedControl
{
	private static readonly Pen ElementEdgePen;

	private readonly ICanvasElement _attachedElement;

	private double _rotation;

	public double Rotation
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

	static SelectionBorder()
	{
		ElementEdgePen = new Pen(Brushes.SlateBlue, 1.0);
		((Freezable)ElementEdgePen).Freeze();
	}

	public SelectionBorder(ICanvasElement attachedElement)
	{
		_attachedElement = attachedElement;
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		dc.PushTransform(new RotateTransform(Rotation));
		dc.PushTransform(new ScaleTransform(base.LocationScale, base.LocationScale));
		dc.DrawRectangle(null, ElementEdgePen, new Rect<double>(-_attachedElement.Size / 2.0, _attachedElement.Size));
	}

	internal void UpdateLocation(Matrix<double> transformMatrix)
	{
		base.Location = new Rect<double>(_attachedElement.Position, _attachedElement.Size).Center * transformMatrix;
		InvalidateVisual();
	}
}
