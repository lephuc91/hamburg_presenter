using System.Threading.Tasks;

namespace ProPresenter.DO.ProContent.Downloads;

public interface IProContentDownloadProcess
{
	Task StartDownloadAsync(IProContentDownloadInfo downloadInfo);

	Task StartDownloadAsync(string identifier);
}
