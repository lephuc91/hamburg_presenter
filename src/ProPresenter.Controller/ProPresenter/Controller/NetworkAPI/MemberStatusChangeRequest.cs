using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class MemberStatusChangeRequest : ILinkRequest
{
	public IEnumerable<ProLink.Types.MemberStatus> Members { get; }

	public MemberStatusChangeRequest(IEnumerable<ProLink.Types.MemberStatus> protoMemberStatuses)
	{
		Members = protoMemberStatuses;
	}
}
