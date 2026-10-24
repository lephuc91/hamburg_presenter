using System;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

public interface IInputsSettingsVM : ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool IsActive { get; set; }

	int SelectedIndex { get; set; }

	IVideoInputsSettingsVM VideoInputsSettingsVM { get; }

	IAudioInputsSettingsVM AudioInputsSettingsVM { get; }

	INdiInputsSettingsVM NdiInputsSettingsVM { get; }

	TimeSlice AudioInputTransitionTime { get; set; }

	ICommand HelpCommand { get; }

	ICommand GotFocusCommand { get; }

	event Action<UndoStack> StackChanged;
}
