using System.ComponentModel;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public interface IColorTriggerItemVMInternal : IColorTriggerItemVM, INotifyPropertyChanged
{
	IColorTrigger ColorTrigger { get; }
}
