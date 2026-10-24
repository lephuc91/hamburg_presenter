using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Print;

public partial class PrintPreview : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty PrintableDocumentProperty = DependencyProperty.Register("PrintableDocument", typeof(IDocumentPaginatorSource), typeof(PrintPreview));

	public IDocumentPaginatorSource PrintableDocument
	{
		get
		{
			return (IDocumentPaginatorSource)((DependencyObject)this).GetValue(PrintableDocumentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrintableDocumentProperty, (object)value);
		}
	}

	public PrintPreview()
	{
		InitializeComponent();
	}

	private void DocumentViewer_Loaded(object? sender, RoutedEventArgs e)
	{
		(sender as DocumentViewer)?.FitToWidth();
	}
}
