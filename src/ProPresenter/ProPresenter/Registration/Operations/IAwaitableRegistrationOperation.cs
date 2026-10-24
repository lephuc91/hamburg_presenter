using Pro.CoreApplication.Registration.Interaction;
using ProPresenter.DO.Registration.Operations;

namespace ProPresenter.Registration.Operations;

public interface IAwaitableRegistrationOperation : IRegistrationOperation, IAwaitableOperation
{
}
public interface IAwaitableRegistrationOperation<T> : IRegistrationOperation, IAwaitableOperation<T>
{
}
