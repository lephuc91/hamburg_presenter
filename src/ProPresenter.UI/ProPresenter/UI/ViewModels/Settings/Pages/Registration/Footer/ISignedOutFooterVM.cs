using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

public interface ISignedOutFooterVM : IFooterVM, INotifyPropertyChanged
{
	IEnterConfirmationCodeVM EnterConfirmationCodeVM { get; }
}
