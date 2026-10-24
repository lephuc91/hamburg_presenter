using System.ComponentModel;

namespace ProPresenter.DO.Resi;

public interface IUpdateClient : INotifyPropertyChanged, IDownloader, IDownloadProgress
{
	UpdateStatus UpdateStatus { get; }
}
