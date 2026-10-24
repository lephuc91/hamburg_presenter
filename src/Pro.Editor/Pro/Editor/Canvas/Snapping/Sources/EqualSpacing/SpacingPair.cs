namespace Pro.Editor.Canvas.Snapping.Sources.EqualSpacing;

public class SpacingPair
{
	public ICanvasElement A { get; set; }

	public ICanvasElement B { get; set; }

	public SpacingPair(ICanvasElement a, ICanvasElement b)
	{
		A = a;
		B = b;
	}
}
