using System;
using Pro.Web.Cookies;

namespace Pro.UI.Factories.LoginDialog;

public interface ILoginDialogFactory
{
	ILoginDialog CreateDialogForMainWindow(string cachePath, CookieSession cookieSession, string initialLoginUrl, Func<string, bool> isValidLoginUrl, string titleTranslationKey, string? cacheSession = null, double height = 0.0, double width = 0.0);
}
