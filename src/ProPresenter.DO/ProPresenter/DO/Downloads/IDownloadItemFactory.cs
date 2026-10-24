using Pro.Common.Downloads;
using ProPresenter.DO.ProContent.Downloads;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.Downloads;

public interface IDownloadItemFactory
{
	IDownloadItem Create(ProContentFileDownload fileDownload, IProContentDownloadDataRefresher downloadRefresher);

	IDownloadItem Create(string url, string destination, string name);
}
