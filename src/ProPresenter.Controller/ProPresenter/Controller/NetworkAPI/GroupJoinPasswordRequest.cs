namespace ProPresenter.Controller.NetworkAPI;

public class GroupJoinPasswordRequest : ILinkRequest
{
	public string GroupName { get; }

	public GroupJoinPasswordRequest(string groupName)
	{
		GroupName = groupName;
	}
}
