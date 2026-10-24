namespace ProPresenter.UI.ViewModels.Registration.PopUpAlerts;

public class SubscribedSuccessfullyPopUpVM : ISubscribedSuccessfullyPopUpVM
{
	public string OrganizationName { get; }

	public SubscribedSuccessfullyPopUpVM(string organizationName)
	{
		OrganizationName = organizationName;
	}
}
