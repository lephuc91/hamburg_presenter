using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.UI.ViewModels.Settings;

public interface ISettingsListItem : INotifyPropertyChanged
{
	string Name { get; }

	Brush? Background { get; }

	ImageSource? Icon { get; }
}
