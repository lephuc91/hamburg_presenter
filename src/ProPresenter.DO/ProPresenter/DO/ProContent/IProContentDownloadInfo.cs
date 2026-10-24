using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.DO.ProContent;

public interface IProContentDownloadInfo
{
	IProContentFormat Format { get; }

	IPlaylist<MediaCue> TargetPlaylist { get; }

	ProContentDownloadAssetType AssetTypesToDownload { get; }
}
