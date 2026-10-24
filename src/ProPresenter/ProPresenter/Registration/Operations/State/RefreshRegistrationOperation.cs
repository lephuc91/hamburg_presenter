using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;
using ProPresenter.Registration.Model.Extensions;

namespace ProPresenter.Registration.Operations.State;

public class RefreshRegistrationOperation : AwaitableRegistrationOperation
{
	private readonly ProPresenter.DO.Registration.Model.UpdateChannel _updateChannel;

	public RefreshRegistrationOperation(ProPresenter.DO.Registration.Model.UpdateChannel updateChannel)
	{
		_updateChannel = updateChannel;
	}

	public override Request Start()
	{
		return new Request
		{
			Refresh = new Refresh
			{
				Channel = _updateChannel.ToProtoUpdateChannel()
			}
		};
	}

	protected override RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		return new RegistrationOperationHandleResponse(MessageHandled: false, responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete);
	}
}
