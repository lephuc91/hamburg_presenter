using System.Collections.Generic;

namespace Pro.Editor.Canvas.Snapping.Sources.CenterSpacing;

public class ProjectedLine : IProjectedLine
{
	public List<ICanvasElement> Owners { get; } = new List<ICanvasElement>();

	public double Center { get; set; }
}
