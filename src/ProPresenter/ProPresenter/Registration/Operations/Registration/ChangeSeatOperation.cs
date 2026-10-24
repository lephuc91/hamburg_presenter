using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.CoreApplication.Registration;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.Registration.UserInteraction;

namespace ProPresenter.Registration.Operations.Registration;

public class ChangeSeatOperation : IAwaitableOperation
{
	private readonly Task _changeSeatTask;

	public ChangeSeatOperation(IRegistrationClient registrationClient, IRegistrationUserDialogService registerOperationUserDialogService, bool isActive, IAwaitableRegistrationOperation actuallyChangeSeatOperation)
	{
		_changeSeatTask = Run(registrationClient, registerOperationUserDialogService, isActive, actuallyChangeSeatOperation);
	}

	private static async Task Run(IRegistrationClient registrationClient, IRegistrationUserDialogService registerOperationUserDialogService, bool isActive, IAwaitableRegistrationOperation actuallyChangeSeatOperation)
	{
		if (isActive || registerOperationUserDialogService.DoesUserReallyWantToSwitchToInactiveSeat())
		{
			registrationClient.Add(actuallyChangeSeatOperation);
			await actuallyChangeSeatOperation;
		}
	}

	public TaskAwaiter GetAwaiter()
	{
		return _changeSeatTask.GetAwaiter();
	}
}
