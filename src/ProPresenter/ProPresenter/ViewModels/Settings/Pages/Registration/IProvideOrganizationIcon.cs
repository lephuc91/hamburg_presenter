using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.ViewModels.Settings.Pages.Registration;

public interface IProvideOrganizationIcon : INotifyPropertyChanged
{
	ImageSource? Icon { get; }
}
