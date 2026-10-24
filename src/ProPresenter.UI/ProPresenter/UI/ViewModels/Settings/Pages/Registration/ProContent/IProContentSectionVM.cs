using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProContent;

public interface IProContentSectionVM : INotifyPropertyChanged
{
	bool IsSignedIn { get; }

	ProContentSubscriptionType SubscriptionType { get; }

	IRelayCommand UpgradeCommand { get; }

	IRelayCommand SignInCommand { get; }
}
