using System.Collections.Generic;
using System.Threading.Tasks;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO;

public interface IThemeRepo
{
	ThemeCollection Themes { get; }

	Task InsertRecentlyAppliedTemplateSlideAsync(RecentlyAppliedTemplateSlideModel theme);

	Task<IEnumerable<RecentlyAppliedTemplateSlideModel>> GetRecentlyAppliedTemplateSlidesAsync(bool orderbyDate = true, int top = -1);

	Task ClearRecentlyAppliedTemplateSlidesAsync();

	Task InsertImportedThemeAsync(ImportedThemeModel importedThemeModel);

	Task<bool> AnyUnacknowledgedImportedThemesExistAsync();

	Task<bool?> HasThemeDetailsBeenViewedAsync(string themeName);

	Task<IEnumerable<ImportedThemeModel>> GetAllThemesThatHaventBeenAcknowledgedAsync();

	Task UpdateUserHasAcknowledgedImportedThemeAsync(string themeName);

	Task UpdateUserHasViewedImportedThemeDetailsAsync(string themeName);

	Task<ThemePickerSettingsModel?> GetThemePickerSettingsByGroupAsync(ThemePickerGroup group);

	Task UpsertThemePickerSettingsAsync(ThemePickerSettingsModel settings);
}
