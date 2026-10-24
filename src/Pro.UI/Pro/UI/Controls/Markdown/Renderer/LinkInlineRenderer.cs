using System.Windows.Documents;
using Markdig.Syntax.Inlines;
using Pro.Common.HTTP;

namespace Pro.UI.Controls.Markdown.Renderer;

internal class LinkInlineRenderer : InlineLinkRendererBase<LinkInline>
{
	public LinkInlineRenderer(IHyperlinkCommandProvider commandProvider, IHyperlinkService hyperlinkService)
		: base(commandProvider, hyperlinkService)
	{
	}

	public override void Render(LinkInline obj, InlineCollection inlines, IMarkdownRenderer renderer)
	{
		InlineCollection inlines2 = AddHyperlink(obj.Url, inlines);
		foreach (Markdig.Syntax.Inlines.Inline item in obj)
		{
			renderer.Render(item, inlines2);
		}
	}
}
