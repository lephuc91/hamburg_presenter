using System.Linq;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;

namespace Pro.Editor.Canvas.Guidelines;

internal class CenterSpacingGuideline : SpacingGuideline
{
	public CenterSpacingGuideline(CenterSpacingSL snapLine, Rect<double> finalBounds)
		: base(snapLine.IsHorizontal, 0.0)
	{
		if (!snapLine.Owners.Any())
		{
			return;
		}
		base.Space = snapLine.Owners.First().SnapBounds.ClosestEdgeDistance(finalBounds, snapLine.IsHorizontal);
		foreach (ICanvasElement owner in snapLine.Owners)
		{
			GenerateLinePosition(finalBounds, owner.SnapBounds);
		}
	}
}
