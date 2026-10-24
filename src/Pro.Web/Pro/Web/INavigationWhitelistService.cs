namespace Pro.Web;

public interface INavigationWhitelistService
{
	bool IsWhitelistLoaded { get; }

	void AddWhitelistedUrl(string url);

	bool CheckIfUrlIsWhitelisted(string url);

	void Clear();
}
