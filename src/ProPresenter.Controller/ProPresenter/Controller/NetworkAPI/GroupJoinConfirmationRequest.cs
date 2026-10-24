namespace ProPresenter.Controller.NetworkAPI;

public class GroupJoinConfirmationRequest : ILinkRequest
{
	public string GroupName { get; }

	public GroupJoinConfirmationRequest(string groupName)
	{
		GroupName = groupName;
	}
}
