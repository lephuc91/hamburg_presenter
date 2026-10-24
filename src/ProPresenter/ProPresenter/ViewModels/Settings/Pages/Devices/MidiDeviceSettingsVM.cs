using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Localization.Services;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Devices;

public class MidiDeviceSettingsVM : LinkedNotifyPropertyChangedBase, IMidiDeviceSettingsVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly ICommunicationOutput _communicationOutput;

	private readonly ILocalization _localization;

	private IDevice? _targetDevice;

	private ISettingsItemVM? _parent;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? removeDeviceItemCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IDevice>? setTargetDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? helpCommand;

	public Guid ID { get; } = Guid.NewGuid();

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPageField> Fields { get; } = Enumerable.Empty<ISettingsSearchPageField>();

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public string Name { get; }

	public ISettingsItemVM? Parent => _parent;

	public DeviceCollection Devices => _communicationOutput.Devices;

	public IDevice? TargetDevice
	{
		get
		{
			return _targetDevice;
		}
		set
		{
			SetValue("TargetDevice", ref _targetDevice, value);
		}
	}

	public Brush? Background => null;

	public ImageSource? Icon => null;

	public bool IsNavigable => true;

	public bool CanExit => true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RemoveDeviceItemCommand => removeDeviceItemCommand ?? (removeDeviceItemCommand = new RelayCommand(RemoveDeviceItem, CanRemoveDeviceItem));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IDevice> SetTargetDeviceCommand => setTargetDeviceCommand ?? (setTargetDeviceCommand = new RelayCommand<IDevice>(SetTargetDevice));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HelpCommand => helpCommand ?? (helpCommand = new RelayCommand(Help));

	public MidiDeviceSettingsVM(ICommunicationOutput communicationOutput, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		_communicationOutput = communicationOutput;
		_localization = localization;
		Name = _localization.Get("SETTINGS_DEVICE_SETTINGS_PAGE_title");
		_communicationOutput.PropertyChanged += base.RaiseLinkedValues;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
	}

	public void SetParent(ISettingsItemVM parent)
	{
		_parent = parent;
	}

	[RelayCommand(CanExecute = "CanRemoveDeviceItem")]
	private void RemoveDeviceItem()
	{
		Devices.RemoveDevice(TargetDevice);
		TargetDevice = null;
	}

	private bool CanRemoveDeviceItem()
	{
		return TargetDevice != null;
	}

	[RelayCommand]
	private void SetTargetDevice(IDevice d)
	{
		TargetDevice = d;
	}

	[RelayCommand]
	private void Help()
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpMidi));
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
