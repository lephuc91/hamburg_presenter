using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Web;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Mathematics;
using Pro.Common.OAuth;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.Localization;
using Pro.Text;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.MultiTracks;

public class MultiTracksConsumer : OAuthConsumerBase, IMultiTracksConsumer, IConsumer
{
	private const string MultiTracksDateTimeFormat = "MM/d/yyyy H:mm:ss";

	private const string BaseAccountURL = "https://account.multitracks.com";

	private const string BaseAPIURL = "https://api.multitracks.com";

	private const string BaseAuthorizationURL = "https://account.multitracks.com/connect/authorize?response_type=code&client_id={0}&client_secret={1}&redirect_uri={2}&scope={3}";

	private const string AuthorizationRedirectURL = "https://api.multitracks.com/callback";

	private const string AccessTokenURL = "https://account.multitracks.com/connect/token";

	private const string ClientID = "proPresenter";

	private const string ClientSecret = "ultraSecretPassword";

	private const string ClientScope = "chartPro openid profile offline_access";

	private const string AccountInfoEndpoint = "https://account.multitracks.com/connect/userinfo";

	private const string SearchEndpoint = "https://api.multitracks.com/chartpro/v1/search";

	private const string SongDetailsEndpoint = "https://api.multitracks.com/chartpro/v1/details";

	private const string SongChordDetailsEndpoint = "https://api.multitracks.com/chartpro/v1/slideDetails";

	private const string AuthorizationEndpoint = "https://api.multitracks.com/chartpro/v1/authorization";

	private readonly IApp _app;

	private readonly IPresentationFactory _presentationFactory;

	private readonly Dictionary<(MultiTracksPresentation presentation, bool consumeCredit), List<(Action<MultiTracksPresentation>? completedCallback, Action<string>? errorCallback)>> _pendingAuthorizations = new Dictionary<(MultiTracksPresentation, bool), List<(Action<MultiTracksPresentation>, Action<string>)>>();

	public event Action? SubscriptionAuthorizationUpdated;

	[GeneratedRegex("(\\[(.*?)\\])?([^\\[]*)?")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex ChordRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__ChordRegex_16.Instance;
	}

	public MultiTracksConsumer(IApp app, IUiDispatcher uiDispatcher, IRestClientFactory restClientFactory, IPresentationFactory presentationFactory)
		: base(uiDispatcher, restClientFactory)
	{
		_app = app;
		_presentationFactory = presentationFactory;
		if (_app.IsMultiTracksAuthorized)
		{
			Reauthorize(_app.MultiTracksAccessToken, _app.MultiTracksRefreshToken, _app.MultiTracksAccessTokenExpiration, null);
		}
		base.AuthorizationStateUpdated += delegate
		{
			_app.IsMultiTracksAuthorized = base.IsAuthorized;
			_app.MultiTracksAccessToken = base.AccessToken ?? string.Empty;
			_app.MultiTracksRefreshToken = base.RefreshToken ?? string.Empty;
			_app.MultiTracksAccessTokenExpiration = base.AccessTokenExpiration;
			if (base.AuthorizationState == CredentialState.Unauthorized)
			{
				_app.MultiTracksCustomerID = string.Empty;
				_app.MultiTracksFirstName = string.Empty;
				_app.MultiTracksLastName = string.Empty;
				_app.MultiTracksChartProStatus = MultiTracksSubscriptionStatus.Disabled;
				_app.MultiTracksSlideProStatus = MultiTracksSubscriptionStatus.Disabled;
				_app.MultiTracksSubscriptionLevel = MultiTracksSubscriptionLevel.Unknown;
			}
			this.SubscriptionAuthorizationUpdated?.Invoke();
		};
	}

