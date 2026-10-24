using System.Threading.Tasks;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.ProContent.Downloads;

public interface IProContentDownloadDataRefresher
{
	Task<ProContentFileDownload?> RefreshDownloadData(ProContentFileDownload request);
}
