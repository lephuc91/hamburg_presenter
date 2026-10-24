using System.Windows;
using System.Windows.Media;

namespace ProPresenter.UI.ViewModels.Settings.Search;

public interface ISettingsSearchResultItemVM
{
	string Name { get; }

	ISettingsItemVM Item { get; }

	Brush? Background { get; }

	ImageSource? Icon { get; }

	Thickness NameIndent { get; }

	bool IsRegistration { get; }
}
