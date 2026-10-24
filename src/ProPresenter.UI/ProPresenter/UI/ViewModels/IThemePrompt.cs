using System.Collections.Generic;
using Pro.UI.Components;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public interface IThemePrompt
{
	void SaveNewTheme(ICommand<string> saveCommand);

	bool ConfirmDelete(Theme theme);

	bool ConfirmDelete(TemplateSlide templateSlide);

	bool Export(out IEnumerable<Theme> themes, out string path);

	void ResolveConflict(out bool overwrite, out bool abort);
}
