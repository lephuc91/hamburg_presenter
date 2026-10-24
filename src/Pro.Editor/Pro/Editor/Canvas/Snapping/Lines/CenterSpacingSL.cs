using System.Collections.Generic;

namespace Pro.Editor.Canvas.Snapping.Lines;

public class CenterSpacingSL : DynamicSL
{
	private IEnumerable<ICanvasElement> _owners;

	public IEnumerable<ICanvasElement> Owners => _owners;

	public CenterSpacingSL(IEnumerable<ICanvasElement> owners)
	{
		_owners = owners;
	}
}
