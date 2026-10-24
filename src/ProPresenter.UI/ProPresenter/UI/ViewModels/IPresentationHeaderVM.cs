using System.ComponentModel;
using System.Windows.Input;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.ViewModels;

public interface IPresentationHeaderVM : INotifyPropertyChanged
{
	TransitionHandler TransitionHandler { get; }

	ISizeSelectorVM SizeSelector { get; }

	IDocumentCue? DocumentCue { get; set; }

	IDocumentAction? DocumentAction { get; }

	bool HasMissingFonts { get; }

	bool SizeIsConfigured { get; }

	bool HasAnyIssues { get; }

	PresentationHeaderViewType ActiveHeaderView { get; set; }

	double[] SlideShowDurations { get; }

	ICommand RemoveSlideShowCommand { get; }

	ICommand<double> SetSlideShowCommand { get; }

	ICommand SetCustomSlideShowCommand { get; }

	ICommand ResolveMissingFontsCommand { get; }

	ICommand<OutputDestination> ChangeOutputDestinationCommand { get; }
}
