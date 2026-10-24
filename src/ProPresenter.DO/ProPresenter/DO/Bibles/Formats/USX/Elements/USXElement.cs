using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class USXElement : ContainerElementBase
{
	public override ElementType Type => ElementType.USX;

	public float Version { get; }

	public USXElement(XmlNode node)
		: base(node)
	{
		Version = node.GetFloatAttribute("version", 1f);
	}
}
