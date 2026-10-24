using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;

namespace Pro.CoreApplication.Media.V1.CoreInteraction;

public class StubCoreMediaServiceV1 : ICoreMediaServiceV1
{
	private sealed class StubCoremediaSubscription : ICoreMediaSubscriptionV1
	{
		public IObservable<MediaReference> WhenMediaReferenceChanged { get; } = Observable.Empty<MediaReference>();

		public IObservable<ConnectionStatus> WhenConnectionStatusChanged { get; } = Observable.Empty<ConnectionStatus>();

		public IObservable<MediaManagementStatus> WhenMediaManagementStatusUpdated { get; } = Observable.Empty<MediaManagementStatus>();
	}

	public Task<ResponseEnvelope> ExecuteAsync(RequestEnvelope request)
	{
		return Task.FromResult(new ResponseEnvelope
		{
			Error = new RequestError
			{
				Code = RequestError.Types.ErrorCode.ServiceCantSendRequest,
				Description = "Failed to connect to media service"
			}
		});
	}

	public ICoreMediaSubscriptionV1 Subscribe(ILogger logger)
	{
		return new StubCoremediaSubscription();
	}
}
