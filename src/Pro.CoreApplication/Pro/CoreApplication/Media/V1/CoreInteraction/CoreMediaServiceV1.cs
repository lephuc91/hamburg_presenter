using System.Threading.Tasks;
using CoreApplication.Media;
using Google.Protobuf;
using Pro.Common.Logging;
using Pro.CoreApplication.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;

namespace Pro.CoreApplication.Media.V1.CoreInteraction;

public class CoreMediaServiceV1 : global::CoreApplication.Media.CoreMediaServiceV1, ICoreMediaServiceV1
{
	private readonly nint _coreInstance;

	private readonly ISubscriptionDisposer _subscriptionDisposer;

	public CoreMediaServiceV1(nint instancePointer, ISubscriptionDisposer subscriptionDisposer)
	{
		_coreInstance = instancePointer;
		_subscriptionDisposer = subscriptionDisposer;
	}

	public Task<ResponseEnvelope> ExecuteAsync(RequestEnvelope request)
	{
		TaskCompletionSource<ResponseEnvelope> taskCompletionSource = new TaskCompletionSource<ResponseEnvelope>(TaskCreationOptions.RunContinuationsAsynchronously);
		SendRequest(callbackReceiver: new CallbackReceiver<ResponseEnvelope>(taskCompletionSource, ResponseEnvelope.Parser.ParseFrom), service: _coreInstance, @params: request.ToByteArray());
		return taskCompletionSource.Task;
	}

	public ICoreMediaSubscriptionV1 Subscribe(ILogger logger)
	{
		CoreMediaSubscriptionV1 coreMediaSubscriptionV = new CoreMediaSubscriptionV1(_coreInstance, logger);
		_subscriptionDisposer.RegisterSubscription(coreMediaSubscriptionV);
		return coreMediaSubscriptionV;
	}
}
