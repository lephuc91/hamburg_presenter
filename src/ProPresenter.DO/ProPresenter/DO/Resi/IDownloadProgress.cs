namespace ProPresenter.DO.Resi;

public interface IDownloadProgress
{
	bool IsDownloading { get; }

	double DownloadProgress { get; }
}
