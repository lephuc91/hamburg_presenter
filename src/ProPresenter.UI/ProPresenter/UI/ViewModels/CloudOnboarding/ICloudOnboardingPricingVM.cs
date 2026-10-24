using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.CloudOnboarding.Model;

namespace ProPresenter.UI.ViewModels.CloudOnboarding;

public interface ICloudOnboardingPricingVM : INotifyPropertyChanged
{
	bool IsBusy { get; }

	PricingOptionsResponse? PricingOptions { get; }

	IRelayCommand OpenLearnMoreCommand { get; }

	IRelayCommand<ICloseable> ContinueWithoutCloudCommand { get; }

	IRelayCommand<ICloseable> BackCommand { get; }
}
