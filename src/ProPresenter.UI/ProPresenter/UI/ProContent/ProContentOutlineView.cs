using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.UI.ProContent;

public partial class ProContentOutlineView : UserControl, IComponentConnector, IStyleConnector
{
	public ProContentOutlineView()
	{
		InitializeComponent();
	}

	private void SearchTextbox_KeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (e.Key.IsAnyOf((Key[])(object)new Key[2]
		{
			(Key)6,
			(Key)6
		}))
		{
			((sender as FrameworkElement)?.DataContext as IProContentSearchGroupVM)?.PerformSearchCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
