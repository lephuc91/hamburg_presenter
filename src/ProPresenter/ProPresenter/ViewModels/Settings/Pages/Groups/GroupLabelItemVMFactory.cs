using Pro.DO.Label;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;

namespace ProPresenter.ViewModels.Settings.Pages.Groups;

public class GroupLabelItemVMFactory : IGroupLabelItemVMFactory
{
	public IGroupLabelItemVM Create(GroupLabel groupLabel)
	{
		return new GroupLabelItemVM(groupLabel);
	}
}
