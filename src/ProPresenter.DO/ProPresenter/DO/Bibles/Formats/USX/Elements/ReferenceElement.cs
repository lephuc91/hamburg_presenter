using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class ReferenceElement : ElementBase
{
	public override ElementType Type => ElementType.Reference;

	public ReferenceElement(XmlNode node)
	{
	}
}
