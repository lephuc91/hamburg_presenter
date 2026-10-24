using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class NoteElement : ElementBase
{
	public override ElementType Type => ElementType.Note;

	public NoteStyle Style { get; }

	public NoteElement(XmlNode node)
	{
		Style = NoteStyleProvider.ParseStyle(node.GetAttribute("style"));
	}
}
