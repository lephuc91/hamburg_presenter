using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public class DeviceSelectorVM : NotifyPropertyChangedBase, IDeviceSelectorVM, INotifyPropertyChanged
{
	private readonly RelayCommand _addCombinedScreenCommand;

	private readonly RelayCommand _addEdgeBlendScreenCommand;

	private readonly RelayCommand<DeviceCommandParameter?> _assignDeviceCommand;

	private readonly ICoreManager _manager;

	private readonly IPhysicalDeviceProvider _physicalDeviceProvider;

	private ScreenArrangementBase? _selectedScreenArrangement;

	private readonly IPeriodicTimer _timer;

	public ScreenArrangementBase? SelectedScreenArrangement
	{
		get
		{
			return _selectedScreenArrangement;
		}
		set
		{
			SetValue("SelectedScreenArrangement", ref _selectedScreenArrangement, value);
		}
	}

	public IOutputConfiguration OutputConfiguration { get; }

	public INotifyEnumerableChanged<PhysicalDevice> AttachedPhysicalDevices => _physicalDeviceProvider.AttachedPhysicalDevices;

	public ICommand AddCombinedScreenCommand => _addCombinedScreenCommand;

	public ICommand AddEdgeBlendScreenCommand => _addEdgeBlendScreenCommand;

	public ICommand<DeviceCommandParameter?> AssignDeviceCommand => _assignDeviceCommand;

	public ICommand ClearScreenIdentifyCommand => new RelayCommand(ClearAllOverlays, () => _timer.IsRunning());

	public ICommand<PhysicalDevice> IdentifyScreenCommand => new RelayCommand<PhysicalDevice>(OnIdentifyScreenCommand, (PhysicalDevice d) => d != null);

	public DeviceSelectorVM(ICoreManager manager, IPhysicalDeviceProvider physicalDeviceProvider, ITimerFactory timerFactory)
	{
		_manager = manager;
		_physicalDeviceProvider = physicalDeviceProvider;
		OutputConfiguration = _manager.OutputConfiguration;
		_timer = timerFactory.CreatePeriodicDispatched(TimeSlice.FromSeconds(5.0), ClearAllOverlays);
		_addCombinedScreenCommand = new RelayCommand(AddCombinedScreenCommandExecuted, () => OutputConfiguration.CanAddMoreScreens);
		_addEdgeBlendScreenCommand = new RelayCommand(AddEdgeBlendScreenCommandExecuted, () => OutputConfiguration.CanAddMoreScreens);
		_assignDeviceCommand = new RelayCommand<DeviceCommandParameter>(OnAssignDevice, CanAssignDevice);
	}

	private void AddCombinedScreenCommandExecuted()
	{
		OutputConfiguration.AudienceArrangementScreens.AddScreenArrangement(new CombinedScreenArrangement(ScreenTargetType.Audience, null, null)
		{
			Name = LocalizedStrings.Get("SCREEN_CONFIGURATION_SCREEN_name")
		});
	}

	private void AddEdgeBlendScreenCommandExecuted()
	{
		OutputConfiguration.AudienceArrangementScreens.AddScreenArrangement(new EdgeBlendScreenArrangement(ScreenTargetType.Audience, null, null)
		{
			Name = LocalizedStrings.Get("SCREEN_CONFIGURATION_SCREEN_name")
		});
	}

	private bool CanAssignDevice(DeviceCommandParameter? parameter)
	{
		if (parameter != null && (!parameter.ScreenTargetType.HasValue || OutputConfiguration.CanAddMoreScreens))
		{
			return ScreenConfigHelper.CanAssignDevice(parameter.Device, parameter.Mode, parameter.TargetRectangle);
		}
		return false;
	}

	private void OnAssignDevice(DeviceCommandParameter? parameter)
	{
		ScreenConfigHelper.AssignDevice(OutputConfiguration.ArrangementScreens, Enumerable.Empty<DeviceBase>(), parameter.ScreenTargetType, parameter.TargetRectangle, parameter.Device, parameter.Mode, delegate
		{
			SelectedScreenArrangement = GetArrangementCollection(parameter.ScreenTargetType.Value).AddScreenArrangement(parameter.Device);
		});
	}

	private ScreenArrangementCollectionBase GetArrangementCollection(ScreenTargetType targetType)
	{
		return targetType switch
		{
			ScreenTargetType.Audience => OutputConfiguration.AudienceArrangementScreens, 
			ScreenTargetType.Stage => OutputConfiguration.StageArrangementScreens, 
			_ => throw new NotSupportedException("Unknown arrangement type"), 
		};
	}

	private void ClearAllOverlays()
	{
		_manager.HideAllMonitorIdentificationOverlays();
		_timer.Stop();
	}

	private void OnIdentifyScreenCommand(PhysicalDevice physicalDevice)
	{
		_timer.Stop();
		_timer.Start();
		_manager.ShowMonitorIdentificationOverlay(physicalDevice);
	}
}
