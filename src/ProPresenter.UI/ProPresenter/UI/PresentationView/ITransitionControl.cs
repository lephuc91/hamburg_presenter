using Pro.DO.Transitions;
using ProPresenter.Controller.Outputs;

namespace ProPresenter.UI.PresentationView;

public interface ITransitionControl
{
	ssAPIOutput OutputController { get; }

	TransitionParameters? SelectedTransition { get; set; }

	TransitionHandler TransitionHandler { get; }
}
