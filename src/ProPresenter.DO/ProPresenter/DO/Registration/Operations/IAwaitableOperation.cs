using System.Runtime.CompilerServices;

namespace ProPresenter.DO.Registration.Operations;

public interface IAwaitableOperation
{
	TaskAwaiter GetAwaiter();
}
public interface IAwaitableOperation<T>
{
	TaskAwaiter<T> GetAwaiter();
}
