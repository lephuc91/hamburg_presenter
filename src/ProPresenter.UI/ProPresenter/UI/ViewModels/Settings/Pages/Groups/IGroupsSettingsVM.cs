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

namespace ProPresenter.UI.ViewModels.Settings.Pages.Groups;

public interface IGroupsSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IDragDropCollection<IGroupLabelItemVM>
{
	INotifyEnumerableChanged<IGroupLabelItemVM> GroupLabels { get; }

	IGroupLabelItemVM SelectedGroupLabel { get; set; }

	ObservableCollection<IGroupLabelItemVM> SelectedGroups { get; }

	bool RenameNextItem { get; set; }

	IRelayCommand AddGroupLabelCommand { get; }

	IRelayCommand RemoveGroupLabelCommand { get; }

	ICommand HelpCommand { get; }

	ICommand GotFocusCommand { get; }

	event Action<UndoStack> StackChanged;
}
