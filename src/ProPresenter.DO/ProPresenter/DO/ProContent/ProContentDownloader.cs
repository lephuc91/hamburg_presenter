using System;
using System.Threading.Tasks;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Downloads;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent;

public class ProContentDownloader : ProContentDownloaderBase
{
	private readonly IProContentUserInteractionBehavior _userInteractionBehavior;

	private readonly IProContentDownloadProcessFactory _processFactory;

	public ProContentDownloader(IProContentDialogService dialogService, IProContentUserInteractionBehavior userInteractionBehavior, IProContentDownloadProcessFactory processFactory)
		: base(dialogService)
	{
		_userInteractionBehavior = userInteractionBehavior;
		_processFactory = processFactory;
	}

	protected override async Task DownloadAssetAsync(IProContentAsset? asset)
	{
		if (asset is IProContentDownloadableAsset toDownload2)
		{
			await _userInteractionBehavior.ExecuteDownloadAsync((IProContentDownloadableAsset asset) => GetDownloadInfo(asset), (IProContentDownloadInfo toDownload) => DoDownloadAsync(toDownload), toDownload2);
		}
	}

	protected override async Task DownloadCollectionAsync(IProContentCollection? collection)
	{
		IProContentDownloadableCollection downloadableCollection = collection as IProContentDownloadableCollection;
		if (downloadableCollection != null)
		{
			await _userInteractionBehavior.ExecuteDownloadAsync((IProContentDownloadableCollection asset) => GetDownloadInfo(downloadableCollection), (IProContentDownloadInfo toDownload) => DoDownloadAsync(toDownload), downloadableCollection);
		}
	}

	public override async Task ImportAssetAsync(IProContentDownloadableAsset asset, VisualPlaylist? playlist, Action<IDownloadObserverCallbackData>? importCallback = null)
	{
		await _userInteractionBehavior.ExecuteDownloadAsync((IProContentDownloadableAsset asset) => GetDownloadInfo(asset, playlist), (IProContentDownloadInfo toDownload) => DoDownloadAsync(toDownload, importCallback), asset);
	}

	private async Task DoDownloadAsync(IProContentDownloadInfo downloadInfo, Action<IDownloadObserverCallbackData>? importCallback = null)
	{
		await _processFactory.Create(importCallback).StartDownloadAsync(downloadInfo);
	}
}
