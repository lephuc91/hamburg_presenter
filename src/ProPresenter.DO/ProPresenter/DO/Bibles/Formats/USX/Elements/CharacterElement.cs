using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class CharacterElement : ContainerElementBase
{
	public override ElementType Type => ElementType.Character;

	public CharacterStyle Style { get; }

	public CharacterElement(XmlNode node)
		: base(node)
	{
		Style = CharacterStyleProvider.ParseStyle(node.GetAttribute("style"));
	}
}
