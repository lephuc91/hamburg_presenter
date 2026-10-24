namespace ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;

public interface ICCLIReportPrompt
{
	bool ConfirmReset();

	bool TryGetExportFile(out string fileName, out bool excludeAutoReported);
}
