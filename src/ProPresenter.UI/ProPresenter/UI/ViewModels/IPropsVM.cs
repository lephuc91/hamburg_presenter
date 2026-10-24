using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.DO.Props;
using ProPresenter.UI.Commands;
using ProPresenter.UI.Props;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.ViewModels;

public interface IPropsVM : INotifyPropertyChanged, IDragDropCollection<IPropCue>
{
	IEnumerable<IPropCue> ActiveProps { get; }

	IPropCue? ActiveItem { get; set; }

	ObservableCollection<IPropCue> SelectedItems { get; }

	IPropCue? SelectedItem { get; set; }

	TransitionHandler TransitionHandler { get; }

	TransitionParameters? SelectedTransition { get; set; }

	int RowCapacity { get; set; }

	string FilterText { get; set; }

	FilteredObservableCollection<IPropCue> FilteredProps { get; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DuplicateCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand<ShowSource> EditPropsCommand { get; }

	ICommand AddSlideCommand { get; }

	ICommand<DragDropCommandParameters<IPropCue, IPropCueCollection>> MoveToCommand { get; }

	ICommand<IPropCue?> TogglePropCommand { get; }

	ICommand<UIElement> TransitionCommand { get; }

	ICommand<DropMediaCommandParameters> DropFilesCommand { get; }

	ICommand<DropMediaCommandParameters> DropMediaCueCommand { get; }

	event Action<IPropGroup, IPropCue> EditProps;
}
