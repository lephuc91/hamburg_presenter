using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Versioning;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.Registration.Model.Extensions;
using ProPresenter.Registration.UserInteraction;

namespace ProPresenter.Registration.Operations.Registration;

public class RegisterWithUnlockCodeOperation : IAwaitableRegistrationOperation<bool>, IRegistrationOperation, IAwaitableOperation<bool>
{
	private readonly TaskCompletionSource<bool> _operationCompletion = new TaskCompletionSource<bool>();

	private readonly Func<bool, IAwaitableRegistrationOperation> _enqueueChangeSeatOperation;

	private readonly string _userName;

	private readonly string _unlockCode;

	private readonly string _deviceName;

	private readonly IRegistrationUserDialogService _registerOperationUserDialogService;

	private readonly IVersionInfoProvider _versionInfoProvider;

	private readonly Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel _updateChannel;

	private IDisposable? _activationInProgressCompletor;

	public RegisterWithUnlockCodeOperation(Func<bool, IAwaitableRegistrationOperation> enqueueChangeSeatOperation, string userName, string unlockCode, string deviceName, IRegistrationUserDialogService registerOperationUserDialogService, IVersionInfoProvider versionInfoProvider, ProPresenter.DO.Registration.Model.UpdateChannel updateChannel = ProPresenter.DO.Registration.Model.UpdateChannel.Production)
	{
		_enqueueChangeSeatOperation = enqueueChangeSeatOperation;
		_userName = userName;
		_unlockCode = unlockCode;
		_deviceName = deviceName;
		_registerOperationUserDialogService = registerOperationUserDialogService;
		_versionInfoProvider = versionInfoProvider;
		_updateChannel = updateChannel.ToProtoUpdateChannel();
	}

	public RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete)
		{
			VerificationComplete verificationComplete = responseCallback.VerificationComplete;
			if (verificationComplete.Result == Status.Success)
			{
				if (verificationComplete.IsCurrentBuildCoveredByLicense(_versionInfoProvider.BuildDate))
				{
					Complete(_enqueueChangeSeatOperation(arg: true)).ExecuteAsync();
					return new RegistrationOperationHandleResponse(MessageHandled: true, OperationCompleted: true);
				}
				_operationCompletion.SetResult(result: true);
			}
			else
			{
				_operationCompletion.SetResult(result: false);
			}
			_activationInProgressCompletor?.Dispose();
			return new RegistrationOperationHandleResponse(MessageHandled: true, OperationCompleted: true);
		}
		return RegistrationOperationHandleResponse.Unhandled;
	}

	private async Task Complete(IAwaitableRegistrationOperation continuationOperation)
	{
		await continuationOperation;
		_activationInProgressCompletor?.Dispose();
		_operationCompletion.SetResult(result: true);
	}

	public Request Start()
	{
		_activationInProgressCompletor = _registerOperationUserDialogService.ShowActivationInProgress();
		return new Request
		{
			Register = new Register
			{
				UserName = _userName,
				RegistrationKey = _unlockCode,
				DisplayName = _deviceName,
				SeatType = SeatType.Inactive,
				Channel = _updateChannel
			}
		};
	}

	public TaskAwaiter<bool> GetAwaiter()
	{
		return _operationCompletion.Task.GetAwaiter();
	}
}
