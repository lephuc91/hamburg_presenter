using System.Windows.Documents;
using Markdig.Syntax;

namespace Pro.UI.Controls.Markdown.Renderer;

internal class MarkdownDocumentRenderer : MarkdownObjectRenderer<MarkdownDocument>
{
	public override void Render(MarkdownDocument obj, InlineCollection inlines, IMarkdownRenderer renderer)
	{
		foreach (Markdig.Syntax.Block item in obj)
		{
			renderer.Render(item, inlines);
		}
	}
}
