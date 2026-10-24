using System.ComponentModel;

namespace ProPresenter.DO.Updates;

public interface IAppDownload : INotifyPropertyChanged
{
	bool DownloadFinished { get; }

	bool DownloadSuccessful { get; }

	int DownloadPercentComplete { get; }

	long BytesDownloaded { get; }

	long TotalBytes { get; }

	IAppInstaller? GetInstaller();

	void CancelDownload();
}
