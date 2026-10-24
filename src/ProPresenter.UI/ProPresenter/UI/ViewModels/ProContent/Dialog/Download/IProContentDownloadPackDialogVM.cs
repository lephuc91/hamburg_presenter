using System.Collections.Generic;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

public interface IProContentDownloadPackDialogVM : IProContentDownloadDialogWithThumbnailVM, IProContentDownloadDialogVM
{
	string PackTitle { get; }

	IReadOnlyList<IProContentPackAssetContainsDownloadEnableVM> Contains { get; }
}
