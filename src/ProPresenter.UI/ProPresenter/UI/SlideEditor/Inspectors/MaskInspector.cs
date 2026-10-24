using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class MaskInspector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedItemNameProperty = DependencyProperty.Register("SelectedItemName", typeof(string), typeof(MaskInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public string? SelectedItemName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedItemNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemNameProperty, (object)value);
		}
	}

	public MaskInspector()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
