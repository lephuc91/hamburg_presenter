using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ViewModels.Macros;

public interface IMacroGroupCollectionVM : INotifyPropertyChanged
{
	bool IsCollectionPopupOpen { get; set; }

	PanelViewType ListOrGrid { get; set; }

	INotifyEnumerableChanged<IMacroGroupVM> MacroGroups { get; }

	IMacroGroupVM? SelectedMacroGroup { get; set; }

	bool RenameNextItem { get; set; }

	ICommand AddMacroGroupCommand { get; }

	ICommand DeleteMacroGroupCommand { get; }

	ICommand DuplicateMacroGroupCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand CloseCollectionPopupCommand { get; }

	event Action<UndoStack> StackChanged;

	event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>> ShowActionDialog;

	event Action<FrameworkElement?> UpdateDialogPlacement;

	void TriggerStartupMacro();
}
