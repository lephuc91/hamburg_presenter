using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class OptionalBreakElement : ElementBase
{
	public override ElementType Type => ElementType.OptionalBreak;

	public OptionalBreakElement(XmlNode node)
	{
	}
}
