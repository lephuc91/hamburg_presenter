using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class AddConnectionSuccess : ILinkRequest
{
	public ProLink.Types.GroupDefinition Group { get; }

	public AddConnectionSuccess(ProLink.Types.GroupDefinition group)
	{
		Group = group;
	}
}
