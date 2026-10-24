using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData.MediaService.v1;

namespace Pro.CoreApplication.Media.V1.CoreInteraction;

public interface ICoreMediaServiceV1
{
	Task<ResponseEnvelope> ExecuteAsync(RequestEnvelope request);

	ICoreMediaSubscriptionV1 Subscribe(ILogger logger);
}
