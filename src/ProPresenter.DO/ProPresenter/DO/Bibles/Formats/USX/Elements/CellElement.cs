using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class CellElement : ContainerElementBase
{
	public override ElementType Type => ElementType.Cell;

	public CellElement(XmlNode node)
		: base(node)
	{
	}
}
