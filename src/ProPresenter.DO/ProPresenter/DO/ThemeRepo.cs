using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.Data.Entities;
using Pro.Data.SQLite;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_themeTreeDebouncer" })]
public class ThemeRepo : IThemeRepo, IDisposable
{
	private readonly IDatabaseService _databaseService;

	private readonly IDebouncer<ThemeCollection> _themeTreeDebouncer;

	private ThemeCollection _themes;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ThemeCollection Themes
	{
		get
		{
			EnsureThemeInitialized();
			return _themes;
		}
	}

	public ThemeRepo(IDatabaseService databaseService, IFileWatcherFactory fileWatcherFactory, IFileSystem fileSystem, IDebouncerFactory debouncerFactory)
	{
		_databaseService = databaseService;
		_themeTreeDebouncer = debouncerFactory.CreateDispatched(delegate(ThemeCollection t)
		{
			t.BuildTree();
		});
	}

	private void EnsureThemeInitialized()
	{
		if (_themes == null && DataVault.Themes != null)
		{
			_themes = DataVault.Themes;
			_themes.CollectionChanged += delegate
			{
				_themeTreeDebouncer?.Invoke(Themes);
			};
		}
	}

	public async Task ClearRecentlyAppliedTemplateSlidesAsync()
	{
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					foreach (RecentlyAppliedTemplateSlide item in EntityBase<RecentlyAppliedTemplateSlide>.Query(database))
					{
						database.Delete(item);
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
	}

	public async Task<IEnumerable<RecentlyAppliedTemplateSlideModel>> GetRecentlyAppliedTemplateSlidesAsync(bool orderbyDate = true, int top = -1)
	{
		List<RecentlyAppliedTemplateSlideModel> themeList = new List<RecentlyAppliedTemplateSlideModel>();
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					if (orderbyDate)
					{
						if (top > 0)
						{
							foreach (RecentlyAppliedTemplateSlide item in (from theme in EntityBase<RecentlyAppliedTemplateSlide>.Query(database)
								orderby theme.DateApplied descending
								select theme).Take(top))
							{
								themeList.Add(new RecentlyAppliedTemplateSlideModel(item.TemplateSlideId, item.DateApplied));
							}
							return;
						}
						{
							foreach (RecentlyAppliedTemplateSlide item2 in from theme in EntityBase<RecentlyAppliedTemplateSlide>.Query(database)
								orderby theme.DateApplied descending
								select theme)
							{
								themeList.Add(new RecentlyAppliedTemplateSlideModel(item2.TemplateSlideId, item2.DateApplied));
							}
							return;
						}
					}
					foreach (RecentlyAppliedTemplateSlide item3 in EntityBase<RecentlyAppliedTemplateSlide>.Query(database))
					{
						themeList.Add(new RecentlyAppliedTemplateSlideModel(item3.TemplateSlideId, item3.DateApplied));
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
		return themeList;
	}

	public async Task InsertRecentlyAppliedTemplateSlideAsync(RecentlyAppliedTemplateSlideModel theme)
	{
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					IOrderedEnumerable<RecentlyAppliedTemplateSlide> source = from theme in EntityBase<RecentlyAppliedTemplateSlide>.Query(database)
						orderby theme.DateApplied descending
						select theme;
					if (source.Count() > 4)
					{
						for (int i = 4; i < source.Count(); i++)
						{
							database.Delete(source.ElementAt(i));
						}
					}
					RecentlyAppliedTemplateSlide recentlyAppliedTemplateSlide = EntityBase<RecentlyAppliedTemplateSlide>.Query(database).FirstOrDefault((RecentlyAppliedTemplateSlide t) => t.TemplateSlideId == theme.TemplateSlideId);
					if (recentlyAppliedTemplateSlide != null)
					{
						recentlyAppliedTemplateSlide.DateApplied = theme.AppliedDateTime;
						recentlyAppliedTemplateSlide.Save(database);
					}
					else
					{
						RecentlyAppliedTemplateSlide recentlyAppliedTemplateSlide2 = new RecentlyAppliedTemplateSlide();
						recentlyAppliedTemplateSlide2.TemplateSlideId = theme.TemplateSlideId;
						recentlyAppliedTemplateSlide2.DateApplied = theme.AppliedDateTime;
						recentlyAppliedTemplateSlide2.Save(database);
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
	}

	public async Task InsertImportedThemeAsync(ImportedThemeModel importedThemeModel)
	{
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					ImportedTheme importedTheme = new ImportedTheme();
					importedTheme.ThemeName = importedThemeModel.ThemeName;
					importedTheme.DateImported = importedThemeModel.DateImported;
					importedTheme.UserAcknowledgedImportIndicator = importedThemeModel.UserAcknowledgedImportIndicator;
					importedTheme.Save(database);
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
	}

	public async Task<bool> AnyUnacknowledgedImportedThemesExistAsync()
	{
		bool result = false;
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					result = EntityBase<ImportedTheme>.Query(database).Any((ImportedTheme importedTheme) => !importedTheme.UserAcknowledgedImportIndicator);
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
		return result;
	}

	public async Task<IEnumerable<ImportedThemeModel>> GetAllThemesThatHaventBeenAcknowledgedAsync()
	{
		List<ImportedThemeModel> importedThemes = new List<ImportedThemeModel>();
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					foreach (ImportedTheme item in EntityBase<ImportedTheme>.Query(database))
					{
						if (!item.UserAcknowledgedImportIndicator)
						{
							importedThemes.Add(new ImportedThemeModel(item.ThemeName, item.DateImported, item.UserAcknowledgedImportIndicator, item.HasUserViewedThemeDetails));
						}
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
		return importedThemes;
	}

	public async Task UpdateUserHasAcknowledgedImportedThemeAsync(string themeName)
	{
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					ImportedTheme importedTheme = EntityBase<ImportedTheme>.Query(database).FirstOrDefault((ImportedTheme _theme) => _theme.ThemeName == themeName);
					if (importedTheme != null)
					{
						importedTheme.UserAcknowledgedImportIndicator = true;
						importedTheme.Save(database);
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
	}

	public async Task UpdateUserHasViewedImportedThemeDetailsAsync(string themeName)
	{
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					ImportedTheme importedTheme = EntityBase<ImportedTheme>.Query(database).FirstOrDefault((ImportedTheme _theme) => _theme.ThemeName == themeName);
					if (importedTheme != null)
					{
						importedTheme.HasUserViewedThemeDetails = true;
						importedTheme.Save(database);
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
	}

	public async Task<bool?> HasThemeDetailsBeenViewedAsync(string themeName)
	{
		bool? result = null;
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					if (!EntityBase<ImportedTheme>.Query(database).Any((ImportedTheme theme) => theme.ThemeName == themeName))
					{
						result = null;
					}
					else
					{
						result = EntityBase<ImportedTheme>.Query(database).Any((ImportedTheme importedTheme) => importedTheme.ThemeName == themeName && importedTheme.HasUserViewedThemeDetails);
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
		return result;
	}

	public async Task UpsertThemePickerSettingsAsync(ThemePickerSettingsModel settings)
	{
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					ThemePickerSettings themePickerSettings = EntityBase<ThemePickerSettings>.Query(database).FirstOrDefault((ThemePickerSettings _settings) => _settings.ContextualGroupId == (int)settings.ContextualGroup);
					if (themePickerSettings != null)
					{
						themePickerSettings.MediaActionEnabled = settings.MediaActionEnabled;
						themePickerSettings.Save(database);
					}
					else
					{
						ThemePickerSettings themePickerSettings2 = new ThemePickerSettings((int)settings.ContextualGroup);
						themePickerSettings2.ContextualGroupId = (int)settings.ContextualGroup;
						themePickerSettings2.MediaActionEnabled = settings.MediaActionEnabled;
						themePickerSettings2.Save(database);
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
	}

	public async Task<ThemePickerSettingsModel?> GetThemePickerSettingsByGroupAsync(ThemePickerGroup contextualGroup)
	{
		ThemePickerSettingsModel result = null;
		await Task.Run(delegate
		{
			try
			{
				_databaseService.PerformDatabaseOperationWithLogging(delegate(IDatabase database)
				{
					if (!EntityBase<ThemePickerSettings>.Query(database).Any((ThemePickerSettings settings) => settings.ContextualGroupId == (int)contextualGroup))
					{
						result = new ThemePickerSettingsModel(contextualGroup);
						new ThemePickerSettings((int)contextualGroup).Save(database);
					}
					else
					{
						ThemePickerSettings themePickerSettings = EntityBase<ThemePickerSettings>.Query(database).FirstOrDefault((ThemePickerSettings settings) => settings.ContextualGroupId == (int)contextualGroup);
						result = new ThemePickerSettingsModel(contextualGroup)
						{
							MediaActionEnabled = (themePickerSettings?.MediaActionEnabled ?? false)
						};
					}
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
		});
		return result;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_themeTreeDebouncer.Dispose();
		}
	}
}
