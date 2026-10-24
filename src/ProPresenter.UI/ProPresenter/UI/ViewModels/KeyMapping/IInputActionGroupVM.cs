using System.ComponentModel;
using Pro.Common.Collections;
using Pro.UI.InputActions;
using ProPresenter.DO.InputActionMap;

namespace ProPresenter.UI.ViewModels.KeyMapping;

public interface IInputActionGroupVM : INotifyPropertyChanged
{
	bool IsExpanded { get; set; }

	string Label { get; }

	INotifyEnumerableChanged<IInputActionItemVM> InputActions { get; }

	INotifyEnumerableChanged<IInputActionItemVM> FilteredInputActions { get; }

	INotifyEnumerableChanged<IInputActionGroupVM> Children { get; }

	InputActionGroupBase Group { get; }

	bool HasFilteredActions { get; }

	void ApplyFilter(FilterType filterType, bool filterCustomized, bool filterConflicts, string filterText);
}
