using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs.Audio;

public partial class AudioInputsView : UserControl, IComponentConnector
{
	public AudioInputsView()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		InitializeComponent();
		base.GotFocus += AudioInputsView_GotFocus;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(AudioInputsView_IsVisibleChanged);
	}

	private void AudioInputsView_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		OnGotFocus();
	}

	private void AudioInputsView_GotFocus(object? sender, RoutedEventArgs e)
	{
		OnGotFocus();
	}

	private void OnGotFocus()
	{
		if (base.IsVisible && base.DataContext is IAudioInputsSettingsVM audioInputsSettingsVM)
		{
			audioInputsSettingsVM.GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
