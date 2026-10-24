using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Registration.Operations;

namespace ProPresenter.Registration.Operations.UpDowngrade;

public abstract class GetUpDowngradeOperationBase<T> : IAwaitableRegistrationOperation<AvailableSoftware>, IRegistrationOperation, IAwaitableOperation<AvailableSoftware> where T : class
{
	private const string PRODUCTION_CHANNEL = "production";

	private const string BETA_CHANNEL = "beta";

	private readonly bool _isBeta;

	private readonly TaskCompletionSource<AvailableSoftware> _completionSource = new TaskCompletionSource<AvailableSoftware>();

	protected GetUpDowngradeOperationBase(bool isBeta)
	{
		_isBeta = isBeta;
	}

	public abstract Request Start();

	public RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (TryGetResponseMessage(responseCallback, out Status responseResult, out T response))
		{
			if (responseResult == Status.Success)
			{
				_completionSource.SetResult(ToAvailableSoftware(response));
			}
			else
			{
				_completionSource.SetResult(AvailableSoftware.Empty);
			}
			return new RegistrationOperationHandleResponse(MessageHandled: true, OperationCompleted: true);
		}
		return RegistrationOperationHandleResponse.Unhandled;
	}

	public TaskAwaiter<AvailableSoftware> GetAwaiter()
	{
		return _completionSource.Task.GetAwaiter();
	}

	protected GetAvailableVersion GetAvailableVersionMessage()
	{
		return new GetAvailableVersion
		{
			Channel = (_isBeta ? "beta" : "production"),
			IncludeNotes = true,
			Format = ""
		};
	}

	protected abstract bool TryGetResponseMessage(Callback responseCallback, out Status responseResult, [NotNullWhen(true)] out T? response);

	protected abstract AvailableSoftware ToAvailableSoftware(T response);
}
