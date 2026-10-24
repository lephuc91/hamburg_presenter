using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Animation;
using Pro.Localization.Services;
using ProPresenter.DO.Cache;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent.Asset;

public class ProContentPackAssetVM : ProContentAssetVM, IProContentPackAssetVM, IProContentAssetVM, INotifyPropertyChanged, IUniformViewSource
{
	public IProContentPackAsset PackAsset { get; }

	public int LoopCount => PackAsset.LoopCount;

	public int CountdownCount => PackAsset.CountdownCount;

	public int StillCount => PackAsset.ImageCount;

	public IReadOnlyList<IProContentPackAssetContainsVM> DownloadContainsTooltip { get; }

	public ProContentPackAssetVM(IProContentPackAsset asset, IProContentGroupVM containingGroup, IProContentDownloader downloader, IUriCacheService<NullableBitmapSource> thumbnailCacheService, ILocalization localization, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService)
		: base(asset, containingGroup, downloader, thumbnailCacheService, previewCacheService)
	{
		PackAsset = asset;
		DownloadContainsTooltip = asset.ToContains(localization);
	}
}
