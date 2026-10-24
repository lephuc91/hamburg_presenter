using System;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Settings;

public interface ISettingsNavigationVM : INotifyPropertyChanged
{
	event Action<ISettingsItemVM>? NavigateItem;

	void UpdateActivePage(ISettingsItemVM? activePage);

	void RemovePage(ISettingsItemVM page);
}
