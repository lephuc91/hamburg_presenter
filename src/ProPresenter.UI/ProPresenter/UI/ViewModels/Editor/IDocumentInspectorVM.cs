using System.Windows.Input;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IDocumentInspectorVM
{
	CustomPresentation? Presentation { get; set; }

	TransitionParameters? SelectedTransition { get; set; }

	ssAPIOutput OutputController { get; }

	TransitionHandler TransitionHandler { get; }

	ICommand RemoveTransitionCommand { get; }

	ICommand<ColorPair> ColorChangeStartedCommand { get; }

	ICommand<ColorPair> ColorChangeFinishedCommand { get; }

	bool IgnoreBackgroundColors { get; }
}
