using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public interface ITemplateVM : INotifyPropertyChanged
{
	Theme DefaultTheme { get; }

	ThemeCollection Themes { get; }

	IThemeContainer? ThemeTree { get; }

	IEnumerable<IThemeContainer> RootThemes { get; }

	ViewType ViewType { get; }

	IThemeContainer? CurrentThemeContainer { get; }

	ICommand NewThemeCommand { get; }

	ICommand<Theme> DeleteThemeCommand { get; }

	ICommand<Theme> EditThemeCommand { get; }

	ICommand ExportThemeCommand { get; }

	ICommand AddSelectionToNewThemeCommand { get; }

	ICommand<Theme> AddSelectionToThemeCommand { get; }

	ICommand<Theme> SelectThemeCommand { get; }

	ICommand GoBackCommand { get; }

	ICommand<IThemeContainer> SelectThemeFolderCommand { get; }

	ICommand ResetViewCommand { get; }

	event Action<Theme?>? EditTheme;
}
