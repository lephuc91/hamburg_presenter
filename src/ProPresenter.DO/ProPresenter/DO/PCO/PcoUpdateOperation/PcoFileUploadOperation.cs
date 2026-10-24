using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.Time;
using ProPresenter.DO.PCO.PcoUpdateOperation.ItemCreator;
using ProPresenter.DO.PCO.RemoteDataModel;
using ProPresenter.DO.PCO.RemoteDataModel.Files.File;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Attachment;
using ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Song;
using RestSharp;

namespace ProPresenter.DO.PCO.PcoUpdateOperation;

public class PcoFileUploadOperation : IPcoUpdateOperation
{
	private readonly PCOUpdateInformation _updateInformation;

	private readonly IRestClient _restClient;

	private readonly IPcoItemFactory _pcoItemFactory;

	public PcoFileUploadOperation(PCOUpdateInformation updateInfo, IRestClient restClient, IPcoItemFactory pcoItemFactory)
	{
		_updateInformation = updateInfo;
		_restClient = restClient;
		_pcoItemFactory = pcoItemFactory;
	}

	public async Task<PCOItem?> ExecuteAsync()
	{
		_ = 4;
		try
		{
			TimeSlice defaultTimeout = TimeSlice.FromSeconds(10.0);
			EncodedData<PlanItemData> itemResponse = await GetItemAsync();
			if (_updateInformation.FileAttachmentPath == null)
			{
				throw new NoNullAllowedException("FileAttachmentPath cannot be null");
			}
			await WaitForFileToGetWrittenToFileSystem(_updateInformation.FileAttachmentPath, defaultTimeout);
			if (!IsItemSong(itemResponse))
			{
				await CreateOrUpdateAttachmentAsync(GetItemAttachmentsEndpoint());
			}
			else
			{
				await CreateOrUpdateAttachmentAsync(GetSongAttachmentsEndpoint(GetSong(itemResponse)?.Id ?? string.Empty));
			}
			return await _pcoItemFactory.CreatePlanItemAsync(itemResponse?.Data, itemResponse?.Included.Where((PcoData i) => i.Id != null).ToDictionary(delegate(PcoData inclusion)
			{
				inclusion.Id.ThrowWhenNull("inclusion.Id");
				return inclusion.Id;
			}, (PcoData inclusion) => inclusion), _updateInformation.Item.ServiceId);
		}
		catch (Exception ex)
		{
			Log.Info("ExecuteAsync: " + ex.Message + " ignored on purpose");
		}
		return null;
	}

	private static async Task WaitForFileToGetWrittenToFileSystem(string fileAttachmentPath, TimeSlice timeout)
	{
		CancellationTokenSource cts = new CancellationTokenSource();
		cts.CancelAfter(timeout);
		CancellationToken token = cts.Token;
		await Task.Run(async delegate
		{
			while (!token.IsCancellationRequested && !File.Exists(fileAttachmentPath))
			{
				await Task.Delay(TimeSpan.FromSeconds(1L), token);
			}
		}, token);
		cts.Dispose();
	}

	private async Task<EncodedData<PlanItemData>?> GetItemAsync()
	{
		RestRequest request = new RestRequest(GetItemEndpoint()).AddQueryParameter("include", "song");
		return await _restClient.GetAsync<EncodedData<PlanItemData>>(request);
	}

	private static SongData? GetSong(EncodedData<PlanItemData> itemResponse)
	{
		string songId = itemResponse?.Data?.Relationships?.Song?.Data?.Id;
		if (string.IsNullOrEmpty(songId))
		{
			return null;
		}
		return itemResponse?.Included.OfType<SongData>().FirstOrDefault((SongData song) => song.Id == songId);
	}

	protected async Task<AttachmentData?> CreateOrUpdateAttachmentAsync(string attachmentsEndpoint)
	{
		FileData fileResponse = await UploadFileAsync();
		if (fileResponse != null)
		{
			AttachmentData attachmentData = await GetExistingAttachmentAsync(attachmentsEndpoint);
			if (attachmentData == null)
			{
				return await CreateNewAttachmentAsync(fileResponse, attachmentsEndpoint);
			}
			return await UpdateExistingAttachmentAsync(attachmentData, fileResponse);
		}
		return null;
	}

	private async Task<AttachmentData?> CreateNewAttachmentAsync(FileData fileResponse, string attachmentsEndpoint)
	{
		RestRequest request = new RestRequest(attachmentsEndpoint).AddJsonBody(GetAttachmentTransmissionData(fileResponse));
		return (await _restClient.PostAsync<EncodedData<AttachmentData>>(request))?.Data;
	}

	private async Task<AttachmentData?> UpdateExistingAttachmentAsync(AttachmentData existingAttachment, FileData fileResponse)
	{
		RestRequest request = new RestRequest(existingAttachment.GetLinkToSelf()).AddJsonBody(GetAttachmentTransmissionData(fileResponse));
		return (await _restClient.PatchAsync<EncodedData<AttachmentData>>(request))?.Data;
	}

	private static EncodedData<AttachmentData> GetAttachmentTransmissionData(FileData fileResponse)
	{
		return new EncodedData<AttachmentData>
		{
			Data = new AttachmentData
			{
				Attributes = new AttachmentAttributes
				{
					FileUploadIdentifier = fileResponse.Id,
					Filename = fileResponse.Attributes?.Name
				}
			}
		};
	}

	private async Task<AttachmentData?> GetExistingAttachmentAsync(string attachmentsEndpoint)
	{
		RestRequest request = new RestRequest(attachmentsEndpoint);
		return (await _restClient.GetAsync<EncodedData<AttachmentData[]>>(request))?.Data?.FirstOrDefault((AttachmentData a) => a.Attributes?.Filename == GetFileName());
	}

	protected async Task<FileData?> UploadFileAsync()
	{
		RestRequest request = new RestRequest(GetFileUploadEndpoint()).AddFile(GetFileName(), _updateInformation.FileAttachmentPath ?? string.Empty, null, new FileParameterOptions
		{
			DisableFilenameStar = false
		});
		return (await _restClient.PostAsync<FileUploadResponse>(request))?.Data?.FirstOrDefault();
	}

	private string GetItemEndpoint()
	{
		return $"/services/v2/service_types/{_updateInformation.Item.ServiceId}/plans/{_updateInformation.Item.PlanID}/items/{_updateInformation.Item.ID}";
	}

	private string GetItemAttachmentsEndpoint()
	{
		return GetItemEndpoint() + "/attachments";
	}

	private static string GetSongAttachmentsEndpoint(string id)
	{
		return "/services/v2/songs/" + id + "/attachments";
	}

	private static string GetFileUploadEndpoint()
	{
		return "https://upload.planningcenteronline.com/v2/files";
	}

	private static bool IsItemSong([NotNullWhen(true)] EncodedData<PlanItemData>? itemResponse)
	{
		if (itemResponse == null)
		{
			return false;
		}
		return itemResponse.Data?.Attributes?.ItemType == PlanItemType.Song;
	}

	private string GetFileName()
	{
		return Path.GetFileName(_updateInformation.FileAttachmentPath) ?? string.Empty;
	}
}
