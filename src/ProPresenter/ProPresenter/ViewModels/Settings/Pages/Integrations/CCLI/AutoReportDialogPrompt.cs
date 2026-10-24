using ProPresenter.UI.Settings.PageTemplates.Integrations.CCLI;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;

public class AutoReportDialogPrompt : IAutoReportDialogPrompt
{
	public bool ShowOption()
	{
		return new AutoReportOptionDialog().ShowDialog() == true;
	}
}
