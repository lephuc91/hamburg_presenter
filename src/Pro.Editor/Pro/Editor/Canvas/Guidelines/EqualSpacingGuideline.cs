using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Snapping.Sources.EqualSpacing;

namespace Pro.Editor.Canvas.Guidelines;

internal class EqualSpacingGuideline : SpacingGuideline
{
	public EqualSpacingGuideline(EqualSpacingSL snapLine, Rect<double> finalBounds)
		: base(snapLine.IsHorizontal, snapLine.ActualSpace)
	{
		GenerateLinePosition(finalBounds, snapLine.Owner.SnapBounds);
		foreach (SpacingPair pair in snapLine.Pairs)
		{
			GenerateLinePosition(pair.A.SnapBounds, pair.B.SnapBounds);
		}
	}
}
