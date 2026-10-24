using System.ComponentModel;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IGroupNameTextLinkVM : INotifyPropertyChanged
{
	GroupSourceType GroupSource { get; set; }
}
