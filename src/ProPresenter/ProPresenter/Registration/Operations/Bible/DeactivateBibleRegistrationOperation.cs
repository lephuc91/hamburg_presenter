using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations.Bible;

public class DeactivateBibleRegistrationOperation : AwaitableRegistrationOperation
{
	private readonly string _bibleId;

	public DeactivateBibleRegistrationOperation(string bibleId)
	{
		_bibleId = bibleId;
	}

	public override Request Start()
	{
		return new Request
		{
			DeactivateBible = new DeactivateBible
			{
				BibleId = _bibleId
			}
		};
	}

	protected override RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		return new RegistrationOperationHandleResponse(MessageHandled: false, responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete);
	}
}
