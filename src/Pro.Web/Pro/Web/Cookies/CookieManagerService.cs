using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.Strings;
using Pro.Data.Entities;
using Pro.Data.SQLite;
using Pro.Data.SQLite.Migration;

namespace Pro.Web.Cookies;

public class CookieManagerService : ICookieManagerService
{
	private readonly LockingList<CookieModel> _cookies = new LockingList<CookieModel>();

	private readonly IDatabaseService _databaseService;

	private readonly ISqliteMigrationService _migrationService;

	public IReadOnlyCollection<CookieModel> Cookies => _cookies;

	public event EventHandler<CookiesChangedEventArgs>? CookiesChanged;

	public CookieManagerService(IDatabaseService databaseService, ISqliteMigrationService migrationService)
	{
		_migrationService = migrationService;
		_databaseService = databaseService ?? throw new ArgumentNullException("databaseService");
		Initialize();
	}

	public CookieModel CreateOrUpdate(string name, string value, string domain, DateTime expiration)
	{
		return AddOrUpdate(name, value, domain, expiration, allowAdd: true);
	}

	public CookieModel? GetCookie(string name)
	{
		return _cookies.FirstOrDefault((CookieModel c) => c.Name.AreEqualIgnoreCase(name));
	}

	public CookieModel? GetCookie(string domain, string name)
	{
		return _cookies.FirstOrDefault((CookieModel c) => c.Domain.AreEqualIgnoreCase(domain) && c.Name.AreEqualIgnoreCase(name));
	}

	public IEnumerable<CookieModel> GetCookies(CookieSession cookieSession)
	{
		return _cookies.Where((CookieModel c) => c.Domain.Contains(cookieSession.Filter));
	}

	private void Initialize()
	{
		_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase d)
		{
			foreach (Cookie c in EntityBase<Cookie>.Query(d))
			{
				if (!string.IsNullOrWhiteSpace(c.Name))
				{
					string name = c.Name.Trim();
					_cookies.AddOrUpdate(new CookieModel(name, c.Value ?? string.Empty, c.Domain, c.Expiration), (CookieModel model) => EntriesEqual(model, c.Domain, name));
				}
			}
		});
		this.CookiesChanged?.Invoke(this, new CookiesChangedEventArgs(Cookies));
	}

	private CookieModel AddOrUpdate(string name, string value, string domain, DateTime expiration, bool allowAdd)
	{
		CookieModel update = new CookieModel(name.Trim(), value, domain, expiration);
		_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase d)
		{
			Cookie cookie = (from c in EntityBase<Cookie>.Query(d)
				where !string.IsNullOrWhiteSpace(c.Name)
				select c).FirstOrDefault((Cookie c) => c.Domain.AreEqualIgnoreCase(update.Domain) && c.Name.Trim().AreEqualIgnoreCase(update.Name));
			if (cookie != null)
			{
				cookie.Value = value;
				cookie.Expiration = update.Expiration;
				cookie.Save(d);
			}
			else if (allowAdd)
			{
				new Cookie(update.Name, update.Value, update.Domain, update.Expiration).Save(d);
			}
			_cookies.AddOrUpdate(update, (CookieModel model) => EntriesEqual(model, update.Domain, update.Name));
		});
		this.CookiesChanged?.Invoke(this, new CookiesChangedEventArgs(new global::_003C_003Ez__ReadOnlySingleElementList<CookieModel>(update)));
		_migrationService.MigrateBack(MigrationTypes.Cookies);
		return update;
	}

	private static bool EntriesEqual(CookieModel a, string domain, string name)
	{
		if (a.Domain.AreEqualIgnoreCase(domain))
		{
			return a.Name.AreEqualIgnoreCase(name);
		}
		return false;
	}
}
