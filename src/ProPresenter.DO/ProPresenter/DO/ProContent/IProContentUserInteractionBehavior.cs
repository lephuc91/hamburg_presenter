using System;
using System.Threading.Tasks;

namespace ProPresenter.DO.ProContent;

public interface IProContentUserInteractionBehavior
{
	Task LoginLogoutAsync();

	Task ExecuteDownloadAsync<T>(Func<T, IProContentDownloadInfo?> getDownloadInfo, Func<IProContentDownloadInfo, Task> performDownload, T toDownload);

	Task ExecuteDownloadAsync<T>(Func<T, Task> performDownload, T toDownload);
}
