using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.KeyMapping;

namespace ProPresenter.UI.KeyMapping;

public partial class InputActionGroupTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty KeyMappingVMProperty = DependencyProperty.Register("KeyMappingVM", typeof(IKeyMappingVM), typeof(InputActionGroupTemplate));

	public IKeyMappingVM? KeyMappingVM
	{
		get
		{
			return (IKeyMappingVM)((DependencyObject)this).GetValue(KeyMappingVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KeyMappingVMProperty, (object)value);
		}
	}

	public InputActionGroupTemplate()
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
