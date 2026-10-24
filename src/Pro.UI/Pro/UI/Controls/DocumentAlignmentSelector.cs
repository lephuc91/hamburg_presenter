using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Text;

namespace Pro.UI.Controls;

public partial class DocumentAlignmentSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedAlignmentProperty = DependencyProperty.Register("SelectedAlignment", typeof(DocumentAlignment?), typeof(DocumentAlignmentSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DocumentAlignment.Middle, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public DocumentAlignment? SelectedAlignment
	{
		get
		{
			return (DocumentAlignment?)((DependencyObject)this).GetValue(SelectedAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedAlignmentProperty, (object)value);
		}
	}

	public event Action<DocumentAlignment?>? AlignmentChanged;

	public DocumentAlignmentSelector()
	{
		InitializeComponent();
	}

	private void DocumentAlignmentRadioButtonClick(object? sender, RoutedEventArgs e)
	{
		this.AlignmentChanged?.Invoke(SelectedAlignment);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
