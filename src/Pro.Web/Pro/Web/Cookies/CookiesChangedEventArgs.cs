using System;
using System.Collections.Generic;

namespace Pro.Web.Cookies;

public class CookiesChangedEventArgs : EventArgs
{
	public IEnumerable<CookieModel> ChangedCookies { get; }

	public CookiesChangedEventArgs(IEnumerable<CookieModel> changedCookies)
	{
		ChangedCookies = new List<CookieModel>(changedCookies);
	}
}
