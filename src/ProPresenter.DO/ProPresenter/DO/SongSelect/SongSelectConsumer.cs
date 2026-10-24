using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.AuthenticatingApiConsumer;
using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.Common.Logging;
using Pro.Common.OAuth;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using ProPresenter.DO.Settings;
using ProPresenter.DO.SongSelect.Model;
using ProPresenter.DO.SongSelect.Model.Reporting;
using ProPresenter.DO.SongSelect.Model.Reporting.SongUsage;
using ProPresenter.DO.SongSelect.Model.Rights;
using ProPresenter.DO.SongSelect.Model.Songs.Lyrics;
using ProPresenter.DO.SongSelect.Model.Songs.Song;
using RestSharp;

namespace ProPresenter.DO.SongSelect;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_authorizationStorage" })]
public class SongSelectConsumer : ObservableObject, ISongSelectConsumer, IConsumer, INotifyPropertyChanged, IDisposable
{
	private record struct ClientInfoProvider(string ClientId, string ClientSecret) : IOAuth2ClientInfoProvider;

	private readonly IApp _app;

	private readonly ILogger _logger;

	private readonly IAuthenticatingApiConsumer _consumer;

	private readonly SongSelectAuthorizationStore _authorizationStorage;

	private static readonly Uri AUTHORIZATION_BASE_URL = new Uri("https://identityservices.ccli.com");

	private const string AUTHORIZE_PATH = "/connect/authorize";

	private const string GET_TOKEN_PATH = "/connect/token";

	private const string AUTHORIZE_CALLBACK_URI = "https://renewedvision.com/oauth2/ss_callback";

	private const string SUBSCRIPTION_KEY = "e9d2f4548a1c42e880e7f6cf1e1dff89";

	private const string CONSUMER_KEY = "eee62600-49f4-4d71-a42b-e118ba4c5695";

	private const string CONSUMER_SECRET = "a7b50e07-6557-43e2-9ce2-fa1bf3346645";

	private const string SCOPE = "openid cclipartnerapi.read offline_access";

	private static readonly Uri API_BASE_URL = new Uri("https://api.ccli.com");

	private const string API_SONG_SEARCH_PATH = "/ss/v2/songs";

	private const string USAGE_REPORT_ORIGIN = "ProPresenter";

	private const string USAGE_REPORT_DATE_FORMAT_STRING = "yyyy-MM-dd";

	private const string USAGE_REPORT_PATH = "/rpt/v1/report-usage";

	private const string GET_RIGHTS_PATH = "ss/v2/rights";

	[ObservableProperty]
	[NotifyPropertyChangedFor("AuthorizationState")]
	private bool _isAuthorized;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string Organization
	{
		get
		{
			return _app.SongSelectOrganization;
		}
		private set
		{
			_app.SongSelectOrganization = value;
			OnPropertyChanged("Organization");
		}
	}

	public CredentialState AuthorizationState
	{
		get
		{
			if (!IsAuthorized)
			{
				return CredentialState.Unauthorized;
			}
			return CredentialState.Authorized;
		}
	}

