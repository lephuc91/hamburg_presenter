using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class BookElement : ElementBase
{
	public override ElementType Type => ElementType.Book;

	public string? Code { get; }

	public string Description { get; }

	public BookElement(XmlNode node)
	{
		Code = node.GetAttribute("code");
		Description = node.Value ?? string.Empty;
	}
}
