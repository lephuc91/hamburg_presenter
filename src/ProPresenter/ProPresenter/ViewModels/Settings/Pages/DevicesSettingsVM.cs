using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components.Reversibility;
using Pro.Common.HTTP;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using Pro.UI.Themes;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Communication.Devices;
using ProPresenter.DO.Communication.MIDI;
using ProPresenter.DO.Settings.Communication;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class DevicesSettingsVM : ObservableObject, IDevicesSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("LastMIDINote", "LastNoteReceived")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("LastMIDIIntensity", "LastNoteReceived")]
	private readonly ICommunicationOutput _communicationOutput;

	private readonly ILocalization _localization;

	private readonly IMidiWindowProvider _midiWindowProvider;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	[ObservableProperty]
	private int _autoFillStart = Communications.Settings.AutoFillStart;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openMIDISettingsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IRelayCommand<ISettingsItemVM>>? addMIDIDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IDevice>? toggleDeviceConnectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? autoFillCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? autoFillBlocksCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<KeyValuePair<MIDIAction, int>>? assignNoteNumberCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? helpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IDevice>? deleteDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? gotFocusCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public bool IsActive => true;

	public ISettingsItemVM? Parent => null;

	public string Name { get; }

	[Pro.Common.SourceGenerator.Attributes.ActionLink("CanAddMIDIDevice", "UpdateCanAddMIDIDevice")]
	public DeviceCollection Devices => _communicationOutput.Devices;

	public IMIDIActionMap MIDIMappings => _communicationOutput.MIDIMappings;

	public IMidiDeviceSettingsVM MidiDeviceSettingsVM { get; }

	public string LastNoteReceived
	{
		get
		{
			if (!_communicationOutput.LastMIDINote.HasValue || !_communicationOutput.LastMIDIIntensity.HasValue)
			{
				return string.Empty;
			}
			return _localization.Get("SETTINGS_DEVICE_MIDI_MAP_LAST_NOTE_label", new object[2]
			{
				_communicationOutput.LastMIDINote.Value,
				_communicationOutput.LastMIDIIntensity.Value
			});
		}
	}

	public Brush? Background => SettingsListItemConstants.Blue;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsDevices);

	public bool IsNavigable => true;

	public bool CanExit => true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int AutoFillStart
	{
		get
		{
			return _autoFillStart;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_autoFillStart, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AutoFillStart);
				_autoFillStart = value;
				OnAutoFillStartChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AutoFillStart);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenMIDISettingsCommand => openMIDISettingsCommand ?? (openMIDISettingsCommand = new RelayCommand(OpenMIDISettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IRelayCommand<ISettingsItemVM>> AddMIDIDeviceCommand => addMIDIDeviceCommand ?? (addMIDIDeviceCommand = new RelayCommand<IRelayCommand<ISettingsItemVM>>(AddMIDIDevice, (IRelayCommand<ISettingsItemVM>? _) => CanAddMIDIDevice()));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IDevice> ToggleDeviceConnectionCommand => toggleDeviceConnectionCommand ?? (toggleDeviceConnectionCommand = new RelayCommand<IDevice>(ToggleDeviceConnection, CanConnectDisconnectDevice));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AutoFillCommand => autoFillCommand ?? (autoFillCommand = new RelayCommand(AutoFill));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AutoFillBlocksCommand => autoFillBlocksCommand ?? (autoFillBlocksCommand = new RelayCommand(AutoFillBlocks));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<KeyValuePair<MIDIAction, int>> AssignNoteNumberCommand => assignNoteNumberCommand ?? (assignNoteNumberCommand = new RelayCommand<KeyValuePair<MIDIAction, int>>(AssignNoteNumber));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HelpCommand => helpCommand ?? (helpCommand = new RelayCommand(Help));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IDevice> DeleteDeviceCommand => deleteDeviceCommand ?? (deleteDeviceCommand = new RelayCommand<IDevice>(DeleteDevice));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GotFocusCommand => gotFocusCommand ?? (gotFocusCommand = new RelayCommand(GotFocus));

	public event Action<UndoStack>? StackChanged;

	public DevicesSettingsVM(ICommunicationOutput communicationOutput, ILocalization localization, IMidiDeviceSettingsVM midiDeviceSettingsVM, IMidiWindowProvider midiWindowProvider, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		_communicationOutput = communicationOutput;
		_localization = localization;
		MidiDeviceSettingsVM = midiDeviceSettingsVM;
		_midiWindowProvider = midiWindowProvider;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		Name = _localization.Get("SETTINGS_DEVICES_PAGE_title");
		midiDeviceSettingsVM.SetParent(this);
		AddPropertyLinks();
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_DEVICES_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICE_SETTINGS_PAGE_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICE_SETTINGS_PAGE_DEVICE_NAME_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICE_SETTINGS_PAGE_DEVICE_AUTO_RECONNECT_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICES_HARDWARE_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICES_DEVICE_BEHAVIOR_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICE_SETTINGS_PAGE_DELETE_DEVICE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICE_SETTINGS_PAGE_DEVICE_SOURCES_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICE_SETTINGS_PAGE_DEVICE_DESTINATIONS_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICE_SETTINGS_PAGE_ART_NET_SPECIFICATIONS_SECTION_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICES_CONNECT_VIA_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICES_NETWORK_ADDRESS_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICES_NETWORK_PORT_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_DEVICES_MIDI_MAP_BUTTON_title", this, isComponent: true));
	}

	[RelayCommand]
	private void OpenMIDISettings()
	{
		_midiWindowProvider.ToggleWindowVisibility(this);
	}

	[RelayCommand(CanExecute = "CanAddMIDIDevice")]
	private void AddMIDIDevice(IRelayCommand<ISettingsItemVM> navigate)
	{
		MIDIDevice parameter = Devices.AddMIDIDevice();
		MidiDeviceSettingsVM.SetTargetDeviceCommand.Execute(parameter);
		navigate.Execute(MidiDeviceSettingsVM);
	}

	private bool CanAddMIDIDevice()
	{
		return Devices.CanAddMIDIDevice;
	}

	private void UpdateCanAddMIDIDevice()
	{
		AddMIDIDeviceCommand.NotifyCanExecuteChanged();
	}

	[RelayCommand(CanExecute = "CanConnectDisconnectDevice")]
	private void ToggleDeviceConnection(IDevice d)
	{
		if (d.IsConnected)
		{
			d.Disconnect();
		}
		else
		{
			d.Connect();
		}
	}

	private bool CanConnectDisconnectDevice(IDevice d)
	{
		return d != null;
	}

	[RelayCommand]
	private void AutoFill()
	{
		_communicationOutput.MIDIMappings.AutoFill(AutoFillStart);
	}

	[RelayCommand]
	private void AutoFillBlocks()
	{
		_communicationOutput.MIDIMappings.AutoFillBlocks();
	}

	[RelayCommand]
	public void AssignNoteNumber(KeyValuePair<MIDIAction, int> noteNumber)
	{
		MIDIMappings.AssignNumberToMIDIAction(noteNumber.Key, noteNumber.Value);
	}

	[RelayCommand]
	public void Help()
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpCommunicationDevices));
	}

	[RelayCommand]
	private void DeleteDevice(IDevice device)
	{
		Devices.RemoveDevice(device);
	}

	[RelayCommand]
	private void GotFocus()
	{
		this.StackChanged?.Invoke(_communicationOutput.Devices.UndoStack);
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnAutoFillStartChanged(int value)
	{
		Communications.Settings.AutoFillStart = value;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _communicationOutput_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "LastMIDINote"))
		{
			if (propertyName == "LastMIDIIntensity")
			{
				OnPropertyChanged("LastNoteReceived");
			}
		}
		else
		{
			OnPropertyChanged("LastNoteReceived");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Devices_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "CanAddMIDIDevice")
		{
			UpdateCanAddMIDIDevice();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_communicationOutput.PropertyChanged += _communicationOutput_PropertyChanged;
		Devices.PropertyChanged += Devices_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_communicationOutput.PropertyChanged -= _communicationOutput_PropertyChanged;
		Devices.PropertyChanged -= Devices_PropertyChanged;
	}
}
