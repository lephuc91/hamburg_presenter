using System;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using Markdig.Syntax;
using Pro.Common.HTTP;

namespace Pro.UI.Controls.Markdown.Renderer;

internal abstract class InlineLinkRendererBase<TObject> : MarkdownObjectRenderer<TObject> where TObject : MarkdownObject
{
	private readonly IHyperlinkCommandProvider _commandProvider;

	private readonly IHyperlinkService _hyperlinkService;

	protected InlineLinkRendererBase(IHyperlinkCommandProvider commandProvider, IHyperlinkService hyperlinkService)
	{
		_commandProvider = commandProvider;
		_hyperlinkService = hyperlinkService;
	}

	protected InlineCollection AddHyperlink(string? destination, InlineCollection inlines)
	{
		Hyperlink hyperlink = new Hyperlink();
		ICommand command = _commandProvider?.Get(destination);
		Uri result;
		if (command != null)
		{
			hyperlink.Command = command;
		}
		else if (Uri.TryCreate(destination, UriKind.Absolute, out result))
		{
			hyperlink.NavigateUri = result;
			hyperlink.RequestNavigate += Hyperlink_RequestNavigate;
		}
		inlines.Add(hyperlink);
		return hyperlink.Inlines;
	}

	private void Hyperlink_RequestNavigate(object? sender, RequestNavigateEventArgs e)
	{
		_hyperlinkService.Open(e.Uri);
		e.Handled = true;
	}
}
