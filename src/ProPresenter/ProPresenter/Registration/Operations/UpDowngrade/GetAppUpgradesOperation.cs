using System;
using System.Diagnostics.CodeAnalysis;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;
using ProPresenter.Registration.Model.Extensions;

namespace ProPresenter.Registration.Operations.UpDowngrade;

public class GetAppUpgradesOperation : GetUpDowngradeOperationBase<UpgradesAvailable>
{
	private readonly Version _currentVersion;

	public GetAppUpgradesOperation(bool isBeta, Version currentVersion)
		: base(isBeta)
	{
		_currentVersion = currentVersion;
	}

	public override Request Start()
	{
		return new Request
		{
			GetUpgradesAvailable = GetAvailableVersionMessage()
		};
	}

	protected override AvailableSoftware ToAvailableSoftware(UpgradesAvailable response)
	{
		return response.ToAvailableSoftware(_currentVersion);
	}

	protected override bool TryGetResponseMessage(Callback responseCallback, out Status responseResult, [NotNullWhen(true)] out UpgradesAvailable? response)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.UpgradesAvailable)
		{
			responseResult = responseCallback.UpgradesAvailable.Status;
			response = responseCallback.UpgradesAvailable;
			return true;
		}
		responseResult = Status.UnknownError;
		response = null;
		return false;
	}
}
