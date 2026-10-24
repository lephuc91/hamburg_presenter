using System.Windows;
using Pro.Common.Startup;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.UI.CloudOnboarding;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public sealed class CloudOnboardingWindowProvider : ICloudOnboardingWindowProvider
{
	private readonly ICloudOnboardingVM _vm;

	private readonly ICloudOnboardingService _service;

	private readonly IAfterStartupCompleteQueue _afterStartupCompleteQueue;

	public CloudOnboardingWindowProvider(ICloudOnboardingVM vm, ICloudOnboardingService service, IAfterStartupCompleteQueue afterStartupCompleteQueue)
	{
		_vm = vm;
		_service = service;
		_afterStartupCompleteQueue = afterStartupCompleteQueue;
		_afterStartupCompleteQueue.AddStartup();
	}

	public void Show(Window? owner = null)
	{
		if (!_service.ShouldShow())
		{
			_afterStartupCompleteQueue.CompleteStartup();
			return;
		}
		CloudOnboardingWindow cloudOnboardingWindow = new CloudOnboardingWindow
		{
			DataContext = _vm
		};
		_vm.Initialize();
		cloudOnboardingWindow.Closed += delegate
		{
			_service.IsOnboardingInProgress = false;
			_afterStartupCompleteQueue.CompleteStartup();
		};
		Window window = owner;
		if (window == null)
		{
			Window window2 = Application.Current?.MainWindow;
			if (window2 != null && window2.IsVisible)
			{
				window = window2;
			}
		}
		if (window != null && window.IsVisible)
		{
			cloudOnboardingWindow.Owner = window;
			cloudOnboardingWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		}
		else
		{
			cloudOnboardingWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}
		cloudOnboardingWindow.ShowDialog();
	}
}
