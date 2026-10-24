using System.Windows.Documents;
using Markdig.Syntax.Inlines;

namespace Pro.UI.Controls.Markdown.Renderer;

internal class LiteralInlineRenderer : MarkdownObjectRenderer<LiteralInline>
{
	public override void Render(LiteralInline obj, InlineCollection inlines, IMarkdownRenderer renderer)
	{
		inlines.Add(obj.Content.ToString());
	}
}
