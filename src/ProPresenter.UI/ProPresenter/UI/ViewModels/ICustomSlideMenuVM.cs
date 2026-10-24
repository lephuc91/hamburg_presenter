using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public interface ICustomSlideMenuVM : INotifyPropertyChanged
{
	FrameworkElement? PlacementTarget { get; set; }

	IActionsMenuVM ActionsMenuVM { get; }

	bool HasGotoNextAction { get; }

	bool CanUngroup { get; }

	bool IsGroupingEnabled { get; }

	string ToggleEnabledHeader { get; }

	ArrangedCue? SelectedSlide { get; set; }

	ObservableCollection<ArrangedCue> SelectedSlides { get; }

	ProPresenterCue? SelectedCue { get; set; }

	TransitionHandler TransitionHandler { get; }

	TransitionParameters? SelectedTransition { get; set; }

	ITemplateVM? TemplateVM { get; set; }

	IQuickEditVM? QuickEditVM { get; set; }

	IEnumerable<ActionLabel> SlideLabels { get; }

	IEnumerable<GroupLabel> GroupLabels { get; }

	ICommand EditSlideCommand { get; }

	ICommand ShowQuickEditCommand { get; }

	ICommand ToggleEnabledCommand { get; }

	ICommand OpenTranstionsCommand { get; }

	ICommand ShowHotkeyDialogCommand { get; }

	ICommand EditGoToNextCommand { get; }

	ICommand<ActionLabel> AssignSlideLabelCommand { get; }

	ICommand NewSlideLabelCommand { get; }

	ICommand<GroupLabel> AssignGroupLabelCommand { get; }

	ICommand UngroupCommand { get; }

	ICommand NewGroupLabelCommand { get; }

	ICommand<TemplateSlide> SelectTemplateCommand { get; }

	ICommand RemoveGotoNextTimerCommand { get; }

	event Action<ArrangedCue?, IPresentation?>? EditCue;

	event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>>? ShowActionDialog;
}
