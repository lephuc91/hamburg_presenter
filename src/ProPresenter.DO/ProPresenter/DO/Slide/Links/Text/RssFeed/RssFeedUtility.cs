using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Time;
using ProPresenter.DO.RSS;
using RestSharp;

namespace ProPresenter.DO.Slide.Links.Text.RssFeed;

public static class RssFeedUtility
{
	private static readonly TimeSlice RssReadTimeout = TimeSlice.FromSeconds(5.0);

	public static RSSFeed? LoadFeed(string url, IRestClientFactory restClientFactory)
	{
		try
		{
			url = NormalizeUrl(url);
			using IRestClient client = restClientFactory.Get(delegate(RestClientOptions options)
			{
				options.Timeout = TimeSpan.FromMilliseconds(RssReadTimeout.TotalMilliseconds);
				options.Expect100Continue = false;
			});
			RestRequest request = new RestRequest(url);
			RestResponse restResponse = client.ExecuteGet(request);
			if (!restResponse.IsSuccessful || string.IsNullOrWhiteSpace(restResponse.Content))
			{
				Log.Warning("[{0}] Failed to load RSS feed from {1}: status:{2} error mesage:{3}\n{4}\n{5}", "RssFeedUtility", url, restResponse.StatusCode, restResponse.ErrorMessage, restResponse.Content, restResponse.ErrorException);
				return null;
			}
			return RSSFeed.LoadFeed(restResponse.Content);
		}
		catch (Exception exception)
		{
			Log.Warning(exception);
			return null;
		}
	}

	[return: NotNullIfNotNull("url")]
	public static string? NormalizeUrl(string? url)
	{
		if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
		{
			return Uri.UriSchemeHttp + Uri.SchemeDelimiter + url;
		}
		return url;
	}

	public static string[] ParseFeed(RSSFeed? feed, RssFeedContentMode contentMode)
	{
		if (feed == null || !feed.Channels.Any())
		{
			return Array.Empty<string>();
		}
		return (from i in feed.Channels.SelectMany(delegate(Channel c)
			{
				IEnumerable<Item> items = c.Items;
				return items ?? Enumerable.Empty<Item>();
			})
			select ParseItem(i, contentMode)).ToArray();
	}

	public static string GetAbsoluteUri(string url)
	{
		try
		{
			if (Uri.TryCreate(NormalizeUrl(url), UriKind.Absolute, out Uri result))
			{
				return result.AbsoluteUri;
			}
		}
		catch
		{
			Log.Error("[{0}] Failed to get absolute string for {1}", "RssFeedUtility", url);
		}
		return url;
	}

	private static string ParseItem(Item item, RssFeedContentMode contentMode)
	{
		if (contentMode != RssFeedContentMode.TextOnly)
		{
			return item.Title + ": " + item.Description;
		}
		return item.Title;
	}
}
