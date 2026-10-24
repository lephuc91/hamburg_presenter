using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.DO.Triggering;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI.ViewModels;

public interface IClearGroupItemVM : ITriggerable, INotifyPropertyChanged
{
	ClearGroup Item { get; }

	string Name { get; set; }

	BitmapSource? Icon { get; }

	Color IconFill { get; }

	bool IsHiddenInPreview { get; }

	ValidationRule NameValidationRule { get; }
}
