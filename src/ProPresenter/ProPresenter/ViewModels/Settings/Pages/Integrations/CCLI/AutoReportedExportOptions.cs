using System;
using Pro.Localization;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;

[Flags]
public enum AutoReportedExportOptions
{
	[LocalizedString("SETTINGS_GENERAL_COPYRIGHT_EXPORT_INCLUDE_AUTO_REPORTED_BUTTON_title")]
	IncludeAutoReported = 1,
	[LocalizedString("SETTINGS_GENERAL_COPYRIGHT_EXPORT_EXCLUDE_AUTO_REPORTED_BUTTON_title")]
	ExcludeAutoReported = 2,
	[LocalizedString("SETTINGS_GENERAL_COPYRIGHT_EXCLUDE_CANCEL_EXPORT_BUTTON_title")]
	CancelExport = 4
}
