using System.ComponentModel;
using System.Threading.Tasks;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.ViewModels.CloudOnboarding;

public interface ICloudOnboardingDoneVM : INotifyPropertyChanged
{
	bool IsBusy { get; }

	bool ShowGetStarted { get; }

	Task InitializeAsync();

	void GetStarted(ICloseable closeable);

	void OpenUpgradePlan();

	void OpenLearnMore();

	void OnConversionComplete();
}