	public string SessionId => "songselect";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsAuthorized
	{
		get
		{
			return _isAuthorized;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isAuthorized, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsAuthorized);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AuthorizationState);
				_isAuthorized = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsAuthorized);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AuthorizationState);
			}
		}
	}

	[GeneratedRegex("^(?:©\\s*|)([0-9]{4}|)(.*)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex CopyrightRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_17.Instance;
	}

	public SongSelectConsumer(IAuthenticatingApiConsumerFactory consumerFactory, IApp app, ILogger logger)
	{
		_authorizationStorage = new SongSelectAuthorizationStore(app);
		_authorizationStorage.IsAuthorized.Subscribe(delegate(bool authorized)
		{
			IsAuthorized = authorized;
		});
		_consumer = consumerFactory.CreateOAuth2ConsumerWithPkceFlow(_authorizationStorage, new ClientInfoProvider("eee62600-49f4-4d71-a42b-e118ba4c5695", "a7b50e07-6557-43e2-9ce2-fa1bf3346645"), API_BASE_URL, AUTHORIZATION_BASE_URL, "/connect/authorize", "/connect/token", "https://renewedvision.com/oauth2/ss_callback", "e9d2f4548a1c42e880e7f6cf1e1dff89", "openid cclipartnerapi.read offline_access");
		_app = app;
		_logger = logger;
	}

	public string GetLoginUrl()
	{
		return _consumer.GetLoginUrl();
	}

	public bool IsAuthorizationCallback(string url)
	{
		return _consumer.IsAuthorizationCallback(url);
	}

	public async Task CompleteAuthorizationWithUrlAsync(string url)
	{
		await _consumer.CompleteAuthorizationWithUrlAsync(url);
		await UpdateOrganizationNameAsync();
	}

	public void Deauthorize()
	{
		_authorizationStorage.ClearAuthorization();
	}

	public async Task<SongSelectSearchResults> SearchAsync(string query, int pageIndex, int resultsPerPage)
	{
		string value = string.Concat(query.Where((char c) => c != '\r' && c != '\n').Append('*'));
		RestRequest request = new RestRequest("/ss/v2/songs").AddQueryParameter("filter[search]", value).AddQueryParameter("page[number]", pageIndex + 1).AddQueryParameter("page[size]", resultsPerPage)
			.AddQueryParameter("lyricspreview", "true");
		PaginatedReceivedData<SongSearchResults> paginatedReceivedData = await ExecuteGetWithErrorHandlingAsync<PaginatedReceivedData<SongSearchResults>>(request);
		if (paginatedReceivedData == null)
		{
			return new SongSelectSearchResults(0, Array.Empty<SongSelectSearchResult>());
		}
		return new SongSelectSearchResults(paginatedReceivedData.Pagination?.TotalItems ?? 0, paginatedReceivedData.Data?.Results.Select((SongSearchInfo r) => new SongSelectSearchResult(r.Id, r.SongNumber, r.Title, GetCommaSeperatedList(r.Authors), CleanupPreviewLyricLineBreaks(r.LyricsPreview))).ToArray() ?? Array.Empty<SongSelectSearchResult>());
	}

	public async Task<SongSelectSongInfo?> GetSongDetailsAsync(int songId)
	{
		RestRequest request = new RestRequest(GetLyricsPath(songId));
		ReceivedData<SongLyrics> receivedData = await ExecuteGetWithErrorHandlingAsync<ReceivedData<SongLyrics>>(request);
		if (receivedData == null)
		{
			return null;
		}
		IEnumerable<SongSelectSongPart> enumerable = receivedData.Data?.LyricParts.Select((LyricPart p) => new SongSelectSongPart
		{
			LyricText = CleanupLyricLineBreaks(p.lyrics ?? string.Empty),
			PartType = (p.partType ?? string.Empty),
			PartTypeNumber = p.partTypeNumber,
			PartLabel = (p.partLabel ?? string.Empty)
		});
		var (items, items2) = ExtractCopyrightAndPublisher(receivedData.Data?.Copyrights ?? Array.Empty<string>());
		return new SongSelectSongInfo
		{
			Lyrics = (enumerable ?? Array.Empty<SongSelectSongPart>()),
			Title = (receivedData.Data?.Title ?? string.Empty),
			Author = GetCommaSeperatedList(receivedData.Data?.Authors ?? Array.Empty<string>()),
			SongId = (receivedData.Data?.SongNumber ?? 0),
			Copyright = GetCommaSeperatedList(items),
			Publisher = GetCommaSeperatedList(items2)
		};
	}

	public async Task<IEnumerable<string>> ReportUsagesAsync(IEnumerable<SongSelectUsageReport>? usages)
	{
		if (!(usages?.Any() ?? false))
		{
			return Enumerable.Empty<string>();
		}
		IEnumerable<IGrouping<DateTime, SongSelectUsageReport>> source = from u in usages
			group u by u.UsageDay.Date;
		Request obj = new Request
		{
			Source = new UsageSource
			{
				Name = "ProPresenter"
			},
			Data = new UsageReport
			{
				Usage = source.Select((IGrouping<DateTime, SongSelectUsageReport> usageGroup) => new UsageReportData
				{
					Date = usageGroup.Key.ToString("yyyy-MM-dd"),
					Songs = usageGroup.Select((SongSelectUsageReport u) => u.CCLINumber).ToArray()
				}).ToArray()
			}
		};
		RestRequest request = new RestRequest("/rpt/v1/report-usage").AddJsonBody(obj);
		ReceivedData<Response> receivedData = await ExecutePostWithErrorHandlingAsync<ReceivedData<Response>>(request);
		if (receivedData != null)
		{
			return receivedData.Data?.Usage.SelectMany((UsageResponse usage) => usage.Songs.Reported.Concat(usage.Songs.PublicDomain)) ?? Array.Empty<string>();
		}
		return Enumerable.Empty<string>();
	}

	private async Task UpdateOrganizationNameAsync()
	{
		RestRequest request = new RestRequest("ss/v2/rights");
		ReceivedData<UserRights> receivedData = await ExecuteGetWithErrorHandlingAsync<ReceivedData<UserRights>>(request);
		if (receivedData != null)
		{
			Organization = receivedData.Data?.LinkedOrganization ?? string.Empty;
		}
	}

	private static string GetLyricsPath(int songId)
	{
		return $"ss/v2/songs/{songId}/lyrics";
	}

	private static string GetCommaSeperatedList(IEnumerable<string> items)
	{
		return string.Join(", ", items);
	}

	private static string CleanupPreviewLyricLineBreaks(string songPart)
	{
		return songPart.Replace("|", LineBreaks.NewLine);
	}

	private static string CleanupLyricLineBreaks(string songPart)
	{
		return songPart.Replace("\n", LineBreaks.NewLine);
	}

	private static (IEnumerable<string> years, IEnumerable<string> publishers) ExtractCopyrightAndPublisher(IEnumerable<string> copyrights)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		foreach (string copyright in copyrights)
		{
			Match match = CopyrightRegex().Match(copyright);
			if (match.Success)
			{
				string text = match.Groups[1].Value.Trim();
				string text2 = match.Groups[2].Value.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
				if (!string.IsNullOrEmpty(text2))
				{
					list2.Add(text2);
				}
			}
		}
		return (years: list, publishers: list2);
	}

	private Task<T?> ExecuteGetWithErrorHandlingAsync<T>(RestRequest request) where T : notnull
	{
		return ExecuteWithErrorHandlingAsync<T>(request, Method.Get);
	}

	private Task<T?> ExecutePostWithErrorHandlingAsync<T>(RestRequest request) where T : notnull
	{
		return ExecuteWithErrorHandlingAsync<T>(request, Method.Post);
	}

	private async Task<T?> ExecuteWithErrorHandlingAsync<T>(RestRequest request, Method method) where T : notnull
	{
		try
		{
			RestResponse<T> restResponse = await _consumer.ExecuteAsync<T>(request, method);
			if (restResponse.IsSuccessful)
			{
				return restResponse.Data;
			}
			_logger.Warning("[{0}] Failed to {4} resource {1}. Returned status code: {2}, returned data: {3}", "SongSelectConsumer", request.Resource, restResponse.StatusCode, restResponse.Content, method);
		}
		catch (Exception ex)
		{
			_logger.Warning("[{0}] Failed to {3} resource {1}. Exception was thrown:{2}", "SongSelectConsumer", request.Resource, ex, method);
		}
		return default(T);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_authorizationStorage.Dispose();
		}
	}
}
