using System.Threading.Tasks;
using CoreApplication.Workspace;
using Google.Protobuf;
using Pro.Common.Logging;
using Pro.CoreApplication.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Call;

namespace Pro.CoreApplication.Workspace.CoreInteraction;

public class CoreCloudWorkspaceService : CoreWorkspaceService, ICoreCloudWorkspaceService
{
	private readonly nint _coreInstance;

	private readonly ISubscriptionDisposer _subscriptionDisposer;

	public CoreCloudWorkspaceService(nint instancePointer, ISubscriptionDisposer subscriptionDisposer)
	{
		_coreInstance = instancePointer;
		_subscriptionDisposer = subscriptionDisposer;
	}

	public Task<ConvertToLocal.Types.Result> ConvertToLocalAsync()
	{
		TaskCompletionSource<ConvertToLocal.Types.Result> taskCompletionSource = new TaskCompletionSource<ConvertToLocal.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		ConvertToLocal(callbackReceiver: new CallbackReceiver<ConvertToLocal.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Workspace.Call.ConvertToLocal.Types.Result.Parser.ParseFrom), service: _coreInstance);
		return taskCompletionSource.Task;
	}

	public Task<OpenLocal.Types.Result> OpenLocalAsync(OpenLocal request)
	{
		TaskCompletionSource<OpenLocal.Types.Result> taskCompletionSource = new TaskCompletionSource<OpenLocal.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		OpenLocal(callbackReceiver: new CallbackReceiver<OpenLocal.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Workspace.Call.OpenLocal.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<OpenRemote.Types.Result> OpenRemoteAsync(OpenRemote request)
	{
		TaskCompletionSource<OpenRemote.Types.Result> taskCompletionSource = new TaskCompletionSource<OpenRemote.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		OpenRemote(callbackReceiver: new CallbackReceiver<OpenRemote.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Workspace.Call.OpenRemote.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<PauseSync.Types.Result> PauseSyncAsync(PauseSync request)
	{
		TaskCompletionSource<PauseSync.Types.Result> taskCompletionSource = new TaskCompletionSource<PauseSync.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		PauseSync(callbackReceiver: new CallbackReceiver<PauseSync.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Workspace.Call.PauseSync.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<ResumeSync.Types.Result> ResumeSyncAsync()
	{
		TaskCompletionSource<ResumeSync.Types.Result> taskCompletionSource = new TaskCompletionSource<ResumeSync.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		ResumeSync(callbackReceiver: new CallbackReceiver<ResumeSync.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Workspace.Call.ResumeSync.Types.Result.Parser.ParseFrom), service: _coreInstance);
		return taskCompletionSource.Task;
	}

	public Task<Publish.Types.Result> PublishAsync(Publish request)
	{
		TaskCompletionSource<Publish.Types.Result> taskCompletionSource = new TaskCompletionSource<Publish.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		Publish(callbackReceiver: new CallbackReceiver<Publish.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Workspace.Call.Publish.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public Task<Rename.Types.Result> RenameAsync(Rename request)
	{
		TaskCompletionSource<Rename.Types.Result> taskCompletionSource = new TaskCompletionSource<Rename.Types.Result>(TaskCreationOptions.RunContinuationsAsynchronously);
		Rename(callbackReceiver: new CallbackReceiver<Rename.Types.Result>(taskCompletionSource, Pro.SerializationInterop.RVProtoData.Service.Workspace.Call.Rename.Types.Result.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public ICoreCloudWorkspaceSubscription Subscribe(ILogger logger)
	{
		CoreCloudWorkspaceSubscription coreCloudWorkspaceSubscription = new CoreCloudWorkspaceSubscription(_coreInstance, logger);
		_subscriptionDisposer.RegisterSubscription(coreCloudWorkspaceSubscription);
		return coreCloudWorkspaceSubscription;
	}
}
