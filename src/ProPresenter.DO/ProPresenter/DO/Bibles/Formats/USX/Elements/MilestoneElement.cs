using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class MilestoneElement : ElementBase
{
	public override ElementType Type => ElementType.Milestone;

	public MilestoneElement(XmlNode node)
	{
	}
}
