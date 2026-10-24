using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.CoreApplication.Media.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;

namespace Pro.CoreApplication.Media.V2.CoreInteraction;

public class StubCoreMediaServiceV2 : ICoreMediaServiceV2
{
	private sealed class StubCoremediaSubscriptionV2 : ICoreMediaSubscriptionV2
	{
		public IObservable<MediaReference> WhenMediaReferenceChanged { get; } = Observable.Empty<MediaReference>();

		public IObservable<ImportMediaV2> WhenMediaImported { get; } = Observable.Empty<ImportMediaV2>();

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

	public ICoreMediaSubscriptionV2 Subscribe(ILogger logger)
	{
		return new StubCoremediaSubscriptionV2();
	}
}
