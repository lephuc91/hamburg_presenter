using Pro.DO.Label;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;

namespace ProPresenter.ViewModels.Settings.Pages.Groups;

public interface IGroupLabelItemVMFactory
{
	IGroupLabelItemVM Create(GroupLabel groupLabel);
}
