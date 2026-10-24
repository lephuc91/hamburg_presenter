using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using Pro.Common.Collections;

namespace ProPresenter.Data;

public static class UriParser
{
	private const string PRO_URI_SCHEME = "pro";

	private const string PROPRESENTER_URI_SCHEME = "propresenter";

	private const string MAIN_HOST = "main";

	private const string REGISTER_SEGMENT = "register";

	private const string ACTIVATE_LINK_SEGMENT = "activate-link";

	public static bool TryParseUnlockCode(Uri input, [NotNullWhen(true)] out string? registrationName, [NotNullWhen(true)] out string? unlockCode)
	{
		if (TryExtractUriSegments(input, new string[2] { "pro", "propresenter" }, "main", out string[] segments) && segments[0] == "register" && segments.Length > 2)
		{
			registrationName = segments[1];
			unlockCode = segments[2];
			return true;
		}
		registrationName = null;
		unlockCode = null;
		return false;
	}

	public static bool TryParseSubscriptionKey(Uri input, [NotNullWhen(true)] out string? subscriptionKey)
	{
		if (TryExtractUriSegments(input, new string[1] { "propresenter" }, "main", out string[] segments) && segments[0] == "activate-link" && segments.Length > 1)
		{
			subscriptionKey = segments[1];
			return true;
		}
		subscriptionKey = null;
		return false;
	}

	private static bool TryExtractUriSegments(Uri uri, string[] supportedSchemes, string host, out string[] segments)
	{
		if (Array.Exists(supportedSchemes, (string scheme) => scheme.Equals(uri.Scheme, StringComparison.InvariantCultureIgnoreCase)) && uri.Host.Equals(host, StringComparison.InvariantCultureIgnoreCase))
		{
			segments = (from segment in uri.Segments
				where !segment.Equals("/", StringComparison.InvariantCultureIgnoreCase)
				select segment.Replace("/", "")).Select(WebUtility.UrlDecode).NotNull().ToArray();
			return true;
		}
		segments = Array.Empty<string>();
		return false;
	}
}
