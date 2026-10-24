using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO;

public interface IThemeService
{
	IThemeCollection Themes { get; }

	event EventHandler<ThemeImportedEventArgs> ThemeImported;

	IThemeContainer? GetCurrentThemeContainerByGroup(ThemePickerGroup group);

	void SetCurrentThemeContainerGroupContext(ThemePickerGroup group, IThemeContainer themeContainer);

	ViewType GetViewTypeByGroup(ThemePickerGroup group);

	void SetViewTypeByGroup(ThemePickerGroup group, ViewType viewType);

	Task ClearRecentlyAppliedTemplateSlidesAsync();

	Task AddRecentlyAppliedTemplateSlideAsync(Guid themeId);

	Task<IEnumerable<RecentlyAppliedTemplateSlideModel>> GetRecentlyAppliedTemplateSlidesAsync(bool orderbyDate = true, int top = -1);

	Task<IThemeContainer?> FindThemeContainerAsync(IEnumerable<IThemeContainer> themeContainers, Theme? targetTheme);

	Task<Theme?> FindThemeByTemplateSlideIdAsync(IEnumerable<IThemeContainer> themeContainers, Guid targetThemeId);

	Task AddNewlyImportedThemeAsync(ImportedThemeModel importedThemeModel);

	Task<bool> AnyUnacknowledgedImportedThemesExistAsync();

	Task<IEnumerable<ImportedThemeModel>> GetAllThemesThatHaventBeenAcknowledgedAsync();

	Task UpdateUserHasAcknowledgedImportedThemeAsync(string themeName);

	Task UpdateUserHasViewedImportedThemeDetailsAsync(string themeName);

	Task<ThemePickerSettingsModel?> GetThemePickerSettingsByGroupAsync(ThemePickerGroup group);

	Task UpsertThemePickerSettingsAsync(ThemePickerSettingsModel settings);
}
