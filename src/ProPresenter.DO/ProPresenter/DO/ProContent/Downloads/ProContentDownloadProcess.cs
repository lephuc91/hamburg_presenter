using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Downloads;
using Pro.Common.Nullability;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.ProContent.Consumer.Model.Download;
using ProPresenter.DO.ProContent.Consumer.Model.Result;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.ProContent.Downloads;

public class ProContentDownloadProcess : IProContentDownloadProcess, IProContentDownloadDataRefresher
{
	private readonly IProContentConsumer _consumer;

	private readonly IProContentDownloadFailedDialogService _dialogService;

	private readonly IProPresenterResourceService _resources;

	private readonly IApp _app;

	private readonly IDownloadItemFactory _downloadItemFactory;

	private readonly IDownloadManager _downloadManager;

	private readonly IProContentAnalyticEventsPublisher _analyticEvents;

	private readonly IFileDownloadObserverFactory? _fileDownloadObserverFactory;

	private readonly Action<IDownloadObserverCallbackData>? _importCallback;

	public ProContentDownloadProcess(IProContentConsumer consumer, IProContentDownloadFailedDialogService dialogService, IProPresenterResourceService resources, IApp app, IDownloadItemFactory downloadItemFactory, IDownloadManager downloadManager, IProContentAnalyticEventsPublisher analyticEvents, IFileDownloadObserverFactory? fileDownloadObserverFactory, Action<IDownloadObserverCallbackData>? importCallback = null)
	{
		_consumer = consumer;
		_dialogService = dialogService;
		_resources = resources;
		_app = app;
		_downloadItemFactory = downloadItemFactory;
		_downloadManager = downloadManager;
		_analyticEvents = analyticEvents;
		_fileDownloadObserverFactory = fileDownloadObserverFactory;
		_importCallback = importCallback;
	}

	public async Task StartDownloadAsync(IProContentDownloadInfo downloadInfo)
	{
		_fileDownloadObserverFactory.ThrowWhenNull("_fileDownloadObserverFactory");
		_analyticEvents?.Download(isRetry: false);
		DownloadAssets downloadAssets = await GetDownloadAssets(downloadInfo.Format.Id);
		if (!(downloadAssets != null) || !(downloadInfo.TargetPlaylist is VisualPlaylist playlist))
		{
			return;
		}
		IEnumerable<ProContentFileDownload> enumerable = Filter(downloadAssets.Assets, downloadInfo);
		playlist.InsertPlaylist(_resources.VisualPlaylists, _app.SelectedMediaPlaylist);
		foreach (ProContentFileDownload item in enumerable)
		{
			IFileDownloadObserver? fileDownloadObserver = _fileDownloadObserverFactory.CreateForProContent(item, playlist, _importCallback);
			IDownloadItem downloadItem = DoDownload(item);
			fileDownloadObserver?.Observe(downloadItem);
		}
	}

	public async Task StartDownloadAsync(string identifier)
	{
		ProContentFileDownload proContentFileDownload = await RefreshDownloadData(identifier);
		if ((object)proContentFileDownload != null)
		{
			DoDownload(proContentFileDownload);
		}
	}

	public async Task<ProContentFileDownload?> RefreshDownloadData(ProContentFileDownload request)
	{
		_analyticEvents?.Download(isRetry: true);
		return await RefreshDownloadData(request.AssetIdentifier);
	}

	private IDownloadItem DoDownload(ProContentFileDownload downloadInfo)
	{
		IDownloadItem orAdd = _downloadManager.GetOrAdd((IDownloadItem i) => IsMatch(i, downloadInfo), () => _downloadItemFactory.Create(downloadInfo, this));
		if (orAdd.Status == DownloadStatus.Stopped)
		{
			orAdd.Retry();
		}
		return orAdd;
	}

	private async Task<ProContentFileDownload?> RefreshDownloadData(string identifier)
	{
		FileDownload fileDownload = (await GetDownloadAssets(identifier))?.Assets.FirstOrDefault() ?? null;
		return (fileDownload == null) ? null : ProContentFileDownload.FromFileDownload(fileDownload);
	}

	private async Task<DownloadAssets?> GetDownloadAssets(string id)
	{
		IRequestResult requestResult = await _consumer.GetDownloadDataAsync(id);
		if (!(requestResult is ErrorResult) && !(requestResult is RedirectResult))
		{
			if (requestResult is SuccessResult<DownloadAssets> successResult)
			{
				return successResult.Data;
			}
		}
		else
		{
			_dialogService.Show(requestResult);
		}
		return null;
	}

	private static bool IsMatch(IDownloadItem item, ProContentFileDownload download)
	{
		if (item is IProContentDownloadItem proContentDownloadItem)
		{
			return proContentDownloadItem.MatchesActiveDownload(download);
		}
		return false;
	}

	private static IEnumerable<ProContentFileDownload> Filter(IEnumerable<FileDownload> downloads, IProContentDownloadInfo downloadInfo)
	{
		return from d in downloads.Select(ProContentFileDownload.FromFileDownload)
			where downloadInfo.AssetTypesToDownload.HasFlag(d.AssetType)
			select d;
	}
}
