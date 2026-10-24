using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Transforming;

public class RotationTransform : TransformBase
{
	private Dictionary<ICanvasElement, Angle<double>> _lastRotationSnaps = new Dictionary<ICanvasElement, Angle<double>>();

	public override void TransformElements(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint, ModifierKeys modifierKeys)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		foreach (ICanvasElement element in base.Elements)
		{
			_lastRotationSnaps.TryGetValue(element, out var value);
			Vector2<double> origin = element.Position + element.Size / 2.0;
			double num = origin.AngleBetween(currentPoint, startPoint);
			Angle<double> angle = new Angle<double>(origin.AngleBetween(lastPoint, startPoint) - num, isCartesian: true) - value;
			if (((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)4))
			{
				Angle<double> angle2 = element.Rotation - angle;
				value = angle2 - new Angle<double>(Math.Round(angle2.InvertedCartesianValue / 45.0, 0) * 45.0);
			}
			else
			{
				value = Angle<double>.Zero;
			}
			_lastRotationSnaps[element] = value;
			element.Rotation -= angle + value;
		}
		if (base.Elements.Any())
		{
			base.TooltipLabel = $"{Math.Round(base.Elements.First().Rotation.CartesianValue, 1)}°";
		}
	}

	public override void CompleteTransform()
	{
		base.CompleteTransform();
		_lastRotationSnaps.Clear();
	}
}
