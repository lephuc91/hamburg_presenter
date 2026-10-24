using Pro.Common.FileSystem;
using Pro.Localization;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;

public class CCLIReportPrompt : ICCLIReportPrompt
{
	private const string DEFAULT_NAME = "CCLIData";

	private readonly IFileSelectorService _fileSelector;

	public CCLIReportPrompt(IFileSelectorService fileSelector)
	{
		_fileSelector = fileSelector;
	}

	public bool ConfirmReset()
	{
		return MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_REPORTING_RESET_ALERT_message"), DefaultButtons.OK | DefaultButtons.CANCEL, DefaultButtons.OK) == DefaultButtons.OK;
	}

	public bool TryGetExportFile(out string fileName, out bool excludeAutoReported)
	{
		fileName = string.Empty;
		excludeAutoReported = false;
		AutoReportedExportOptions? autoReportedExportOptions = MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_EXPORT_OPTIONS_WINDOW_title"), LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_EXPORT_OPTIONS_WINDOW_message"), AutoReportedExportOptions.IncludeAutoReported | AutoReportedExportOptions.ExcludeAutoReported | AutoReportedExportOptions.CancelExport, AutoReportedExportOptions.IncludeAutoReported);
		if (!autoReportedExportOptions.HasValue || autoReportedExportOptions.Value == AutoReportedExportOptions.CancelExport)
		{
			return false;
		}
		excludeAutoReported = autoReportedExportOptions.Value == AutoReportedExportOptions.ExcludeAutoReported;
		return _fileSelector.SaveFile(FileFilters.TextFilter, "CCLIData", CommonPaths.DocumentsFolder, out fileName);
	}
}
