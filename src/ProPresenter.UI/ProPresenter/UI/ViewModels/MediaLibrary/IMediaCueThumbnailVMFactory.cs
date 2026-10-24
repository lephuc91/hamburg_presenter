using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface IMediaCueThumbnailVMFactory
{
	IMediaCueThumbnailVM Create(MediaCue mediaCue);
}
