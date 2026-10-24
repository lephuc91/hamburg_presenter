namespace ProPresenter.Controller.NetworkAPI;

public enum FailureResultType
{
	Unexpected,
	Declined,
	Timeout,
	LinkDisabled,
	InOtherGroup,
	InvalidIpAddress,
	AlreadyInGroup,
	CouldNotAdd,
	CouldNotJoin
}
