using System.Windows.Documents;
using Markdig.Syntax.Inlines;

namespace Pro.UI.Controls.Markdown.Renderer;

internal class EmphasisInlineRenderer : MarkdownObjectRenderer<EmphasisInline>
{
	public override void Render(EmphasisInline obj, InlineCollection inlines, IMarkdownRenderer renderer)
	{
		Span span;
		switch (obj.DelimiterChar)
		{
		default:
			return;
		case '*':
			span = new Bold();
			break;
		case '_':
			span = new Italic();
			break;
		}
		foreach (Markdig.Syntax.Inlines.Inline item in obj)
		{
			renderer.Render(item, span.Inlines);
		}
		inlines.Add(span);
	}
}
