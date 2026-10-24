using System.Collections.Specialized;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Registration;

public interface IPurchaseWindowVM : INotifyPropertyChanged
{
	NameValueCollection? CurrentHeaders { get; set; }

	bool IsPurchaseComplete { get; }

	string RegistrationName { get; }

	string UnlockCode { get; }

	bool IsTrialComplete { get; }
}
