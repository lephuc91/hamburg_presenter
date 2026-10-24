using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.Capture.Destination;

namespace ProPresenter.UI.Capture;

public partial class DiskCapture : UserControl, IComponentConnector
{
	public DiskCapture()
	{
		InitializeComponent();
		if (base.Resources["ResolutionMenu"] is ContextMenu contextMenu)
		{
			contextMenu.ItemContainerStyleSelector = new ResolutionMenuItemStyleSelector(base.Resources);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
