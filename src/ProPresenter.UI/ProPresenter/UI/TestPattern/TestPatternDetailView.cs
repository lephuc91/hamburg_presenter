using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.TestPattern;

public partial class TestPatternDetailView : UserControl, IComponentConnector
{
	public TestPatternDetailView()
	{
		InitializeComponent();
	}

	private void Details_RequestBringIntoView(object? sender, RequestBringIntoViewEventArgs e)
	{
		e.Handled = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
