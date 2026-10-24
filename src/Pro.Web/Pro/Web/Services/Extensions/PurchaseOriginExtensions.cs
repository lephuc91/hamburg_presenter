using Flurl;

namespace Pro.Web.Services.Extensions;

internal static class PurchaseOriginExtensions
{
	public static Url AppendOrigin(this Url uri, PurchaseOrigin origin)
	{
		return origin switch
		{
			PurchaseOrigin.Trial => uri.AppendQueryParam("path", "trial"), 
			PurchaseOrigin.Inactive => uri, 
			_ => uri.AppendQueryParam("path", "expired"), 
		};
	}
}
