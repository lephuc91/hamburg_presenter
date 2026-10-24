using System;
using System.Threading.Tasks;

namespace Pro.Common.OAuth.Authenticator;

public interface IOAuth2AuthorizationStore
{
	IObservable<bool> IsAuthorized { get; }

	OAuth2AuthorizationDataStored GetAuthorization();

	void StoreAuthorization(OAuth2AuthorizationDataStored data);

	void ClearAuthorization();

	Task RefreshAuthorization();

	bool OverrideOAuthRefresh();
}
