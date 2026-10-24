using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.MacroGroups;
using ProPresenter.UI.Macros;

namespace ProPresenter.UI.ViewModels.Macros;

public interface IMacroGroupVM
{
	MacroGroup MacroGroup { get; }

	IMacroGroupCollectionVM Parent { get; }

	FrameworkElement? ContextMenuTarget { get; set; }

	IActionsMenuVM ActionsMenuVM { get; }

	IDragDropNotifyEnumerableChanged<IMacroItemVM> SourceMacros { get; }

	INotifyEnumerableChanged<IMacroItemVM> FilteredMacros { get; }

	IMacroItemVM? ActiveMacro { get; set; }

	IMacroItemVM? SelectedMacro { get; set; }

	ObservableCollection<IMacroItemVM> SelectedMacros { get; }

	string FilterText { get; set; }

	string Name { get; set; }

	bool RenameNextItem { get; set; }

	bool TriggerOnStartup { get; }

	ICommand AddMacroCommand { get; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DuplicateCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand<IMacroItemVM> TriggerMacroCommand { get; }

	ICommand<MacroDropParameter> DropActionCommand { get; }

	ICommand<FrameworkElement> UpdateDialogPlacementCommand { get; }

	ICommand TriggerOnStartupCommand { get; }

	ICommand MoveMacroGroupCommand { get; }

	ICommand AddMacroToGroupCommand { get; }

	ICommand<IEnumerable<IMacroItemVM>> RemoveMacrosCommand { get; }

	ICommand<IEnumerable<IMacroItemVM>> AddMacrosCommand { get; }

	ICommand<ImageType> SelectIconCommand { get; }

	ICommand ChangeIconCommand { get; }

	event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;

	event Action<FrameworkElement?>? UpdateDialogPlacement;

	event Action? InvokeTriggerOnStartup;

	event Action<IMacroItemVM>? NewMacroAdded;
}
