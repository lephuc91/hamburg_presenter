using System.Threading;
using System.Threading.Tasks;
using RestSharp.Authenticators;

namespace Pro.Common.OAuth.Authenticator;

public interface IAuthenticator : RestSharp.Authenticators.IAuthenticator
{
	string GetLoginUrl();

	bool IsAuthorizationCallback(string url);

	Task CompleteAuthorizationWithUrlAsync(string url, CancellationToken token = default(CancellationToken));

	Task<bool> RefreshAuthorizationAsync(CancellationToken token = default(CancellationToken));
}
