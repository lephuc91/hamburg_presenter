using System.Windows.Documents;
using Markdig.Syntax.Inlines;
using Pro.Common.HTTP;

namespace Pro.UI.Controls.Markdown.Renderer;

internal class AutolinkInlineRenderer : InlineLinkRendererBase<AutolinkInline>
{
	public AutolinkInlineRenderer(IHyperlinkCommandProvider commandProvider, IHyperlinkService hyperlinkService)
		: base(commandProvider, hyperlinkService)
	{
	}

	public override void Render(AutolinkInline obj, InlineCollection inlines, IMarkdownRenderer renderer)
	{
		AddHyperlink(obj.Url, inlines).Add(obj.Url);
	}
}
