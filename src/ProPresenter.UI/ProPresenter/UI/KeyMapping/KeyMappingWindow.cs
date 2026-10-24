using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.KeyMapping;

public partial class KeyMappingWindow : ChromedWindow, IComponentConnector
{
	public KeyMappingWindow()
	{
		InitializeComponent();
	}

	private void FilterType_Unchecked(object? sender, RoutedEventArgs e)
	{
		if (sender is ToggleButton toggleButton)
		{
			toggleButton.GetBindingExpression(ToggleButton.IsCheckedProperty).UpdateTarget();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
