using System;
using Pro.Common.Utility;
using Pro.Common.Versioning;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.CallbackHandlers;

public class GetProductInformationHandler : IRegistrationCallbackHandler
{
	private readonly IVersionInfoProvider _versionInfoProvider;

	public GetProductInformationHandler(IVersionInfoProvider versionInfoProvider)
	{
		_versionInfoProvider = versionInfoProvider;
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.GetProductInformation)
		{
			Version appVersion = _versionInfoProvider.AppVersion;
			Request request = new Request
			{
				ProductInformation = new ProductInformation
				{
					ProductName = "ProPresenter",
					MajorVersion = appVersion.Major.ToString(),
					MinorVersion = appVersion.Minor.ToString(),
					PatchVersion = appVersion.Revision.ToString(),
					BuildNumber = appVersion.Build.ToString(),
					BuildDate = _versionInfoProvider.BuildDate.ToUnixTimestamp()
				}
			};
			requestSender.Send(request);
			return true;
		}
		return false;
	}
}
