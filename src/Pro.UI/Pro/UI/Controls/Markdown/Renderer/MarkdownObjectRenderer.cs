using System.Windows.Documents;
using Markdig.Syntax;

namespace Pro.UI.Controls.Markdown.Renderer;

internal abstract class MarkdownObjectRenderer<TObject> : IMarkdownObjectRenderer where TObject : MarkdownObject
{
	public bool CanRender(MarkdownObject obj)
	{
		return obj is TObject;
	}

	public abstract void Render(TObject obj, InlineCollection inlines, IMarkdownRenderer renderer);

	public void Render(MarkdownObject obj, InlineCollection inlines, IMarkdownRenderer renderer)
	{
		if (obj is TObject obj2)
		{
			Render(obj2, inlines, renderer);
		}
	}
}
