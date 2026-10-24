using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Pro.Common.OAuth;

public static class QueryHelper
{
	public static bool TryGetValueFromURLQuery(this string url, string keyFragment, [NotNullWhen(true)] out string? value)
	{
		value = null;
		NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(url);
		string text = nameValueCollection.AllKeys.FirstOrDefault((string k) => k?.Contains(keyFragment) ?? false);
		if (!string.IsNullOrEmpty(text))
		{
			value = nameValueCollection[text];
			return value != null;
		}
		return false;
	}
}
