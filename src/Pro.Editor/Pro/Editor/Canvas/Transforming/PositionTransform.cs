using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping;
using Pro.Editor.Canvas.Snapping.Sources;

namespace Pro.Editor.Canvas.Transforming;

public class PositionTransform : TransformBase
{
	private ISnappingSource? _snappingSource;

	public override void StartTransform(IEnumerable<ICanvasElement> elements, SnapController snapController)
	{
		base.StartTransform(elements, snapController);
		_snappingSource = new GroupedSS(base.Elements);
	}

	public override void TransformElements(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint, ModifierKeys modifierKeys)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		if (!base.Elements.Any())
		{
			return;
		}
		if (base.SnapController == null)
		{
			throw new MemberAccessException("SnapController");
		}
		Vector2<double> vector = currentPoint - lastPoint;
		foreach (ICanvasElement element in base.Elements)
		{
			Vector2<double> snapDelta = base.SnapController.LatestResult.SnapDelta;
			snapDelta = snapDelta.Rotate(Vector2<double>.Zero, (element.CanvasParent?.Rotation ?? Angle<double>.Zero).CartesianValue);
			element.Position += vector - snapDelta;
		}
		bool flag = !((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)1);
		SnappingResult snappingResult = SnappingResult.EmptyResults;
		if (_snappingSource != null && flag)
		{
			snappingResult = base.SnapController.FindMatchingSnaps(_snappingSource);
		}
		if (snappingResult.DidSnap)
		{
			foreach (ICanvasElement element2 in base.Elements)
			{
				Vector2<double> snapDelta2 = snappingResult.SnapDelta;
				snapDelta2 = snapDelta2.Rotate(Vector2<double>.Zero, (element2.CanvasParent?.Rotation ?? Angle<double>.Zero).CartesianValue);
				element2.Position += snapDelta2;
			}
		}
		if (_snappingSource != null && flag)
		{
			base.SnapController.UpdateFinalBounds(_snappingSource.Bounds);
		}
		else
		{
			base.SnapController.ClearResults();
		}
		base.TooltipLabel = $"X: {Math.Round(base.Elements.First().Position.X, 0)}, Y: {Math.Round(base.Elements.First().Position.Y, 0)}";
	}
}
