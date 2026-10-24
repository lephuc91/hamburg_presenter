using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;

namespace ProPresenter.UI.Settings;

public partial class SettingsWindow : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty HideOnCloseProperty = DependencyProperty.Register("HideOnClose", typeof(bool), typeof(SettingsWindow), new PropertyMetadata((object)true));

	public bool HideOnClose
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideOnCloseProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideOnCloseProperty, (object)value);
		}
	}

	public SettingsWindow()
	{
		InitializeComponent();
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		if (base.DataContext is ISettingsVM { ActiveItem: INavigationItem { CanExit: false } activeItem })
		{
			activeItem.PromptUnableToExit();
			e.Cancel = true;
		}
		else
		{
			base.OnClosing(e);
		}
	}

	private void VisibilityChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.DataContext is ISettingsVM settingsVM)
		{
			settingsVM.ToggleInputStatus(base.IsVisible);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
