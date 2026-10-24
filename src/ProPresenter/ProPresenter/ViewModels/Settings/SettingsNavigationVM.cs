using System;
using System.ComponentModel;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.ViewModels.Navigation;

namespace ProPresenter.ViewModels.Settings;

public class SettingsNavigationVM : NavigationVMBase<ISettingsItemVM>, ISettingsNavigationVM, INotifyPropertyChanged
{
	public event Action<ISettingsItemVM>? NavigateItem;

	protected override void OnNavigate(ISettingsItemVM item)
	{
		this.NavigateItem?.Invoke(item);
	}

	public void UpdateActivePage(ISettingsItemVM? activePage)
	{
		UpdateActiveItem(activePage);
	}

	public void RemovePage(ISettingsItemVM page)
	{
		RemoveItem(page);
	}
}
