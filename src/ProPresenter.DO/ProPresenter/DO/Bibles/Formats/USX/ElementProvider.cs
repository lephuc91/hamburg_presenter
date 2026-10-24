using System.Xml;
using Pro.Common.Strings;
using ProPresenter.DO.Bibles.Formats.USX.Elements;

namespace ProPresenter.DO.Bibles.Formats.USX;

internal static class ElementProvider
{
	public static ElementBase? ParseElement(XmlNode node)
	{
		try
		{
			return node.NodeType switch
			{
				XmlNodeType.Text => (node.Value == null) ? null : new TextElement(node.Value), 
				XmlNodeType.Whitespace => (node.Value == null) ? null : new TextElement(LineBreaks.Replace(node.Value)), 
				XmlNodeType.Element => node.Name switch
				{
					"usx" => new USXElement(node), 
					"book" => new BookElement(node), 
					"chapter" => new ChapterElement(node), 
					"verse" => new VerseElement(node), 
					"para" => new ParagraphElement(node), 
					"table" => new TableElement(node), 
					"row" => new RowElement(node), 
					"cell" => new CellElement(node), 
					"char" => new CharacterElement(node), 
					"ms" => new MilestoneElement(node), 
					"note" => new NoteElement(node), 
					"sidebar" => new SidebarElement(node), 
					"periph" => new PeripheralElement(node), 
					"figure" => new FigureElement(node), 
					"optbreak" => new OptionalBreakElement(node), 
					"ref" => new ReferenceElement(node), 
					_ => null, 
				}, 
				_ => null, 
			};
		}
		catch
		{
			return null;
		}
	}
}
