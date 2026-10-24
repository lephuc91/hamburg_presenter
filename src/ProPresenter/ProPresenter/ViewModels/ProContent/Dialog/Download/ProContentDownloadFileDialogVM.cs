using System.Collections.Generic;
using Pro.Common.Animation;
using ProPresenter.DO;
using ProPresenter.DO.Cache;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.ViewModels.ProContent.Dialog.Download;

public class ProContentDownloadFileDialogVM : ProContentDownloadDialogWithThumbnailVMBase, IProContentDownloadFileDialogVM, IProContentDownloadDialogWithThumbnailVM, IProContentDownloadDialogVM
{
	public ProContentDownloadFileDialogVM(IProPresenterResourceService resources, IApp app, IUriCacheService<NullableBitmapSource> thumbnailCacheService, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService, IProContentDownloadableAsset downloadableAsset)
		: base(resources, app, thumbnailCacheService, previewCacheService, downloadableAsset)
	{
	}
}
