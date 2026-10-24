using Pro.Common.FeatureFlag;

namespace Pro.Web.Services;

public class ApiService : IApiService
{
	private const string SECURE_PROTOCOL = "https://";

	private const string TARGET_REDIRECT_HOST = "api.renewedvision.com";

	private const string DEV_TARGET_REDIRECT_HOST = "api-staging.renewedvision.com";

	private readonly IFlagService _flagService;

	public ApiService(IFlagService flagService)
	{
		_flagService = flagService;
	}

	public string GetTargetRedirectHost(bool includeProtocol)
	{
		string text = (_flagService.IsFlagEnabled(Flag.StagingApiEndpoints) ? "api-staging.renewedvision.com" : "api.renewedvision.com") + "/v1.1";
		if (!includeProtocol)
		{
			return text;
		}
		return "https://" + text;
	}
}
