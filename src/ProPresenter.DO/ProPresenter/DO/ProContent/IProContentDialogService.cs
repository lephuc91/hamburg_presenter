using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent;

public interface IProContentDialogService
{
	IProContentDownloadInfo? Show(IProContentPackAsset asset, VisualPlaylist? defautSelected = null);

	IProContentDownloadInfo? Show(IProContentDownloadableAsset asset, VisualPlaylist? defautSelected = null);

	IProContentDownloadInfo? Show(IProContentDownloadableCollection collection, VisualPlaylist? defautSelected = null);
}
