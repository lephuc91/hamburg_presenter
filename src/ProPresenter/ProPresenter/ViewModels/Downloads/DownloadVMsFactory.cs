using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Localization.Services;
using ProPresenter.DO.Cache;
using ProPresenter.UI.ViewModels.Downloads;

namespace ProPresenter.ViewModels.Downloads;

public class DownloadVMsFactory : IDownloadVMsFactory
{
	private readonly ILocalization _localization;

	private readonly IUriCacheService<NullableBitmapSource> _thumbnailCacheService;

	private readonly IUiScheduler _uiScheduler;

	public DownloadVMsFactory(ILocalization localization, IUriCacheService<NullableBitmapSource> thumbnailCacheService, IUiScheduler uiScheduler)
	{
		_localization = localization;
		_thumbnailCacheService = thumbnailCacheService;
		_uiScheduler = uiScheduler;
	}

	public IDownloadItemVM Create(IDownloadItem item)
	{
		return new DownloadItemVM(item, _localization, _thumbnailCacheService, _uiScheduler);
	}
}
