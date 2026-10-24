using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Pro.Common.AuthenticatingApiConsumer;

public interface IAuthenticatingApiConsumer
{
	Task CompleteAuthorizationWithUrlAsync(string url, CancellationToken token = default(CancellationToken));

	Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request, Method method, CancellationToken cancellationToken = default(CancellationToken)) where T : notnull;

	Task<Stream?> DownloadStreamAsync(RestRequest request, CancellationToken cancellationToken = default(CancellationToken));

	string GetLoginUrl();

	bool IsAuthorizationCallback(string url);
}
