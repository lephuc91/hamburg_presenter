using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class PeripheralElement : ElementBase
{
	public override ElementType Type => ElementType.Peripheral;

	public PeripheralElement(XmlNode node)
	{
	}
}
