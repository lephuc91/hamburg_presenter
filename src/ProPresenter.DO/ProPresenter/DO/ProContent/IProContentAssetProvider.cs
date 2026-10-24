using System;
using System.Threading.Tasks;

namespace ProPresenter.DO.ProContent;

public interface IProContentAssetProvider
{
	Task StartDownloadAssetAsync(string assetId);

	Uri GetAssetThumbnailUrl(string assetFormatId);
}
