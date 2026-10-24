using System.ComponentModel;
using Pro.DO.Triggering;
using ProPresenter.DO.Cues;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface IMediaCueThumbnailVM : IThumbnailVM, IThumbnailSource, INotifyPropertyChanged, IUniformViewSource, ITriggerable
{
	MediaCue MediaCue { get; }

	void UpdateIndex(int index);
}
