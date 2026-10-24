using System.Collections.Generic;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.ViewModels;

public interface ILiveVideoDialogService
{
	IEnumerable<LiveVideoInput> AvailableInputs { get; }

	void OpenSetup(LiveVideoInput input);
}
