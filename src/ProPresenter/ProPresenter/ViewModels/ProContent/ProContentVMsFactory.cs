using System.Collections.Generic;
using Pro.Common.Animation;
using Pro.Common.Time.Timer;
using Pro.Localization.Services;
using ProPresenter.DO.Cache;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.DO.ProContent.Model.Group;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;
using ProPresenter.UI.ViewModels.ProContent.Group;
using ProPresenter.ViewModels.ProContent.Asset;
using ProPresenter.ViewModels.ProContent.Collection;
using ProPresenter.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent;

public class ProContentVMsFactory : IProContentVMsFactory
{
	private readonly IUriCacheService<NullableBitmapSource> _thumbnailCacheService;

	private readonly IUriCacheService<IReadOnlyList<IAnimationFrame>> _previewCacheService;

	private readonly IProContentProvider _provider;

	private readonly IProContentDownloader _downloader;

	private readonly ILocalization _localization;

	private readonly ITimerFactory _timerFactory;

	public ProContentVMsFactory(IUriCacheService<NullableBitmapSource> thumbnailCacheService, IProContentProvider provider, IProContentDownloader downloader, ILocalization localization, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService, ITimerFactory timerFactory)
	{
		_thumbnailCacheService = thumbnailCacheService;
		_previewCacheService = previewCacheService;
		_provider = provider;
		_downloader = downloader;
		_localization = localization;
		_timerFactory = timerFactory;
	}

	public IProContentGroupVM CreateGroup(IProContentGroup group, INavigationItem parent)
	{
		if (group is IProContentSearchGroup searchGroup)
		{
			return new ProContentSearchGroupVM(_provider, searchGroup, parent, this, _timerFactory);
		}
		return new ProContentGroupVM(group, parent, this);
	}

	public IProContentAssetVM CreateAsset(IProContentAsset asset, IProContentGroupVM group)
	{
		if (asset is IProContentPackAsset asset2)
		{
			return new ProContentPackAssetVM(asset2, group, _downloader, _thumbnailCacheService, _localization, _previewCacheService);
		}
		return new ProContentAssetVM(asset, group, _downloader, _thumbnailCacheService, _previewCacheService);
	}

	public IProContentCollectionVM CreateCollection(IProContentCollection collection, IProContentGroupVM group)
	{
		return new ProContentCollectionVM(collection, group, _provider, _downloader, this);
	}
}
