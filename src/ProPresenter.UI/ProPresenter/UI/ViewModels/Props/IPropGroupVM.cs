using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.UI.Props;

namespace ProPresenter.UI.ViewModels.Props;

public interface IPropGroupVM : INotifyPropertyChanged
{
	ObservableCollection<IPropCueVM> SelectedCues { get; }

	ObservableCollection<IPropCueVM> ActiveCues { get; }

	string Name { get; set; }

	bool SingleMode { get; set; }

	string FilterText { get; set; }

	INotifyEnumerableChanged<IPropCueVM> PropCues { get; }

	IDragDropNotifyEnumerableChanged<IPropCueVM> DragDropSource { get; }

	ICommand AddPropCommand { get; }

	ICommand<IEnumerable<IPropCueVM>> AddPropsCommand { get; }

	ICommand<IPropCueVM?> RemovePropCommand { get; }

	ICommand<IEnumerable<IPropCueVM>> RemovePropsCommand { get; }

	ICommand<IPropCueVM?> EditPropsCommand { get; }

	ICommand<IPropCueVM?> TogglePropCommand { get; }

	ICommand ToggleSingleModeCommand { get; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DuplicateCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand<IPropGroupVM> AddPropToGroupCommand { get; }

	ICommand<IPropGroupVM> MoveToGroupCommand { get; }

	ICommand<double> SetAutoClearCommand { get; }

	ICommand PopupAutoClearCustomCommand { get; }

	IPropCueVM? SelectedCue { get; set; }

	ICommand<PropsDropParameter> DropActionCommand { get; }

	event Action<IPropCueVM> NewItemAdded;
}
