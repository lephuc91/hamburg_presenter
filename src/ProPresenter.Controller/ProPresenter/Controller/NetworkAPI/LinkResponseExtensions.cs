using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public static class LinkResponseExtensions
{
	public static ProApiOut? Serialize(this ILinkResponse response)
	{
		OutboundMessageBuilder outboundMessageBuilder = new OutboundMessageBuilder().Handler();
		if (!(response is GroupNameResponse groupNameResponse))
		{
			if (response is GroupJoinResponse groupJoinResponse)
			{
				return outboundMessageBuilder.GroupJoin(groupJoinResponse.DidAccept).Build();
			}
			return null;
		}
		return outboundMessageBuilder.GroupName(groupNameResponse.GroupName).Build();
	}
}
