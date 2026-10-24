using System.Collections.Generic;

namespace Pro.Editor.Canvas.Snapping.Sources.EqualSpacing;

public class ProjectedLine : IProjectedLine
{
	public List<ICanvasElement> Owners { get; } = new List<ICanvasElement>();

	public double MatchedSpace { get; set; }

	public double ActualSpace { get; set; }

	public List<SpacingPair> SpacingPairs { get; } = new List<SpacingPair>();
}
