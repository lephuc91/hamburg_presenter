using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using Flurl;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.HTTP;
using Pro.Localization;
using Pro.UI.Components;
using Pro.Web.Services;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.OutputConfiguration;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class ScreenConfigVM : LinkedNotifyPropertyChangedBase, IScreenConfigVM, INotifyPropertyChanged
{
	private bool _ignoreSelectionChanges;

	private readonly ICoreManager _manager;

	private readonly ssAPIOutput _outputController;

	private readonly IRemoveScreenOperation _removeScreenOperation;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IApiService _apiService;

	private ScreenArrangementBase? _selectedScreenArrangement;

	private ScreenArrangementBase? _selectedAudienceScreenArrangement;

	private ScreenArrangementBase? _selectedStageScreenArrangement;

	private IEnumerable<PhysicalDevice?>? _attachedPhysicalDevices;

	private readonly DispatcherTimer _showScreenIdentifyTimer = new DispatcherTimer
	{
		Interval = TimeSpan.FromSeconds(5.0)
	};

	private readonly RelayCommand<DeviceCommandParameter?> _assignDeviceCommand;

	private readonly RelayCommand _addCombinedScreenCommand;

	private readonly RelayCommand _addEdgeBlendScreenCommand;

	public IOutputConfiguration OutputConfiguration { get; }

	public AudienceScreenArrangementCollection AudienceArrangementScreens => OutputConfiguration.AudienceArrangementScreens;

	public StageScreenArrangementCollection StageArrangementScreens => OutputConfiguration.StageArrangementScreens;

	public IEnumerable<ScreenArrangementBase> Screens => AudienceArrangementScreens.Concat(StageArrangementScreens);

	public ScreenArrangementBase? SelectedScreenArrangement
	{
		get
		{
			return _selectedScreenArrangement;
		}
		set
		{
			if (!_ignoreSelectionChanges)
			{
				SetValue("SelectedScreenArrangement", ref _selectedScreenArrangement, value);
			}
		}
	}

	public ScreenArrangementBase? SelectedAudienceScreenArrangement
	{
		get
		{
			return _selectedAudienceScreenArrangement;
		}
		set
		{
			SetValue<ScreenArrangementBase>("SelectedAudienceScreenArrangement", ref _selectedAudienceScreenArrangement, value, delegate(ScreenArrangementBase o, ScreenArrangementBase n)
			{
				if (n != null)
				{
					SelectedStageScreenArrangement = null;
				}
				SelectedScreenArrangement = n;
			});
		}
	}

	public ScreenArrangementBase? SelectedStageScreenArrangement
	{
		get
		{
			return _selectedStageScreenArrangement;
		}
		set
		{
			SetValue<ScreenArrangementBase>("SelectedStageScreenArrangement", ref _selectedStageScreenArrangement, value, delegate(ScreenArrangementBase o, ScreenArrangementBase n)
			{
				if (n != null)
				{
					SelectedAudienceScreenArrangement = null;
				}
				SelectedScreenArrangement = n;
			});
		}
	}

	public bool IdentifyScreensActive
	{
		get
		{
			return _outputController.IdentifyScreens;
		}
		set
		{
			_outputController.IdentifyScreens = value;
		}
	}

	public bool AudienceEnable
	{
		get
		{
			return _manager.AudienceEnable;
		}
		set
		{
			if (value)
			{
				_manager.ShowAudienceScreens();
			}
			else
			{
				_manager.HideAudienceScreens();
			}
		}
	}

	public bool StageEnable
	{
		get
		{
			return _manager.StageEnable;
		}
		set
		{
			if (value)
			{
				_manager.ShowStageScreens();
			}
			else
			{
				_manager.HideStageScreens();
			}
		}
	}

	public IEnumerable<PhysicalDevice?>? AttachedPhysicalDevices
	{
		get
		{
			return _attachedPhysicalDevices;
		}
		private set
		{
			SetValue("AttachedPhysicalDevices", ref _attachedPhysicalDevices, value);
		}
	}

	public ICommand<ScreenArrangementBase> RemoveScreenArrangementCommand => new RelayCommand<ScreenArrangementBase>(OnRemoveScreenArrangement, (ScreenArrangementBase a) => a != null);

	public ICommand<ScreenArrangementType> ChangeArrangementTypeCommand => new RelayCommand<ScreenArrangementType>(OnChangeArrangementType, (ScreenArrangementType s) => SelectedScreenArrangement != null);

	public ICommand<DeviceCommandParameter?> AssignDeviceCommand => _assignDeviceCommand;

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(OutputConfiguration.UndoStack);
	});

	public ICommand<ScreenArrangementBase> ActivateScreenArrangementCommand => new RelayCommand<ScreenArrangementBase>(OnActivateScreenArrangement, (ScreenArrangementBase a) => a != null);

	public ICommand<PhysicalDevice> IdentifyScreenCommand => new RelayCommand<PhysicalDevice>(OnIdentifyScreenCommand, (PhysicalDevice d) => d != null);

	public ICommand ClearScreenIdentifyCommand => new RelayCommand(ClearAllOverlays, () => _showScreenIdentifyTimer.IsEnabled);

	public ICommand AddCombinedScreenCommand => _addCombinedScreenCommand;

	public ICommand AddEdgeBlendScreenCommand => _addEdgeBlendScreenCommand;

	public bool CanAddMoreScreens => OutputConfiguration.CanAddMoreScreens;

	public ICommand ShowHelpCommand => new RelayCommand(OnShowHelpCommandExecuted);

	public event Action<UndoStack?>? StackChanged;

	public ScreenConfigVM(ICoreManager manager, ssAPIOutput outputController, IRemoveScreenOperation removeScreenOperation, IOutputService outputService, IHyperlinkService hyperlinkService, IApiService apiService)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		_manager = manager;
		_outputController = outputController;
		_removeScreenOperation = removeScreenOperation;
		_hyperlinkService = hyperlinkService;
		_apiService = apiService;
		OutputConfiguration = outputService.OutputConfiguration;
		_addCombinedScreenCommand = new RelayCommand(OnAddCombinedScreenCommand, () => OutputConfiguration.CanAddMoreScreens);
		_addEdgeBlendScreenCommand = new RelayCommand(OnAddEdgeBlendScreenCommand, () => OutputConfiguration.CanAddMoreScreens);
		_assignDeviceCommand = new RelayCommand<DeviceCommandParameter>(OnAssignDevice, CanAssignDevice);
		_showScreenIdentifyTimer.Tick += ShowScreenIdentifyTimer_Tick;
		HookupLinkedProperties();
		SelectedAudienceScreenArrangement = AudienceArrangementScreens.FirstOrDefault();
		UpdateAttachedPhysicalDevices();
		PhysicalDevice.AttachedPhysicalDevices.CollectionChanged += AttachedPhysicalDevices_CollectionChanged;
	}

	private void HookupLinkedProperties()
	{
		LinkProperties("AudienceEnable", "AudienceEnable");
		LinkProperties("StageEnable", "StageEnable");
		LinkProperties("IdentifyScreens", "IdentifyScreensActive");
		LinkProperties("CanAddMoreScreens", "CanAddMoreScreens");
		LinkAction("CanAddMoreScreens", _addCombinedScreenCommand.NotifyCanExecuteChanged);
		LinkAction("CanAddMoreScreens", _addEdgeBlendScreenCommand.NotifyCanExecuteChanged);
		LinkAction("CanAddMoreScreens", _assignDeviceCommand.NotifyCanExecuteChanged);
		_manager.PropertyChanged += base.RaiseLinkedValues;
		_outputController.PropertyChanged += base.RaiseLinkedValues;
		AudienceArrangementScreens.CollectionChanged += OnAudienceScreensChanged;
		StageArrangementScreens.CollectionChanged += OnStageScreensChanged;
		OutputConfiguration.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnAudienceScreensChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		SelectedAudienceScreenArrangement = OnScreensChanged(sender, e, SelectedAudienceScreenArrangement, AudienceArrangementScreens);
	}

	private void OnStageScreensChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		SelectedStageScreenArrangement = OnScreensChanged(sender, e, SelectedStageScreenArrangement, StageArrangementScreens);
	}

	private ScreenArrangementBase? OnScreensChanged(object? sender, NotifyCollectionChangedEventArgs e, ScreenArrangementBase? currentSelected, ScreenArrangementCollectionBase fallbackCollection)
	{
		OnPropertyChanged("Screens");
		ScreenArrangementCollectionBase screenArrangementCollectionBase = sender as ScreenArrangementCollectionBase;
		if (e.NewItems == null || screenArrangementCollectionBase == null || currentSelected == null || !screenArrangementCollectionBase.Contains(currentSelected))
		{
			return currentSelected;
		}
		ScreenArrangementBase? screenArrangementBase = e.NewItems.Cast<ScreenArrangementBase>().FirstOrDefault();
		if (screenArrangementBase == null)
		{
			screenArrangementBase = screenArrangementCollectionBase.LastOrDefault();
			if (screenArrangementBase == null)
			{
				if (fallbackCollection == null)
				{
					return null;
				}
				screenArrangementBase = fallbackCollection.FirstOrDefault();
			}
		}
		return screenArrangementBase;
	}

	private void OnRemoveScreenArrangement(ScreenArrangementBase target)
	{
		if (_removeScreenOperation.Execute(target, GetArrangementCollection(target.ScreenTargetType), out ScreenArrangementBase newSelection) && target == SelectedScreenArrangement)
		{
			SelectedScreenArrangement = newSelection ?? AudienceArrangementScreens.FirstOrDefault();
		}
	}

	private void OnChangeArrangementType(ScreenArrangementType type)
	{
		_ignoreSelectionChanges = true;
		ScreenArrangementBase selectedScreenArrangement = GetArrangementCollection(SelectedScreenArrangement?.ScreenTargetType).ChangeScreenArrangementType(SelectedScreenArrangement, type);
		_ignoreSelectionChanges = false;
		SelectedScreenArrangement = selectedScreenArrangement;
	}

	private ScreenArrangementCollectionBase GetArrangementCollection(ScreenTargetType? targetType)
	{
		return targetType switch
		{
			ScreenTargetType.Audience => AudienceArrangementScreens, 
			ScreenTargetType.Stage => StageArrangementScreens, 
			_ => throw new NotSupportedException("Unknown arrangement type"), 
		};
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

	private void OnActivateScreenArrangement(ScreenArrangementBase arrangement)
	{
	}

	private void AttachedPhysicalDevices_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateAttachedPhysicalDevices();
	}

	private void UpdateAttachedPhysicalDevices()
	{
		AttachedPhysicalDevices = PhysicalDevice.AttachedPhysicalDevices.ToArray();
	}

	private void ShowScreenIdentifyTimer_Tick(object? sender, EventArgs e)
	{
		ClearAllOverlays();
	}

	private void ClearAllOverlays()
	{
		_manager.HideAllMonitorIdentificationOverlays();
		_showScreenIdentifyTimer.Stop();
	}

	private void OnIdentifyScreenCommand(PhysicalDevice physicalDevice)
	{
		_showScreenIdentifyTimer.Stop();
		_showScreenIdentifyTimer.Start();
		_manager.ShowMonitorIdentificationOverlay(physicalDevice);
	}

	private void OnAddCombinedScreenCommand()
	{
		AudienceArrangementScreens.AddScreenArrangement(new CombinedScreenArrangement(ScreenTargetType.Audience, null, null)
		{
			Name = LocalizedStrings.Get("SCREEN_CONFIGURATION_SCREEN_name")
		});
	}

	private void OnAddEdgeBlendScreenCommand()
	{
		AudienceArrangementScreens.AddScreenArrangement(new EdgeBlendScreenArrangement(ScreenTargetType.Audience, null, null)
		{
			Name = LocalizedStrings.Get("SCREEN_CONFIGURATION_SCREEN_name")
		});
	}

	private void OnShowHelpCommandExecuted()
	{
		_hyperlinkService.Open(new Uri(_apiService.GetTargetRedirectHost(includeProtocol: true).AppendPathSegments("pro", "resource", "screen_configuration")));
	}
}
