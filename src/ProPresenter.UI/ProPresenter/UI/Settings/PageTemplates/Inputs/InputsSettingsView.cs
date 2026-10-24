using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public partial class InputsSettingsView : UserControl, IComponentConnector
{
	private IInputsSettingsVM? _inputsSettingsVM;

	public InputsSettingsView()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(InputsSettingsView_IsVisibleChanged);
		base.Loaded += InputsSettingsView_Loaded;
		base.Unloaded += InputsSettingsView_Unloaded;
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(InputsSettingsView_DataContextChanged);
	}

	private void InputsSettingsView_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IInputsSettingsVM inputsSettingsVM)
		{
			_inputsSettingsVM = inputsSettingsVM;
		}
	}

	private void InputsSettingsView_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		VisibilityChanged();
	}

	private void VisibilityChanged()
	{
		if (base.IsVisible && _inputsSettingsVM != null)
		{
			_inputsSettingsVM.GotFocusCommand?.Invoke();
		}
	}

	private void InputsSettingsView_Loaded(object? sender, RoutedEventArgs e)
	{
		SetIsActive(isActive: true);
	}

	private void InputsSettingsView_Unloaded(object? sender, RoutedEventArgs e)
	{
		SetIsActive(isActive: false);
	}

	private void SetIsActive(bool isActive)
	{
		if (_inputsSettingsVM != null)
		{
			_inputsSettingsVM.IsActive = isActive;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