	protected override string GetAuthorizationURL()
	{
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = "proPresenter";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = "ultraSecretPassword";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = HttpUtility.UrlEncode("https://api.multitracks.com/callback");
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = HttpUtility.UrlEncode("chartPro openid profile offline_access");
		return string.Format("https://account.multitracks.com/connect/authorize?response_type=code&client_id={0}&client_secret={1}&redirect_uri={2}&scope={3}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}

	public override bool TryCompleteAuthorization(string url)
	{
		if (url.StartsWith("https://api.multitracks.com/callback"))
		{
			string text = HttpUtility.ParseQueryString(new Uri(url).Query).Get("code");
			if (!string.IsNullOrWhiteSpace(text))
			{
				Response<object> response = new Client(base.RestClientFactory).SendRequest(new Request
				{
					Method = Method.POST,
					URL = "https://account.multitracks.com/connect/token",
					Body = new
					{
						grant_type = "authorization_code",
						code = text,
						client_id = "proPresenter",
						client_secret = "ultraSecretPassword",
						scope = "chartPro openid profile offline_access",
						redirect_uri = "https://api.multitracks.com/callback"
					}
				}, ContentType.FormURLEncoded);
				if (response != null && response.IsSuccessful)
				{
					Authorize(((string)((dynamic)response.Body)?.access_token) ?? string.Empty, ((string)((dynamic)response.Body)?.refresh_token) ?? string.Empty, DateTime.Now + TimeSpan.FromSeconds((int)(((dynamic)response.Body)?.expires_in ?? ((object)0))), null);
					return true;
				}
			}
		}
		return false;
	}

	protected override bool RefreshAccessToken()
	{
		Response<object> response = new Client(base.RestClientFactory).SendRequest(new Request
		{
			Method = Method.POST,
			URL = "https://account.multitracks.com/connect/token",
			Body = new
			{
				grant_type = "refresh_token",
				refresh_token = base.RefreshToken,
				client_id = "proPresenter",
				client_secret = "ultraSecretPassword"
			}
		}, ContentType.FormURLEncoded);
		if (response != null && response.IsSuccessful && response.Body != null)
		{
			Authorize((string)((dynamic)response.Body).access_token, (string)((dynamic)response.Body).refresh_token, DateTime.Now + TimeSpan.FromSeconds((int)((dynamic)response.Body).expires_in), null);
			return true;
		}
		CheckIfRevoked(response);
		return false;
	}

	protected override Request<T> PrepareRequest<T>(string resource)
	{
		return new Request<T>
		{
			URL = resource,
			Headers = { 
			{
				"Authorization",
				"Bearer " + base.AccessToken
			} }
		};
	}

	private void CheckIfRevoked(Response<dynamic>? response)
	{
		try
		{
			if (response != null && response.StatusCode == 400 && (object)response.Body != null && (string)response.Body.error == "invalid_grant")
			{
				Deauthorize();
			}
		}
		catch
		{
		}
	}

	public void GetAccountInfo(Action<MultiTracksAccountInfo?> completedCallback)
	{
		SendRequestAsync("https://account.multitracks.com/connect/userinfo", Method.GET, null, null, delegate(Response<dynamic> response)
		{
			if (response.IsSuccessful && (object)response.Body != null)
			{
				MultiTracksAccountInfo multiTracksAccountInfo = new MultiTracksAccountInfo((string)response.Body.UserID, (string)response.Body.CustomerID, (string)response.Body.UserFirstName, (string)response.Body.UserLastName, (string)response.Body.Organization, (int)response.Body.RemainingChartProSongs, (int)response.Body.RemainingSlideSongs, (MultiTracksSubscriptionStatus)response.Body.ChartProStatus, DateTime.ParseExact((string)response.Body.ChartProSubscriptionDate, "MM/d/yyyy H:mm:ss", null), (MultiTracksSubscriptionStatus)response.Body.SlideStatus, DateTime.ParseExact((string)response.Body.SlideSubscriptionDate, "MM/d/yyyy H:mm:ss", null));
				_app.MultiTracksCustomerID = multiTracksAccountInfo.CustomerID;
				_app.MultiTracksFirstName = multiTracksAccountInfo.FirstName;
				_app.MultiTracksLastName = multiTracksAccountInfo.LastName;
				_app.MultiTracksChartProStatus = multiTracksAccountInfo.ChartProStatus;
				_app.MultiTracksSlideProStatus = multiTracksAccountInfo.SlideProStatus;
				_app.MultiTracksSubscriptionLevel = ((multiTracksAccountInfo.SlideProStatus == MultiTracksSubscriptionStatus.Active) ? MultiTracksSubscriptionLevel.SlidePro : ((multiTracksAccountInfo.ChartProStatus == MultiTracksSubscriptionStatus.Active) ? MultiTracksSubscriptionLevel.ChartPro : MultiTracksSubscriptionLevel.Disabled));
				this.SubscriptionAuthorizationUpdated?.Invoke();
				completedCallback?.Invoke(multiTracksAccountInfo);
			}
			else
			{
				CheckIfRevoked(response);
				completedCallback?.Invoke(null);
			}
		});
	}

	public void GetSearchResults(string searchTerms, Action<MultiTracksSearchResults> completedCallback, Action<string> errorCallback, int pageNumber = 1, int pageSize = 15)
	{
		SendRequestAsync("https://api.multitracks.com/chartpro/v1/search", Method.POST, null, new
		{
			search = searchTerms,
			pageNumber = pageNumber,
			pageSize = pageSize
		}, delegate(Response<dynamic> response)
		{
			if (response.IsSuccessful && (object)response.Body != null)
			{
				if ((int)response.Body.status == 1)
				{
					List<MultiTracksSearchResult> list = new List<MultiTracksSearchResult>();
					foreach (dynamic item in response.Body.songs)
					{
						Key.TryParse((string)item.originalKey, out Key parsedKey);
						list.Add(new MultiTracksSearchResult((long)item.mtID, (string)item.song, (string)item.album, (string)item.artist, (string)item.imageURL, (string)item.lyricPreview, parsedKey, _app.MultiTracksSubscriptionLevel == MultiTracksSubscriptionLevel.SlidePro));
					}
					completedCallback?.Invoke(new MultiTracksSearchResults((int)response.Body.totalRecords, (int)response.Body.totalPages, (int)response.Body.pageNumber, list.ToArray()));
				}
				else
				{
					errorCallback(GetErrorMessage((string)response.Body.message));
				}
			}
			else
			{
				CheckIfRevoked(response);
				errorCallback?.Invoke(GetErrorMessage(response));
			}
		});
	}

	public void GetImportedSong(MultiTracksSearchResult searchResult, int linesPerSlide, TemplateSlide templateSlide, Vector2<double> documentSize, string presentationName, Action<PresentationBase> completedCallback, Action<string>? errorCallback)
	{
		SendRequestAsync("https://api.multitracks.com/chartpro/v1/details", Method.POST, null, new
		{
			mtID = searchResult.ID
		}, delegate(Response<dynamic> response)
		{
			if (response.IsSuccessful && (object)response.Body != null)
			{
				if ((int)response.Body.status == 1)
				{
					string text = string.Empty;
					foreach (dynamic item in response.Body.sections)
					{
						string text2 = (string)item.lyrics;
						if (!string.IsNullOrEmpty(text))
						{
							text += LineBreaks.NewLine;
						}
						text = text + "[" + (string)item.section + "]" + LineBreaks.NewLine;
						text += text2;
					}
					CCLIData ccliInfo = new CCLIData
					{
						Title = searchResult.Title,
						Artist = searchResult.Artist,
						Author = (string)response.Body.writers,
						Album = (string)response.Body.album,
						SongNumber = response.Body.ccli,
						ArtworkImageData = searchResult.Image?.ToByteArray()
					};
					MultiTracksLicenseData multiTracksInfo = new MultiTracksLicenseData(searchResult.ID, _app.MultiTracksCustomerID, DateTime.ParseExact((string)response.Body.dateExpirationTether, "MM/d/yyyy H:mm:ss", null), DateTime.ParseExact((string)response.Body.dateExpirationLicense, "MM/d/yyyy H:mm:ss", null), MultiTracksSubscriptionLevel.ChartPro);
					completedCallback?.Invoke(ImportHelper.GeneratePresentation(presentationName, text, ccliInfo, string.Empty, templateSlide, BreakMode.NewLine, null, linesPerSlide, documentSize, _presentationFactory, strictGroupMatching: true, null, multiTracksInfo));
				}
				else
				{
					errorCallback?.Invoke(GetErrorMessage((string)response.Body.message));
				}
			}
			else
			{
				CheckIfRevoked(response);
				errorCallback?.Invoke(GetErrorMessage(response));
			}
		});
	}

	public void GetImportedSong(MultiTracksSearchResult searchResult, Key baseKey, int linesPerSlide, TemplateSlide templateSlide, Vector2<double> documentSize, string presentationName, Action<PresentationBase> completedCallback, Action<string>? errorCallback)
	{
		SendRequestAsync("https://api.multitracks.com/chartpro/v1/slideDetails", Method.POST, null, new
		{
			mtID = searchResult.ID,
			key = baseKey.ToRawString(),
			linesPerSlide = linesPerSlide
		}, delegate(Response<dynamic> response)
		{
			if (response.IsSuccessful && (object)response.Body != null)
			{
				if ((int)response.Body.status == 1)
				{
					CCLIData cCLIData = new CCLIData
					{
						Title = searchResult.Title,
						Artist = searchResult.Artist,
						Author = (string)response.Body.writers,
						Album = (string)response.Body.album,
						SongNumber = response.Body.ccli,
						ArtworkImageData = searchResult.Image?.ToByteArray()
					};
					MultiTracksLicenseData licenseData = new MultiTracksLicenseData(searchResult.ID, _app.MultiTracksCustomerID, DateTime.ParseExact((string)response.Body.dateExpirationTether, "MM/d/yyyy H:mm:ss", null), DateTime.ParseExact((string)response.Body.dateExpirationLicense, "MM/d/yyyy H:mm:ss", null), MultiTracksSubscriptionLevel.SlidePro);
					Dictionary<string, List<string[]>> dictionary = new Dictionary<string, List<string[]>>();
					foreach (dynamic item2 in response.Body.slides)
					{
						string key = (string)item2.sectionUUID;
						if (!dictionary.ContainsKey(key))
						{
							dictionary.Add(key, new List<string[]>());
						}
						List<string> list = new List<string>();
						foreach (object item3 in item2.chordPro)
						{
							string item = (string)(dynamic)item3;
							list.Add(item);
						}
						dictionary[key].Add(list.ToArray());
					}
					MultiTracksPresentation multiTracksPresentation = _presentationFactory.CreateMultiTracks(templateSlide, licenseData);
					if (base.IsAuthorized && multiTracksPresentation.AuthorizationTetherExpiration < DateTime.Today)
					{
						RefreshAuthorization(multiTracksPresentation, consumeCredit: false);
					}
					multiTracksPresentation.Name = presentationName;
					multiTracksPresentation.BaseKey = baseKey;
					multiTracksPresentation.TargetKey = multiTracksPresentation.BaseKey;
					multiTracksPresentation.UndoStack?.StartIgnoring();
					multiTracksPresentation.CCLIInfo.Artist = cCLIData.Artist;
					multiTracksPresentation.CCLIInfo.Author = cCLIData.Author;
					multiTracksPresentation.CCLIInfo.Album = cCLIData.Album;
					multiTracksPresentation.CCLIInfo.Copyright = cCLIData.Copyright;
					multiTracksPresentation.CCLIInfo.Display = cCLIData.Display;
					multiTracksPresentation.CCLIInfo.Publisher = cCLIData.Publisher;
					multiTracksPresentation.CCLIInfo.SongNumber = cCLIData.SongNumber;
					multiTracksPresentation.CCLIInfo.Title = cCLIData.Title;
					multiTracksPresentation.CCLIInfo.ArtworkImageData = cCLIData.ArtworkImageData;
					Dictionary<string, Guid> dictionary2 = new Dictionary<string, Guid>();
					foreach (dynamic item4 in response.Body.songSections)
					{
						bool flag = true;
						string key2 = (string)item4.uuid;
						if (dictionary.TryGetValue(key2, out var value))
						{
							foreach (string[] item5 in value)
							{
								SlideCue cue = multiTracksPresentation.AddCue();
								if (flag)
								{
									string text = (string)item4.title;
									GroupLabel label = ImportHelper.FindExistingLabel(text) ?? new GroupLabel(text);
									multiTracksPresentation.AssignGroupLabel(label, new ArrangedCue[1] { multiTracksPresentation.DefaultArrangement.ArrangedCues.First((ArrangedCue a) => a.Source == cue) });
									dictionary2.Add(key2, multiTracksPresentation.ArrangementGroups.Last().ID);
									flag = false;
								}
								ClosedBezierPath closedBezierPath = ((CustomSlide)(cue.SlideAction?.Slide))?.GetPrimaryTextElement(useDisplayText: false);
								if (closedBezierPath != null)
								{
									TextDocument text2 = closedBezierPath.Text;
									if (!(text2 == null))
									{
										text2.Clear();
										string[] array = item5;
										foreach (string input in array)
										{
											if (text2.LastCharacterIndex > 0)
											{
												text2.InsertParagraph(text2.LastCharacterIndex);
												text2.Last().First().Settings.ChordAnnotation = null;
											}
											foreach (Match item6 in ChordRegex().Matches(input))
											{
												string chord = item6.Groups[2].Value;
												string text3 = item6.Groups[3].Value;
												int lastCharacterIndex = text2.LastCharacterIndex;
												if (string.IsNullOrEmpty(text3) && chord.Length > 0)
												{
													text3 = "\u200b";
												}
												text2.InsertText(lastCharacterIndex, text3);
												if (chord.Length > 0)
												{
													text2.IterateRuns(new Pro.Text.Range(lastCharacterIndex, lastCharacterIndex + text3.Length), splitRuns: true, delegate(RunBase r)
													{
														r.Settings.ChordAnnotation = chord;
													});
												}
											}
										}
									}
								}
							}
						}
					}
					IArrangement arrangement = multiTracksPresentation.Arrangements.AddArrangement("Full");
					arrangement.Clear();
					foreach (dynamic item7 in response.Body.fullArrangementSections)
					{
						if (dictionary2.TryGetValue((string)item7.uuid, out var id))
						{
							CueGroup cueGroup = multiTracksPresentation.ArrangementGroups.FirstOrDefault((CueGroup g) => g.ID == id);
							if (cueGroup != null)
							{
								arrangement.AddArrangementGroup(cueGroup);
							}
						}
					}
					multiTracksPresentation.ChangeSize(documentSize);
					multiTracksPresentation.UndoStack?.StopIgnoring();
					completedCallback?.Invoke(multiTracksPresentation);
				}
				else
				{
					errorCallback?.Invoke(GetErrorMessage((string)response.Body.message));
				}
			}
			else
			{
				CheckIfRevoked(response);
				errorCallback?.Invoke(GetErrorMessage(response));
			}
		});
	}

	public void RefreshAuthorization(MultiTracksPresentation presentation, bool consumeCredit, Action<MultiTracksPresentation>? completedCallback = null, Action<string>? errorCallback = null)
	{
		lock (_pendingAuthorizations)
		{
			(MultiTracksPresentation presentation, bool consumeCredit) key = (presentation: presentation, consumeCredit: consumeCredit);
			List<(Action<MultiTracksPresentation>? completedCallback, Action<string>? errorCallback)> callbacks;
			bool num = !_pendingAuthorizations.TryGetValue(key, out callbacks);
			if (num)
			{
				callbacks = new List<(Action<MultiTracksPresentation>, Action<string>)>();
				presentation.IsCheckingAccountStatus = true;
				_pendingAuthorizations.Add(key, callbacks);
			}
			callbacks.Add((completedCallback, errorCallback));
			if (!num)
			{
				return;
			}
			if (!consumeCredit && presentation.OwnedByCurrentCustomer && !presentation.IsLicenseExpired)
			{
				consumeCredit = true;
			}
			SendRequestAsync("https://api.multitracks.com/chartpro/v1/authorization", Method.POST, null, new
			{
				action = ((!consumeCredit) ? 1 : 2),
				authorizationType = (int)presentation.SubscriptionLevel,
				mtID = new long[1] { presentation.SongID }
			}, delegate(Response<dynamic> response)
			{
				lock (_pendingAuthorizations)
				{
					if (response.IsSuccessful && (object)response.Body != null)
					{
						if ((int)response.Body.status == 1)
						{
							foreach (dynamic item in response.Body.songs)
							{
								if ((object)item != null && (long)item.mtID == presentation.SongID)
								{
									presentation.RefreshAuthorization((string)response.Body.customerID, DateTime.ParseExact((string)item.dateExpirationTether, "MM/d/yyyy H:mm:ss", null), DateTime.ParseExact((string)item.dateExpirationLicense, "MM/d/yyyy H:mm:ss", null));
									this.SubscriptionAuthorizationUpdated?.Invoke();
									break;
								}
							}
							callbacks.ForEach(delegate((Action<MultiTracksPresentation>? completedCallback, Action<string>? errorCallback) c)
							{
								c.completedCallback?.Invoke(presentation);
							});
						}
						else
						{
							string errorMessage = GetErrorMessage((string)response.Body.message);
							callbacks.ForEach(delegate((Action<MultiTracksPresentation>? completedCallback, Action<string>? errorCallback) c)
							{
								c.errorCallback?.Invoke(errorMessage);
							});
						}
					}
					else
					{
						CheckIfRevoked(response);
						string errorMessage2 = GetErrorMessage(response);
						callbacks.ForEach(delegate((Action<MultiTracksPresentation>? completedCallback, Action<string>? errorCallback) c)
						{
							c.errorCallback?.Invoke(errorMessage2);
						});
					}
					_pendingAuthorizations.Remove(key);
					presentation.IsCheckingAccountStatus = false;
				}
			});
		}
	}

	private static string GetErrorMessage<T>(Response<T> response) where T : class
	{
		return GetErrorMessage(LocalizedStrings.Get("PRESENTATION_MULTITRACKS_FAILED_Message", new object[1] { response.StatusCode }));
	}

	private static string GetErrorMessage(string message)
	{
		return message + "\n\n" + LocalizedStrings.Get("PRESENTATION_MULTITRACKS_FAILED_CONTACT_Message");
	}

	void IMultiTracksConsumer.add_AuthorizationStateUpdated(Action value)
	{
		base.AuthorizationStateUpdated += value;
	}

	void IMultiTracksConsumer.remove_AuthorizationStateUpdated(Action value)
	{
		base.AuthorizationStateUpdated -= value;
	}

	string IMultiTracksConsumer.BeginAuthorization()
	{
		return BeginAuthorization();
	}
}
