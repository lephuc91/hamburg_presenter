using System.ComponentModel;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ISlideCountTextLinkVM : INotifyPropertyChanged
{
	SlideCountType SlideCountType { get; set; }
}
