using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Labels;

public interface ILabelsSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IDragDropCollection<ILabelItemVM>
{
	INotifyEnumerableChanged<ILabelItemVM> Labels { get; }

	ILabelItemVM SelectedLabel { get; set; }

	ObservableCollection<ILabelItemVM> SelectedLabels { get; }

	bool RenameNextItem { get; set; }

	IRelayCommand AddLabelCommand { get; }

	IRelayCommand RemoveLabelCommand { get; }

	ICommand GotFocusCommand { get; }

	event Action<UndoStack> StackChanged;
}
