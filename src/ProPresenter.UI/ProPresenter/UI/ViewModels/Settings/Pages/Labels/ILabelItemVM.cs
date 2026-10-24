using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Labels;

public interface ILabelItemVM : INotifyPropertyChanged
{
	string Text { get; set; }

	Color? Color { get; set; }
}
