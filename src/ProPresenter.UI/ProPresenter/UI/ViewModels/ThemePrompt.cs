using System.Collections.Generic;
using System.Linq;
using Pro.Common.FileSystem;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Themes;
using ProPresenter.UI.Export;
using ProPresenter.UI.Templates;

namespace ProPresenter.UI.ViewModels;

public class ThemePrompt : IThemePrompt
{
	private readonly IProPresenterResourceService _proPresenterResourceService;

	public ThemePrompt(IProPresenterResourceService proPresenterResourceService)
	{
		_proPresenterResourceService = proPresenterResourceService;
	}

	public void SaveNewTheme(ICommand<string> saveCommand)
	{
		new NewThemeDialog(_proPresenterResourceService.Themes, saveCommand).ShowDialog();
	}

	public bool ConfirmDelete(Theme theme)
	{
		return MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("THEMES_ALERT_DELETE_THEME_message", new object[1] { theme.Name }) + "\n" + LocalizedStrings.Get("THEMES_ALERT_DELETE_THEME_info"));
	}

	public bool ConfirmDelete(TemplateSlide templateSlide)
	{
		return MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("THEMES_POPOVER_SLIDE_CONTEXT_MENU_DELETE_title") + "\n" + LocalizedStrings.Get("THEMES_POPOVER_DELETE_THEME_SLIDE_ALERT_message", new object[1] { templateSlide.Name }));
	}

	public bool Export(out IEnumerable<Theme> themes, out string path)
	{
		ExportThemeView exportThemeView = new ExportThemeView();
		path = string.Empty;
		bool result = exportThemeView.ShowDialog() == true && DialogHelper.SaveFile(FileFilters.ProThemeFilter, LocalizedStrings.Get("EXPORT_THEMES_FILE_name"), out path);
		themes = exportThemeView.ThemesToExport ?? Enumerable.Empty<Theme>();
		return result;
	}

	public void ResolveConflict(out bool overwrite, out bool abort)
	{
		ThemeConflictButtons themeConflictButtons = MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("THEMES_CREATE_WINDOW_ALREADY_EXISTS_ALERT_message"), ThemeConflictButtons.Cancel | ThemeConflictButtons.AddNewVersion | ThemeConflictButtons.WriteOver, ThemeConflictButtons.WriteOver) ?? ThemeConflictButtons.Cancel;
		abort = themeConflictButtons == ThemeConflictButtons.Cancel;
		overwrite = themeConflictButtons == ThemeConflictButtons.WriteOver;
	}
}
