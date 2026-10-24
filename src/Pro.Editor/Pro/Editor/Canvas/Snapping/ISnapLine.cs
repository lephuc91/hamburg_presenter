namespace Pro.Editor.Canvas.Snapping;

public interface ISnapLine
{
	bool IsHorizontal { get; }

	bool IsEnabled { get; }

	double Position { get; }

	SnapEdge SnapEdges { get; }
}
