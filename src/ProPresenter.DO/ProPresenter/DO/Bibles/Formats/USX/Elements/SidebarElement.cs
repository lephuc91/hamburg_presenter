using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class SidebarElement : ElementBase
{
	public override ElementType Type => ElementType.Sidebar;

	public SidebarElement(XmlNode node)
	{
	}
}
