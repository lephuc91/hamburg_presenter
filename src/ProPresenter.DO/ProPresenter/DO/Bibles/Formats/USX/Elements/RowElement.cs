using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class RowElement : ContainerElementBase
{
	public override ElementType Type => ElementType.Row;

	public RowElement(XmlNode node)
		: base(node)
	{
	}
}
