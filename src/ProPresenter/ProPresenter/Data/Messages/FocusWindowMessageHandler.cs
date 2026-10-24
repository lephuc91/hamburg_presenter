using System;
using System.Windows;
using ProPresenter.DO;

namespace ProPresenter.Data.Messages;

public class FocusWindowMessageHandler : IMessageHandler
{
	private readonly Func<MainWindow?> _getMainWindow;

	public AppMessages HandledMessage => AppMessages.FocusWindow;

	public FocusWindowMessageHandler(Func<MainWindow> getMainWindow)
	{
		_getMainWindow = getMainWindow;
	}

	public void Handle()
	{
		MainWindow mainWindow = _getMainWindow();
		if (mainWindow != null)
		{
			if (mainWindow.WindowState == WindowState.Minimized)
			{
				SystemCommands.RestoreWindow(mainWindow);
			}
			mainWindow.Activate();
		}
	}
}
