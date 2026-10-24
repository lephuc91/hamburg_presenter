using Pro.Common.Downloads;
using ProPresenter.UI.ViewModels.Downloads;

namespace ProPresenter.ViewModels.Downloads;

public interface IDownloadVMsFactory
{
	IDownloadItemVM Create(IDownloadItem item);
}
