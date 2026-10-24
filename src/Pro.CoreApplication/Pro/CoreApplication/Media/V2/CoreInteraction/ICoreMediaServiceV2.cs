using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;

namespace Pro.CoreApplication.Media.V2.CoreInteraction;

public interface ICoreMediaServiceV2
{
	Task<ResponseEnvelope> ExecuteAsync(RequestEnvelope request);

	ICoreMediaSubscriptionV2 Subscribe(ILogger logger);
}
