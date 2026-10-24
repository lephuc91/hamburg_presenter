using System;
using Pro.Localization;
using Pro.UI.Controls;
using Pro.Web.Cookies;

namespace Pro.UI.Factories.LoginDialog;

public class LoginDialogFactory : ILoginDialogFactory
{
	private readonly ICookieManagerService _cookieManagerService;

	public LoginDialogFactory(ICookieManagerService cookieManagerService)
	{
		_cookieManagerService = cookieManagerService;
	}

	public ILoginDialog CreateDialogForMainWindow(string cachePath, CookieSession cookieSession, string initialLoginUrl, Func<string, bool> isValidLoginUrl, string titleTranslationKey, string? cacheSession = null, double height = 0.0, double width = 0.0)
	{
		Pro.UI.Controls.LoginDialog loginDialog = new Pro.UI.Controls.LoginDialog(cachePath, _cookieManagerService, cookieSession, initialLoginUrl, isValidLoginUrl)
		{
			Title = LocalizedStrings.Get(titleTranslationKey)
		};
		if (cacheSession != null)
		{
			loginDialog.CacheSession = cacheSession;
		}
		if (height != 0.0)
		{
			loginDialog.Height = height;
		}
		if (width != 0.0)
		{
			loginDialog.Width = width;
		}
		return loginDialog;
	}
}
