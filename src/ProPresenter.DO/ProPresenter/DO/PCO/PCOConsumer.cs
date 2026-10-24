using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.OAuth;
using Pro.Common.OAuth.Authenticator;
using Pro.DO.Storage;
using Pro.Localization.Services;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.PCO.PcoUpdateOperation;
using ProPresenter.DO.PCO.PcoUpdateOperation.ItemCreator;
using ProPresenter.DO.PCO.RemoteDataModel;
using ProPresenter.DO.PCO.RemoteDataModel.People.Person;
using ProPresenter.DO.PCO.RemoteDataModel.Relationship;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Arrangement;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Attachment;
using ProPresenter.DO.PCO.RemoteDataModel.Services.AttachmentActivity;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Folder;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Media;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Organization;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Plan;
using ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;
using ProPresenter.DO.PCO.RemoteDataModel.Services.ServiceType;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Song;
using ProPresenter.DO.Settings;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Serializers.Json;

namespace ProPresenter.DO.PCO;

public class PCOConsumer : ObservableObject, IPcoItemFactory, IPCOConsumer, IConsumer, INotifyPropertyChanged
{
	private const string ApiClientId = "17125b3d4831b9dcca4b1e4249d002adb34967581af074614de066f964f0aed0";

	private const string ApiClientSecret = "921b16192087665931a04f9779e12f3d960361be66b8e5acdb4a9e5a4474ce29";

	private const string ApiScopeServicesPeople = "people services";

	private const string ApiBaseUrl = "https://api.planningcenteronline.com";

	private const string ApiRedirectUri = "https://renewedvision.com/oauth_callback.php";

	private const string ApiAuthorizeEndpoint = "/oauth/authorize";

	private const string ApiAccessTokenEndpoint = "/oauth/token";

	private const string ApiOrganizationEndpoint = "/services/v2";

	private const string ApiFoldersEndpoint = "/services/v2/folders";

	private const string ApiServiceTypesEndpoint = "/services/v2/service_types";

	private const string ApiPlansEndpoint = "/services/v2/service_types/{0}/plans";

	private const string ApiPlanItemsEndpoint = "/services/v2/service_types/{0}/plans/{1}/items";

	private const string ApiPlanEndpoint = "/services/v2/service_types/{0}/plans/{1}";

	private const string ApiCurrentUserEndpoint = "/people/v2/me";

	private const string ApiPlanDetailsEndpoint = "/services/v2/service_types/{0}/plans/{1}";

	public const string SessionID = "pco";

	private const string PageQuery = "per_page=500";

	private const string OffsetQuery = "offset={0}";

	private const string FutureFilter = "filter=future";

	private const string OrderByNameQuery = "order=name";

	private const string OrderByDateQuery = "order=sort_date";

	private readonly PCOOrganization _organization;

	private readonly IOAuth2AuthorizationStore _authorizationStorage;

	private readonly IRestClientFactory _restClientFactory;

	private readonly ILogger _logger;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly ILocalization _localization;

	private readonly IAuthenticator _authenticator;

	private readonly IStoredPcoOptions _storedPcoOptions;

