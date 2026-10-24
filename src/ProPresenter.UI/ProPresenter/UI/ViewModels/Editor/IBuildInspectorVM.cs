using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IBuildInspectorVM
{
	CustomSlide? SelectedSlide { get; set; }

	BuildCollection? Builds { get; set; }

	ObservableCollection<SlideElementBase> SelectedElements { get; }

	ObservableCollection<ObservableCollection<IBuild>> BuildGroups { get; }

	ObservableCollection<IBuild> SelectedBuilds { get; }

	bool ShowBuildFrom { get; }

	IEnumerable<IBuild> BuildFromPoints { get; }

	IBuild? SelectedBuildFromPoint { get; }

	bool AnySelectedBuilds { get; }

	ssAPIOutput OutputController { get; }

	TransitionHandler BuildInTransitionHandler { get; }

	TransitionHandler BuildOutTransitionHandler { get; }

	TransitionHandler SlideTransitionHandler { get; }

	TransitionParameters? BuildInTransition { get; set; }

	TransitionParameters? BuildOutTransition { get; set; }

	RevealType Delivery { get; }

	bool ShowDelivery { get; }

	IEnumerable<StartMode> AvailableStartMode { get; }

	StartMode Start { get; set; }

	TimeSlice Delay { get; set; }

	Dictionary<IBuild, int> BuildIndexMap { get; }

	bool IsBuild { get; }

	EditMode EditMode { get; set; }

	ICommand<IBuild> SelectBuildsCommand { get; }

	ICommand<StartMode> SelectStartModeCommand { get; }

	ICommand<IBuild> ChangeRevealFromIndexCommand { get; }

	ICommand<RevealType> ChangeDeliveryCommand { get; }

	ICommand DeleteBuildsCommand { get; }

	void SelectBuilds(IEnumerable<IBuild> builds);
}
