using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent;

public interface IProContentDownloader
{
	IAsyncRelayCommand<IProContentAsset> DownloadAssetCommand { get; }

	IAsyncRelayCommand<IProContentCollection> DownloadCollectionCommand { get; }

	Task ImportAssetAsync(IProContentDownloadableAsset asset, VisualPlaylist? playlist, Action<IDownloadObserverCallbackData>? importCallback = null);
}
