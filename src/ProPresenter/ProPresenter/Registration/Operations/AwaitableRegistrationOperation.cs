using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Operations;

namespace ProPresenter.Registration.Operations;

public abstract class AwaitableRegistrationOperation : IAwaitableRegistrationOperation, IRegistrationOperation, IAwaitableOperation
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct EmptyStruct
	{
	}

	private readonly TaskCompletionSource<EmptyStruct> _operationCompletion = new TaskCompletionSource<EmptyStruct>();

	public TaskAwaiter GetAwaiter()
	{
		return GetWaitTask().GetAwaiter();
	}

	public RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		RegistrationOperationHandleResponse registrationOperationHandleResponse = InternalHandleResponse(responseCallback, requestSender);
		if (registrationOperationHandleResponse.OperationCompleted)
		{
			_operationCompletion.SetResult(default(EmptyStruct));
		}
		return registrationOperationHandleResponse;
	}

	public abstract Request Start();

	protected abstract RegistrationOperationHandleResponse InternalHandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender);

	private Task GetWaitTask()
	{
		return _operationCompletion.Task;
	}
}
