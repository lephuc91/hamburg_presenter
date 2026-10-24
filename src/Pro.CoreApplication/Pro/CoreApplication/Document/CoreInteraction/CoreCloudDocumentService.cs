using System.Threading.Tasks;
using CoreApplication.Document;
using Google.Protobuf;
using Pro.Common.Logging;
using Pro.CoreApplication.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.Service.Document.Call;

namespace Pro.CoreApplication.Document.CoreInteraction;

public class CoreCloudDocumentService : CoreDocumentService, ICoreCloudDocumentService
{
	private readonly nint _coreInstance;

	private readonly ISubscriptionDisposer _subscriptionDisposer;

	public CoreCloudDocumentService(nint instancePointer, ISubscriptionDisposer subscriptionDisposer)
	{
		_coreInstance = instancePointer;
		_subscriptionDisposer = subscriptionDisposer;
	}

	public Task<Load.Types.Result> LoadAsync(Load request)
	{
		TaskCompletionSource<Load.Types.Result> taskCompletionSource = new TaskCompletionSource<Load.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		Load(callbackReceiver: new CallbackReceiver<Load.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Document.Call.Load.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<Patch.Types.Result> PatchAsync(Patch request)
	{
		TaskCompletionSource<Patch.Types.Result> taskCompletionSource = new TaskCompletionSource<Patch.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		Patch(callbackReceiver: new CallbackReceiver<Patch.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Document.Call.Patch.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<Add.Types.Result> AddAsync(Add request)
	{
		TaskCompletionSource<Add.Types.Result> taskCompletionSource = new TaskCompletionSource<Add.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		Add(callbackReceiver: new CallbackReceiver<Add.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Document.Call.Add.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<Relocate.Types.Result> RelocateAsync(Relocate request)
	{
		TaskCompletionSource<Relocate.Types.Result> taskCompletionSource = new TaskCompletionSource<Relocate.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		Relocate(callbackReceiver: new CallbackReceiver<Relocate.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Document.Call.Relocate.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<Remove.Types.Result> RemoveAsync(Remove request)
	{
		TaskCompletionSource<Remove.Types.Result> taskCompletionSource = new TaskCompletionSource<Remove.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		Remove(callbackReceiver: new CallbackReceiver<Remove.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Document.Call.Remove.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public ICoreCloudDocumentSubscription Subscribe(ILogger logger)
	{
		CoreCloudDocumentSubscription coreCloudDocumentSubscription = new CoreCloudDocumentSubscription(_coreInstance, logger);
		_subscriptionDisposer.RegisterSubscription(coreCloudDocumentSubscription);
		return coreCloudDocumentSubscription;
	}
}
