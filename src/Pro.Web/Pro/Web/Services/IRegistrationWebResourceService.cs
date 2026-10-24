namespace Pro.Web.Services;

public interface IRegistrationWebResourceService
{
	string GetAddSeats();

	string GetManageAccount();

	string GetManageSeats();

	string GetWorkspaceDashboard();

	string GetPurchase(PurchaseOrigin origin);

	string GetRenewedVisionAccountDiscover();

	string GetRenewedVisionAccountDiscoverSubscription();

	string GetSignIn();

	string GetSignUp(RegistrationType registrationType = RegistrationType.Standard);

	string GetUpgradeToSubscription();

	string GetUpgradeProContent();

	string GetPurchaseBibles();

	string GetManageBibles();

	string GetLaunchPopUpKnowledgeBase(LaunchPopUp origin);

	string GetAccountsKnowledgeBase(AccountState origin);

	string GetDownloadProPresenterVersions();
}
