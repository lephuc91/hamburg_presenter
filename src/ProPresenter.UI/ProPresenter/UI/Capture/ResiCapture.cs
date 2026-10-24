using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using Pro.Common.Utility;

namespace ProPresenter.UI.Capture;

public partial class ResiCapture : UserControl, IComponentConnector
{
	public ResiCapture()
	{
		InitializeComponent();
	}

	private void OnNavigate(object? sender, RequestNavigateEventArgs e)
	{
		ProcessHelper.StartProcess(e.Uri.AbsoluteUri);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
