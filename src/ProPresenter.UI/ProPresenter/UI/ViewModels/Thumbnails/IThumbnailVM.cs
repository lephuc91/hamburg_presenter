using System.ComponentModel;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.ViewModels.Thumbnails;

public interface IThumbnailVM : IThumbnailSource, INotifyPropertyChanged, IUniformViewSource
{
	IMediaOverlayVM? MediaOverlayVM { get; }
}
