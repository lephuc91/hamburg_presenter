using System.Windows.Documents;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Pro.UI.Controls.Markdown.Renderer;

internal class ParagraphRenderer : MarkdownObjectRenderer<ParagraphBlock>
{
	public override void Render(ParagraphBlock obj, InlineCollection inlines, IMarkdownRenderer renderer)
	{
		if (obj.Inline == null)
		{
			return;
		}
		foreach (Markdig.Syntax.Inlines.Inline item in obj.Inline)
		{
			renderer.Render(item, inlines);
		}
	}
}
