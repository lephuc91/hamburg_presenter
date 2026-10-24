using System;
using System.IO;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Data.Entities;
using Pro.Data.SQLite;
using ProPresenter.DO;

namespace ProPresenter.Data;

public class DatabaseService : IDatabaseService
{
	private bool _initialized;

	public IDatabase? Database { get; private set; }

	public DatabaseService()
	{
		Initialize();
	}

	public void PerformDatabaseOperationWithLogging(Action<IDatabase> action)
	{
		Database.ThrowWhenNull("Database");
		try
		{
			action?.Invoke(Database);
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message);
		}
	}

	private void Initialize()
	{
		if (_initialized)
		{
			return;
		}
		if (Database == null)
		{
			Database = new Database(Path.Combine(CommonPaths.Preferences, "Settings.db"), "Settings");
		}
		Database.Open();
		PerformDatabaseOperationWithLogging(delegate(IDatabase d)
		{
			d.PerformInTransaction(delegate
			{
				d.CreateOrUpdateTable(typeof(Cookie));
				d.CreateOrUpdateTable(typeof(RecentlyAppliedTemplateSlide));
				d.CreateOrUpdateTable(typeof(ImportedTheme));
				d.CreateOrUpdateTable(typeof(ThemePickerSettings));
			});
		});
		_initialized = true;
	}
}
