using System;
using Pro.Common.Win32;

namespace Pro.Common.IO;

public static class ConsoleHelper
{
	public static void ShowConsole()
	{
		nint consoleWindow = WindowsFunctions.GetConsoleWindow();
		if (consoleWindow == IntPtr.Zero)
		{
			WindowsFunctions.AllocConsole();
		}
		else
		{
			WindowsFunctions.ShowWindow(consoleWindow, SW.SHOW);
		}
	}

	public static void HideConsole()
	{
		WindowsFunctions.ShowWindow(WindowsFunctions.GetConsoleWindow(), SW.HIDE);
	}
}
