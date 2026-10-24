using ProPresenter.DO.LiveVideo;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class VideoInputItemVMFactory : IVideoInputItemVMFactory
{
	public IVideoInputItemVM Create(LiveVideoInput liveVideoInput)
	{
		return new VideoInputItemVM(liveVideoInput);
	}
}
