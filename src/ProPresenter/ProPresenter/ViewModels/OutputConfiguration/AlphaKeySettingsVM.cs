using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public class AlphaKeySettingsVM : ObservableObject, IAlphaKeySettingsVM, INotifyPropertyChanged
{
	private readonly string ALPHA_SETTINGS_HELP_PATH = "/pro/resource/help_alphakey";

	private readonly Screen _screen;

	private readonly IHardwareAlphaConfigurationVMFactory _hardwareAlphaConfigurationFactory;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IApiService _apiService;

	[ObservableProperty]
	private IHardwareAlphaConfigurationVM? _hardwareConfiguration;

	[ObservableProperty]
	private IReadOnlyCollection<ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode>? _availableModes;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showAlphaSettingsHelpCommand;

	public ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode Mode
	{
		get
		{
			return _screen.AlphaBlendMode.ToViewModelValue();
		}
		set
		{
			_screen.AlphaBlendMode = value.ToDataObjectValue();
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IHardwareAlphaConfigurationVM? HardwareConfiguration
	{
		get
		{
			return _hardwareConfiguration;
		}
		set
		{
			if (!EqualityComparer<IHardwareAlphaConfigurationVM>.Default.Equals(_hardwareConfiguration, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.HardwareConfiguration);
				_hardwareConfiguration = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.HardwareConfiguration);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyCollection<ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode>? AvailableModes
	{
		get
		{
			return _availableModes;
		}
		set
		{
			if (!EqualityComparer<IReadOnlyCollection<ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode>>.Default.Equals(_availableModes, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AvailableModes);
				_availableModes = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AvailableModes);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowAlphaSettingsHelpCommand => showAlphaSettingsHelpCommand ?? (showAlphaSettingsHelpCommand = new RelayCommand(ShowAlphaSettingsHelp));

	public AlphaKeySettingsVM(Screen screen, IHardwareAlphaConfigurationVMFactory hardwareAlphaConfigurationFactory, IHyperlinkService hyperlinkService, IApiService apiService)
	{
		_screen = screen;
		_hardwareAlphaConfigurationFactory = hardwareAlphaConfigurationFactory;
		_hyperlinkService = hyperlinkService;
		_apiService = apiService;
		AvailableModes = (IReadOnlyCollection<ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode>?)(object)Enum.GetValues<ProPresenter.UI.ViewModels.OutputConfiguration.AlphaBlendMode>();
		OnOutputDeviceChanged();
		_screen.PropertyChanged += ScreenChanged;
	}

	private void ScreenChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "MainOutputDevice"))
		{
			if (propertyName == "AlphaBlendMode")
			{
				OnPropertyChanged("Mode");
			}
		}
		else
		{
			OnOutputDeviceChanged();
		}
	}

	private void OnOutputDeviceChanged()
	{
		HardwareConfiguration = _hardwareAlphaConfigurationFactory.Create(_screen);
	}

	[RelayCommand]
	private void ShowAlphaSettingsHelp()
	{
		_hyperlinkService.Open(new Uri(_apiService.GetTargetRedirectHost(includeProtocol: true) + ALPHA_SETTINGS_HELP_PATH));
	}
}
