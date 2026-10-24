using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.UI.CloudOnboarding;

public partial class CloudOnboardingDoneView : UserControl, IComponentConnector
{
	public CloudOnboardingDoneView()
	{
		InitializeComponent();
		base.Loaded += OnLoaded;
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		if (base.DataContext is ICloudOnboardingDoneVM viewModel)
		{
			InitializeAsync(viewModel);
		}
	}

	private static async Task InitializeAsync(ICloudOnboardingDoneVM viewModel)
	{
		try
		{
			await viewModel.InitializeAsync();
		}
		catch (Exception)
		{
			viewModel.OnConversionComplete();
		}
	}
}
