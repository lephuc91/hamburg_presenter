using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components;

namespace ProPresenter.UI.ViewModels.Editor.Links;

public interface IColorTriggersVM : INotifyPropertyChanged, IDragDropCollection<IColorTriggerItemVM>
{
	IEnumerable<IColorTriggerItemVM>? ColorTriggers { get; }

	ObservableCollection<IColorTriggerItemVM> SelectedItems { get; }

	IRelayCommand AddColorTriggerCommand { get; }

	IRelayCommand RemoveColorTriggersCommand { get; }

	IRelayCommand SaveAsDefaultColorTriggersCommand { get; }

	IRelayCommand ResetToDefaultColorTriggersCommand { get; }

	void UpdateColorTriggers(IFormatDataVM formatDataVM);
}
