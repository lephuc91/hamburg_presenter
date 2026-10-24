using ProPresenter.DO.LiveVideo;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public interface IVideoInputItemVMFactory
{
	IVideoInputItemVM Create(LiveVideoInput liveVideoInput);
}
