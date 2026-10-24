using System.Threading.Tasks;
using CoreApplication.Media;
using Google.Protobuf;
using Pro.Common.Logging;
using Pro.CoreApplication.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;

namespace Pro.CoreApplication.Media.V2.CoreInteraction;

public class CoreMediaServiceV2 : global::CoreApplication.Media.CoreMediaServiceV2, ICoreMediaServiceV2
{
	private readonly nint _coreInstance;

	private readonly ISubscriptionDisposer _subscriptionDisposer;

	public CoreMediaServiceV2(nint instancePointer, ISubscriptionDisposer subscriptionDisposer)
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

	public ICoreMediaSubscriptionV2 Subscribe(ILogger logger)
	{
		CoreMediaSubscriptionV2 coreMediaSubscriptionV = new CoreMediaSubscriptionV2(_coreInstance, logger);
		_subscriptionDisposer.RegisterSubscription(coreMediaSubscriptionV);
		return coreMediaSubscriptionV;
	}
}
