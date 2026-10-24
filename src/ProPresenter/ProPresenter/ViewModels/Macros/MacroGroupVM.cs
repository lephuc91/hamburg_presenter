using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.DO;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.UI;
using ProPresenter.UI.Macros;
using ProPresenter.UI.Utility;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.ViewModels.Actions;
using ProPresenter.ViewModels.ActionsMenu;
using ProPresenter.ViewModels.Props;

namespace ProPresenter.ViewModels.Macros;

public class MacroGroupVM : LinkedNotifyPropertyChangedBase, IMacroGroupVM, IAddActionInteractor
{
	private sealed class MacroItemVMDragDropPairedCollection : DragDropPairedCollection<ProPresenterMacro, IMacroItemVM>
	{
		private readonly IMacroGroupVM _macroGroupVM;

		public MacroItemVMDragDropPairedCollection(MacroGroupVM macroGroupVM, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, IActionValidator validator, IEventCalendar calendar)
			: base((IDragDropNotifyEnumerableChanged<ProPresenterMacro>?)macroGroupVM.MacroGroup, (PairedCollection<IDragDropNotifyEnumerableChanged<ProPresenterMacro>, ProPresenterMacro, IMacroItemVM>.GenerateTargetDelegate)((ProPresenterMacro m) => new MacroItemVM(m, macroGroupVM, overlayVMFactory, validator, calendar)), (PairedCollection<IDragDropNotifyEnumerableChanged<ProPresenterMacro>, ProPresenterMacro, IMacroItemVM>.TeardownTargetDelegate?)null, (DragDropPairedCollection<ProPresenterMacro, IMacroItemVM>.UnwrapTargetDelegate?)null)
		{
			_macroGroupVM = macroGroupVM;
		}

		public override void DroppedInto(IEnumerable<IMacroItemVM> items, int index, bool isCopy)
		{
			if (!items.Any())
			{
				return;
			}
			IMacroGroupVM parent = items.First().Parent;
			if (_macroGroupVM != parent)
			{
				parent?.MacroGroup.RemoveMacros(items.Select((IMacroItemVM m) => m.Macro));
				_macroGroupVM.MacroGroup.InsertMacros(items.Select((IMacroItemVM m) => m.Macro), index);
			}
			else
			{
				base.DroppedInto(items, index, isCopy);
			}
		}
	}

	private readonly DragDropPairedCollection<ProPresenterMacro, IMacroItemVM> _sourceMacros;

	private readonly FilteredObservableCollection<IMacroItemVM> _filteredMacros;

	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly IMacroPrompt _prompt;

	private IMacroItemVM? _activeItem;

	private IMacroItemVM? _selectedItem;

	private string _filterText = string.Empty;

	private bool _renameNextItem;

	private readonly ActionDropOperation _dropOperation;

	private readonly IFileSelectorService _fileSelectorService;

	private readonly ICustomIconProvider _customIconProvider;

	public IMacroGroupCollectionVM Parent { get; }

	public MacroGroup MacroGroup { get; }

