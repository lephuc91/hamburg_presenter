using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class NetworkEnvironmentRequest : ILinkRequest
{
	public ProLink.Types.ZeroConfig.Types.NetworkEnvironment Environment { get; }

	public NetworkEnvironmentRequest(ProLink.Types.ZeroConfig.Types.NetworkEnvironment environment)
	{
		Environment = environment;
	}
}
