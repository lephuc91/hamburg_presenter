using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;

namespace ProPresenter.UI.Settings.PageTemplates.Devices;

public partial class DevicesSettingsView : UserControl, IComponentConnector
{
	public DevicesSettingsView()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(DevicesSettingsView_IsVisibleChanged);
	}

	private void DevicesSettingsView_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.IsVisible && base.DataContext is IDevicesSettingsVM devicesSettingsVM)
		{
			devicesSettingsVM.GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
