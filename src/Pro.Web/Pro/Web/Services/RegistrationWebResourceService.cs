using System;
using Flurl;
using Pro.Common.Versioning;
using Pro.Web.Services.Extensions;

namespace Pro.Web.Services;

public class RegistrationWebResourceService : IRegistrationWebResourceService
{
	private readonly IApiService _apiService;

	private readonly IVersionInfoProvider _versionInfoProvider;

	private readonly IActivationKeyProvider _activationkeyProvider;

	public RegistrationWebResourceService(IApiService apiService, IVersionInfoProvider versionInfoProvider, IActivationKeyProvider activationKeyProvider)
	{
		_apiService = apiService;
		_versionInfoProvider = versionInfoProvider;
		_activationkeyProvider = activationKeyProvider;
	}

	public string GetSignIn()
	{
		return AppendAppInformation(GetProNamespace().AppendPathSegments("account", "sign-in"));
	}

	public string GetSignUp(RegistrationType registrationType = RegistrationType.Standard)
	{
		Url url = GetProNamespace().AppendPathSegments("account", "registration");
		return registrationType switch
		{
			RegistrationType.Standard => url, 
			RegistrationType.FreeTrial => url.AppendQueryParam("trial", "true"), 
			_ => throw new ArgumentOutOfRangeException("registrationType", registrationType, null), 
		};
	}

	public string GetRenewedVisionAccountDiscover()
	{
		return GetProNamespace().AppendPathSegments("account", "discover");
	}

	public string GetRenewedVisionAccountDiscoverSubscription()
	{
		return GetProNamespace().AppendPathSegments("account", "discover-subscription");
	}

	public string GetUpgradeToSubscription()
	{
		return AppendAppInformation(GetProNamespace().AppendPathSegments("account", "sign-in").AppendQueryParam("path", "legacy").AppendQueryParam("checkout-code", _activationkeyProvider.ActivationKey));
	}

	public string GetManageAccount()
	{
		return GetProNamespace().AppendPathSegments("account", "manage");
	}

	public string GetAddSeats()
	{
		return GetProNamespace().AppendPathSegments("account", "add-seats");
	}

	public string GetManageSeats()
	{
		return GetProNamespace().AppendPathSegments("account", "manage-seats");
	}

	public string GetWorkspaceDashboard()
	{
		return GetProNamespace().AppendPathSegments("account", "workspace-dashboard");
	}

	public string GetPurchase(PurchaseOrigin origin)
	{
		return GetProNamespace().AppendPathSegments("account", "purchase").AppendOrigin(origin);
	}

	public string GetUpgradeProContent()
	{
		return GetProNamespace().AppendPathSegments("procontent", "upgrade");
	}

	public string GetPurchaseBibles()
	{
		return GetProNamespace().AppendPathSegments("account", "purchase-bibles");
	}

	public string GetManageBibles()
	{
		return GetProNamespace().AppendPathSegments("account", "manage-bibles");
	}

	public string GetLaunchPopUpKnowledgeBase(LaunchPopUp origin)
	{
		string proNamespace = GetProNamespace();
		object obj = "resource";
		object obj2 = "launch-pop-up";
		string text = origin switch
		{
			LaunchPopUp.SignedInActiveLegacyLicense => "signed-in-legacy-license", 
			LaunchPopUp.SignedOutNoLicense => "signed-out-no-license", 
			LaunchPopUp.SignedOutLegacyLicense => "signed-out-legacy-license", 
			LaunchPopUp.SignedInNoLicense => "signed-in-no-license", 
			_ => throw new ArgumentOutOfRangeException("origin", origin, null), 
		};
		return proNamespace.AppendPathSegments(obj, obj2, text);
	}

	public string GetAccountsKnowledgeBase(AccountState origin)
	{
		string proNamespace = GetProNamespace();
		object obj = "resource";
		object obj2 = "account-settings";
		string text = origin switch
		{
			AccountState.SignedInWithLegacyLicense => "signed-in-legacy-license", 
			AccountState.SignedOutLegacyLicense => "signed-out-legacy-license", 
			AccountState.SignedInInactiveSubscription => "signed-in-inactive-subscription", 
			AccountState.SignedInTrialSubscription => "signed-in-free-trial", 
			AccountState.SignedInActiveSubscription => "signed-in-active-subscription", 
			AccountState.SignedOutNoLicense => "signed-out-no-license", 
			_ => throw new ArgumentOutOfRangeException("origin", origin, null), 
		};
		return proNamespace.AppendPathSegments(obj, obj2, text);
	}

	public string GetDownloadProPresenterVersions()
	{
		return GetProNamespace().AppendPathSegments("resource", "download_previous_version");
	}

	private string GetProNamespace()
	{
		return _apiService.GetTargetRedirectHost(includeProtocol: true).AppendPathSegments("pro");
	}

	private Url AppendAppInformation(Url currentState)
	{
		return currentState.AppendQueryParam("inapp", "true").AppendQueryParam("name", Environment.MachineName).AppendQueryParam("appName", "ProPresenter")
			.AppendQueryParam("appVersion", _versionInfoProvider.ShortDisplayAppVersion);
	}
}
