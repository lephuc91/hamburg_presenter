using System.Linq;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class AvailableGroup : INetworkEntity
{
	private readonly ProLink.Types.GroupDefinition _group;

	public string Name => _group.Name;

	public AvailableGroup(ProLink.Types.GroupDefinition group)
	{
		_group = group;
	}

	public (string?, int) GetConnectionInfo()
	{
		ProLink.Types.GroupDefinition.Types.Member member = _group.Members.FirstOrDefault();
		if (member == null)
		{
			return (null, 0);
		}
		return (member.Ip, (int)member.Port);
	}
}
