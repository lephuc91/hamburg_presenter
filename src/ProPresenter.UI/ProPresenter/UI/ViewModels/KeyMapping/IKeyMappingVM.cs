using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO.InputActionMap;

namespace ProPresenter.UI.ViewModels.KeyMapping;

public interface IKeyMappingVM : INotifyPropertyChanged
{
	FilterType FilterType { get; }

	bool FilterCustomized { get; set; }

	bool FilterConflicts { get; set; }

	string FilterText { get; set; }

	INotifyEnumerableChanged<IInputActionGroupVM> InputActionGroups { get; }

	IInputActionItemVM? SelectedItem { get; set; }

	string ConflictButtonContent { get; }

	ICommand<FilterType> SetFilterTypeCommand { get; }

	ICommand ResetAllCommand { get; }
}
