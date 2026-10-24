using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.ViewModels.Props;

public interface IPropCueVM : INotifyPropertyChanged, IUniformViewSource, ITriggerable
{
	TransitionParameters? SelectedTransition { get; set; }

	string Name { get; set; }

	bool AutoClearEnabled { get; set; }

	double AutoClearDuration { get; set; }

	ImageSource? PreviewImage { get; }

	IPropGroupVM Parent { get; }

	TransitionHandler TransitionHandler { get; }

	PropSlideAction? SlideAction { get; }

	bool IsSelected { get; set; }

	Vector2<int> ThumbnailSize { get; set; }

	Vector2<double> PreviewSize { get; set; }

	bool IsPlaying { get; }

	double PlayProgress { get; }

	bool ShowProgress { get; }

	ICommand TogglePropAutoClearCommand { get; }

	void MoveToGroup(IPropGroupVM parentGroupVM);
}
