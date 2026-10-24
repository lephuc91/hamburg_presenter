using System.ComponentModel;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ISlideTextLinkVM : INotifyPropertyChanged
{
	SlideTargetSourceMode SlideTargetSourceMode { get; }

	SlideTextSourceMode SlideTextSourceMode { get; set; }

	bool PreserveNotesFormat { get; set; }
}
