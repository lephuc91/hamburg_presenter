using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using ProPresenter.UI.ViewModels.Settings;

namespace ProPresenter.ViewModels.Settings;

public class SettingsHeaderItemVM : NotifyPropertyChangedBase, ISettingsHeaderItemVM, ISettingsListItem, INotifyPropertyChanged
{
	public string Name => string.Empty;

	public Brush? Background => null;

	public ImageSource? Icon => null;
}
