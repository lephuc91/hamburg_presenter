using System.Runtime.CompilerServices;

namespace Pro.Web.Cookies;

public record CookieSession
{
	public string Filter { get; }

	public static CookieSession PCO { get; } = new CookieSession("planningcenteronline.com");

	public static CookieSession MultiTracks { get; } = new CookieSession("multitracks.com");

	public static CookieSession SongSelect { get; } = new CookieSession("ccli.com");

	public static CookieSession Resi { get; } = new CookieSession("resi.io");

	public static CookieSession ProContent { get; } = new CookieSession("procontent.renewedvision.com");

	private CookieSession(string filter)
	{
		Filter = filter;
	}

	[CompilerGenerated]
	protected CookieSession(CookieSession original)
	{
		Filter = original.Filter;
	}
}
