using System;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.ProContent.Asset;

public interface IProContentPackAssetContainsDownloadEnableVM : IProContentPackAssetContainsVM, INotifyPropertyChanged, IDisposable
{
	bool ShouldDownload { get; set; }
}
