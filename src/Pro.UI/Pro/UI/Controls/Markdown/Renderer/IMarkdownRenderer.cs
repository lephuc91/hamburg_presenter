using System.Windows.Documents;
using Markdig.Syntax;

namespace Pro.UI.Controls.Markdown.Renderer;

internal interface IMarkdownRenderer
{
	void Render(MarkdownObject markdownObject, InlineCollection inlines);
}
