using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.ssAPI.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages;

namespace ProPresenter.UI.Settings.PageTemplates.Audio;

public partial class AudioSettingsView : UserControl, IComponentConnector
{
	public AudioSettingsView()
	{
		InitializeComponent();
	}

	private void OnFilterOtherAudioDevice(object? sender, FilterEventArgs e)
	{
		e.Accepted = e.Item is IAudioDevice audioDevice && !audioDevice.DeviceType.IsAnyOf(AudioDeviceType.ASIO, AudioDeviceType.WaveOut);
	}

	private void ContextMenu_OnClosed(object? sender, RoutedEventArgs e)
	{
		if (base.DataContext is IAudioSettingsVM audioSettingsVM)
		{
			audioSettingsVM.ClearAllTestTones.Execute(null);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
