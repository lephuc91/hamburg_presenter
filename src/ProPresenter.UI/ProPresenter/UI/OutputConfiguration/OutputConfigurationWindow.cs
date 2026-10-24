using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using Pro.UI.DependencyInjection;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class OutputConfigurationWindow : ChromedWindow, IComponentConnector
{
	private static readonly DependencyProperty SelectedScreenProperty = DependencyProperty.Register("SelectedScreen", typeof(Screen), typeof(OutputConfigurationWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedScreenPropertyChanged)));

	private static readonly DependencyProperty AlphaSettingsVMProperty = DependencyProperty.Register("AlphaSettingsVM", typeof(IAlphaKeySettingsVM), typeof(OutputConfigurationWindow));

	private readonly IAlphaKeySettingsVMFactory _alphaKeySettingsVMFactory;

	private Screen? SelectedScreen
	{
		get
		{
			return (Screen)((DependencyObject)this).GetValue(SelectedScreenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedScreenProperty, (object)value);
		}
	}

	private IAlphaKeySettingsVM? AlphaSettingsVM
	{
		get
		{
			return (IAlphaKeySettingsVM)((DependencyObject)this).GetValue(AlphaSettingsVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AlphaSettingsVMProperty, (object)value);
		}
	}

	private static void OnSelectedScreenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((OutputConfigurationWindow)(object)d).SelectedScreenPropertyChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as Screen);
	}

	public OutputConfigurationWindow()
	{
		_alphaKeySettingsVMFactory = UIServiceProvider.GetService<IAlphaKeySettingsVMFactory>();
		InitializeComponent();
		base.GotFocus += OutputConfigurationWindow_GotFocus;
	}

	private void OutputConfigurationWindow_GotFocus(object? sender, RoutedEventArgs e)
	{
		(base.DataContext as IScreenConfigVM)?.GotFocusCommand?.Invoke();
	}

	private void SelectedScreenPropertyChanged(Screen? screen)
	{
		AlphaSettingsVM = ((screen == null) ? null : _alphaKeySettingsVMFactory.Create(screen));
	}

	private void OutputConfigurationWindow_Closing(object sender, CancelEventArgs e)
	{
		bool flag = false;
		ScreenArrangementBase screenArrangementBase = (base.DataContext as IScreenConfigVM)?.SelectedScreenArrangement;
		if (screenArrangementBase != null)
		{
			Screen screen = Array.Find(screenArrangementBase.Screens, delegate(Screen x)
			{
				IDevice? mainOutputDevice = x.MainOutputDevice;
				if (mainOutputDevice == null || !mainOutputDevice.ValidationError.HasValue)
				{
					HardwareScreenRectangleOptions alphaOutput = x.AlphaOutput;
					if (alphaOutput == null)
					{
						return false;
					}
					return alphaOutput.OutputDevice?.ValidationError.HasValue ?? false;
				}
				return true;
			});
			if (screen != null)
			{
				(string, string)? tuple = screen.MainOutputDevice?.ValidationError ?? screen.AlphaOutput?.OutputDevice?.ValidationError;
				MessageDialogService.ShowAlert(tuple.Value.Item1, tuple.Value.Item2);
				flag = true;
			}
		}
		e.Cancel = true;
		if (!flag)
		{
			(sender as Window)?.Hide();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
