using System.Collections.Generic;
using Pro.Editor.Canvas.Snapping.Sources.EqualSpacing;

namespace Pro.Editor.Canvas.Snapping.Lines;

public class EqualSpacingSL : DynamicSL
{
	public ICanvasElement Owner { get; }

	public IEnumerable<SpacingPair> Pairs { get; }

	public double MatchedSpace { get; }

	public double ActualSpace { get; }

	public EqualSpacingSL(ICanvasElement owner, IEnumerable<SpacingPair> pairs, double matchedSpace, double actualSpace)
	{
		Owner = owner;
		Pairs = pairs;
		MatchedSpace = matchedSpace;
		ActualSpace = actualSpace;
	}
}
