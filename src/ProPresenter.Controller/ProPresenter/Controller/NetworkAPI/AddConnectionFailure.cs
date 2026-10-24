namespace ProPresenter.Controller.NetworkAPI;

public class AddConnectionFailure : ILinkRequest
{
	public FailureResultType Type { get; }

	public string MemberName { get; }

	public string GroupName { get; }

	public AddConnectionFailure(FailureResultType type, string memberName = "", string groupName = "")
	{
		Type = type;
		MemberName = memberName;
		GroupName = groupName;
	}
}
