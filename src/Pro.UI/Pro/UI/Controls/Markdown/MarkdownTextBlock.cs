using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Markdig.Parsers;
using Markdig.Syntax;
using Pro.Common.HTTP;
using Pro.UI.Controls.Markdown.Renderer;
using Pro.UI.DependencyInjection;

namespace Pro.UI.Controls.Markdown;

public partial class MarkdownTextBlock : UserControl, IComponentConnector
{
	private IHyperlinkService _hyperlinkService;

	public static readonly DependencyProperty MarkdownProperty = DependencyProperty.Register("Markdown", typeof(string), typeof(MarkdownTextBlock), new PropertyMetadata(new PropertyChangedCallback(RegenerateContent_DependencyCallback))
	{
		DefaultValue = string.Empty
	});

	public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(MarkdownTextBlock));

	public static readonly DependencyProperty TextTrimmingProperty = DependencyProperty.Register("TextTrimming", typeof(TextTrimming), typeof(MarkdownTextBlock));

	public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(MarkdownTextBlock));

	public static readonly DependencyProperty LinkTextForegroundProperty = DependencyProperty.Register("LinkTextForeground", typeof(SolidColorBrush), typeof(MarkdownTextBlock));

	public static readonly DependencyProperty HyperlinkCommandsProviderProperty = DependencyProperty.Register("HyperlinkCommandsProvider", typeof(IHyperlinkCommandProvider), typeof(MarkdownTextBlock), new PropertyMetadata(new PropertyChangedCallback(RegenerateContent_DependencyCallback)));

	public string Markdown
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MarkdownProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkdownProperty, (object)value);
		}
	}

	public TextAlignment TextAlignment
	{
		get
		{
			return (TextAlignment)((DependencyObject)this).GetValue(TextAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextAlignmentProperty, (object)value);
		}
	}

	public TextTrimming TextTrimming
	{
		get
		{
			return (TextTrimming)((DependencyObject)this).GetValue(TextTrimmingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextTrimmingProperty, (object)value);
		}
	}

	public TextWrapping TextWrapping
	{
		get
		{
			return (TextWrapping)((DependencyObject)this).GetValue(TextWrappingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextWrappingProperty, (object)value);
		}
	}

	public SolidColorBrush LinkTextForeground
	{
		get
		{
			return (SolidColorBrush)((DependencyObject)this).GetValue(LinkTextForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkTextForegroundProperty, (object)value);
		}
	}

	public IHyperlinkCommandProvider HyperlinkCommandsProvider
	{
		get
		{
			return (IHyperlinkCommandProvider)((DependencyObject)this).GetValue(HyperlinkCommandsProviderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HyperlinkCommandsProviderProperty, (object)value);
		}
	}

	private static void RegenerateContent_DependencyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is MarkdownTextBlock markdownTextBlock)
		{
			markdownTextBlock.RegenerateTextBoxContent();
		}
	}

	public MarkdownTextBlock()
	{
		_hyperlinkService = UIServiceProvider.GetService<IHyperlinkService>();
		InitializeComponent();
	}

	private void RegenerateTextBoxContent()
	{
		text.Inlines.Clear();
		if (!string.IsNullOrEmpty(Markdown))
		{
			MarkdownDocument markdownObject = MarkdownParser.Parse(Markdown);
			new TextInlinesRenderer(HyperlinkCommandsProvider, _hyperlinkService).Render(markdownObject, text.Inlines);
		}
	}
}
