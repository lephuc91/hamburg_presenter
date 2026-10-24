using Pro.DO.Label;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;

namespace ProPresenter.ViewModels.Settings.Pages.Labels;

public class LabelItemVMFactory : ILabelItemVMFactory
{
	public ILabelItemVM Create(ActionLabel label)
	{
		return new LabelItemVM(label);
	}
}
