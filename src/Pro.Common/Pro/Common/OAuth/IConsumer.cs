namespace Pro.Common.OAuth;

public interface IConsumer
{
	CredentialState AuthorizationState { get; }

	bool IsAuthorized { get; }

	void Deauthorize();
}
