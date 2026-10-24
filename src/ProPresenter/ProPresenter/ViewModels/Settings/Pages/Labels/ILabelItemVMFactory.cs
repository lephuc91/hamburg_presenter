using Pro.DO.Label;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;

namespace ProPresenter.ViewModels.Settings.Pages.Labels;

public interface ILabelItemVMFactory
{
	ILabelItemVM Create(ActionLabel label);
}
