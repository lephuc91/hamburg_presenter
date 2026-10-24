using System;
using System.Linq;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.ViewModels.ProContent.Dialog.Download;

public class ProContentDownloadInfo : IProContentDownloadInfo
{
	public IProContentFormat Format { get; }

	public IPlaylist<MediaCue> TargetPlaylist { get; }

	public ProContentDownloadAssetType AssetTypesToDownload { get; }

	public ProContentDownloadInfo(IProContentFormat format, IPlaylist<MediaCue> targetPlaylist)
		: this(format, targetPlaylist, (ProContentDownloadAssetType)(-1))
	{
	}

	public ProContentDownloadInfo(IProContentFormat format, IPlaylist<MediaCue> targetPlaylist, ProContentDownloadAssetType assetTypesToDownload)
	{
		Format = format;
		TargetPlaylist = targetPlaylist;
		AssetTypesToDownload = ((assetTypesToDownload == (ProContentDownloadAssetType)0) ? ((ProContentDownloadAssetType)Enum.GetValues<ProContentDownloadAssetType>().Aggregate(0, (int v, ProContentDownloadAssetType newValue) => v | (int)newValue)) : assetTypesToDownload);
	}
}
