using System.ComponentModel;
using ProPresenter.DO;

namespace ProPresenter.UI.ViewModels;

public interface IUtilityViewVM : INotifyPropertyChanged
{
	UtilityViewType SelectedViewType { get; set; }

	UtilityViewTypeCollection UtilityViewTabs { get; }
}
