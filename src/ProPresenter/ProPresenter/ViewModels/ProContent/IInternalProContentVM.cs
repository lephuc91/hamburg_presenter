using System.ComponentModel;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent;

namespace ProPresenter.ViewModels.ProContent;

public interface IInternalProContentVM : IProContentVM, INotifyPropertyChanged, INavigationItem
{
	void SetParent(IMediaBinHeaderNavigatorVM headerNavigatorVM);
}
