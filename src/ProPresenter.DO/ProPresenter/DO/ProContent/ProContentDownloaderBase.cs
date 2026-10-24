using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent;

public abstract class ProContentDownloaderBase : IProContentDownloader
{
	public IAsyncRelayCommand<IProContentAsset> DownloadAssetCommand { get; }

	public IAsyncRelayCommand<IProContentCollection> DownloadCollectionCommand { get; }

	protected IProContentDialogService DialogService { get; }

	protected ProContentDownloaderBase(IProContentDialogService dialogService)
	{
		DialogService = dialogService;
		DownloadAssetCommand = new AsyncRelayCommand<IProContentAsset>(DownloadAssetAsync, CanDownloadAsset);
		DownloadCollectionCommand = new AsyncRelayCommand<IProContentCollection>(DownloadCollectionAsync, CanDownloadCollection);
	}

	public abstract Task ImportAssetAsync(IProContentDownloadableAsset asset, VisualPlaylist? playlist, Action<IDownloadObserverCallbackData>? importCallback = null);

	protected abstract Task DownloadAssetAsync(IProContentAsset? asset);

	private static bool CanDownloadAsset(IProContentAsset? asset)
	{
		return asset is IProContentDownloadableAsset;
	}

	protected abstract Task DownloadCollectionAsync(IProContentCollection? collection);

	private static bool CanDownloadCollection(IProContentCollection? collection)
	{
		return collection is IProContentDownloadableCollection;
	}

	protected IProContentDownloadInfo? GetDownloadInfo(IProContentDownloadableAsset asset, VisualPlaylist? playlist = null)
	{
		if (!(asset is IProContentPackAsset asset2))
		{
			return DialogService.Show(asset, playlist);
		}
		return DialogService.Show(asset2, playlist);
	}

	protected IProContentDownloadInfo? GetDownloadInfo(IProContentDownloadableCollection collection)
	{
		return DialogService.Show(collection);
	}
}
