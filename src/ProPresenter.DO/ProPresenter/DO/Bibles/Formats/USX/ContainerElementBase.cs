using System.Linq;
using System.Xml;
using Pro.Common.Collections;

namespace ProPresenter.DO.Bibles.Formats.USX;

internal abstract class ContainerElementBase : ElementBase
{
	public ElementBase[] Children { get; }

	public ContainerElementBase(XmlNode node)
	{
		Children = (from e in node.ChildNodes.Cast<XmlNode>().Select(ElementProvider.ParseElement)
			where e != null
			select e).NonNull().ToArray();
	}
}
