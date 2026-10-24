using Pro.Common.Downloads;

namespace ProPresenter.DO.Downloads;

public interface IFileDownloadObserver
{
	void Observe(IDownloadItem downloadItem);
}
