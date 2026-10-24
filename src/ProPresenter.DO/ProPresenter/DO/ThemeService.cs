using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO;

public class ThemeService : IThemeService
{
	private readonly IThemeRepo _themeRepo;

	private readonly Dictionary<ThemePickerGroup, IThemeContainer> _cachedThemeContainers = new Dictionary<ThemePickerGroup, IThemeContainer>();

	private readonly Dictionary<ThemePickerGroup, ViewType> _cachedThemeViewTypes = new Dictionary<ThemePickerGroup, ViewType>();

	public IThemeCollection Themes => _themeRepo.Themes;

	public event EventHandler<ThemeImportedEventArgs>? ThemeImported;

	public ThemeService(IThemeRepo themeRepo)
	{
		_themeRepo = themeRepo;
	}

	public async Task ClearRecentlyAppliedTemplateSlidesAsync()
	{
		await _themeRepo.ClearRecentlyAppliedTemplateSlidesAsync();
	}

	public async Task AddRecentlyAppliedTemplateSlideAsync(Guid themeId)
	{
		await _themeRepo.InsertRecentlyAppliedTemplateSlideAsync(new RecentlyAppliedTemplateSlideModel(themeId, DateTime.Now));
	}

	public async Task<IEnumerable<RecentlyAppliedTemplateSlideModel>> GetRecentlyAppliedTemplateSlidesAsync(bool orderbyDate = true, int top = -1)
	{
		return await _themeRepo.GetRecentlyAppliedTemplateSlidesAsync(orderbyDate, top);
	}

	public async Task<IThemeContainer?> FindThemeContainerAsync(IEnumerable<IThemeContainer> themeContainers, Theme? targetTheme)
	{
		return await Task.Run(() => FindThemeContainer(themeContainers, targetTheme));
	}

	private IThemeContainer? FindThemeContainer(IEnumerable<IThemeContainer> themeContainers, Theme? targetTheme)
	{
		if (themeContainers == null || themeContainers.Count() == 0)
		{
			return null;
		}
		foreach (IThemeContainer themeContainer2 in themeContainers)
		{
			if (themeContainer2.Theme == targetTheme)
			{
				return themeContainer2;
			}
			if (themeContainer2.Children.Count() > 0)
			{
				IThemeContainer themeContainer = FindThemeContainer(themeContainer2.Children, targetTheme);
				if (themeContainer != null)
				{
					return themeContainer;
				}
			}
		}
		return null;
	}

	public async Task<Theme?> FindThemeByTemplateSlideIdAsync(IEnumerable<IThemeContainer> themeContainers, Guid targetThemeId)
	{
		return await Task.Run(() => FindThemeByTemplateSlideId(themeContainers, targetThemeId));
	}

	private Theme? FindThemeByTemplateSlideId(IEnumerable<IThemeContainer> themeContainers, Guid targetThemeId)
	{
		if (themeContainers == null || themeContainers.Count() == 0)
		{
			return null;
		}
		foreach (IThemeContainer themeContainer in themeContainers)
		{
			if (themeContainer.Children.Count() > 0 && themeContainer.Theme == null)
			{
				Theme theme = FindThemeByTemplateSlideId(themeContainer.Children, targetThemeId);
				if (theme != null)
				{
					return theme;
				}
			}
			else
			{
				if (themeContainer.Theme == null)
				{
					continue;
				}
				foreach (TemplateSlide item in themeContainer.Theme)
				{
					if (item.ID == targetThemeId)
					{
						return themeContainer.Theme;
					}
				}
			}
		}
		return null;
	}

	public async Task AddNewlyImportedThemeAsync(ImportedThemeModel importedThemeModel)
	{
		await _themeRepo.InsertImportedThemeAsync(importedThemeModel);
		this.ThemeImported?.Invoke(this, new ThemeImportedEventArgs(importedThemeModel));
	}

	public async Task<bool> AnyUnacknowledgedImportedThemesExistAsync()
	{
		return await _themeRepo.AnyUnacknowledgedImportedThemesExistAsync();
	}

	public async Task<IEnumerable<ImportedThemeModel>> GetAllThemesThatHaventBeenAcknowledgedAsync()
	{
		return await _themeRepo.GetAllThemesThatHaventBeenAcknowledgedAsync();
	}

	public async Task UpdateUserHasAcknowledgedImportedThemeAsync(string themeName)
	{
		await _themeRepo.UpdateUserHasAcknowledgedImportedThemeAsync(themeName);
		SetThemeUserHasAcknowledged(themeName, hasAcknowledged: true);
	}

	public async Task UpdateUserHasViewedImportedThemeDetailsAsync(string themeName)
	{
		await _themeRepo.UpdateUserHasViewedImportedThemeDetailsAsync(themeName);
		SetThemeUserHasAcknowledged(themeName, hasAcknowledged: true);
	}

	private void SetThemeUserHasAcknowledged(string themeName, bool hasAcknowledged)
	{
		Themes?.Where((Theme x) => x.Name == themeName).ForEach(delegate(Theme t)
		{
			t.HasThemeDetailsBeenAcknowledgedByUser = hasAcknowledged;
		});
	}

	public async Task<bool?> HasThemeDetailsBeenViewedAsync(string themeName)
	{
		return await _themeRepo.HasThemeDetailsBeenViewedAsync(themeName);
	}

	public IThemeContainer? GetCurrentThemeContainerByGroup(ThemePickerGroup group)
	{
		_cachedThemeContainers.TryGetValue(group, out IThemeContainer value);
		object themeContainer = value;
		if (themeContainer == null)
		{
			IThemeCollection themes = Themes;
			if (themes == null)
			{
				return null;
			}
			themeContainer = themes.ThemeTree;
		}
		return (IThemeContainer?)themeContainer;
	}

	public void SetCurrentThemeContainerGroupContext(ThemePickerGroup group, IThemeContainer themeContainer)
	{
		_cachedThemeContainers[group] = themeContainer;
	}

	public ViewType GetViewTypeByGroup(ThemePickerGroup group)
	{
		_cachedThemeViewTypes.TryGetValue(group, out var value);
		return value;
	}

	public void SetViewTypeByGroup(ThemePickerGroup group, ViewType viewType)
	{
		_cachedThemeViewTypes[group] = viewType;
	}

	public Task<ThemePickerSettingsModel?> GetThemePickerSettingsByGroupAsync(ThemePickerGroup group)
	{
		return _themeRepo.GetThemePickerSettingsByGroupAsync(group);
	}

	public Task UpsertThemePickerSettingsAsync(ThemePickerSettingsModel settings)
	{
		return _themeRepo.UpsertThemePickerSettingsAsync(settings);
	}
}
