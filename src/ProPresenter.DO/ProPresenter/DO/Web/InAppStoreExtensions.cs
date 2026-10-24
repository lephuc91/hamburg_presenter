using System;

namespace ProPresenter.DO.Web;

public static class InAppStoreExtensions
{
	public static ResourceType ToResourceType(this InAppStoreType type)
	{
		return type switch
		{
			InAppStoreType.Bibles => ResourceType.InAppBibles, 
			InAppStoreType.Renewal => ResourceType.InAppRenewal, 
			_ => throw new NotSupportedException(), 
		};
	}
}
