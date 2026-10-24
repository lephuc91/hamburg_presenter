using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Pro.Common.Animation;
using Pro.Common.Cache;

namespace ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

public interface IProContentDownloadDialogWithThumbnailVM : IProContentDownloadDialogVM
{
	IAsyncValue<BitmapSource?> Thumbnail { get; }

	IAsyncValue<IReadOnlyList<IAnimationFrame>> Preview { get; }

	double ThumbnailAspectRatio { get; }
}
