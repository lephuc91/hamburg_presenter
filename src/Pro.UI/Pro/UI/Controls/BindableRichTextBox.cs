using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Pro.UI.Controls;

public class BindableRichTextBox : RichTextBox
{
	public static readonly DependencyProperty BindableDocumentProperty = DependencyProperty.Register("BindableDocument", typeof(FlowDocument), typeof(BindableRichTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnBindableDocumentChanged)));

	public FlowDocument? BindableDocument
	{
		get
		{
			return (FlowDocument)((DependencyObject)this).GetValue(BindableDocumentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BindableDocumentProperty, (object)value);
		}
	}

	private static void OnBindableDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BindableRichTextBox)(object)d).SetDocument(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as FlowDocument);
	}

	public BindableRichTextBox()
	{
		base.TextChanged += delegate
		{
			((DependencyObject)this).SetCurrentValue(BindableDocumentProperty, (object)base.Document);
		};
	}

	private void SetDocument(FlowDocument? flowDocument)
	{
		if (base.Document != flowDocument)
		{
			base.Document = flowDocument;
		}
	}
}
