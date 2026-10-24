using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using Pro.Common.SourceGenerator.Attributes;
using RestSharp;

namespace Pro.Common.HTTP;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public sealed class RestClientFactory : IRestClientFactory, IDisposable
{
	private sealed class RestClientOptionsComparer : IEqualityComparer<RestClientOptions>
	{
		public bool Equals(RestClientOptions? x, RestClientOptions? y)
		{
			if (x == null)
			{
				return y == null;
			}
			if (y == null)
			{
				return false;
			}
			TimeSpan? timeout = x.Timeout;
			TimeSpan? timeout2 = y.Timeout;
			if (timeout.HasValue == timeout2.HasValue && (!timeout.HasValue || timeout.GetValueOrDefault() == timeout2.GetValueOrDefault()) && x.UserAgent == y.UserAgent && x.Expect100Continue == y.Expect100Continue)
			{
				return Equals(x.BaseUrl, y.BaseUrl);
			}
			return false;
		}

		private static bool Equals(Uri? x, Uri? y)
		{
			if ((object)x == null)
			{
				return (object)y == null;
			}
			if ((object)y == null)
			{
				return false;
			}
			return x.Equals(y);
		}

		public int GetHashCode(RestClientOptions obj)
		{
			return HashCode.Combine(obj.Timeout, obj.UserAgent, obj.Expect100Continue, obj.BaseUrl);
		}
	}

	private readonly string _userAgent;

	private readonly int _maxConcurrentDownloadLimit;

	private readonly ConcurrentDictionary<RestClientOptions, HttpClient> _cachedClients = new ConcurrentDictionary<RestClientOptions, HttpClient>(new RestClientOptionsComparer());

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public RestClientFactory(string userAgent, int maxConcurrentDownloadLimit)
	{
		_userAgent = userAgent;
		_maxConcurrentDownloadLimit = maxConcurrentDownloadLimit;
	}

	public IRestClient Get(ConfigureRestClient? configureClient = null, ConfigureSerialization? configureSerialization = null)
	{
		RestClientOptions defaultClientOptions = GetDefaultClientOptions();
		configureClient?.Invoke(defaultClientOptions);
		HttpClient httpClient = GetHttpClient(defaultClientOptions);
		CleanOptions(defaultClientOptions);
		return new RestClient(httpClient, defaultClientOptions, disposeHttpClient: false, configureSerialization);
	}

	private RestClientOptions GetDefaultClientOptions()
	{
		return new RestClientOptions
		{
			UserAgent = _userAgent
		};
	}

	private HttpClient GetHttpClient(RestClientOptions options)
	{
		return _cachedClients.GetOrAdd(options, CreateHttpClient);
	}

	private HttpClient CreateHttpClient(RestClientOptions options)
	{
		string value = (string.IsNullOrEmpty(options.UserAgent) ? _userAgent : options.UserAgent);
		HttpClient httpClient = new HttpClient(new HttpClientHandler
		{
			MaxConnectionsPerServer = _maxConcurrentDownloadLimit
		});
		if (options.Timeout.HasValue)
		{
			httpClient.Timeout = options.Timeout.Value;
		}
		httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", value);
		if (options.Expect100Continue.HasValue)
		{
			httpClient.DefaultRequestHeaders.ExpectContinue = options.Expect100Continue;
		}
		return httpClient;
	}

	private static void CleanOptions(RestClientOptions options)
	{
		options.Timeout = null;
		options.UserAgent = null;
		options.Expect100Continue = null;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		foreach (HttpClient value in _cachedClients.Values)
		{
			value.Dispose();
		}
	}
}
