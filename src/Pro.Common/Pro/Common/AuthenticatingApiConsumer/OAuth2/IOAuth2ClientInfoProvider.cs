namespace Pro.Common.AuthenticatingApiConsumer.OAuth2;

public interface IOAuth2ClientInfoProvider
{
	string ClientId { get; }

	string? ClientSecret { get; }
}
