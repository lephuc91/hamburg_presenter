using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Settings;
using ProPresenter.UI.Macros;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.ViewModels.Macros;

public class MacroGroupCollectionVM : NotifyPropertyChangedBase, IMacroGroupCollectionVM, INotifyPropertyChanged
{
	private readonly DragDropPairedCollection<MacroGroup, IMacroGroupVM> _macroGroups;

	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly IApp _app;

	private IMacroGroupVM? _selectedMacroGroup;

	private bool _isCollectionPopupOpen;

	private PanelViewType _listOrGrid;

	private bool _renameNextItem;

	private MacroGroupCollection MacroGroupCollection { get; }

	public INotifyEnumerableChanged<IMacroGroupVM> MacroGroups => _macroGroups;

	public IMacroGroupVM? SelectedMacroGroup
	{
		get
		{
			return _selectedMacroGroup;
		}
		set
		{
			SetValue("SelectedMacroGroup", ref _selectedMacroGroup, value, (Action)delegate
			{
				if (_manager != null)
				{
					_manager.ActiveMacroGroup = SelectedMacroGroup?.MacroGroup;
				}
				if (_app != null)
				{
					_app.SelectedMacroGroupId = ((value != null) ? value.MacroGroup.ID : Guid.Empty);
				}
			}, (Predicate<IMacroGroupVM>?)null, referenceComparison: false);
		}
	}

	public bool IsCollectionPopupOpen
	{
		get
		{
			return _isCollectionPopupOpen;
		}
		set
		{
			SetValue("IsCollectionPopupOpen", ref _isCollectionPopupOpen, value);
		}
	}

