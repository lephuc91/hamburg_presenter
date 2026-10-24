using System;
using System.Windows.Documents;
using Markdig.Syntax;
using Pro.Common.HTTP;

namespace Pro.UI.Controls.Markdown.Renderer;

internal class TextInlinesRenderer : IMarkdownRenderer
{
	private readonly IMarkdownObjectRenderer[] _renderers;

	public TextInlinesRenderer(IHyperlinkCommandProvider commandProvider, IHyperlinkService hyperlinkService)
	{
		_renderers = new IMarkdownObjectRenderer[6]
		{
			new LiteralInlineRenderer(),
			new EmphasisInlineRenderer(),
			new LinkInlineRenderer(commandProvider, hyperlinkService),
			new AutolinkInlineRenderer(commandProvider, hyperlinkService),
			new ParagraphRenderer(),
			new MarkdownDocumentRenderer()
		};
	}

	public void Render(MarkdownObject markdownObject, InlineCollection inlines)
	{
		Array.Find(_renderers, (IMarkdownObjectRenderer r) => r.CanRender(markdownObject))?.Render(markdownObject, inlines, this);
	}
}
