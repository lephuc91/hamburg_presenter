using System;
using ProPresenter.DO.ProContent.Consumer.Model.Download;

namespace ProPresenter.DO.ProContent.Model.Download;

public record ProContentFileDownload(string DisplayName, string RelativePath, Uri DownloadUrl, Uri ThumbnailUrl, ProContentDownloadAssetType AssetType, string AssetIdentifier)
{
	public static ProContentFileDownload FromFileDownload(FileDownload fileDownload)
	{
		return new ProContentFileDownload(fileDownload.DisplayName, fileDownload.RelativePath, fileDownload.DownloadUrl, fileDownload.ThumbnailUrl, fileDownload.AssetType.ToDownloadAssetType(), fileDownload.AssetIdentifier);
	}
}
