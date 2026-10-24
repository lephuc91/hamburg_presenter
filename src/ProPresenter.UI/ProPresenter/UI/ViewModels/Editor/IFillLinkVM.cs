using System.ComponentModel;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IFillLinkVM : INotifyPropertyChanged
{
	IElementFillLinkVM ElementFillLinkVM { get; }

	IOutputScreenLinkVM OutputScreenLinkVM { get; }

	ISlideImageLinkVM SlideImageLinkVM { get; }

	IPCOLinkVM PCOLinkVM { get; }

	CustomSlide? SelectedSlide { get; set; }

	EditMode EditMode { get; set; }

	LinkedFillType LinkedFillType { get; set; }

	ICommand<LinkedFillType> SetLinkedFillCommand { get; }
}
