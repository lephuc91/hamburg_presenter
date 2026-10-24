namespace Pro.Common.OAuth;

public enum CredentialState
{
	Unauthorized,
	AwaitingAuthorization,
	Authorized,
	AwaitingRefresh
}
