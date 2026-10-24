using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class ParagraphElement : ContainerElementBase
{
	public override ElementType Type => ElementType.Paragraph;

	public ParagraphStyle Style { get; }

	public string VerseID { get; }

	public ParagraphElement(XmlNode node)
		: base(node)
	{
		Style = ParagraphStyleProvider.ParseStyle(node.GetAttribute("style") ?? string.Empty);
		VerseID = node.GetAttribute("vid") ?? string.Empty;
	}
}
