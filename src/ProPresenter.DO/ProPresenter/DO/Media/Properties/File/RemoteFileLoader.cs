using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ProPresenter.DO.Cache;
using ProPresenter.DO.ProContent;

namespace ProPresenter.DO.Media.Properties.File;

public class RemoteFileLoader : IRemoteFileLoader
{
	private readonly IUriCacheService<NullableBitmapSource> _thumbnailCacheService;

	private readonly IProContentAssetProvider _proContentProvider;

	public RemoteFileLoader(IUriCacheService<NullableBitmapSource> thumbnailCacheService, IProContentAssetProvider proContentProvider)
	{
		_thumbnailCacheService = thumbnailCacheService;
		_proContentProvider = proContentProvider;
	}

	public async Task<BitmapSource?> LoadThumbnailAsync(IRemoteFileProperties remoteFile)
	{
		if (remoteFile is ProContentFileProperties proContentFileProperties)
		{
			Uri assetThumbnailUrl = _proContentProvider.GetAssetThumbnailUrl(proContentFileProperties.DownloadId);
			return await _thumbnailCacheService.GetAsync(assetThumbnailUrl);
		}
		return null;
	}

	public async Task StartDownloadAsync(IRemoteFileProperties remoteFile)
	{
		if (remoteFile is ProContentFileProperties proContentFileProperties)
		{
			await _proContentProvider.StartDownloadAssetAsync(proContentFileProperties.DownloadId);
		}
	}
}
