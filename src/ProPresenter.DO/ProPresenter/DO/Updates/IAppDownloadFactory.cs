using ProPresenter.DO.Registration.Model;

namespace ProPresenter.DO.Updates;

public interface IAppDownloadFactory
{
	IAppDownload Create(BuildInformation downloadVersion);
}
