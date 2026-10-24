using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.UI.CloudOnboarding;

public partial class CloudOnboardingEligibilityView : UserControl, IComponentConnector
{
	public CloudOnboardingEligibilityView()
	{
		InitializeComponent();
		base.Loaded += OnLoaded;
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		if (base.DataContext is ICloudOnboardingEligibilityVM cloudOnboardingEligibilityVM)
		{
			cloudOnboardingEligibilityVM.Initialize();
		}
	}
}
