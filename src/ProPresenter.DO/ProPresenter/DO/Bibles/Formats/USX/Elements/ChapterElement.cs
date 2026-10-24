using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class ChapterElement : ElementBase
{
	public override ElementType Type => ElementType.Chapter;

	public int Number { get; }

	public string StartID { get; }

	public string EndID { get; }

	public bool IsValid => Number >= 0;

	public ChapterElement(XmlNode node)
	{
		Number = node.GetIntAttribute("number", -1);
		StartID = node.GetAttribute("sid") ?? string.Empty;
		EndID = node.GetAttribute("eid") ?? string.Empty;
	}
}
