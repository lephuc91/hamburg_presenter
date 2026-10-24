using System.Windows.Documents;
using Markdig.Syntax;

namespace Pro.UI.Controls.Markdown.Renderer;

internal interface IMarkdownObjectRenderer
{
	void Render(MarkdownObject obj, InlineCollection inlines, IMarkdownRenderer renderer);

	bool CanRender(MarkdownObject obj);
}
