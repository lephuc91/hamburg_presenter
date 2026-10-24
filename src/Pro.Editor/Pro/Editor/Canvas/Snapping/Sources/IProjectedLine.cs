using System.Collections.Generic;

namespace Pro.Editor.Canvas.Snapping.Sources;

public interface IProjectedLine
{
	List<ICanvasElement> Owners { get; }
}
