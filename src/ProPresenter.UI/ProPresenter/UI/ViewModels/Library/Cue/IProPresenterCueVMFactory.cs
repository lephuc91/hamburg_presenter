using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.Library.Cue;

public interface IProPresenterCueVMFactory
{
	IProPresenterCueVM Create(ProPresenterCue cue);
}
