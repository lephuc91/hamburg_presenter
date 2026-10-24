using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using RestSharp;

namespace Pro.Common.HTTP;

internal static class HttpHeadersExtensions
{
	public static IReadOnlyCollection<HeaderParameter> GetHeaderParameters(this HttpHeaders httpHeaders)
	{
		return (from x in httpHeaders.SelectMany<KeyValuePair<string, IEnumerable<string>>, (string, string)>((KeyValuePair<string, IEnumerable<string>> x) => x.Value.Select((string y) => (Key: x.Key, y: y)))
			select new HeaderParameter(x.Key, x.y)).ToList();
	}
}
