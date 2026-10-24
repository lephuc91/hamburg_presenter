using System;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.Registration.UserInteraction;

namespace ProPresenter.Registration.Operations.Registration;

public class ActivateOperation : AwaitableRegistrationOperation
{
	private readonly string _confirmationCode;

	private readonly bool _showVisualIndication;

	private readonly IRegistrationUserDialogService _registerOperationUserDialogService;

	private IDisposable? _activationInProgressCompletor;

	public ActivateOperation(string confirmationCode, bool showVisualIndication, IRegistrationUserDialogService registerOperationUserDialogService)
	{
		_confirmationCode = confirmationCode;
		_showVisualIndication = showVisualIndication;
		_registerOperationUserDialogService = registerOperationUserDialogService;
	}

	protected override RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete)
		{
			_activationInProgressCompletor?.Dispose();
			return new RegistrationOperationHandleResponse(MessageHandled: false, OperationCompleted: true);
		}
		return new RegistrationOperationHandleResponse(MessageHandled: false, OperationCompleted: false);
	}

	public override Request Start()
	{
		if (_showVisualIndication)
		{
			_activationInProgressCompletor = _registerOperationUserDialogService.ShowActivationInProgress();
		}
		return new Request
		{
			ActivateLink = new ActivateLink
			{
				Identifier = _confirmationCode
			}
		};
	}
}
