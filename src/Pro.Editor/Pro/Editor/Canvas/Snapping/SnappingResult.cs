using System.Collections.Generic;
using System.Linq;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Snapping;

public class SnappingResult
{
	public static readonly SnappingResult EmptyResults = new SnappingResult(new ISnapLine[0], Vector2<double>.Zero, Vector2<double>.Zero);

	public IEnumerable<ISnapLine> SnapLines { get; }

	public Vector2<double> SnapOrigin { get; }

	public Vector2<double> SnapDelta { get; }

	public bool DidSnap => SnapLines.Any();

	public SnappingResult(IEnumerable<ISnapLine> snapLines, Vector2<double> snapOrigin, Vector2<double> snapDelta)
	{
		SnapLines = snapLines;
		SnapOrigin = snapOrigin;
		SnapDelta = snapDelta;
	}
}
