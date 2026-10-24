using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.UI.ViewModels;

public interface IStageMessageTextLinkVM : INotifyPropertyChanged
{
	bool ShouldFlash { get; set; }

	Color FlashColor { get; set; }
}
