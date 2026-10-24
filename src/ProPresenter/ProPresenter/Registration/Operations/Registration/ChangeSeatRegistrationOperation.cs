using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;
using ProPresenter.Registration.Model.Extensions;

namespace ProPresenter.Registration.Operations.Registration;

public class ChangeSeatRegistrationOperation : AwaitableRegistrationOperation
{
	private readonly Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel _updateChannel;

	private readonly SeatType _seatType;

	public ChangeSeatRegistrationOperation(bool isActive, ProPresenter.DO.Registration.Model.UpdateChannel updateChannel = ProPresenter.DO.Registration.Model.UpdateChannel.Production)
	{
		_updateChannel = updateChannel.ToProtoUpdateChannel();
		_seatType = isActive.ToProtoSeatType();
	}

	protected override RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete)
		{
			return new RegistrationOperationHandleResponse(MessageHandled: true, OperationCompleted: true);
		}
		return RegistrationOperationHandleResponse.Unhandled;
	}

	public override Request Start()
	{
		return new Request
		{
			ChangeSeatType = new ChangeSeatType
			{
				SeatType = _seatType,
				Channel = _updateChannel
			}
		};
	}
}
