using System;
using Pro.Common.Logging;
using Pro.Common.Win32;

namespace Pro.Common.Utility;

public class InternetAccessCheck : IInternetAccess
{
	private readonly Action _showMessageWhenNoConnectionCallback;

	public InternetAccessCheck(Action showMessageWhenNoConnectionCallback)
	{
		_showMessageWhenNoConnectionCallback = showMessageWhenNoConnectionCallback;
	}

	bool IInternetAccess.IsInternetAvailable()
	{
		return IsInternetAvailable();
	}

	public bool CheckIfInternetAvailableThenShowPrompt()
	{
		bool num = IsInternetAvailable();
		if (!num)
		{
			Action showMessageWhenNoConnectionCallback = _showMessageWhenNoConnectionCallback;
			if (showMessageWhenNoConnectionCallback == null)
			{
				return num;
			}
			showMessageWhenNoConnectionCallback();
		}
		return num;
	}

	public static bool IsInternetAvailable()
	{
		try
		{
			int description;
			return WindowsFunctions.InternetGetConnectedState(out description, 0);
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return false;
		}
	}
}