	public PanelViewType ListOrGrid
	{
		get
		{
			return _listOrGrid;
		}
		set
		{
			SetValue("ListOrGrid", ref _listOrGrid, value, (Action)delegate
			{
				if (_app != null)
				{
					_app.MacroViewPanelType = value;
				}
			}, (Predicate<PanelViewType>?)null, referenceComparison: false);
		}
	}

	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			SetValue("RenameNextItem", ref _renameNextItem, value);
		}
	}

	public ICommand AddMacroGroupCommand => new RelayCommand(OnAddMacroGroup);

	public ICommand DeleteMacroGroupCommand => new RelayCommand(OnDeleteMacroGroup, () => SelectedMacroGroup != null);

	public ICommand DuplicateMacroGroupCommand => new RelayCommand(OnDuplicateMacroGroup, () => SelectedMacroGroup != null);

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(MacroGroupCollection.UndoStack);
	});

	public ICommand CloseCollectionPopupCommand => new RelayCommand(delegate
	{
		IsCollectionPopupOpen = false;
	});

	public event Action<UndoStack>? StackChanged;

	public event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	public event Action<FrameworkElement?>? UpdateDialogPlacement;

	public MacroGroupCollectionVM(ICoreManager manager, IProPresenterResourceService resourceService, IFileSelectorService fileSelectorService, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, IApp app, ITriggeringFactory triggeringFactory, IMacroPrompt macroPrompt, ICoreManager coreManager, IActionValidator validator, IEventCalendar calendar, IActionsMenuVMFactory actionsMenuVMFactory, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IUiDispatcher uiDispatcher)
	{
		MacroGroupCollectionVM macroGroupCollectionVM = this;
		_manager = manager;
		_app = app;
		MacroGroupCollection = resourceService.MacroGroups;
		MacroGroupCollection.TargetDirectoryChanged += SetDefaultSelectedGroup;
		_macroGroups = new DragDropPairedCollection<MacroGroup, IMacroGroupVM>(MacroGroupCollection, delegate(MacroGroup g)
		{
			MacroGroupVM macroGroupVM = new MacroGroupVM(g, macroGroupCollectionVM, manager, fileSelectorService, overlayVMFactory, app, triggeringFactory, macroPrompt, new CustomIconProvider(), validator, calendar, actionsMenuVMFactory, importProcessFactory, factoryProvider, transitionDescriptions, uiDispatcher);
			macroGroupVM.ShowActionDialog += macroGroupCollectionVM.GroupVM_ShowActionDialog;
			macroGroupVM.UpdateDialogPlacement += macroGroupCollectionVM.GroupVM_UpdateDialogPlacement;
			macroGroupVM.InvokeTriggerOnStartup += macroGroupCollectionVM.OnTriggerOnStartupCommand;
			return macroGroupVM;
		}, delegate(IMacroGroupVM vm)
		{
			vm.ShowActionDialog -= macroGroupCollectionVM.GroupVM_ShowActionDialog;
			vm.UpdateDialogPlacement -= macroGroupCollectionVM.GroupVM_UpdateDialogPlacement;
			vm.InvokeTriggerOnStartup -= macroGroupCollectionVM.OnTriggerOnStartupCommand;
		});
		_service = triggeringFactory.Create();
		manager.MacroTriggerCompleted += Manager_MacroTriggerStarted;
		manager.MacroTriggerCompleted += Manager_MacroTriggerCompleted;
		manager.PropertyChanged += Manager_PropertyChanged;
		_listOrGrid = _app.MacroViewPanelType;
		SetDefaultSelectedGroup();
		coreManager.SendMacroIcons(MacroIconHelper.GetIconSvgStringFromEnum);
	}

	private void SetDefaultSelectedGroup()
	{
		if (_app.SelectedMacroGroupId != Guid.Empty)
		{
			SelectedMacroGroup = MacroGroups.FirstOrDefault((IMacroGroupVM m) => m.MacroGroup.ID == _app.SelectedMacroGroupId);
		}
		if (SelectedMacroGroup == null)
		{
			IMacroGroupVM macroGroupVM2 = (SelectedMacroGroup = MacroGroups.FirstOrDefault());
		}
	}

	private void GroupVM_UpdateDialogPlacement(FrameworkElement? target)
	{
		this.UpdateDialogPlacement?.Invoke(target);
	}

	private void GroupVM_ShowActionDialog(FrameworkElement? target, IAction? action, IActionRepository? actionStore, IEnumerable<IActionRepository> otherActionStores)
	{
		this.ShowActionDialog?.Invoke(target, action, actionStore, otherActionStores);
	}

	private void Manager_MacroTriggerStarted(ProPresenterMacro macro)
	{
		IMacroItemVM macroItemVM = MacroGroups.SelectMany((IMacroGroupVM g) => g.SourceMacros).FirstOrDefault((IMacroItemVM m) => m.Macro.ID == macro.ID);
		if (macroItemVM != null)
		{
			macroItemVM.IsTriggering = true;
		}
	}

	private void Manager_MacroTriggerCompleted(ProPresenterMacro macro)
	{
		IMacroItemVM macroItemVM = MacroGroups.SelectMany((IMacroGroupVM g) => g.SourceMacros).FirstOrDefault((IMacroItemVM m) => m.Macro.ID == macro.ID);
		if (macroItemVM != null)
		{
			macroItemVM.IsTriggering = false;
		}
	}

	private void Manager_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveMacroGroup")
		{
			SelectedMacroGroup = MacroGroups.FirstOrDefault((IMacroGroupVM g) => g.MacroGroup == _manager.ActiveMacroGroup);
		}
	}

	private void OnAddMacroGroup()
	{
		RenameNextItem = true;
		MacroGroup newGroup = MacroGroupCollection.AddMacroGroup();
		SelectedMacroGroup = MacroGroups.FirstOrDefault((IMacroGroupVM g) => g.MacroGroup.Equals(newGroup));
	}

	private void OnDeleteMacroGroup()
	{
		SelectedMacroGroup.ThrowWhenNull("SelectedMacroGroup");
		MacroGroup macroGroup = SelectedMacroGroup.MacroGroup;
		int index = MacroGroupCollection.IndexOf(macroGroup);
		MacroGroupCollection.RemoveMacroGroup(macroGroup);
		if (!MacroGroupCollection.Any())
		{
			MacroGroupCollection.AddDefaultMacro();
		}
		SelectedMacroGroup = MacroGroups.ElementAtOrDefault(index) ?? MacroGroups.FirstOrDefault();
	}

	private void OnDuplicateMacroGroup()
	{
		SelectedMacroGroup.ThrowWhenNull("SelectedMacroGroup");
		MacroGroup macroGroup = SelectedMacroGroup.MacroGroup.Clone();
		int num = MacroGroupCollection.IndexOf(SelectedMacroGroup.MacroGroup);
		num = ((num < 0) ? MacroGroupCollection.Count() : num);
		MacroGroupCollection.InsertMacroGroup(macroGroup, num);
	}

	private void OnTriggerOnStartupCommand()
	{
		ProPresenterMacro proPresenterMacro = SelectedMacroGroup?.SelectedMacro?.Macro;
		bool flag = proPresenterMacro?.TriggerOnStartup ?? false;
		if (proPresenterMacro == null)
		{
			return;
		}
		if (flag)
		{
			flag = false;
		}
		else
		{
			ProPresenterMacro proPresenterMacro2 = MacroGroupCollection.SelectMany((MacroGroup g) => g).ToArray().FirstOrDefault((ProPresenterMacro m) => m.TriggerOnStartup);
			if (proPresenterMacro2 != null)
			{
				string message = LocalizedStrings.Get("MACROS_TRIGGER_ON_STARTUP_WARNING_message") + Environment.NewLine + Environment.NewLine + LocalizedStrings.Get("MACROS_TRIGGER_ON_STARTUP_WARNING_informative", new object[2] { proPresenterMacro2.Name, proPresenterMacro.Name });
				DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("UNDO_MACRO_TRIGGER_ON_STARTUP"), message, DefaultButtons.YES | DefaultButtons.NO, DefaultButtons.YES);
				if (!defaultButtons.HasValue || defaultButtons.Value != DefaultButtons.YES)
				{
					return;
				}
				flag = true;
			}
			else
			{
				flag = true;
			}
		}
		MacroGroupCollection.SetTriggerOnStartup(proPresenterMacro, flag);
	}

	public void TriggerStartupMacro()
	{
		ProPresenterMacro proPresenterMacro = MacroGroupCollection.SelectMany((MacroGroup g) => g).ToArray().FirstOrDefault((ProPresenterMacro m) => m.TriggerOnStartup);
		if (proPresenterMacro != null)
		{
			_service.TriggerMacro(proPresenterMacro);
			MacrosStartupEvent.Publish();
		}
	}
}
