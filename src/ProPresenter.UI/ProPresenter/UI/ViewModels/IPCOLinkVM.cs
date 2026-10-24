using ProPresenter.DO.PCO;

namespace ProPresenter.UI.ViewModels;

public interface IPCOLinkVM
{
	PCOLiveTheme PCOLiveTheme { get; set; }

	PCOLiveCountdownType PCOLiveCountdownType { get; set; }
}
