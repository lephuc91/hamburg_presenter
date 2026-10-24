using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class TableElement : ContainerElementBase
{
	public override ElementType Type => ElementType.Table;

	public TableElement(XmlNode node)
		: base(node)
	{
	}
}
