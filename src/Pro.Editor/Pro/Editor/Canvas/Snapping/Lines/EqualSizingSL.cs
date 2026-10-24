using System.Collections.Generic;

namespace Pro.Editor.Canvas.Snapping.Lines;

public class EqualSizingSL : DynamicSL
{
	public IEnumerable<ICanvasElement> Owners { get; }

	public double Size { get; }

	public EqualSizingSL(IEnumerable<ICanvasElement> owners, double size)
	{
		Owners = owners;
		Size = size;
	}
}
