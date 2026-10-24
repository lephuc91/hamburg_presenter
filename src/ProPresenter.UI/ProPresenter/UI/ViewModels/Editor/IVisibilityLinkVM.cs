using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IVisibilityLinkVM : INotifyPropertyChanged
{
	TimerCollection AvailableTimerCollection { get; }

	IEnumerable<ClosedBezierPath> AvailableElementsCollection { get; }

	ILiveVideoInputCollection AvailableLiveVideoInputs { get; }

	VisibilityCriterion Criterion { get; set; }

	VisibilityConditionCollection? Conditions { get; }

	CustomSlide? SelectedSlide { get; set; }

	bool IsVisibilityLinkEnabled { get; set; }

	bool CanRemoveCondition { get; }

	ICommand<(VisibilityCondition, SlideElementBase)> SetElementVisibilityLinkCommand { get; }

	ICommand<(VisibilityCondition, TimerData)> SetTimerVisibilityLinkCommand { get; }

	ICommand<VisibilityCondition> SetVideoCountdownVisibilityLinkCommand { get; }

	ICommand<VisibilityCondition> SetVideoInputVisibilityLinkCommand { get; }

	ICommand AddConditionCommand { get; }

	ICommand<VisibilityCondition> RemoveConditionCommand { get; }
}
