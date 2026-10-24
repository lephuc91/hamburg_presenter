using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IPropsInspectorVM : INotifyPropertyChanged
{
	IPropCue? SelectedProp { get; set; }

	ssAPIOutput OutputController { get; }

	bool UseBackgroundColor { get; set; }

	Color BackgroundColor { get; set; }

	TransitionHandler TransitionHandler { get; }

	TransitionParameters? SelectedTransition { get; }

	Func<Vector2<double>, bool> ConfirmResize { get; }

	ICommand<ColorPair> ColorChangeStartedCommand { get; }

	ICommand<ColorPair> ColorChangeFinishedCommand { get; }

	ICommand RemoveTransitionCommand { get; }

	SlideBase? Slide { get; }

	ICommand<double> SetAutoClearCommand { get; }
}
