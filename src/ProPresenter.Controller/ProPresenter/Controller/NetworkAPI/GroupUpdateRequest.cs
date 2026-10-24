using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class GroupUpdateRequest : ILinkRequest
{
	public ProLink.Types.GroupDefinition Group { get; }

	public GroupUpdateRequest(ProLink.Types.GroupDefinition protoGroupDefinition)
	{
		Group = protoGroupDefinition;
	}
}
