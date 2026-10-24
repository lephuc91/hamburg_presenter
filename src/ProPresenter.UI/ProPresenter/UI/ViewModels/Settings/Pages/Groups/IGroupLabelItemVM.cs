using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Groups;

public interface IGroupLabelItemVM : INotifyPropertyChanged
{
	string Text { get; set; }

	Color? Color { get; set; }
}