	private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		TypeInfoResolver = new DefaultJsonTypeInfoResolver
		{
			Modifiers = { (Action<JsonTypeInfo>)delegate(JsonTypeInfo typeInfo)
			{
				foreach (JsonPropertyInfo property in typeInfo.Properties)
				{
					if (typeof(ICollection).IsAssignableFrom(property.PropertyType))
					{
						property.ShouldSerialize = (object _, object? val) => val is ICollection collection && collection.Count > 0;
					}
				}
			} }
		}
	};

	[ObservableProperty]
	[NotifyPropertyChangedFor("AuthorizationState")]
	private bool _isAuthorized;

	[ObservableProperty]
	private string _username = string.Empty;

	[ObservableProperty]
	private bool _isPCOBusy;

	[ObservableProperty]
	private string _pCOBusyMessage = string.Empty;

	private string ApiItemsToInclude => "include=song,media,arrangement";

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

	public Func<Task>? RequestPCOLogin { get; set; }

	public string CacheSessionId => "pco";

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
				OnIsAuthorizedChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsAuthorized);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AuthorizationState);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Username
	{
		get
		{
			return _username;
		}
		[MemberNotNull("_username")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_username, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Username);
				_username = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Username);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPCOBusy
	{
		get
		{
			return _isPCOBusy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPCOBusy, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsPCOBusy);
				_isPCOBusy = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsPCOBusy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PCOBusyMessage
	{
		get
		{
			return _pCOBusyMessage;
		}
		[MemberNotNull("_pCOBusyMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_pCOBusyMessage, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PCOBusyMessage);
				_pCOBusyMessage = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PCOBusyMessage);
			}
		}
	}

	public event Action<PCOPlan>? PlanRefreshed;

	public event Action? Deauthorized;

	public PCOConsumer(PCOOrganization organization, IAuthenticatorFactory authenticatorFactory, IRestClientFactory restClientFactory, IApp app, IStoredPcoOptions storedPcoOptions, ILogger logger, IAsyncExecutor asyncExecutor, ILocalization localization)
	{
		_organization = organization;
		_logger = logger;
		_asyncExecutor = asyncExecutor;
		_localization = localization;
		_restClientFactory = restClientFactory;
		_storedPcoOptions = storedPcoOptions;
		_authorizationStorage = new PcoAuthorizationStore(app);
		_authenticator = authenticatorFactory.CreateOAuth2Authenticator(_authorizationStorage, "17125b3d4831b9dcca4b1e4249d002adb34967581af074614de066f964f0aed0", new Uri("https://api.planningcenteronline.com"), "/oauth/authorize", "/oauth/token", "https://renewedvision.com/oauth_callback.php", "921b16192087665931a04f9779e12f3d960361be66b8e5acdb4a9e5a4474ce29", null, "people services");
		_authorizationStorage.IsAuthorized.Subscribe(delegate(bool authorized)
		{
			IsAuthorized = authorized;
		});
		_storedPcoOptions.PropertyChanged += StoredPcoOptionsChanged;
	}

	public Task RefreshOAuthTokenAsync()
	{
		return _authenticator.RefreshAuthorizationAsync();
	}

	public string GetLoginUrl()
	{
		return _authenticator.GetLoginUrl();
	}

	public bool IsAuthorizationCallback(string url)
	{
		return _authenticator.IsAuthorizationCallback(url);
	}

	public Task CompleteAuthorizationWithUrlAsync(string url)
	{
		return _authenticator.CompleteAuthorizationWithUrlAsync(url);
	}

	public void Deauthorize()
	{
		_authorizationStorage.ClearAuthorization();
	}

	private void StoredPcoOptionsChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ShowHistoricalPlans")
		{
			ReloadOrganizationData();
		}
	}

	private static string AppendQueries(string rootUrl, params string?[] queries)
	{
		return rootUrl + "?" + string.Join("&", queries.NotNull());
	}

	private void LoadOrganizationData(OrganizationData? organizationData, IList<FolderData> foldersData, IList<ServiceTypeData> serviceTypesData)
	{
		if (organizationData != null)
		{
			string name = organizationData.Attributes?.Name;
			ILookup<string, ServiceTypeData> serviceTypeLookup = serviceTypesData.ToLookup((ServiceTypeData f) => f.Relationships?.Parent?.Data?.Id);
			ILookup<string, FolderData> folderLookup = foldersData.ToLookup((FolderData f) => f.Relationships?.Parent?.Data?.Id);
			PCOFolder[] folders = folderLookup[null].Select((FolderData f) => CreateFolder(f, folderLookup, serviceTypeLookup)).ToArray();
			PCOServiceType[] rootServiceTypes = serviceTypeLookup[null].Select(CreateServiceType).ToArray();
			_organization.Reload(name, rootServiceTypes, folders);
		}
	}

	private PCOFolder CreateFolder(FolderData data, ILookup<string?, FolderData> folderLookup, ILookup<string?, ServiceTypeData> serviceTypeLookup)
	{
		return new PCOFolder(data.Id, data.Attributes?.Name, folderLookup[data.Id].Select((FolderData f) => CreateFolder(f, folderLookup, serviceTypeLookup)).ToArray(), serviceTypeLookup[data.Id].Select(CreateServiceType).ToArray());
	}

	private PCOServiceType CreateServiceType(ServiceTypeData t)
	{
		PCOServiceType pCOServiceType = new PCOServiceType(t?.Id, t?.Attributes?.Name);
		pCOServiceType.RequestPlans = (Action<PCOServiceType>)Delegate.Combine(pCOServiceType.RequestPlans, new Action<PCOServiceType>(LoadPlansForService));
		return pCOServiceType;
	}

	private void LoadPlansForService(PCOServiceType serviceType)
	{
		PCOServiceType pCOServiceType = serviceType;
		pCOServiceType.RequestPlans = (Action<PCOServiceType>)Delegate.Remove(pCOServiceType.RequestPlans, new Action<PCOServiceType>(LoadPlansForService));
		_asyncExecutor.ExecuteAsync(() => LoadPlansForServiceAsync(serviceType));
	}

	private async Task LoadPlansForServiceAsync(PCOServiceType serviceType)
	{
		IList<PlanData> item = (await LoadListDataAsync<PlanData>((int offset) => AppendQueries($"/services/v2/service_types/{serviceType.ID}/plans", _storedPcoOptions.ShowHistoricalPlans ? null : "filter=future", "order=sort_date", "per_page=500", $"offset={offset}"))).Item1;
		serviceType.ID.ThrowWhenNull("serviceType.ID");
		serviceType.Plans = item.Select((PlanData p) => new PCOPlan(serviceType.ID, p.Id, p.Attributes?.Title, p.Attributes?.UpdatedAt, p.Attributes?.Dates, p.Attributes?.SeriesTitle, p.Attributes?.CreatedAt)).ToArray();
	}

	private async Task<(IList<T> Data, IDictionary<string, PcoData> Inclusions)> LoadListDataAsync<T>(Func<int, string> getUrlCallback) where T : PcoData
	{
		List<T> data = new List<T>();
		Dictionary<string, PcoData> inclusions = new Dictionary<string, PcoData>();
		int? num = 0;
		while (num.HasValue)
		{
			RestRequest request = new RestRequest(getUrlCallback(num.Value));
			EncodedData<List<T>> encodedData = await ExecuteGetWithErrorHandlingAsync<EncodedData<List<T>>>(request);
			if (encodedData == null)
			{
				break;
			}
			encodedData.Data.ThrowWhenNull("receptionData.Data");
			data.AddRange(encodedData.Data);
			PcoData[] included = encodedData.Included;
			foreach (PcoData pcoData in included)
			{
				pcoData.Id.ThrowWhenNull("inclusion.Id");
				inclusions[pcoData.Id] = pcoData;
			}
			num = encodedData.Meta?.Next?.Offset;
		}
		return (Data: data, Inclusions: inclusions);
	}

	public async Task<PCOPlan> LoadPlanItemsAsync(PCOPlan plan, bool isRefresh = false)
	{
		if (!isRefresh && plan.IsPlanItemsLoaded)
		{
			return plan;
		}
		plan.ID.ThrowWhenNull("plan.ID");
		(IList<PlanItemData>, IDictionary<string, PcoData>) tuple = await LoadListDataAsync<PlanItemData>((int offset) => AppendQueries($"/services/v2/service_types/{plan.ServiceTypeID}/plans/{plan.ID}/items", "per_page=500", $"offset={offset}", ApiItemsToInclude));
		IList<PlanItemData> item2 = tuple.Item1;
		IDictionary<string, PcoData> inclusions = tuple.Item2;
		PCOPlan pCOPlan = plan;
		pCOPlan.LoadItems((await Task.WhenAll(item2.Select(async (PlanItemData item) => await CreatePlanItemAsync(item, inclusions, plan.ServiceTypeID)))).NotNull().ToArray());
		await LoadAttachmentsAsync($"/services/v2/service_types/{plan.ServiceTypeID}/plans/{plan.ID}", plan, plan.ID);
		this.PlanRefreshed?.Invoke(plan);
		return plan;
	}

	public async Task<PCOItem?> CreatePlanItemAsync(PlanItemData? item, IDictionary<string, PcoData>? inclusions, string? serviceTypeId)
	{
		(item?.Id).ThrowWhenNull("item?.Id");
		PCOItem result = null;
		switch (item.Attributes?.ItemType)
		{
		case PlanItemType.Item:
			result = new PCOPlanItem(item.Id, item.Attributes.Title, item.Relationships?.Plan?.Data?.Id, item.Attributes.UpdatedAt, serviceTypeId);
			break;
		case PlanItemType.Header:
			result = new PCOPlanHeader(item.Id, item.Attributes.Title, item.Relationships?.Plan?.Data?.Id, item.Attributes.UpdatedAt, serviceTypeId);
			break;
		case PlanItemType.Media:
			result = new PCOPlanMedia(item.Id, item.Attributes.Title, item.Relationships?.Plan?.Data?.Id, item.Attributes.UpdatedAt, serviceTypeId);
			break;
		case PlanItemType.Song:
		{
			PCOPlanSong song = new PCOPlanSong(item.Id, item.Attributes.Title, item.Relationships?.Plan?.Data?.Id, item.Attributes.UpdatedAt, serviceTypeId, item.Relationships?.Song?.Data?.Id, item.Relationships?.Arrangement?.Data?.Id);
			await LoadSongDetailsAsync(song, inclusions, item.Attributes.CustomArrangementSequence);
			result = song;
			break;
		}
		}
		if (result == null)
		{
			return result;
		}
		await LoadMediaAsync(item, inclusions, result);
		await LoadAttachmentsAsync(item, result, item.Id);
		return result;
	}

	private async Task LoadSongDetailsAsync(PCOPlanSong song, IDictionary<string, PcoData>? inclusions, string[]? customArrangementSequence)
	{
		song.SongID.ThrowWhenNull("song.SongID");
		song.ServiceId.ThrowWhenNull("song.ServiceId");
		song.ID.ThrowWhenNull("song.ID");
		inclusions.ThrowWhenNull("inclusions");
		SongData songData = inclusions[song.SongID] as SongData;
		songData.ThrowWhenNull("songInfo");
		song.LoadSong(new PCOSongDetails(songData, song.ServiceId));
		PcoData value;
		if (customArrangementSequence != null && customArrangementSequence.Length > 0)
		{
			song.LoadArrangment(new PCOSongArrangement(null, _localization.Get("PCO_CUSTOM_ARRANGEMENT_name"), customArrangementSequence, isCustom: true));
		}
		else if (inclusions.TryGetValue(song.SelectedArrangementID ?? string.Empty, out value) && value is ArrangementData arrangement)
		{
			song.LoadArrangment(new PCOSongArrangement(arrangement));
		}
		await LoadAttachmentsAsync(songData, song, song.ID);
	}

	private async Task LoadMediaAsync(PlanItemData item, IDictionary<string, PcoData>? inclusions, PCOItem result)
	{
		result.ID.ThrowWhenNull("result.ID");
		inclusions.ThrowWhenNull("inclusions");
		IEnumerable<MediaData> enumerable = (item.Relationships?.Media?.Data.Select((RelationshipData d) => d.Id))?.Select((string id) => (id == null) ? null : (inclusions[id] as MediaData)).NotNull();
		if (enumerable != null)
		{
			PCOItem pCOItem = result;
			pCOItem.LoadMedia(await Task.WhenAll(enumerable.Select(async delegate(MediaData i)
			{
				PCOMediaDetails mediaDetail = new PCOMediaDetails(i, result.ID);
				await LoadAttachmentsAsync(i, mediaDetail, result.ID);
				return mediaDetail;
			})));
		}
	}

	private Task LoadAttachmentsAsync(PcoData resourceData, IPCOAttachmentsContainer destination, string pcoItemId)
	{
		return LoadAttachmentsAsync(resourceData.GetLinkToSelf(), destination, pcoItemId);
	}

	private async Task LoadAttachmentsAsync(string resourceLink, IPCOAttachmentsContainer destination, string pcoItemId)
	{
		RestRequest request = new RestRequest(resourceLink + "/attachments");
		EncodedData<List<AttachmentData>> encodedData = await ExecuteGetWithErrorHandlingAsync<EncodedData<List<AttachmentData>>>(request);
		if (encodedData?.Data != null)
		{
			destination.LoadAttachments(encodedData.Data.Select((AttachmentData a) => new PCOAttachmentDetails(a, pcoItemId)).ToList());
		}
	}

	public async Task<PlanRefreshResult> RefreshPCOPlanAsync(PCOPlan plan)
	{
		if (!IsAuthorized)
		{
			await RequestPcoLogin();
		}
		if (IsAuthorized)
		{
			IsPCOBusy = true;
			RestRequest request = new RestRequest($"/services/v2/service_types/{plan.ServiceTypeID}/plans/{plan.ID}");
			EncodedData<PlanData> encodedData = await ExecuteGetWithErrorHandlingAsync<EncodedData<PlanData>>(request);
			if (encodedData == null)
			{
				return new PlanRefreshResult(Success: true);
			}
			if (encodedData.Data != null)
			{
				plan.UpdatePlanDetails(encodedData.Data.Attributes?.Dates ?? string.Empty, encodedData.Data.Attributes?.SeriesTitle ?? string.Empty, encodedData.Data.Attributes?.Title ?? string.Empty, encodedData.Data.Attributes?.UpdatedAt);
			}
			return new PlanRefreshResult(Success: true, await LoadPlanItemsAsync(plan, isRefresh: true));
		}
		return new PlanRefreshResult(Success: false);
	}

	public Task<IList<PCOAttachmentDetails>> DownloadFilesAsync(PCOPlan plan, Action<string> displayStatusMessage)
	{
		return DownloadFilesAsync(plan.PlanItems, displayStatusMessage);
	}

	public async Task<IList<PCOAttachmentDetails>> DownloadFilesAsync(PCOItem[]? planItems, Action<string> displayStatusMessage)
	{
		List<PCOAttachmentDetails> downloadedFiles = new List<PCOAttachmentDetails>();
		if (planItems != null)
		{
			foreach (PCOItem pcoItem in planItems)
			{
				PCOAttachmentDetails downloadableContent = GetDownloadableContent(pcoItem);
				if (downloadableContent != null)
				{
					displayStatusMessage(downloadableContent.Filename);
					await DownloadFileAsync(downloadableContent);
					if ((object)downloadableContent.LocalDownloadPath != null)
					{
						downloadedFiles.Add(downloadableContent);
					}
				}
			}
		}
		displayStatusMessage(string.Empty);
		return downloadedFiles;
	}

	public async Task<DateTime?> GetLastUpdateTimeForPlanAsync(string serviceID, string planID)
	{
		RestRequest request = new RestRequest($"/services/v2/service_types/{serviceID}/plans/{planID}");
		request.AddQueryParameter("fields[Plan]", "updated_at");
		return (await ExecuteGetWithErrorHandlingAsync<EncodedData<PlanData>>(request))?.Data?.Attributes?.UpdatedAt;
	}

	private static PCOAttachmentDetails? GetDownloadableContent(PCOItem pcoItem)
	{
		PCOAttachmentDetails downloadableAsset = null;
		PCOPlanSong planSong = pcoItem as PCOPlanSong;
		if (planSong != null)
		{
			IEnumerable<PCOAttachmentDetails> enumerable = planSong.Song?.Attachments.Where((PCOAttachmentDetails a) => a.Filename.IsProDocumentFile()).OrderByDescending((PCOAttachmentDetails a) => a.Filename, new ProVersionComparer()).Concat(planSong.Attachments.Where((PCOAttachmentDetails a) => a.Filename.IsProDocumentFile() && a.SongID == planSong.SongID).OrderByDescending((PCOAttachmentDetails a) => a.Filename, new ProVersionComparer()));
			IEnumerable<PCOAttachmentDetails> source = from a in pcoItem.Media.SelectMany((PCOMediaDetails m) => m.Attachments).Concat(pcoItem.Attachments)
				where a.Filename.IsMediaFile()
				select a;
			downloadableAsset = enumerable?.FirstOrDefault() ?? source.FirstOrDefault();
		}
		if (downloadableAsset == null && pcoItem.Media.Any())
		{
			pcoItem.Media.ForEach(delegate(PCOMediaDetails media)
			{
				DateTime? runningDate = null;
				media.Attachments.ForEach(delegate(PCOAttachmentDetails attachment)
				{
					if (!runningDate.HasValue || runningDate < attachment.UpdatedAt)
					{
						downloadableAsset = attachment;
						runningDate = media.UpdatedAt;
					}
				});
			});
		}
		if (downloadableAsset == null && pcoItem.Attachments.Any())
		{
			DateTime? runningDate2 = null;
			pcoItem.Attachments.ForEach(delegate(PCOAttachmentDetails attachment)
			{
				if (!runningDate2.HasValue || runningDate2 < attachment.UpdatedAt)
				{
					downloadableAsset = attachment;
					runningDate2 = attachment.UpdatedAt;
				}
			});
		}
		return downloadableAsset;
	}

	public async Task DownloadFileAsync(PCOAttachmentDetails file)
	{
		if (!string.IsNullOrWhiteSpace(file.Filename))
		{
			string remoteDownloadURL = file.RemoteDownloadURL;
			file.LocalDownloadPath = new RelativePath(Path.Combine(CommonPaths.Temp, file.Filename));
			RestRequest request = new RestRequest(remoteDownloadURL);
			EncodedData<AttachmentActivityData> encodedData = await ExecutePostWithErrorHandlingAsync<EncodedData<AttachmentActivityData>>(request);
			if (encodedData != null && encodedData.Data != null)
			{
				await DownloadFileAsync(encodedData.Data.Attributes?.AttachmentUrl ?? string.Empty, file.LocalDownloadPath);
			}
		}
	}

	private async Task DownloadFileAsync(string targetURL, string destinationPath)
	{
		if (string.IsNullOrWhiteSpace(targetURL))
		{
			return;
		}
		RestRequest request = new RestRequest(targetURL);
		using IRestClient client = _restClientFactory.Get();
		_ = 1;
		try
		{
			using Stream responseStream = await client.DownloadStreamAsync(request);
			using FileStream file = File.Create(destinationPath);
			if (responseStream != null && file != null)
			{
				await responseStream.CopyToAsync(file);
			}
		}
		catch (Exception ex)
		{
			_logger.Error("[{0}] Failed to download file:\n{1}", GetType().Name, ex);
		}
	}

	public async Task UploadFilesAsync(IEnumerable<PCOUpdateInformation> updateRequests, Action<string> displayStatusMessage, Action<PCOUpdateInformation, bool, PCOItem?>? onUploadRequestComplete = null)
	{
		if (IsAuthorized)
		{
			foreach (PCOUpdateInformation request in updateRequests)
			{
				string fileName = Path.GetFileName(request.FileAttachmentPath);
				fileName.ThrowWhenNull("fileName");
				displayStatusMessage(fileName);
				using IRestClient client = GetClient();
				PCOItem pCOItem = await new PcoFileUploadOperation(request, client, this).ExecuteAsync();
				onUploadRequestComplete?.Invoke(request, pCOItem != null, pCOItem);
			}
			displayStatusMessage(string.Empty);
		}
		else
		{
			await RequestPcoLogin();
		}
	}

	public void ReloadOrganizationData()
	{
		if (IsAuthorized)
		{
			_asyncExecutor.ExecuteAsync(LoadOrganizationDataAsync);
		}
	}

	private IRestClient GetClient()
	{
		return _restClientFactory.Get(delegate(RestClientOptions options)
		{
			options.BaseUrl = new Uri("https://api.planningcenteronline.com");
			options.Authenticator = _authenticator;
		}, delegate(SerializerConfig serializationOptions)
		{
			serializationOptions.UseSystemTextJson(_serializerOptions);
		});
	}

	private async Task LoadUserAndOrganizationDataAsync()
	{
		Task task = LoadUserDataAsync();
		Task task2 = LoadOrganizationDataAsync();
		global::_003C_003Ey__InlineArray2<Task> buffer = default(global::_003C_003Ey__InlineArray2<Task>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task>, Task>(ref buffer, 0) = task;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task>, Task>(ref buffer, 1) = task2;
		await Task.WhenAll(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<Task>, Task>(in buffer, 2));
	}

	private async Task LoadUserDataAsync()
	{
		RestRequest request = new RestRequest("/people/v2/me");
		EncodedData<PersonData> encodedData = await ExecuteGetWithErrorHandlingAsync<EncodedData<PersonData>>(request);
		if (encodedData != null && encodedData.Data != null)
		{
			Username = encodedData.Data.Attributes?.Name ?? string.Empty;
		}
	}

	private async Task LoadOrganizationDataAsync()
	{
		RestRequest request = new RestRequest("/services/v2");
		Task<EncodedData<OrganizationData>?> getOrganizationDataTask = ExecuteGetWithErrorHandlingAsync<EncodedData<OrganizationData>>(request);
		Task<(IList<FolderData> Data, IDictionary<string, PcoData> Inclusions)> getFolderDataTask = LoadListDataAsync<FolderData>((int offset) => AppendQueries("/services/v2/folders", "order=name", "per_page=500", $"offset={offset}"));
		Task<(IList<ServiceTypeData> Data, IDictionary<string, PcoData> Inclusions)> getServiceTypesTask = LoadListDataAsync<ServiceTypeData>((int offset) => AppendQueries("/services/v2/service_types", "order=name", "per_page=500", $"offset={offset}"));
		global::_003C_003Ey__InlineArray3<Task> buffer = default(global::_003C_003Ey__InlineArray3<Task>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<Task>, Task>(ref buffer, 0) = getOrganizationDataTask;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<Task>, Task>(ref buffer, 1) = getFolderDataTask;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<Task>, Task>(ref buffer, 2) = getServiceTypesTask;
		await Task.WhenAll(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray3<Task>, Task>(in buffer, 3));
		LoadOrganizationData(getOrganizationDataTask.Result?.Data, getFolderDataTask.Result.Data, getServiceTypesTask.Result.Data);
	}

	private Task<T?> ExecuteGetWithErrorHandlingAsync<T>(RestRequest request) where T : notnull
	{
		return ExecuteWithErrorHandlingAsync<T>(request, RestSharp.Method.Get);
	}

	private Task<T?> ExecutePostWithErrorHandlingAsync<T>(RestRequest request) where T : notnull
	{
		return ExecuteWithErrorHandlingAsync<T>(request, RestSharp.Method.Post);
	}

	private async Task<T?> ExecuteWithErrorHandlingAsync<T>(RestRequest request, RestSharp.Method method) where T : notnull
	{
		using IRestClient client = GetClient();
		try
		{
			RestResponse<T> restResponse = await client.ExecuteAsync<T>(request, method);
			if (restResponse.IsSuccessful)
			{
				return restResponse.Data;
			}
			_logger.Warning("[{0}] Failed to {4} resource {1}. Returned status code: {2}, returned data: {3}", "PCOConsumer", request.Resource, restResponse.StatusCode, restResponse.Content, method);
		}
		catch (Exception ex)
		{
			_logger.Warning("[{0}] Failed to {3} resource {1}. Exception was thrown:{2}", "PCOConsumer", request.Resource, ex, method);
		}
		return default(T);
	}

	private async Task RequestPcoLogin()
	{
		if (RequestPCOLogin != null)
		{
			await RequestPCOLogin();
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsAuthorizedChanged(bool value)
	{
		if (!value)
		{
			this.Deauthorized?.Invoke();
		}
		else
		{
			_asyncExecutor.ExecuteAsync(LoadUserAndOrganizationDataAsync);
		}
	}
}
