using System.Collections;
using System.Windows.Media;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface INavigationItem
{
	string Name { get; }

	INavigationItem? Parent { get; }

	IEnumerable Children { get; }

	ImageSource? Icon { get; }
}
