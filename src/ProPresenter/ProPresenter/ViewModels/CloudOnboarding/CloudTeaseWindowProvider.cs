using System.Windows;
using Pro.Common.Startup;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.UI.CloudOnboarding;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public sealed class CloudTeaseWindowProvider : ICloudTeaseWindowProvider
{
	private readonly ICloudTeaseVM _vm;

	private readonly ICloudOnboardingService _service;

	private readonly IAfterStartupCompleteQueue _afterStartupCompleteQueue;

	public CloudTeaseWindowProvider(ICloudTeaseVM vm, ICloudOnboardingService service, IAfterStartupCompleteQueue afterStartupCompleteQueue)
	{
		_vm = vm;
		_service = service;
		_afterStartupCompleteQueue = afterStartupCompleteQueue;
		_afterStartupCompleteQueue.AddStartup();
	}

	public void Show(Window? owner = null)
	{
		if (!_service.ShouldShowCloudTease())
		{
			_afterStartupCompleteQueue.CompleteStartup();
			return;
		}
		CloudTeaseWindow cloudTeaseWindow = new CloudTeaseWindow
		{
			DataContext = _vm
		};
		cloudTeaseWindow.Closed += delegate
		{
			_vm.OnWindowClosed();
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
			cloudTeaseWindow.Owner = window;
			cloudTeaseWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		}
		else
		{
			cloudTeaseWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}
		cloudTeaseWindow.ShowDialog();
	}
}
