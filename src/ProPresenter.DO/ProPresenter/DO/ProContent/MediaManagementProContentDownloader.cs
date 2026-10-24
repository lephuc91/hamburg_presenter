using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V2;
using Pro.DO;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.ProContent.Consumer.Model.Download;
using ProPresenter.DO.ProContent.Consumer.Model.Result;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.ProContent;

public class MediaManagementProContentDownloader : ProContentDownloaderBase
{
	private readonly IApp _app;

	private readonly IProContentUserInteractionBehavior _userInteractionBehavior;

	private readonly IProContentConsumer _consumer;

	private readonly IProContentDownloadFailedDialogService _downloadFailedDialogService;

	private readonly IMediaServiceV2 _mediaService;

	private readonly ILogger _logger;

	private readonly IProContentAnalyticEventsPublisher _analyticEvents;

	private readonly IProPresenterResourceService _resources;

	private readonly IFileSystem _fileSystem;

	private readonly IImport _import;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public MediaManagementProContentDownloader(IApp app, IProContentDialogService dialogService, IProContentUserInteractionBehavior userInteractionBehavior, IProContentConsumer consumer, IProContentDownloadFailedDialogService downloadFailedDialogService, IMediaServiceV2 mediaService, ILogger logger, IProContentAnalyticEventsPublisher analyticEvents, IProPresenterResourceService resources, IFileSystem fileSystem, IImport import, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
		: base(dialogService)
	{
		_app = app;
		_userInteractionBehavior = userInteractionBehavior;
		_consumer = consumer;
		_downloadFailedDialogService = downloadFailedDialogService;
		_mediaService = mediaService;
		_logger = logger;
		_analyticEvents = analyticEvents;
		_resources = resources;
		_fileSystem = fileSystem;
		_import = import;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
	}

	protected override async Task DownloadAssetAsync(IProContentAsset? asset)
	{
		if (asset is IProContentDownloadableAsset toDownload2)
		{
			await _userInteractionBehavior.ExecuteDownloadAsync((IProContentDownloadableAsset asset) => GetDownloadInfo(asset), (IProContentDownloadInfo toDownload) => DoDownloadWithMediaManagement(toDownload), toDownload2);
		}
	}

	protected override async Task DownloadCollectionAsync(IProContentCollection? collection)
	{
		IProContentDownloadableCollection downloadableCollection = collection as IProContentDownloadableCollection;
		if (downloadableCollection != null)
		{
			await _userInteractionBehavior.ExecuteDownloadAsync((IProContentDownloadableCollection asset) => GetDownloadInfo(downloadableCollection), (IProContentDownloadInfo toDownload) => DoDownloadWithMediaManagement(toDownload), downloadableCollection);
		}
	}

	public override async Task ImportAssetAsync(IProContentDownloadableAsset asset, VisualPlaylist? playlist, Action<IDownloadObserverCallbackData>? importCallback = null)
	{
		IProContentDownloadInfo downloadInfo = GetDownloadInfo(asset, playlist);
		if (downloadInfo != null)
		{
			await DoDownloadWithMediaManagement(downloadInfo, importCallback);
		}
	}

	private async Task DoDownloadWithMediaManagement(IProContentDownloadInfo downloadInfo, Action<IDownloadObserverCallbackData>? importCallback = null)
	{
		IPlaylist<MediaCue> targetPlaylist = downloadInfo.TargetPlaylist;
		if (!(targetPlaylist is VisualPlaylist playlist) || _mediaService == null)
		{
			return;
		}
		IRequestResult requestResult = await _consumer.GetDownloadDataAsync(downloadInfo.Format.Id);
		if (!(requestResult is SuccessResult<DownloadAssets> successResult))
		{
			_downloadFailedDialogService.Show(requestResult);
			return;
		}
		playlist.InsertPlaylist(_resources.VisualPlaylists, _app.SelectedMediaPlaylist);
		IEnumerable<FileDownload> enumerable = successResult.Data.Assets.Where((FileDownload x) => downloadInfo.AssetTypesToDownload.HasFlag(x.AssetType.ToDownloadAssetType()));
		foreach (FileDownload asset in enumerable)
		{
			MediaCue mediaCue = CreateMediaCue(ProContentFileDownload.FromFileDownload(asset), _fileSystem, _import, _app, _mediaFactory, _transitionDescriptions, downloadInfo.TargetPlaylist.ContainerId);
			if (mediaCue?.MediaAction?.FileMedia == null)
			{
				_logger.Error("Failed to create media action for {0}", asset.AssetIdentifier);
				continue;
			}
			string containerId = MediaContainerIds.Playlist(playlist.ID);
			if (mediaCue.MediaAction.Media is ITrackedMedia trackedMedia)
			{
				trackedMedia.UpdateContainerId(containerId);
			}
			if (await _mediaService.AddProContentReference(new AddProContentReference
			{
				Id = new ReferenceIdentifier
				{
					Uuid = mediaCue.MediaAction.FileMedia.ID.ToString(),
					ContainerId = containerId
				},
				Priority = Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Priority.UserInitiated,
				DownloadDetails = new ProContentDownloadDetails
				{
					AssetIdentifier = asset.AssetIdentifier,
					DisplayName = asset.DisplayName,
					AssetType = asset.AssetType.ToProtoAssetType(),
					DownloadUrl = asset.DownloadUrl.ToString(),
					ThumbnailUrl = asset.ThumbnailUrl.ToString(),
					RelativePath = asset.RelativePath.ToString()
				}
			}) is MediaServiceV2ErrorResponse<Pro.SerializationInterop.RVProtoData.MediaManagement.v1.RequestError> mediaServiceV2ErrorResponse)
			{
				_logger.Error("Failed to add media content reference with error {0} - {1}", mediaServiceV2ErrorResponse.Error.Code, asset.DisplayName);
			}
			else
			{
				_analyticEvents.Download(isRetry: false);
				playlist.AddItem(mediaCue);
				importCallback?.Invoke(new ProContentDownloadObserveCallbackData((MediaCue)mediaCue.Clone()));
			}
		}
	}

	private static MediaCue? CreateMediaCue(ProContentFileDownload fileDownload, IFileSystem fileSystem, IImport import, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		string text = CreateProContentFileDestination(fileDownload.RelativePath, fileSystem);
		if (!text.IsVisualMediaFile())
		{
			return null;
		}
		ProContentDownloadAssetType assetType = fileDownload.AssetType;
		string fileNameWithoutExtension = fileSystem.Path.GetFileNameWithoutExtension(text);
		MediaCue mediaCue = new MediaCue(new MediaAction(mediaFactory.CreateEmptyFileMedia(text, containerId, null), app, transitionDescriptions))
		{
			Name = fileNameWithoutExtension
		};
		ProContentDownloadAssetType proContentDownloadAssetType = assetType;
		ProContentDownloadAssetType proContentDownloadAssetType2 = proContentDownloadAssetType;
		if (proContentDownloadAssetType2.HasFlag(ProContentDownloadAssetType.Loop))
		{
			if (mediaCue.MediaAction != null)
			{
				mediaCue.MediaAction.TriggerLayer = TriggerLayer.Background;
				if (mediaCue.MediaAction.VideoMedia != null)
				{
					mediaCue.MediaAction.VideoMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
					mediaCue.MediaAction.VideoMedia.Drawing.ScaleBehavior = ScaleBehavior.ScaleToFill;
				}
			}
		}
		else
		{
			ProContentDownloadAssetType proContentDownloadAssetType3 = proContentDownloadAssetType;
			if (proContentDownloadAssetType3.HasFlag(ProContentDownloadAssetType.Countdown))
			{
				if (mediaCue.MediaAction != null)
				{
					mediaCue.MediaAction.TriggerLayer = TriggerLayer.Foreground;
					if (mediaCue.MediaAction.VideoMedia != null)
					{
						mediaCue.MediaAction.VideoMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
						mediaCue.MediaAction.VideoMedia.Drawing.ScaleBehavior = ScaleBehavior.ScaleToFill;
					}
				}
			}
			else
			{
				import.ApplyImportSettings(mediaCue);
			}
		}
		mediaCue.MediaAction?.FileMedia?.UpdateSource(userInitiated: true, new RelativePath(text));
		if (mediaCue.MediaAction?.Media is IFileMedia fileMedia)
		{
			fileMedia.File.RemoteProperties = new ProContentFileProperties(fileDownload.AssetIdentifier, fileDownload.DisplayName, fileDownload.DownloadUrl.ToString(), fileDownload.ThumbnailUrl.ToString(), fileDownload.RelativePath, fileDownload.AssetType);
		}
		return mediaCue;
	}

	private static string CreateProContentFileDestination(string relativePath, IFileSystem fileSystem)
	{
		relativePath = relativePath.TrimStart(fileSystem.Path.DirectorySeparatorChar, fileSystem.Path.AltDirectorySeparatorChar);
		return fileSystem.Path.Combine(CommonPaths.ProContentAssets, relativePath);
	}
}
