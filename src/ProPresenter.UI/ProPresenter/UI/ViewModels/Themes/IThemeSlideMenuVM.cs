using System.Collections.ObjectModel;
using System.Windows.Input;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels.Themes;

public interface IThemeSlideMenuVM
{
	ICommand FetchMediaActionEnabledCommand { get; }

	ICommand FetchRecentlyAppliedThemeDataCommand { get; }

	bool MediaActionEnabled { get; set; }

	ObservableCollection<Theme> RecentThemes { get; }

	IThemeCollection Themes { get; }

	ThemeContainer? ThemeTree { get; }
}
