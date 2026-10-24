using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class FigureElement : ElementBase
{
	public override ElementType Type => ElementType.Figure;

	public FigureElement(XmlNode node)
	{
	}
}
