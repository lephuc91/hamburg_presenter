using System;

namespace Pro.Web.Cookies;

public record CookieModel(string Name, string Value, string Domain, DateTime Expiration)
{
	public bool IsExpired
	{
		get
		{
			if (!string.IsNullOrEmpty(Value))
			{
				return DateTime.UtcNow > Expiration;
			}
			return false;
		}
	}
}
