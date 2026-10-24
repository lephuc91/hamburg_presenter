using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

public interface IFooterVM : INotifyPropertyChanged
{
	IRelayCommand HelpCommand { get; }
}
