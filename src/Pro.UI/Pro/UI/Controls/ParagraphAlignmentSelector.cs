using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Text;

namespace Pro.UI.Controls;

public partial class ParagraphAlignmentSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedAlignmentProperty = DependencyProperty.Register("SelectedAlignment", typeof(ParagraphAlignment?), typeof(ParagraphAlignmentSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ParagraphAlignment.Center, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public ParagraphAlignment? SelectedAlignment
	{
		get
		{
			return (ParagraphAlignment?)((DependencyObject)this).GetValue(SelectedAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedAlignmentProperty, (object)value);
		}
	}

	public event Action<ParagraphAlignment?>? AlignmentChanged;

	public ParagraphAlignmentSelector()
	{
		InitializeComponent();
	}

	private void ParagraphAlignmentRadioButtonClick(object? sender, RoutedEventArgs e)
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
