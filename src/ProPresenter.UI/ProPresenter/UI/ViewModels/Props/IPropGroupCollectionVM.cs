using System;
using System.Collections.Generic;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.UI.Commands;

namespace ProPresenter.UI.ViewModels.Props;

public interface IPropGroupCollectionVM
{
	IPropGroupVM? ActiveGroup { get; set; }

	IPropGroupVM? SelectedGroup { get; set; }

	Guid CollectionId { get; }

	TransitionParameters? SelectedTransition { get; set; }

	PanelViewType ListOrGrid { get; set; }

	bool IsCollectionPopupOpen { get; set; }

	ssAPIOutput OutputController { get; }

	IEnumerable<double> AutoClearMenuData { get; }

	INotifyEnumerableChanged<IPropGroupVM> PropGroups { get; }

	ICommand GotFocusCommand { get; }

	ICommand<ShowSource> EditPropsCommand { get; }

	ICommand CloseCollectionPopupCommand { get; }

	ICommand DuplicateGroupCommand { get; }

	ICommand DeleteGroupCommand { get; }

	IDragDropNotifyEnumerableChanged<IPropGroupVM> DragSource { get; }

	ICommand AddGroupCommand { get; }

	event Action<IPropGroupVM, IPropCueVM?> EditProps;

	event Action<UndoStack> StackChanged;

	void OnEditProps(IPropGroupVM groupVM, IPropCueVM? cueVM);
}