	public string Name
	{
		get
		{
			return MacroGroup.Name;
		}
		set
		{
			if (MacroGroup.Name != value)
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					_prompt.AlertEmptyGroupName();
				}
				else
				{
					MacroGroup.Name = value;
				}
				OnPropertyChanged("Name");
			}
		}
	}

	public FrameworkElement? ContextMenuTarget { get; set; }

	public IActionsMenuVM ActionsMenuVM { get; }

	public IDragDropNotifyEnumerableChanged<IMacroItemVM> SourceMacros => _sourceMacros;

	public INotifyEnumerableChanged<IMacroItemVM> FilteredMacros => _filteredMacros;

	public IMacroItemVM? ActiveMacro
	{
		get
		{
			return _activeItem;
		}
		set
		{
			SetValue("ActiveMacro", ref _activeItem, value);
		}
	}

	public IMacroItemVM? SelectedMacro
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			SetValue<IMacroItemVM>("SelectedMacro", ref _selectedItem, value, delegate(IMacroItemVM o, IMacroItemVM n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				ActionsMenuVM.SelectedItem = n?.Macro;
				OnPropertyChanged("TriggerOnStartup");
				OnPropertyChanged("MacroColor");
			});
		}
	}

	public ObservableCollection<IMacroItemVM> SelectedMacros { get; } = new ObservableCollection<IMacroItemVM>();

	public string FilterText
	{
		get
		{
			return _filterText;
		}
		set
		{
			SetValue("FilterText", ref _filterText, value, _filteredMacros.Refresh);
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

	public Color MacroColor
	{
		get
		{
			return SelectedMacro?.Color ?? Colors.Transparent;
		}
		set
		{
			SelectedMacros.ForEach(delegate(IMacroItemVM m)
			{
				m.Color = value;
			});
			OnPropertyChanged("MacroColor");
		}
	}

	public bool TriggerOnStartup => SelectedMacro?.TriggerOnStartup ?? false;

	public ICommand AddMacroCommand => new RelayCommand(OnAddMacroCommand);

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => SelectedMacros.Any());

	public ICommand CutCommand => new RelayCommand(OnCutCommand, () => SelectedMacros.Any());

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, () => ClipboardManagerHelper.CanPasteIntoCollection<IMacro>());

	public ICommand DuplicateCommand => new RelayCommand(OnDuplicateMacroCommand, () => SelectedMacros.Any());

	public ICommand DeleteCommand => new RelayCommand(OnDeleteMacroCommand, () => SelectedMacros.Any());

	public ICommand<IMacroItemVM> TriggerMacroCommand => new RelayCommand<IMacroItemVM>(OnTriggerMacroCommand, (IMacroItemVM m) => m != null);

	public ICommand<MacroDropParameter> DropActionCommand => new RelayCommand<MacroDropParameter>(OnDropActionCommand);

	public ICommand<FrameworkElement> UpdateDialogPlacementCommand => new RelayCommand<FrameworkElement>(OnUpdateDialogPlacementCommand);

	public ICommand TriggerOnStartupCommand => new RelayCommand(delegate
	{
		this.InvokeTriggerOnStartup?.Invoke();
	});

	public ICommand ChangeIconCommand => new RelayCommand(OnChangeIconCommand);

	public ICommand<ImageType> SelectIconCommand => new RelayCommand<ImageType>(OnSelectIconCommand);

	public ICommand MoveMacroGroupCommand => new RelayCommand(OnMoveMacroGroupCommand);

	public ICommand AddMacroToGroupCommand => new RelayCommand(OnAddMacroToGroupCommand);

	public ICommand<IEnumerable<IMacroItemVM>> RemoveMacrosCommand => new RelayCommand<IEnumerable<IMacroItemVM>>(delegate(IEnumerable<IMacroItemVM> v)
	{
		MacroGroup.RemoveMacros(v.Select((IMacroItemVM m) => m.Macro));
	});

	public ICommand<IEnumerable<IMacroItemVM>> AddMacrosCommand => new RelayCommand<IEnumerable<IMacroItemVM>>(delegate(IEnumerable<IMacroItemVM> v)
	{
		MacroGroup.InsertMacros(v.Select((IMacroItemVM m) => m.Macro), MacroGroup.Count);
	});

	public event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	public event Action<FrameworkElement?>? UpdateDialogPlacement;

	public event Action? InvokeTriggerOnStartup;

	public event Action<IMacroItemVM>? NewMacroAdded;

	public MacroGroupVM(MacroGroup macroGroup, IMacroGroupCollectionVM parent, ICoreManager manager, IFileSelectorService fileSelectorService, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, IApp app, ITriggeringFactory triggeringFactory, IMacroPrompt prompt, ICustomIconProvider customIconProvider, IActionValidator validator, IEventCalendar calendar, IActionsMenuVMFactory actionsMenuVMFactory, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IUiDispatcher uiDispatcher)
	{
		MacroGroup = macroGroup;
		Parent = parent;
		_sourceMacros = new MacroItemVMDragDropPairedCollection(this, overlayVMFactory, validator, calendar);
		_sourceMacros.CollectionChanged += delegate
		{
			OnPropertyChanged("SourceMacros");
		};
		_fileSelectorService = fileSelectorService;
		_customIconProvider = customIconProvider;
		_filteredMacros = new UpdatingFilteredObservableCollection<IMacroItemVM>(_sourceMacros, (IMacroItemVM m) => string.IsNullOrEmpty(FilterText) || m.Name.ToLowerInvariant().Contains(FilterText.ToLowerInvariant()), uiDispatcher, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Name"));
		_manager = manager;
		_service = triggeringFactory.Create();
		_prompt = prompt;
		ActionsMenuVM = actionsMenuVMFactory.Create(this);
		ActionsMenuVM.ShowActionDialog += delegate(IAction? a, IActionRepository? i, IEnumerable<IActionRepository> c)
		{
			this.ShowActionDialog?.Invoke(ContextMenuTarget, a, i, c);
		};
		SelectedMacros.CollectionChanged += delegate
		{
			SourceMacros.Where((IMacroItemVM m) => m.IsSelected).ForEach(delegate(IMacroItemVM m)
			{
				m.IsSelected = false;
			});
			SelectedMacros.Where((IMacroItemVM m) => !m.IsSelected).ForEach(delegate(IMacroItemVM m)
			{
				m.IsSelected = true;
			});
			ActionsMenuVM.SelectedItems.Clear();
			ActionsMenuVM.SelectedItems.AddRange(SelectedMacros.Select((IMacroItemVM i) => i.Macro).ToArray());
		};
		MacroMediaActionRepositoryProvider provider = new MacroMediaActionRepositoryProvider();
		MacroActionRepositoryProvider provider2 = new MacroActionRepositoryProvider();
		_dropOperation = new ActionDropOperation(new MediaActionHandler(provider, null), new PlaylistActionHandler(provider2), new ActionHandler(provider2), app, importProcessFactory, factoryProvider.MediaFactory, transitionDescriptions);
		LinkProperties("TriggerOnStartup", "TriggerOnStartup");
		LinkProperties("Name", "Name");
		MacroGroup.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnAddMacroCommand()
	{
		RenameNextItem = true;
		MacroGroup.AddMacro();
		IMacroItemVM macroItemVM = SourceMacros.LastOrDefault();
		if (macroItemVM != null)
		{
			this.NewMacroAdded?.Invoke(macroItemVM);
		}
		MacrosCreateEvent.Publish();
	}

	private void OnChangeIconCommand()
	{
		SelectedMacro.ThrowWhenNull("SelectedMacro");
		if (Parent.ListOrGrid == PanelViewType.List)
		{
			SelectedMacro.IsListIconPopUpOpen = true;
		}
		else
		{
			SelectedMacro.IsGridIconPopUpOpen = true;
		}
	}

	private void OnSelectIconCommand(ImageType imageType)
	{
		SelectedMacro.ThrowWhenNull("SelectedMacro");
		IMacroItemVM? selectedMacro = SelectedMacro;
		bool isListIconPopUpOpen = (SelectedMacro.IsGridIconPopUpOpen = false);
		selectedMacro.IsListIconPopUpOpen = isListIconPopUpOpen;
		if (imageType == ImageType.Custom)
		{
			ImportCustomIcon();
			return;
		}
		SelectedMacros.ForEach(delegate(IMacroItemVM m)
		{
			m.ImageType = imageType;
			m.Macro.Icon = null;
		});
	}

	private void ImportCustomIcon()
	{
		if (_fileSelectorService.SelectFile(out string selectedFile, FileFilters.ImageOnlyFilter) && _customIconProvider.TryGetIcon(out BitmapSource icon, selectedFile))
		{
			SelectedMacros.ForEach(delegate(IMacroItemVM m)
			{
				m.Macro.Icon = icon;
				m.ImageType = ImageType.Custom;
			});
		}
	}

	private void OnCopyCommand()
	{
		IMacro[] array = (from s in ((IEnumerable<IMacroItemVM>)SelectedMacros).Select((Func<IMacroItemVM, IMacro>)((IMacroItemVM m) => m.Macro)).ToArray()
			orderby MacroGroup.IndexOf(s)
			select s).ToArray();
		if (array.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(array);
		}
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteMacroCommand();
	}

	private void OnPasteCommand()
	{
		Parent.SelectedMacroGroup.ThrowWhenNull("Parent.SelectedMacroGroup");
		IMacroGroupVM selectedMacroGroup = Parent.SelectedMacroGroup;
		MacroGroup macroGroup = selectedMacroGroup.MacroGroup;
		Macro[] source = ((IEnumerable<IMacroItemVM>)selectedMacroGroup.SelectedMacros).Select((Func<IMacroItemVM, Macro>)((IMacroItemVM m) => m.Macro)).ToArray();
		int index = (source.Any() ? (source.Max((Macro m) => macroGroup.IndexOf(m)) + 1) : macroGroup.Count());
		IEnumerable<IMacro> pastedMacros = ClipboardManagerHelper.PasteIntoCollection<MacroGroup, IMacro>(macroGroup, index);
		selectedMacroGroup.SelectedMacros.Clear();
		selectedMacroGroup.SelectedMacros.AddRange(SourceMacros.Where((IMacroItemVM m) => pastedMacros.Contains(m.Macro)));
	}

	private void OnDuplicateMacroCommand()
	{
		OnCopyCommand();
		OnPasteCommand();
	}

	private void OnMoveMacroGroupCommand()
	{
		Parent.SelectedMacroGroup.ThrowWhenNull("Parent.SelectedMacroGroup");
		if (Parent.SelectedMacroGroup.SelectedMacros.Any())
		{
			ProPresenterMacro[] array = Parent.SelectedMacroGroup.SelectedMacros.Select((IMacroItemVM m) => m.Macro).ToArray();
			foreach (ProPresenterMacro macro in array)
			{
				Parent.SelectedMacroGroup.MacroGroup.RemoveMacro(macro);
				MacroGroup.AddMacro(macro);
			}
		}
		Parent.SelectedMacroGroup.SelectedMacros.Clear();
	}

	private void OnAddMacroToGroupCommand()
	{
		Parent.SelectedMacroGroup.ThrowWhenNull("Parent.SelectedMacroGroup");
		IMacroGroupVM selectedMacroGroup = Parent.SelectedMacroGroup;
		if (!selectedMacroGroup.SelectedMacros.Any() || selectedMacroGroup.SelectedMacro == null)
		{
			return;
		}
		foreach (ProPresenterMacro item in selectedMacroGroup.SelectedMacros.Select((IMacroItemVM a) => a.Macro.Clone()).OfType<ProPresenterMacro>())
		{
			MacroGroup.AddMacro(item);
		}
		selectedMacroGroup.SelectedMacros.Clear();
	}

	private void OnDeleteMacroCommand()
	{
		MacroGroup.RemoveMacros(SelectedMacros.Select((IMacroItemVM m) => m.Macro).ToArray());
		SelectedMacros.Clear();
		MacrosDeleteEvent.Publish();
		if (!string.IsNullOrEmpty(FilterText) && !FilteredMacros.Any())
		{
			FilterText = string.Empty;
		}
	}

	private void OnTriggerMacroCommand(IMacroItemVM itemVM)
	{
		SelectedMacro = null;
		SelectedMacros.Clear();
		_service.TriggerMacro(itemVM.Macro);
		MacrosTriggerEvent.Publish();
	}

	public IAction? Execute(IAction? action)
	{
		if (action == null)
		{
			return null;
		}
		IAction actionToEdit = null;
		SelectedMacros.ForEach(delegate(IMacroItemVM m)
		{
			IAction action2 = action.Clone();
			m.Macro.AddAction(action2);
			actionToEdit = action2;
		});
		return actionToEdit;
	}

	private void OnDropActionCommand(MacroDropParameter? parameter)
	{
		parameter.ThrowWhenNull("parameter");
		bool dropBefore = parameter.DropBefore;
		bool droppedOutside = parameter.DropOutside;
		ProPresenterMacro proPresenterMacro = null;
		if (parameter.Target?.DataContext is IMacroItemVM macroItemVM)
		{
			proPresenterMacro = macroItemVM.Macro;
		}
		if (proPresenterMacro == null)
		{
			droppedOutside = false;
		}
		IActionRepository placement = proPresenterMacro;
		IAction action = null;
		if (parameter.DroppedItems.AllOf<MediaCue>())
		{
			_dropOperation.Execute(parameter.DroppedItems.Cast<MediaCue>(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside);
		}
		else if (parameter.DroppedItems.AllOf<ClearType>())
		{
			_dropOperation.Execute(from ClearType c in parameter.DroppedItems
				select c.ToAction(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside);
		}
		else if (parameter.DroppedItems.AllOf<ActionType>())
		{
			action = _dropOperation.Execute((from ActionType a in parameter.DroppedItems
				select a.ConstructAction(null, MediaContainerIds.Macro(MacroGroup.ID))).ToArray(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<MediaType>())
		{
			(IAction? FirstAction, IActionRepository? Placement) tuple = _dropOperation.Execute(parameter.DroppedItems.Cast<MediaType>().FirstOrDefault(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, MediaContainerIds.Macro(MacroGroup.ID));
			placement = tuple.Placement;
			(action, _) = tuple;
		}
		else if (parameter.DroppedItems.AllOf<FileInfo>())
		{
			_dropOperation.Execute(parameter.DroppedItems.Cast<FileInfo>(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, MediaContainerIds.Macro(MacroGroup.ID));
		}
		else if (parameter.DroppedItems.AllOf<IPlaylist<MediaCue>>())
		{
			action = _dropOperation.Execute(parameter.DroppedItems.Cast<IPlaylist<MediaCue>>(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<ScreenArrangementBase>())
		{
			StageAction[] array = (from ScreenArrangementBase s in parameter.DroppedItems
				select s.ToAction()).OfType<StageAction>().ToArray();
			foreach (StageScreenAssignment assignment in from a in array.SelectMany(delegate(StageAction a)
				{
					IEnumerable<StageScreenAssignment> screenAssignments = a.ScreenAssignments;
					return screenAssignments ?? Enumerable.Empty<StageScreenAssignment>();
				})
				where (object)a?.Layout != null
				select a)
			{
				KeyValuePair<ScreenArrangementBase, SlideCue> keyValuePair = _manager.OutputConfiguration.StageScreenLayoutMap.FirstOrDefault<KeyValuePair<ScreenArrangementBase, SlideCue>>((KeyValuePair<ScreenArrangementBase, SlideCue> kp) => kp.Key.ID == assignment.Screen.ID);
				assignment.Layout = new Identifier(keyValuePair.Value.ID, keyValuePair.Value.Name);
			}
			action = _dropOperation.Execute(array, MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<ITimerVM>())
		{
			action = _dropOperation.Execute(from ITimerVM t in parameter.DroppedItems
				select new TimerAction(t.ID), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<Message>())
		{
			action = _dropOperation.Execute((from Message m in parameter.DroppedItems
				select m.ToAction()).NotNull(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IPropCue>())
		{
			_dropOperation.Execute(from IPropCue s in parameter.DroppedItems
				select s.ToAction(null), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IMacroItemVM>())
		{
			_dropOperation.Execute((from IMacroItemVM vm in parameter.DroppedItems
				select vm.Macro.ToAction()).NotNull(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<ActionBase>())
		{
			_dropOperation.Execute(parameter.DroppedItems.Cast<IAction>().CloneItems(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IClearGroupItemVM>())
		{
			_dropOperation.Execute((from IClearGroupItemVM vm in parameter.DroppedItems
				select vm.Item.ToAction()).NotNull(), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		else if (parameter.DroppedItems.AllOf<IPropCueVMInternal>())
		{
			_dropOperation.Execute(from IPropCueVMInternal vm in parameter.DroppedItems
				select vm.Source.ToAction(null), MacroGroup, proPresenterMacro, dropBefore, droppedOutside, out placement);
		}
		if (action != null && action.CanShowDialogOnDrop(parameter.DroppedItems))
		{
			placement.ThrowWhenNull("placement");
			OnShowDialog(parameter.Target, action, placement);
		}
	}

	private void OnShowDialog(FrameworkElement? placement, IAction action, IActionRepository target)
	{
		this.ShowActionDialog?.Invoke(placement, action, target, SelectedMacros.Select((IMacroItemVM m) => m.Macro));
	}

	private void OnUpdateDialogPlacementCommand(FrameworkElement placement)
	{
		this.UpdateDialogPlacement?.Invoke(placement);
	}
}
