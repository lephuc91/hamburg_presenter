using System;
using System.Collections.Generic;

namespace Pro.Web.Cookies;

public interface ICookieManagerService
{
	IReadOnlyCollection<CookieModel> Cookies { get; }

	event EventHandler<CookiesChangedEventArgs> CookiesChanged;

	CookieModel CreateOrUpdate(string name, string value, string domain, DateTime expiration);

	CookieModel? GetCookie(string name);

	CookieModel? GetCookie(string domain, string name);

	IEnumerable<CookieModel> GetCookies(CookieSession cookieSession);
}
