using System.Collections.Generic;

namespace Pro.Editor.Canvas.Snapping.Sources.EqualSizing;

public class ProjectedLine : IProjectedLine
{
	public List<ICanvasElement> Owners { get; } = new List<ICanvasElement>();

	public double MatchedSize { get; set; }

	public double ActualSize { get; set; }
}
